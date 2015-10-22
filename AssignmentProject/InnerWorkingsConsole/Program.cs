using System.Collections.Generic;
using System.Configuration;
using InnerWorkings;
using InnerWorkings.Adapters;
using InnerWorkings.Business;
using InnerWorkings.Configuration;
using InnerWorkings.Processors;
using Microsoft.Practices.Unity;
using AutoMapper;

namespace InnerWorkingsConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
        }

        private void Run(string[] args)
        {
            var unityContainer = new UnityContainer();

            UnityConfiguration(unityContainer);
            ConfigureMappings(unityContainer);
            // Load input data - either from file or by parsing input arguments
            // Results to console/to file?
            var jobsSection = ConfigurationManager.GetSection("jobsSection") as JobsConfigurationSection;

            // Init all mappings (unity + automapper)

            List<Job> jobItems = null;

            if (jobsSection.Jobs != null)
            {
                jobItems = Mapper.Map<List<Job>>(jobsSection.Jobs);
            }

            
            var processor = unityContainer.Resolve<IJobProcessor>("console");

            // Process input Jobs
            ProcessAllJobs(jobItems, processor);
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
    }
}
