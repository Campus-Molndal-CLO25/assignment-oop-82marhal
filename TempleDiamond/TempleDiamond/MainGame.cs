using System.ComponentModel;

namespace TempleDiamond

{

    // Hanterar huvudloopen och tolkar spelarens kommandon
    public class MainGame
    {
        private Player player;
        private bool gameOver = false;

        public Dictionary<string, Room> allRooms;
        public SpiderBoss spiderBoss;
        public bool MedallionUsed { get; set; } = false;

        public void Start()
        {
            Program.CurrentGame = this;
            Console.WriteLine("'Farfar. Kan du inte berätta en gång till om den försvunna diamanten?'");
            Console.WriteLine("'Men den historian har jag ju berättat så många gånger nu'");
            Console.WriteLine("'Gör det igen!' Och farfar berättade igen, som han hade gjort varje gång.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("23 år senare - Långt inne i en sedan länge bortglömt djungel:");
            Console.WriteLine("Han stod där nu. Framför porten till det gamla templet som farfar hade berättat om. Nu behövde han bara ta sig in...");
            Console.WriteLine("I den uråldriga gamla stenporten såg han en urgröpning. Han kände i fickan där han hade farfars medaljong.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Vad vill du göra? (är du osäker, skriv: hjälp)");

            CreateWorld();
            player = new Player(allRooms["Ingången"]);
            player.Inventory.Add(ItemFactory.CreateItem("medallion"));

            while (!gameOver)
            {
                Console.Write("------------------------------------------------\n> ");
                string? command = Console.ReadLine();
                ProcessCommand(command);
            }
        }

        private void CreateWorld() //Här byggs världen upp
        {
            spiderBoss = new SpiderBoss();

            // --- Rooms ---
            var entrance = new Room("Ingången", "Du står framför porten. Farfars medaljong ser ut att passa i urgröpningen.");
            var hall = new Room("Hallen", "Du kommer in i ett rum med högt i tak.");
            var hole = new Room("Hålet", "Du lägger stegen över hålet och klättrar över. Ett felsteg och du är död...");
            var spiderRoom = new Room("Spindelrummet", "En gigantisk spindel blockerar din väg! Hur tusan ska du ta dig förbi den?");
            var diamondRoom = new Room("Diamanten", "Mitt i rummet ser du diamanten på en pidestal.");
            var ladderRoom = new Room("Stegen", "Ännu ett rum med högt i tak. En lång stege står lutad mot väggen och du ser en liten ingång längst däruppe.");
            var dadJoke = new Room("Pappaskämt", "Rummet är helt tomt förutom en tavla. På tavlan står en text: 'Varför tippar alltid dykare bakåt när de ska i vattnet? Om de tippar framåt hamnar de i båten.'");
            var stone = new Room("Stenen", "Mitt i rummet står en stor sten. Något blänker till vid foten av stenen. Vad kan det vara?");
            var treeRoom = new Room("Trädet", "Ett enormt träd växer i mitten av rummet. Hur är det möjligt, det finns ju varken solljus eller vatten här. Ändå är trädet fyllt av gröna löv.");
            var caterpillarRoom = new Room("Larven", "En fet, saftig larv kryper runt på golvet.");

            // --- Exits ---
            entrance.Exits["norr"] = hall;
            hall.Exits["söder"] = entrance;
            hall.Exits["väster"] = hole;
            hall.Exits["öster"] = ladderRoom;
            hole.Exits["öster"] = hall;
            hole.Exits["norr"] = spiderRoom;
            spiderRoom.Exits["söder"] = hole;
            spiderRoom.Exits["norr"] = diamondRoom;
            ladderRoom.Exits["väster"] = hall;
            ladderRoom.Exits["norr"] = treeRoom;
            ladderRoom.Exits["öster"] = dadJoke;
            treeRoom.Exits["söder"] = ladderRoom;
            treeRoom.Exits["norr"] = caterpillarRoom;
            caterpillarRoom.Exits["söder"] = treeRoom;
            dadJoke.Exits["väster"] = ladderRoom;
            dadJoke.Exits["öster"] = stone;
            stone.Exits["väster"] = dadJoke;

            // --- Items ---
            hall.ItemsInRoom.Add(ItemFactory.CreateItem("torch"));
            diamondRoom.ItemsInRoom.Add(ItemFactory.CreateItem("diamond"));
            stone.ItemsInRoom.Add(ItemFactory.CreateItem("smallbox"));
            treeRoom.ItemsInRoom.Add(ItemFactory.CreateItem("leaf"));
            caterpillarRoom.ItemsInRoom.Add(ItemFactory.CreateItem("caterpillar"));
            ladderRoom.ItemsInRoom.Add(ItemFactory.CreateItem("ladder"));

            // --- All rooms ---
            allRooms = new Dictionary<string, Room>
            {
                { "Ingången", entrance },
                { "Hallen", hall },
                { "Hålet", hole },
                { "Spindelrummet", spiderRoom },
                { "Diamanten", diamondRoom },
                { "Stegen", ladderRoom },
                { "Pappaskämt", dadJoke },
                { "Stenen", stone },
                { "Trädet", treeRoom },
                { "Larven", caterpillarRoom }
            };
        }

        private readonly Dictionary<string, Action<string>> commandHandlers;

        public MainGame()
        {
            commandHandlers = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
    {
        { "gå", HandleGo },
        { "titta", HandleLook },
        { "ta", HandleTake },
        { "använd", HandleUse },
        { "inventarium", HandleInventory },
        { "fånga", HandleCatch },
        { "lägg", HandlePut },
        { "sluta", HandleQuit },
        { "hjälp", HandleHelp }
    };
        }

        private void ProcessCommand(string? command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Ange ett kommando.");
                return;
            }

            var words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string verb = words[0];
            string obj = string.Join(' ', words.Skip(1));

            if (commandHandlers.TryGetValue(verb, out var handler))
            {
                handler(obj);
            }
            else
            {
                Console.WriteLine("Jag förstår inte vad du vill göra.");
            }

            if (!gameOver) Console.WriteLine("Vad vill du göra nu?");
        }
        private void HandleGo(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
            {
                Console.WriteLine("Åt vilket håll?");
                return;
            }

            // --- Startrumsbegränsning ---
            if (player.CurrentRoom.Name == "Ingången" && !MedallionUsed)
            {
                Console.WriteLine("Du behöver öppna porten innan du går in. Du är inget spöke som kan gå igenom väggar vet du!");
                return;
            }

            // --- När det är mörkt i templet ---
            if (player.CurrentRoom.Name == "Hallen" && (direction == "väster" || direction == "öster") && !player.HasItem("Fackla"))
            {
                Console.WriteLine("Det är för mörkt att gå in där! Glöm inte att du är mörkrädd!");
                return;
            }

            if (player.CurrentRoom.Exits.TryGetValue(direction, out Room nextRoom))
            {
                // --- Specialfall för Stege-rummet och hålet norrut ---
                if (player.CurrentRoom.Name == "Stegen" && direction == "norr")
                {
                    // Kolla om stegen finns i rummet
                    var ladderInRoom = player.CurrentRoom.ItemsInRoom.FirstOrDefault(i => i.Name == "Stege");
                    if (ladderInRoom == null)
                    {
                        Console.WriteLine("Det finns ingen stege här längre. Du kan inte gå norrut.");
                        return;
                    }
                }

                if (nextRoom.Name == "Hålet")
                    {
                        HandleHole(nextRoom);
                    }
                else
                    {
                        player.MoveToRoom(nextRoom);
                    }
            }

            else Console.WriteLine("Du kan inte gå åt det hållet.");
        }
        

