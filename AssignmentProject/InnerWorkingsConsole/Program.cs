#region Problem Statement

/*
Problem Statement : 

At InnerWorkings a "job" is a group of print items.For example,

a job can be a run of business cards, envelopes, and letterhead together.

Some items qualify as being sales tax free, whereas, by default, others

are not.Sales tax is 7%.

InnerWorkings also applies a margin, which is the percentage above printing

cost that is charged to the customer.  For example, an item that costs $100 

to print that has a margin of 11% will cost:

item: $100 -> $7 sales tax = $107

job:  $100 -> $11 margin

total: $100 + $7 + $11 = $118

The base margin is 11% for all jobs this problem.Some jobs have an

"extra margin" of 5%.  These jobs that are flagged as extra margin have

an additional 5% margin (16% total) applied.

The final cost is rounded to the nearest even cent.Individual items are

rounded to the nearest cent.

Write a program that calculates the total charge to a customer

for a job (Bonus: Try to read the input from a file and output the invoice to a file).  The program should

accept the inputs below and output the

total bill for the customer.

Job 1:

extra-margin

envelopes 520.00

letterhead 1983.37 exempt

should output:

envelopes: $556.40

letterhead: $1983.37

total: $2940.30

Job 2:

t-shirts 294.04

output:

t-shirts: $314.62

total: $346.96

Job 3:

extra-margin

frisbees 19385.38 exempt

yo-yos 1829 exempt

output:

frisbees: $19385.38

yo-yos: $1829.00

total: $24608.68
*/

#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using InnerWorkings;
using InnerWorkings.Adapters;
using InnerWorkings.Business;
using InnerWorkings.Configuration;
using InnerWorkings.Processors;
using Microsoft.Practices.Unity;
using AutoMapper;

namespace InnerWorkingsConsole
{
    /// <summary>
    /// The program is fully configurable using xml file in app.config.
    /// Or by passing inpt arguments in the expected order 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                // TODO: Replace with proper loging framework

                Console.WriteLine("Unhandled exception!");
                var exception = eventArgs.ExceptionObject as Exception;
                if (exception != null)
                    Console.WriteLine(exception.Message);
            };

            var program = new Program();
            program.Run(args);
        }

        private void Run(string[] args)
        {
            // TODO: check for input parameters and if present try to parse as input job data
            if (args.Any())
            {
                var singleJob = this.ProcessArgs(args);
                IJobProcessor processor = new JobProcessorSimple(new ItemPriceCalculator(), new ConsoleWriterAdapter());
                processor.ProcessJob(singleJob);

                Console.WriteLine("Press Any key to exit the window!");
                Console.ReadKey();
                return;
            }

            var unityContainer = new UnityContainer();

            UnityConfiguration(unityContainer);
            ConfigureMappings(unityContainer);

            var jobsSection = ConfigurationManager.GetSection("jobsSection") as JobsConfigurationSection;

            List<Job> jobItems = null;

            if (jobsSection == null || jobsSection.Jobs == null)
            {
                throw new InvalidOperationException("Unable to load necessary data from configuration file...");
            }

            // Map config code to proper internal structures
            jobItems = Mapper.Map<List<Job>>(jobsSection.Jobs);

            // Update unity mappings to reflect changes from configuration
            unityContainer.RegisterType<IMargin, ExtraMargin>("extra", 
                new InjectionConstructor(jobsSection.BaseMargin, jobsSection.ExtraMargin));
            unityContainer.RegisterType<IMargin, MarginBase>("base", 
                new InjectionConstructor(jobsSection.BaseMargin));

            // Process input Jobs
            ProcessAllJobs(jobItems, unityContainer.Resolve<IJobProcessor>("console"));
        }

        public void ProcessAllJobs(List<Job> jobs, IJobProcessor processor)
        {
            foreach (var job in jobs)
            {
                processor.ProcessJob(job);
            }
        }

        private void UnityConfiguration(IUnityContainer container)
        {
            container.RegisterType<IItemPriceCalculator, ItemPriceCalculator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMargin, ExtraMargin>("extra", new InjectionConstructor((double)11, (double)5));
            container.RegisterType<IMargin, MarginBase>("base", new InjectionConstructor((double)11));
            container.RegisterType<ITax, SalesTax>(new InjectionConstructor((double)7));
            container.RegisterType<IOutputWriter, ConsoleWriterAdapter>("console", new ContainerControlledLifetimeManager());
            container.RegisterType<IOutputWriter, FileOutputWriterAdapter>("file");
            container.RegisterType<IJobProcessor, JobProcessorSimple>("console", new InjectionFactory(c => new JobProcessorSimple(c.Resolve<IItemPriceCalculator>(), c.Resolve<IOutputWriter>("console"))));
            container.RegisterType<IJobProcessor, JobProcessorSimple>("file", new InjectionFactory(c => new JobProcessorSimple(c.Resolve<IItemPriceCalculator>(), c.Resolve<IOutputWriter>("file"))));
        }

        private void ConfigureMappings(IUnityContainer container)
        {
            Mapper.CreateMap<ItemConfiguration, Item>();

            AutoMapper.Mapper.CreateMap<JobConfiguration, Job>()
                .ConvertUsing(src => new Job()
                {
                    Items = AutoMapper.Mapper.Map<List<Item>>(src.Items),
                    Margin = container.Resolve<IMargin>(src.MarginType),
                    Tax = container.Resolve<ITax>()
                });
        }

        private Job ProcessArgs(string[] args)
        {
            // TODO: prepare unit tests for this..

            IMargin margin = null;
            var items = new List<Item>();
            int index = 0;

            if (args[index] == "extra-margin")
            {
                margin = new MarginBase();
                index++;
            }
            else
            {
                margin = new ExtraMargin();
            }

            State state = State.Name;

            // iterate rest of the items
            for (int i = index; i < args.Count(); ++i)
            {
                Item item = null;
                switch (state)
                {
                    case State.Name:
                        item = new Item();
                        items.Add(item);

                        item.Name = args[i];
                        state = State.Value;
                        break;

                    case State.Value:
                        item.Price = Double.Parse(args[i]);
                        if (i + 1 < args.Count())
                        {
                            if (args[i + 1] == "exempt")
                            {
                                state = State.Extra;
                            }
                            else
                            {
                                state = State.Name;
                            }
                        }
                        else
                        {
                            state = State.Name;
                        }
                        break;

                    case State.Extra:
                        item.IsTaxFree = true;
                        state = State.Name;
                        break;
                }
            }

            return new Job()
            {
                Items = items,
                Margin = margin,
                Tax = new SalesTax(7)
            };
        }
    }
}
