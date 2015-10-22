using System;
using System.Configuration;

namespace InnerWorkings.Configuration
{
    [ConfigurationCollection(typeof(JobConfiguration), AddItemName = "job", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class JobConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new JobConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var jobConfiguration = element as JobConfiguration;

            if (jobConfiguration == null)
            {
                throw new ArgumentException("element cannot be null!");
            }

            return jobConfiguration.Id;
        }
    }
}