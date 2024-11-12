using System; // Importera System-namnrymden som innehåller grundläggande klasser och funktioner

using System.Collections.Generic; // Importera namnrymden som innehåller definitioner för generiska kollektioner, som List<T>

internal class Program // Definiera en intern klass med namnet "Program"
{
    // Deklarera listan som alla blogginlägg ska vara i. Varje inlägg är en array av strängar.
    static List<string[]> blogginlägg = new List<string[]>(); // Skapa en ny tom lista för blogginlägg

    // Huvudmetoden för programmet
    static void Main(string[] args) // Definiera huvudmetoden för programmet med en parameter för kommandoradsargument
    {
        bool kör = true; // Skapa en boolesk variabel och sätt den till sant

        // En while-loop som körs tills användaren väljer att avsluta programmet och min boolean för programmet alltså är lika med falskt
        while (kör) // Loopa så länge kör är sant
        {
            // Visa huvudmenyn för användaren
            Console.WriteLine("Välkommen till iwans blogg!"); // Skriv ut en välkomsthälsning
            Console.WriteLine("[1] - Skriv nytt inlägg i bloggen"); // Visa ett alternativ för att skriva nytt inlägg
            Console.WriteLine("[2] - Visa alla inlägg i bloggen"); // Visa ett alternativ för att visa alla inlägg
            Console.WriteLine("[3] - Sök inlägg i bloggen"); // Visa ett alternativ för att söka efter inlägg
            Console.WriteLine("[4] - Redigera inlägg"); // Visa ett alternativ för att redigera inlägg
            Console.WriteLine("[5] - Ta bort inlägg"); // Visa ett alternativ för att ta bort inlägg
            Console.WriteLine("[6] - Sortera inlägg efter titel"); // Visa ett alternativ för att sortera inlägg
            Console.WriteLine("[7] - Avsluta programmet"); // Visa ett alternativ för att avsluta programmet

            // Läs in användarens val och försök konvertera det till en int
            Console.Write("Välj ett av dem ovanstående valen: "); // Be användaren välja ett alternativ
            Int32.TryParse(Console.ReadLine(), out int menyval); // Läs in användarens val och försök konvertera det till en int

            // Utför den valda åtgärden baserat på användarens input
            switch (menyval) // Beroende på användarens val, utför en specifik åtgärd
            {
                case 1:
                    Console.Clear();
                    LäggTillInlägg(); // Lägger till inlägg
                    break;

                case 2:
                    Console.Clear();
                    SkrivUtInlägg(); // Skriver ut alla inlägg i min blogg
                    break;

                case 3:
                    Console.Clear();
                    SökInlägg(); // Söker inlägg baserat på titeln
                    break;

                case 4:
                    Console.Clear();
                    RedigeraInlägg(); // Redigerar ett inlägg i bloggen med denna
                    break;

                case 5:
                    Console.Clear();
                    TaBortInlägg(); // Tar bort ett inlägg från bloggen
                    break;

                case 6:
                    Console.Clear();
                    BubbelSort(blogginlägg); // Anropa BubbelSort för att sortera inläggen efter titel
                    SkrivUtInlägg(); // Skriv ut de sorterade inläggen
                    break;

                case 7:
                    kör = false; // kör blir false om användaren väljer detta och programmet avslutas
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig inmatning. Vänligen försök igen."); // Meddela användaren om ogiltigt val
                    break;
            }
        }
    }

    // Metod för att lägga till ett nytt inlägg i bloggen
    static void LäggTillInlägg() // Metod för att lägga till ett nytt inlägg i bloggen, tar en lista som parameter
    {
        // Skapar en vektor som tar in titel, meddelande och datum
        string[] nyttInlägg = new string[3]; // Skapa en ny array med tre platser för titel, meddelande och datum
        Console.Write("Ange en titel för inlägget: "); // Be användaren ange titel för det nya inlägget
        nyttInlägg[0] = Console.ReadLine(); // Läs in användarens inmatning och spara den som titel i den nya arrayen

        Console.Write("Ange meddelande för inlägget: "); // Be användaren ange meddelande för det nya inlägget
        nyttInlägg[1] = Console.ReadLine(); // Läs in användarens inmatning och spara den som meddelande i den nya arrayen

        // Hämta dagens datum
        nyttInlägg[2] = DateTime.Now.ToString("yyyy-MM-dd"); // Spara dagens datum i formatet "yyyy-MM-dd" i den nya arrayen

        blogginlägg.Add(nyttInlägg); // Lägg till det nya inlägget i listan med blogginlägg

        Console.WriteLine("Inlägget lades till i bloggen."); // Meddela användaren att inlägget har lagts till
    }

