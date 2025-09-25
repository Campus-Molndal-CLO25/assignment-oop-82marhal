# Reflektion över [Temple Diamond]

## Planering

- Hur planerade du ditt arbete från start till mål?

Jag började med att skriva ner en plan för hur jag ville att problemen i spelet skulle lösas. Därefter ritade jag upp en karta över hur alla rum i templet är placerade, vilka håll man kan gå i varje rum och vilka prylar som finns i varje rum. För att kunna göra en planering för hur jag skulle bygga upp min kod skrev jag ner alla steg för att vinna spelet. När grunden för spelet var planerad gjorde jag ett enkelt flödesschema för alla möjliga scenarier och skrev en enkel pseudokod utifrån mitt flödesschema. Med tipset om att bygga upp rummen och koppla ihop dem och se till så att de var rätt ihopkopplade i bakhuvuet började jag med just det med hjälp av min handritade karta. När alla rum var skapade och man kunde röra sig mellan dem på korrekt sätt skapade jag de items som skulle finnas i varje rum och kopplade dessa till respektive rum. Jag rådfrågade ChatGPT om vad som kunde vara det bästa sättet att skapa Items och den föreslog att jag skulle göra en så kallad Factory som var separerad från Item-klassen för att koden skulle bli tydligare. Därefter skapade jag spelaren och satte upp regler för hur denne kunde agera och röra sig. Grunden var nu lagd och det gick att göra en första genomkörning av spelet för att se så att spelaren kunde röra sig mellan varje rum och interagera med alla föremål. 

Dags att sätta upp alla specialfall. Jag kontrollerade först och främst om det fanns några specialfall där man kunde använda samma metod för att inte behöva upprepa koden flera gånger. Nu i efterhand kan jag säga att jag missade några gemensamma nämnare men det sparade mycket tid att tänka igenom dem i förväg och sedan förändra koden i efterhand så den blev mer clean. 

När jag tyckte att jag hade fått ihop ett spel som var logiskt och inte längre innehöll några buggar lät jag min sambo testa det. Han hittade naturligtvis en bugg redan efter att ha skrivit ett fåtal kommandon. Efter att ha löst buggen bad jag ChatGPT granska min kod och ge mig förslag på förbättringar. Jag redogör mer för dessa längre ner i denna reflektion. 

Vi fick göra ett större projekt när jag läste Programmering 1 i våras också, och då fick jag lära mig den hårda vägen hur viktigt det var att lägga upp en tydlig plan för sitt arbete. 


## Problem

- Vad var den svåraste delen av uppgiften och varför? 
- Hur löste du de problem du stötte på?

Jag kan utan att ljuga säga att det som har varit det absolut svåraste i uppgiften har varit att få koden pushad till Github, till rätt repository. Jag har suttit många timmar tillsammans med ChatGPT för att få ordning på det och till slut löste jag det och jag kan nu säga att jag nästan till och med har blivit vän med kommandotolken. Till slut förstod jag även förhållandet mellan VS - Github - Utforskaren. Verkligen en proud moment! 

Något jag alltid tycker är svårt är att veta vart man ska börja när man sitter med en helt blank skärm. Men efter att ha börjat med att rita upp en karta, skriva min story, planera för hur man tar sig från start till mål och vilka hinder man ska ta sig förbi på vägen var det mycket enklare att veta vart och hur man skulle börja. Ett bra sätt att komma igång är alltid att börja med något som man är säker på hur man gör och sedan har man liksom kommit igång och då är det lättare att bara "köra på". 

Under kodningens gång stötte jag på en hel del buggar. Exempelvis kunde man klättra upp för stegen utan att den ens var där, man kunde ta larven istället för att behöva fånga den i asken med lövet och man kunde gå runt i templet trots att man inte hade med sig facklan och det var helt mörkt. Jag har tagit ChatGPT till hjälp för att lösa dessa buggar. AI fick dock endast ge mig tips och exempel på hur man skulle lösa problemen, inte ge mig färdig kod. 