        private void HandleLook(string _)
        {
            Console.WriteLine(player.CurrentRoom.GetDescription(player));
        }

        private void HandleTake(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                Console.WriteLine("Vad vill du ta?");
                return;
            }

            var item = player.CurrentRoom.ItemsInRoom
                .FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("Det finns inget sådant föremål här.");
                return;
            }

            if (item.Name == "Larv")
            {
                Console.WriteLine("Larven är för snabb för att bara ta med händerna. Kanske du kan locka in den i något?");
                return;
            }

            player.TakeItem(item);

            if (item.Name == "Diamant")
            {
                HandleDiamondTaken();
            }
        }

        private void HandleUse(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                Console.WriteLine("Vad vill du använda?");
                return;
            }

            UseItem(itemName);
        }

        private void HandleInventory(string _)
        {
            if (player.Inventory.Count == 0)
                Console.WriteLine("Ditt inventarium är tomt.");
            else
                Console.WriteLine("Inventarium: " + string.Join(", ", player.Inventory.Select(i => i.Name)));
        }

        private void HandleCatch(string obj)
        {
            if (obj == "larv" && player.CurrentRoom.Name == "Larven")
            {
                var box = player.Inventory.FirstOrDefault(i => i.Name == "Ask");
                if (box == null) { Console.WriteLine("Du behöver något att fånga larven i."); return; }
                if (!box.Contains("Löv")) { Console.WriteLine("Du tror väl inte att larven kommer gå in i en ask bara utan vidare. Kanske du kan locka med något?."); return; }

                var larv = player.CurrentRoom.ItemsInRoom.FirstOrDefault(i => i.Name == "Larv");
                if (larv == null) { Console.WriteLine("Larven är borta."); return; }

                box.AddItem(larv);
                player.CurrentRoom.RemoveItem(larv);
                Console.WriteLine("Du har fångat larven i asken.");
            }
            else Console.WriteLine("Du kan inte fånga det här.");
        }

        private void HandlePut(string command)
        {
            var words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int indexOfI = Array.IndexOf(words, "i");

            // Fall 1: Lägger i en behållare
            if (indexOfI > 0 && indexOfI < words.Length - 1)
            {
                string itemName = string.Join(" ", words.Take(indexOfI));
                string containerName = string.Join(" ", words.Skip(indexOfI + 1));

                var itemToPlace = player.Inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
                var container = player.Inventory.FirstOrDefault(i => i.Name.Equals(containerName, StringComparison.OrdinalIgnoreCase));

                if (itemToPlace == null)
                {
                    Console.WriteLine("Du har inte det föremålet.");
                    return;
                }

                if (container == null)
                {
                    Console.WriteLine("Du har ingen sådan behållare.");
                    return;
                }

                container.AddItem(itemToPlace);
                player.Inventory.Remove(itemToPlace);
                Console.WriteLine($"Du lägger {itemToPlace.Name} i {container.Name}");
            }
            // Fall 2: Lägger föremålet direkt i rummet
            else
            {
                string itemName = string.Join(" ", words);

                var itemToPlace = player.Inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
                if (itemToPlace == null)
                {
                    Console.WriteLine("Du har inte det föremålet.");
                    return;
                }

                player.Inventory.Remove(itemToPlace);
                player.CurrentRoom.AddItem(itemToPlace);
                Console.WriteLine($"Du lägger {itemToPlace.Name} i rummet.");
            }
        }


        private void HandleQuit(string _)
        {
            gameOver = true;
            Console.WriteLine("Spelet avslutas.");
        }
        private void HandleHole(Room holeRoom)
        {
            var ladder = player.Inventory.FirstOrDefault(i => i.Name == "Stege");
            var spiderweb = holeRoom.ItemsInRoom.FirstOrDefault(i => i.Name == "Spindelnät");

            if (spiderweb != null)
            {
                player.MoveToRoom(holeRoom);
            }
            else if (ladder != null)
            {
                holeRoom.ItemsInRoom.Add(ladder);
                player.Inventory.Remove(ladder);
                player.MoveToRoom(holeRoom);
            }
            else Console.WriteLine("Ett stort hål blockerar vägen. Du behöver något för att ta dig över!");
        }

        private void HandleDiamondTaken()
        {
            var holeRoom = allRooms["Hålet"];
            var spiderweb = holeRoom.ItemsInRoom.FirstOrDefault(i => i.Name == "Spindelnät");

            if (spiderBoss.IsAlive)
            {
                Console.WriteLine("När du tar diamanten börjar väggarna att skaka. Du hör hur stegen faller ner i hålet.");
                Console.WriteLine("Du rusar dit och ser att spindeln har byggt ett nät åt dig så du kan klättra ut, som tack för maten.");
                Console.WriteLine("Grattis! Du har hittat diamanten och tagit dig ut levande. Du klarade spelet!");
            }
            else
            {
                if (spiderweb == null)
                {
                    Console.WriteLine("När du tar diamanten börjar väggarna att skaka. Du hör hur stegen faller ner i hålet.");
                    Console.WriteLine("Det finns ingen annan väg ut. Du kanske ska vara snällare nästa gång. Du dör en långsam och plågsam död. Spelet är slut. ");
                }
            }
            gameOver = true;
        }

        private void HandleHelp(string _)
        {
            Console.WriteLine("Tillgängliga kommandon:");
            foreach (var cmd in commandHandlers.Keys.OrderBy(c => c))
            {
                Console.WriteLine($" - {cmd}");
            }
        }




        private void UseItem(string itemName)
        {
            var item = player.Inventory
                .FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("Du har inte det föremålet.");
                return;
            }

            switch (item.Name)
            {
                case "Medaljong":
                    HandleUseMedallion(item);
                    break;

                case "Ask":
                    HandleUseBox(item);
                    break;

                case "Fackla":
                    HandleUseTorch(item);
                    break;

                default:
                    Console.WriteLine($"Du använder {item.Name}.");
                    break;
            }
        }
        private void HandleUseMedallion(Item medallion)
        {
            if (player.CurrentRoom.Name == "Ingången")
            {
                MedallionUsed = true;
                Console.WriteLine("Du använder medaljongen i urgröpningen. Den stora stenporten skakar till och öppnas!");
            }
            else
            {
                Console.WriteLine("Medaljongen verkar inte passa här.");
            }
        }

        private void HandleUseBox(Item box)
        {
            if (player.CurrentRoom.Name == "Spindelrummet" && spiderBoss.IsAlive)
            {
                if (box.Contains("Larv"))
                {
                    spiderBoss.HasEatenCaterpillar = true;
                    Console.WriteLine("Du matar spindeln med larven. Spindeln blir glad och låter dig passera.");

                    var holeRoom = allRooms["Hålet"];
                    if (!holeRoom.ItemsInRoom.Any(i => i.Name == "Spindelnät"))
                        holeRoom.ItemsInRoom.Add(ItemFactory.CreateItem("spiderweb"));

                    player.Inventory.Remove(box);
                }
                else
                {
                    Console.WriteLine("Asken är tom. Spindeln ser inte imponerad ut...");
                }
            }
            else
            {
                Console.WriteLine("Du skakar lite på asken, men inget händer.");
            }
        }

        private void HandleUseTorch(Item torch)
        {
            if (player.CurrentRoom.Name == "Spindelrummet" && spiderBoss.IsAlive)
            {
                spiderBoss.IsAlive = false;
                Console.WriteLine("Du bränner spindeln med facklan. Spindeln dör.");
            }
            else
            {
                Console.WriteLine("Facklan sprakar till lite, men inget särskilt händer.");
            }
        }

    }
}