    // Metod för att skriva ut alla inlägg i bloggen
    static void SkrivUtInlägg() // Metod för att skriva ut alla inlägg i bloggen
    {
        // Kontrollera om det finns inlägg i bloggen
        if (blogginlägg.Count == 0) // Om det inte finns några inlägg i bloggen
        {
            Console.WriteLine("Finns inga inlägg ännu."); // Meddela användaren om att det inte finns några inlägg att visa
        }
        else // Om det finns inlägg i bloggen
        {
            // Loopa igenom alla inlägg och skriv ut dem
            Console.WriteLine("Alla inläggen i Iwans blogg:");
            foreach (string[] inlägg in blogginlägg) // Loopa igenom varje inlägg i listan med blogginlägg
            {
                Console.WriteLine($"Titel: {inlägg[0]}\nMeddelande: {inlägg[1]}\nDatum: {inlägg[2]}"); // Skriv ut titeln, meddelandet och datumet för varje inlägg
                Console.WriteLine("-----------------------"); // Skriv ut en linje som separerar varje inlägg
            }
        }
    }

    // Metod för att söka efter inlägg baserat på titeln
    static void SökInlägg() // Metod för att söka efter inlägg baserat på titeln
    {
        Console.Write("Ange titeln för inlägget: "); // Användaren anger titeln för det den söker
        string sök = Console.ReadLine(); // Läs in användarens inmatning och spara den som sök

        bool hittat = false; // Skapa en boolesk variabel och sätt den till falsk

        // Loopa igenom alla inlägg och jämför titlarna med sökordet
        foreach (string[] inlägg in blogginlägg) // Loopa igenom varje inlägg i listan med blogginlägg
        {
            if (JämförTitel(inlägg[0], sök)) // Om titeln på det aktuella inlägget matchar sökordet
            {
                Console.WriteLine($"Titel: {inlägg[0]}\nMeddelande: {inlägg[1]}\nDatum: {inlägg[2]}"); // Skriv ut titeln, meddelandet och datumet för det matchande inlägget
                Console.WriteLine("-----------------------"); // Skriv ut en linje som separerar inlägget
                hittat = true; // Sätt hittat till sant eftersom ett matchande inlägg har hittats
            }
        }

        // Om inget inlägg hittades
        if (!hittat) // Om ingen matchande titel hittades
        {
            Console.WriteLine("Inget inlägg med den titeln hittades."); // Skriv ut att inget inlägg hittades med den angivna titeln
        }
    }

    // Metod för att jämföra titlar (icke skiftlägeskänslig jämförelse)
    static bool JämförTitel(string titel, string sökord) // Metod för att jämföra titlar (icke skiftlägeskänslig jämförelse)
    {
        // Konvertera både titel och sökord till små bokstäver för en icke-skiftlägeskänslig sökning
        string titelLiten = titel.ToLower(); // Konvertera titel till små bokstäver och spara resultatet i titelLiten
        string sökordLiten = sökord.ToLower(); // Konvertera sökord till små bokstäver och spara resultatet i sökordLiten

        // Om jämför titel med sökord är lika, returnerar vi true annars false.
        if (titelLiten == sökordLiten) // Om titeln matchar sökordet
        {
            return true; // Returnera sant eftersom titeln matchar sökordet
        }
        return false; // Annars returnera falsk eftersom titeln inte matchar sökordet
    }

    // Metod för att redigera ett befintligt inlägg i bloggen
    static void RedigeraInlägg() // Metod för att redigera ett befintligt inlägg i bloggen
    {
        // Visa alla inlägg så att användaren kan välja vilket som ska redigeras
        SkrivUtInlägg(); // Anropa SkrivUtInlägg-metoden för att visa alla inlägg

        // Kontrollera om det finns inlägg att redigera
        if (blogginlägg.Count == 0) // Om det inte finns några inlägg i bloggen
        {
            Console.WriteLine("Det finns inga inlägg att redigera."); // Skriv ut att det inte finns några inlägg att redigera
            return; // Avsluta metoden
        }

        // Låt användaren välja vilket inlägg som ska redigeras baserat på index
        Console.Write("Välj vilket inlägg du vill redigera (ange index): "); // Be användaren välja vilket inlägg som ska redigeras genom att ange dess index
        if (Int32.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= blogginlägg.Count) // Försök att läsa in användarens inmatning och konvertera den till en int
        {
            //Eftersom det användaren matar in -1 är index platsen för vart inlägget finns sparat, då användaren i den riktiga världen kanske inte vet om att att första platsen i listan egentligen är 0
            string[] inlägg = blogginlägg[index - 1]; // Hämta det valda inlägget baserat på det angivna indexet
            Console.WriteLine($"Redigerar inlägg med titeln: {inlägg[0]}"); // Skriv ut titeln på det valda inlägget

            // Be användaren ange ny titel och nytt meddelande för inlägget
            Console.Write("Ange ny titel: "); // Be användaren ange den nya titeln för inlägget
            string nyTitel = Console.ReadLine(); // Läs in användarens inmatning och spara den som nyTitel
            Console.Write("Ange nytt meddelande: "); // Be användaren ange det nya meddelandet för inlägget
            string nyttMeddelande = Console.ReadLine(); // Läs in användarens inmatning och spara den som nyttMeddelande

            // Uppdatera inlägget med de nya värdena
            inlägg[0] = nyTitel; // Uppdatera titeln på inlägget med den nya titeln
            inlägg[1] = nyttMeddelande; // Uppdatera meddelandet på inlägget med det nya meddelandet
            Console.WriteLine("Inlägget redigerades."); // Meddela användaren att inlägget har redigerats
        }
        else // Om användaren angav ogiltig inmatning
        {
            Console.WriteLine("Felaktig inmatning, vänligen försök igen."); // Skriv ut ett felmeddelande om ogiltig inmatning
        }
    }

