﻿using System.Configuration;
using System.Xml;

namespace InnerWorkings.Configuration
{
    public class JobsConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("jobs", IsDefaultCollection = false)]
        public JobConfigurationCollection Jobs => (JobConfigurationCollection) this["jobs"];

        [ConfigurationProperty("tax", DefaultValue = "7", IsRequired = false)]
        public string Tax
        {
            get { return (string)this["tax"]; }
            set { this["tax"] = value; }
        }

        [ConfigurationProperty("baseMargin", DefaultValue = "11", IsRequired = false)]
        public double BaseMargin
        {
            get { return (double)this["baseMargin"]; }
            set { this["baseMargin"] = value; }
        }

        [ConfigurationProperty("extraMargin", DefaultValue = "5", IsRequired = false)]
        public double ExtraMargin
        {
            get { return (double)this["extraMargin"]; }
            set { this["extraMargin"] = value; }
        }
    }
}
