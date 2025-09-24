# Temple Diamond - Martina Halldin

**Valt alternativ:** [Textäventyr]

## Projektbeskrivning

Jag har valt att skapa ett textäventyr. Vi får följa en äventyrare som letar efter diamanten från en av farfars berättelser. 
Genom att förflytta sig genom templets alla rum och använda sig av de saker man hittar under spelets gång tar äventyraren sig förhoppningsvis förbi den stora spindeln som vaktar diamanten. 

## Screenshot

_Lägg till minst en skärmbild som visar ditt program i aktion. Detta gör ditt projekt mer intressant och hjälper andra att förstå vad det gör._

![Skärmbild av programmet](screenshot.png)
På bilden ser du inledningsscenen i spelet. 

### Så här lägger du till screenshots:

1. Ta en skärmbild när ditt program körs (använd `Print Screen` eller `Snipping Tool`)
2. Spara bilden som `screenshot.png` i din projektmapp
3. Committa och pusha bilden till GitHub tillsammans med din kod
4. Bilden visas automatiskt i din README

_Tips: Du kan lägga till flera bilder för att visa olika delar av programmet, t.ex. spelstart, gameplay och slutskärm._

## Hur man startar programmet

### Förutsättningar

- .NET 8.0 eller senare
- En av följande utvecklingsmiljöer: Visual Studio, JetBrains Rider, Visual Studio Code, eller terminal/kommandotolk

### Klona projektet

```bash
git clone https://github.com/orgs/Campus-Molndal-CLO25/repositories/assignment-oop-[82marhal]]
cd assignment-oop-[82marhal]
```

### Starta programmet

#### Visual Studio

1. Öppna `TempleDiamond.sln` eller projektmappen
2. Tryck `F5` eller klicka på "Start" (grön triangel)

#### JetBrains Rider

1. Öppna projektmappen genom "File → Open"
2. Tryck `Ctrl+F5` eller klicka på "Run" (grön triangel)

#### Visual Studio Code

1. Öppna projektmappen: `code .`
2. Installera C# Dev Kit-tillägget om det saknas
3. Tryck `F5` eller använd "Run → Start Debugging"

#### Terminal/Kommandotolk

```bash
dotnet run
```

## Hur man använder programmet

- För att gå mellan rum: Skriv "gå [norr]/[söder]/[väster]/[öster]"
- FÖr att använda något från inventariet: Skriv "använd [item]"
- FÖr att se vad som finns i rummet: Skriv "titta"
- För att kombinera två items: Skriv "lägg [item1] i [item2]"
- För att fånga något: Skriv "fånga [item]


## Funktioner

_Lista de huvudsakliga funktionerna ditt program har._

### Grundfunktioner

- [ ] [Funktion 1]
- [ ] [Funktion 2]
- [ ] [Funktion 3]

### Extra funktioner (för VG)

- [ ] [VG-funktion om implementerad]

## Projektstruktur

```
projektmapp/
├── Program.cs         # Huvudprogram
├── Item.cs            # Dina klasser
├── ItemFactory.cs
├── MainGame.cs
├── Player.cs
├── Program.cs
├── Room.cs
├── Spider.cs
├── README.md          # Denna fil
├── reflection.md      # Reflektion över projektet
└── [eventuella datafiler]
```

## Teknisk information

- **Programmeringsspråk:** C#
- **Framework:** .NET 8.0
- **Utvecklingsmiljö:** [Visual Studio Code / Visual Studio]

## Spara projektet för framtiden

När du är klar och nöjd med ditt projekt, rekommenderas du att "forka" (kopiera) det till ditt privata GitHub-konto. Detta skapar en permanent kopia som du kan visa för framtida arbetsgivare som en del av din portfolio.

### Så här forkar du projektet:

1. **Gå till ditt projekt** på GitHub: https://github.com/orgs/Campus-Molndal-CLO25/repositories/assignment-oop-[ditt-username]

2. **Klicka på "Fork"** (längst upp till höger på sidan)

3. **Välj ditt privata konto** som destination för fork:en

4. **Uppdatera beskrivningen** i din fork:

   - Gå till din fork: `https://github.com/[ditt-privata-username]/assignment-oop-[ditt-username]`
   - Klicka på kugghjulet (Settings)
   - Lägg till en beskrivning som: "C# OOP project - Ocean research game built during studies at Campus Mölndal"
   - Lägg till topics/tags som: `csharp`, `oop`, `console-game`, `dotnet`

5. **Gör en sista uppdatering** av README.md i din fork och ändra länken under "GitHub Repository" till din nya fork

### Varför är detta viktigt?

- **Portfolio:** Visar dina programmeringsfärdigheter för potentiella arbetsgivare
- **Permanent kopia:** Skolans repositories kan tas bort efter kursen
- **Progression:** Du kan se tillbaka på ditt arbete och hur du utvecklats
- **Referens:** Användbart att ha tillgång till din egen kod för framtida projekt

## Länkar

- **GitHub Repository:** https://github.com/orgs/Campus-Molndal-CLO25/repositories/assignment-oop-82marhal
- **Din privata fork:** (uppdatera denna länk efter att du forkat)

---

_Skapad som del av kursen "Grundläggande objektorienterad programmering i C#" vid Yrkeshögskolan Campus Mölndal._
