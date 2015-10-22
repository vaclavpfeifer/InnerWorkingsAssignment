using System;
using System.Configuration;

namespace InnerWorkings.Configuration
{
    public class JobConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("margin", DefaultValue = "base", IsRequired = false)]
        public string MarginType
        {
            get { return (string) this["margin"]; }
            set { this["margin"] = value; }
        }

        public Guid Id { get; } = Guid.NewGuid();

        [ConfigurationProperty("items", IsDefaultCollection = false, IsRequired = false)]
        public ItemConfigurationCollection Items => (ItemConfigurationCollection) this["items"];
    }
}