En sista svårighet jag hade att övervinna var att inte komplicera för mycket och verkligen begränsa spelet för att jag skulle ha tillräckligt tid med att färdigställa det. Jag hade förmodligen kunnat fortsätta bygga ut spelet hur mycket som helst om jag inte hade haft en plan och verkligen höll mig till den. Självklart gjorde jag några få förändringar från originalplanen för att jag insåg att vissa saker inte var relevanta (t ex hade jag en smörgås i asken från början men insåg sen att jag inte behövde den till någonting). 

## Stolthet

- Vad är du mest stolt över med ditt projekt?

Jag är mest stolt över alla begränsningar jag skapat i spelet - OCH att jag har fått dem att funka. Jag är stolt över att ha skapat två olika slut beroende på hur man hanterar och kommer förbi spindelbossen. Nu när jag sitter här med ett funktionellt spel och inser att jag faktiskt hade uppskattat att spela det själv känner jag en enorm stolthet. För 20 år sedan sökte jag in till Speldesign på högskolan (men kom inte in) och där och då lämnade jag tanken på att syssla med det. Det var roligt att få skapa det här spelet och få en pytteliten inblick i det arbetsliv jag aldrig levde. 

Jag är stolt över att jag inte gav upp när jag stötte på patrull utan gav mig tusan på att lösa problemen. Jag är även stolt över hur mycket jag utvecklat mitt  tänkande kring datastrukturer, kommandosystem och modulär kod. Många textäventyr kör fast i långa switch-case, men jag har lyckats skapa en smart lösning där varje kommando kopplas till en metod. Det gör det superenkelt att lägga till nya funktioner och är ett konkret exempel på bra programmeringsdesign. Spelet är överskådligt och inte överkomplicerat, men samtidigt har det tillräckligt med logik och regler för att kännas levande. Jag är dessutom mycket stolt över storytellingen, humorn och pusslet som jag har skapat. 

Slutligen är jag stolt över att jag kom på så många saker att vara stolt över när jag är så marinerad i jantelagen som jag är. 

---

## Reflektion för Väl Godkänt (VG)


### Datastrukturer

- Vilka datastrukturer (t.ex. listor, arrays, dictionaries) använde du i ditt program? Varför valde du just dessa?
- Finns det andra datastrukturer som hade kunnat fungera och vilka för- eller nackdelar hade de haft i just ditt projekt?

I mitt spel har jag använt flera olika datastrukturer för att organisera information:

#### Listor
Jag använder listor för spelarens inventarium och för föremål som finns i ett rum. Listor är smidiga eftersom de är dynamiska (man kan enkelt lägga till och ta bort föremål) och de bevarar en ordning. Det passar bra i ett spel där spelaren ofta plockar upp och lägger ifrån sig saker.

#### Dictionary
Jag använder dictionaries på flera ställen: För att hålla reda på alla rum i världen och för att definiera utgångar från rummen (riktning till nästa rum). 
Jag använder det även för att koppla ihop kommandon med funktioner (t.ex. "gå" → HandleGo). Detta var något som ChatGPT föreslog för mig då jag bad den ge mig förslag på förbättringar av min kod. Tidigare hade jag byggt upp denna del med en switch-sats och koden blev helt klart mycket mer lättläst och lätthanterlig efter att ha ändrat detta. 
Dictionaries är effektiva när man snabbt vill slå upp ett värde utifrån en nyckel. Det gör koden både tydligare och snabbare än om jag hade behövt loopa igenom en lista varje gång.

#### Alternativa lösningar

Jag hade kunnat använda vanliga arrays för inventariet eller föremål i ett rum. Nackdelen är att arrays har en fast storlek, så det hade blivit mycket mer krångligt att lägga till och ta bort saker. I ett spel där listan över föremål ofta förändras är List<T> mycket mer flexibel.
Ett alternativ till listan för inventariet hade kunnat vara HashSet<T>. Det hade gjort det snabbare att kolla om spelaren redan har ett föremål, eftersom uppslagningen sker i konstant tid. Nackdelen är att en HashSet inte bevarar ordningen och att man inte kan ha dubbletter – i mitt spel är ordning och enkelhet viktigare än maximal prestanda, så en lista kändes mer passande.
Jag hade kunnat använda en Queue eller Stack om jag ville att spelaren skulle hantera föremål i en särskild ordning (t.ex. FIFO eller LIFO). Men i mitt spel kan spelaren fritt använda vilket föremål som helst i inventariet, så det hade inte passat lika bra.

