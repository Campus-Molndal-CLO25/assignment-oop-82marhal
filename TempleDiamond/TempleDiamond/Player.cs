using System.ComponentModel.DataAnnotations;

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
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(CurrentRoom.Description);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Utgångar: " + string.Join(", ", CurrentRoom.Exits.Keys));
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
                Console.WriteLine($"Du tog upp {item.Name}.");
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

    }
}