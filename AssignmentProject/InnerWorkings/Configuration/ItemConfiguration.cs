using System.Configuration;

namespace InnerWorkings.Configuration
{
    public class ItemConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("price", IsRequired = true)]
        public double Price
        {
            get { return (double)this["price"]; }
            set { this["price"] = value; }
        }

        [ConfigurationProperty("isTaxFree", IsRequired = true)]
        public bool IsTaxFree
        {
            get { return (bool)this["isTaxFree"]; }
            set { this["isTaxFree"] = value; }
        }
    }
}