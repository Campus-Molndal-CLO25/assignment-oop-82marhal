namespace TempleDiamond

{
    public class Player
    {
        public Room CurrentRoom { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(Room startRoom)
        {
            CurrentRoom = startRoom;
            Inventory = new List<Item>();
        }


        public void MoveToRoom(Room newRoom)
        {
            if (newRoom != null)
            {
                CurrentRoom = newRoom;
                Console.WriteLine($"Du är nu i {newRoom.Name}.");
                Console.WriteLine(CurrentRoom.Description);
            }
            else
            {
                Console.WriteLine("Du kan inte gå dit!");
            }
        }


        public void TakeItem(Item item)
        {

            if (item != null)
            {
                Inventory.Add(item);
                CurrentRoom.RemoveItem(item);
                Console.WriteLine($"Du plockade upp {item.Name}.");
            }
        }

        public bool HasItem(string itemName)
        {
            foreach (Item item in Inventory)
            {
                if (item.Name == itemName) return true;

            }
            return false;
        }

        public void UseItem(string itemName)
        {
            var item = Inventory.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            if (item == null)
            {
                Console.WriteLine("Du har inte det föremålet.");
                return;
            }
            Console.WriteLine($"Du använder {item.Name}.");
        }

    }
}