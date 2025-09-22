namespace TempleDiamond

{
    // Hanterar huvudloopen och tolkar spelarens kommandon
    public class MainGame
    {
        private Player player;
        private bool gameOver = false;
        private Dictionary<string, Room> allRooms; // Alla rum i spelet

        public void Start()
        {
            Console.WriteLine("'Farfar. Kan du inte berätta en gång till om den försvunna diamanten?'");
            Console.WriteLine("'Men den historian har jag ju berättat så många gånger nu'");
            Console.WriteLine("'Gör det igen!' Och farfar berättade igen, som han hade gjort varje gång.");
            Console.WriteLine("23 år senare - Långt inne i en sedan länge bortglömt djungel:");
            Console.WriteLine("Han stod där nu. Framför porten till det gamla templet som farfar hade berättat om. Nu behövde han bara ta sig in...");
            Console.WriteLine("I den uråldriga gamla stenporten såg han en urgröpning. Han kände i fickan efter farfars medaljong.");

            CreateWorld();
            player = new Player(allRooms["Ingången"]);

            while (!gameOver)
            {
                Console.Write("> ");
                string? command = Console.ReadLine();
                ProcessCommand(command);
            }
        }

        private void CreateWorld()
        {
            // Skapa världen
            Room entrance = new Room(
            "Ingången",
            "Du står framför den stora porten till templet. I porten finns en urgröpning. Farfars medaljong ser ut att passa i den.");


            Room candle = new Room(
                "Hallen",
                "Du kommer in i ett nästan helt mörkt rum. Längst inne i hörnet står ett ensamt stearinljus och sprider mycket lite ljus omkring sig.");

            Room hole = new Room(
                "Hålet",
                "Ett stort hål i golvet upptar nästan hela rummet.");

            Room spiderRoom = new Room(
                "Spindelrummet",
                "En gigantisk spindel blockerar din väg!");

            Room diamondRoom = new Room(
                "Diamanten",
                "Mitt i rummet ser du diamanten på en pidestal. I hörnet av rummet ser du ett skelett.");

            Room ladderRoom = new Room(
                "Stegen",
                "En lång stege står lutad mot väggen. Den når nästan upp till taket. Längst upp ser du ett hål i väggen.");

            Room dadJoke = new Room(
                "Pappaskämt",
                "Rummet är tomt förutom en tavla på väggen. Det står: 'Vilken fågel är snabbast? Svaret är: Ööööööörn örn örn örn'");

            Room sandwich = new Room(
                "Smörgåsen",
                "På en sten i mitten av rummet ligger ask. Undrar vad som finns däri?");

            Room treeRoom = new Room(
                "Trädet",
                "Ett enormt träd växer i mitten av rummet. Grenarna når nästan taket.");

            Room caterpillar = new Room(
                "Larven",
                "En fet, saftig larv kryper runt på golvet.");

            // Skapa vägar mellan rummen
            entrance.Exits["norr"] = candle;
            candle.Exits["söder"] = entrance;
            candle.Exits["väster"] = hole;
            candle.Exits["öster"] = ladderRoom;
            hole.Exits["öster"] = candle;
            hole.Exits["norr"] = spiderRoom;
            spiderRoom.Exits["söder"] = hole;
            spiderRoom.Exits["norr"] = diamondRoom;
            ladderRoom.Exits["väster"] = candle;
            ladderRoom.Exits["norr"] = treeRoom;
            ladderRoom.Exits["öster"] = dadJoke;
            treeRoom.Exits["söder"] = ladderRoom;
            treeRoom.Exits["norr"] = caterpillar;
            caterpillar.Exits["söder"] = treeRoom;
            dadJoke.Exits["väster"] = ladderRoom;
            dadJoke.Exits["öster"] = sandwich;
            sandwich.Exits["väster"] = dadJoke;

            // Lägg till föremål i rummen
            entrance.ItemsInRoom.Add(ItemFactory.CreateItem("medallion"));
            candle.ItemsInRoom.Add(ItemFactory.CreateItem("torch"));
            hole.ItemsInRoom.Add(ItemFactory.CreateItem("spiderweb"));
            diamondRoom.ItemsInRoom.Add(ItemFactory.CreateItem("diamond"));
            sandwich.ItemsInRoom.Add(ItemFactory.CreateItem("smallbox"));
            treeRoom.ItemsInRoom.Add(ItemFactory.CreateItem("leaf"));
            caterpillar.ItemsInRoom.Add(ItemFactory.CreateItem("caterpillar"));
            ladderRoom.ItemsInRoom.Add(ItemFactory.CreateItem("ladder"));

            // Lägg till alla rum i ordboken
            allRooms = new Dictionary<string, Room>
            {
                { "Ingången", entrance },
                { "Hallen", candle },
                { "Hålet", hole },
                { "Spindelrummet", spiderRoom },
                { "Diamanten", diamondRoom },
                { "Stegen", ladderRoom },
                { "Pappaskämt", dadJoke },
                { "Smörgåsen", sandwich },
                { "Trädet", treeRoom },
                { "Larven", caterpillar }
            };



        }

        private void ProcessCommand(string? command)
        {

            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Ange ett kommando.");
                return;
            }

            var words = command.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string verb = words[0];
            string obj = string.Join(' ', words.Skip(1));

            switch (verb)
            {
                case "gå":
                    if (string.IsNullOrWhiteSpace(obj))
                    {
                        Console.WriteLine("Åt vilket håll vill du gå?");
                        return;
                    }

                    if (player.CurrentRoom.Exits.ContainsKey(obj))
                    {
                        Room nextRoom = player.CurrentRoom.Exits[obj];
                        player.MoveToRoom(nextRoom);

                    }
                    else
                    {
                        Console.WriteLine("Du kan inte gå åt det hållet.");
                    }
                    break;

                case "titta":
                    Console.WriteLine(player.CurrentRoom.GetDescription());
                    break;

                case "ta":
                    if (string.IsNullOrWhiteSpace(obj))
                    {
                        Console.WriteLine("Vad vill du ta?");
                        return;
                    }

                    var item = player.CurrentRoom.ItemsInRoom
                        .FirstOrDefault(i => i.Name.ToLower() == obj);

                    if (item != null)
                    {
                        player.TakeItem(item);
                        player.CurrentRoom.RemoveItem(item);
                        Console.WriteLine($"Du plockar upp {item.Name}.");
                    }
                    else
                    {
                        Console.WriteLine("Det finns inget sådant föremål här.");
                    }
                    break;

                case "använd":
                    if (string.IsNullOrWhiteSpace(obj))
                    {
                        Console.WriteLine("Vad vill du använda?");
                    }
                    else
                    {
                        player.UseItem(obj);
                    }
                    break;

                case "inventarium":
                    if (player.Inventory.Count == 0)
                    {
                        Console.WriteLine("Ditt inventarium är tomt.");
                    }
                    else
                    {
                        Console.WriteLine("Du har följande föremål i ditt inventarium:");
                        Console.WriteLine(string.Join(", ", player.Inventory.Select(i => i.Name)));
                    }
                    break;

                case "sluta":
                    gameOver = true;
                    Console.WriteLine("Spelet avslutas. Tack för att du spelade!");
                    return;

                default:
                    Console.WriteLine("Okänt kommando.");
                    break;
            }
            Console.WriteLine("Vad vill du göra nu?");
        }
    }
}