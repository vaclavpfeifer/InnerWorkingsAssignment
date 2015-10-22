using System;
using System.Configuration;

namespace InnerWorkings.Configuration
{
    [ConfigurationCollection(typeof(ItemConfiguration), AddItemName = "item", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ItemConfigurationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ItemConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var itemConfiguration = element as ItemConfiguration;

            if (itemConfiguration == null)
            {
                throw new ArgumentException("element cannot be null!");
            }

            return itemConfiguration.Name;
        }
    }
}