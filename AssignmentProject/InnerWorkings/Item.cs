namespace InnerWorkings
{
    public class Item
    {
        public Item(bool isTaxFree = false)
        {
            this.IsTaxFree = isTaxFree;
        }

        public bool IsTaxFree { get; }

        public string Name { get; set; }
        public float Price { get; set; }
    }
}
