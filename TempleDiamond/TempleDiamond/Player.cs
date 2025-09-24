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
                Console.WriteLine(CurrentRoom.GetDescription(this));
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