    // Metod för att ta bort ett inlägg från bloggen
    static void TaBortInlägg() // Metod för att ta bort ett inlägg från bloggen
    {
        // Visar alla inlägg så att användaren kan välja vilket som ska tas bort från bloggen
        SkrivUtInlägg(); // Anropa SkrivUtInlägg-metoden för att visa alla inlägg

        // Kontrollera om det finns inlägg att ta bort
        if (blogginlägg.Count == 0) // Om det inte finns några inlägg i bloggen
        {
            Console.WriteLine("Det finns inga inlägg att ta bort."); // Skriv ut att det inte finns några inlägg att ta bort
            return; // Avsluta metoden
        }

        // Låt användaren välja vilket inlägg som ska tas bort baserat på index
        Console.Write("Välj vilket inlägg du vill ta bort (ange index): "); // Be användaren välja vilket inlägg som ska tas bort genom att ange dess index
        if (Int32.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= blogginlägg.Count) // Försök att läsa in användarens inmatning och konvertera den till en int
        {
            // Ta bort det valda inlägget från listan med blogginlägg
            blogginlägg.RemoveAt(index - 1); // Ta bort det valda inlägget från listan genom att ange dess index
            Console.WriteLine("Inlägget har blivit borttaget."); // Meddela användaren att inlägget har tagits bort
        }
        else // Om användaren angav ogiltig inmatning
        {
            Console.WriteLine("Felaktig inmatning, vänligen försök igen."); // Skriv ut ett felmeddelande om ogiltig inmatning
        }
    }

    // Metod för bubbelsortering
    static void BubbelSort(List<string[]> list) // Metod för att utföra bubbel-sortering på en lista med arrayer av strängar
    {
        // Antal element i listan
        int n = list.Count; // Sätt n till antalet element i listan

        // En variabel som håller reda på om någon byte har skett under en iteration
        bool swapped; // Skapa en boolesk variabel för att hålla reda på om några byten har skett

        // Utför bubbel-sorteringen tills inga byten görs under en iteration
        do // Utför loopen minst en gång och sedan upprepa den så länge som swapped är sant
        {
            // Återställer swapped till falskt för varje ny iteration
            swapped = false; // Återställ variabeln till falsk för varje iteration

            // Loopa igenom listan från början till näst sista elementet
            for (int i = 1; i < n; i++) // Loopa igenom listan från index 1 till index (n - 1)
            {
                // Jämför de två intilliggande elementen i listan
                // Här jämförs strängarna som finns i den första positionen (index 0) i varje delarray
                if (String.Compare(list[i - 1][0], list[i][0]) > 0) // Jämför titlarna på de två intilliggande inläggen i listan
                {
                    // Om strängen på index i - 1 är större än strängen på index i, byt plats på dem. Använd en temporär variabel för att byta plats på elementen
                    string[] temp = list[i - 1]; // Tillfälligt spara det aktuella inlägget i en temporär variabel
                    list[i - 1] = list[i]; // Byt plats på det aktuella inlägget med det föregående inlägget
                    list[i] = temp; // Byt plats på det föregående inlägget med det aktuella inlägget genom att använda den temporära variabeln

                    // Flagga för att ett byte har skett och sätt swapped lika med true.
                    swapped = true; // Sätt swapped till sant eftersom ett byte har skett
                }
            }

            // Eftersom det största elementet kommer att "bubbla upp" till rätt position, minskas antalet iterationer för att undvika onödiga jämförelser
            n--; // Minska värdet av n med 1 för varje iteration för att undvika onödiga jämförelser

        } while (swapped); // Fortsätt loopa tills inga byten görs under en iteration
    }
}
