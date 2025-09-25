namespace TempleDiamond

{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Contents { get; set; }
        

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            Contents = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Contents.Add(item);
        }

        public bool Contains(string itemName)
        {
            return Contents.Any(i => i.Name.ToLower() == itemName.ToLower());
        }
    }
}