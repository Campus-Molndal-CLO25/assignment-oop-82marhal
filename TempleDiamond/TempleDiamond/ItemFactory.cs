namespace TempleDiamond

{
    public static class ItemFactory
    {
        public static Item CreateItem(string itemName)
        {
            switch (itemName.ToLower())
            {
                case "smallbox":
                    return new Item("Ask", "Det är en ask. Det är något inuti.");
                case "torch":
                    return new Item("Fackla", "Det står en fackla vid väggen.");
                case "caterpillar":
                    return new Item("Larv", "En fet, saftig larv kryper runt på golvet.");
                case "ladder":
                    return new Item("Stege", "En lång stege står lutad mot väggen.");
                case "diamond":
                    return new Item("Diamant", "Där är den! Diamanten från farfars berättelser!");
                case "spiderweb":
                    return new Item("Spindelnät", "Spindeln är borta men den har gjort ett finfint nät över hålet som tack för maten.");
                case "leaf":
                    return new Item("Löv", "Trädet är fullt av gröna löv. Det ser nästan gott ut...om du hade varit gräsätare.");
                case "medallion":
                    return new Item("Medaljong", "Farfars gamla medaljong. Den verkar passa perfekt i urgröpningen i porten.");
                default:
                    throw new ArgumentException($"Unknown item type: {itemName}");
            }
        }
    }
}