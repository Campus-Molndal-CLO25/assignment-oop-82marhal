namespace TempleDiamond

{
    // Bygger upp och hanterar rum
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> ItemsInRoom { get; set; }
        public Dictionary<string, Room> Exits { get; set; }



        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            ItemsInRoom = new List<Item>();
            Exits = new Dictionary<string, Room>();
        }

        public string GetDescription(Player player)
        {
            string exitNames = string.Join(", ", Exits.Keys);
            string itemNames = ItemsInRoom.Count > 0
                ? string.Join(", ", ItemsInRoom.Select(i => i.Name))
                : "Det finns inga föremål här.";

            string roomDescription = Description;           

            return $"-------------------------------------------\n{roomDescription}\n-------------------------------------------\nUtgångar: {exitNames}\nFöremål i rummet: {itemNames}";
        }

        public void RemoveItem(Item item)
        {
            ItemsInRoom.Remove(item);
        }

        public void AddItem(Item item)
        {
            ItemsInRoom.Add(item);
        }

    }
}