Jag valde Listor och Dictionaries eftersom de är flexibla och enkla att arbeta med i ett textäventyr där föremål, rum och kommandon ofta förändras eller slås upp. Andra datastrukturer hade kunnat fungera, men de hade antingen gjort spelet mer begränsat (arrays) eller mer komplext än nödvändigt (HashSet, Stack/Queue).

### Clean Code och Struktur

Hur har du arbetat för att göra din kod "ren" och välstrukturerad? Reflektera över hur du har organiserat dina klasser och metoder för att göra koden läsbar, återanvändbar och lätt att underhålla (modularitet). Ge konkreta exempel från din kod.

_Diskutera din kodkvalitet:_

- _Hur namngav du klasser, metoder och variabler?_
Jag har använt beskrivande namn som tydligt visar vad varje del gör. Till exempel heter klassen Player för att den hanterar spelarens data och Room för att beskriva ett rum. Metoder som HandleGo, HandleTake och HandleUse säger direkt vilket kommando de hanterar. Variabler som ItemsInRoom och MedallionUsed gör det tydligt vad de representerar.
- _Hur följde du grundregeln att klasser och metoder ska göra vad de heter och inget annat?_
Jag har försökt hålla varje metod fokuserad på en uppgift. Till exempel hanterar HandleGo enbart logiken för att gå till ett nytt rum, medan HandleDiamondTaken bara tar hand om vad som händer när spelaren plockar upp diamanten. På samma sätt ansvarar MainGame för spelets flöde, medan Player sköter inventariet. Detta gör att koden blir mer lättläst och mindre rörig.
- _Vilka metoder bröt du ut för att undvika upprepning?_
Jag bröt ut metoder som används på flera ställen, t.ex. UseItem för logiken när spelaren använder ett föremål, och HandleHole för logiken vid hålet. På så sätt slipper jag skriva samma kod flera gånger i olika delar av spelet. Det gör också att framtida ändringar blir enklare, eftersom de bara behöver göras på ett ställe.
- _Hur kommenterade du din kod?_
Jag har lagt in kommentarer där det behövs för att förklara mer komplexa delar, som i CreateWorld där världen byggs upp. Däremot har jag försökt att hålla koden tillräckligt självdokumenterande genom tydliga namn, så att kommentarer inte behövs i varje rad. På det sättet undviker jag onödiga kommentarer men ger extra förklaring där logiken kan vara svårare att följa.


### Framtida utveckling

Kan du fortsätta att utveckla ditt projekt utan att behöva göra om allt från grunden? Hur har du designat din kod för att den ska vara möjlig att bygga vidare på i framtiden?

_Reflektion över koddesign:_

- _Vilka delar av din kod skulle vara lätta att ändra eller utöka?_
Det är enkelt att lägga till nya rum, föremål och utgångar i spelet eftersom all världsgenerering sker i metoden CreateWorld. Även nya kommandon är lätta att lägga till tack vare dictionaryn commandHandlers, där jag bara behöver registrera ett nytt nyckelord och en metod. Dessutom kan jag enkelt skapa fler fiender eller pussel genom att följa samma mönster som redan används för spindeln.
- _Vad skulle vara svårt att ändra och varför?_
Något svårare skulle vara att ändra på hela spelstrukturen, till exempel om spelet skulle byta från textbaserat till grafiskt gränssnitt. Mycket av logiken bygger idag på konsolutskrifter (Console.WriteLine), så det hade krävt större omarbetning. Även om jag kan återanvända spelmekaniken skulle presentationen behöva skrivas om.
- _Har du tänkt på att separera olika ansvarsområden?_
Ja, jag har försökt separera ansvar så mycket som möjligt. Till exempel har MainGame hand om spelstyrning och kommandon, Player sköter inventarium och position, och Room håller reda på föremål och utgångar. Spindeln har en egen klass (SpiderBoss) för att hålla bosslogiken isolerad. Detta gör att varje klass har ett tydligt syfte, vilket underlättar både felsökning och vidareutveckling.


---

_Denna reflektion är skapad som del av inlämningsuppgiften i kursen "Grundläggande objektorienterad programmering i C#" vid Yrkeshögskolan Campus Mölndal._
