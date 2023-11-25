/*
mozda nekako dodavat u listu npr. tabs i onda
Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
 */
using oop_dump1;
using System.Xml.Serialization;

static void ListContacts(Dictionary<Contact, List<Call>> phonebook)
{
    Console.WriteLine("IME\t\tBROJ\t\tPREFERENCA");
    foreach (var item in phonebook)
    {
        Console.WriteLine($"{item.Key.Name}\t{item.Key.Number}\t{item.Key.Preference}");
    }
    Console.WriteLine("");
}

static Contact ChooseContact(Dictionary<Contact, List<Call>> phonebook, List<string> tabs)
{
    var choice = "";
    while (true)
    {
        Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
        Console.WriteLine("Unesite ime kontakta kojim zelite upravljati:\n");
        ListContacts(phonebook);
        choice = Console.ReadLine();
        choice = choice.ToLower();

        foreach (var item in phonebook)
        {
            if (choice == item.Key.Name.ToLower())
            {
                Console.Clear();
                return item.Key;
            }
        }
        Console.Clear();
        Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
    }
}
static string ManageContact(List<string> tabs)
{
    var choice = "";
    while (true)
    {
        Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
        Console.WriteLine("1 - Ispis poziva s kontaktom\n2 - Kreiranje novog poziva\n0 - Natrag\n");

        choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
            case "2":
            case "0":
                Console.Clear();
                return choice;
            
            default:
                Console.Clear();
                Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
                break;
        }
    }
}


var default_contact = new Contact("Igor Ticinovic", "0958116868", "Normalan");
var default_call = new Call(DateTime.Parse("11/24/2023 10:18:00 PM"), "zavrsen");
var phonebook = new Dictionary<Contact, List<Call>>()
{
    {default_contact, new List<Call> {default_call} },
};

var tabs = new List<string>();

var choice_main = "";
var temp = "";

while (choice_main != "0")
{
    Console.WriteLine("1 - Ispis svih kontakata\n" +
        "2 - Dodavanje novih kontakata u imenik\n" +
        "3 - Brisanje kontakata iz imenika\n" +
        "4 - Editiranje preference kontakta\n" +
        "5 - Upravljanje kontaktom ...\n" +
        "6 - Ispis svih poziva\n" +
        "0 - Izlaz iz aplikacije\n");
    
    choice_main = Console.ReadLine();
    Console.Clear();
    tabs.Clear();
    switch(choice_main)
    {
        case "1":
            tabs.Add("Ispis kontakata");
            Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
            Console.WriteLine("");
            ListContacts(phonebook);
            Console.WriteLine("\nZa povratak na glavni meni unesite bilo sto:");
            temp = Console.ReadLine();
            Console.Clear();
            break;
        
        case "2":
            break; 
        
        case "3":
            break; 
        
        case "4":
            break; 
        
        case "5":
            tabs.Add("Upravljanje kontaktom");
            var chosen_contact = ChooseContact(phonebook, tabs);
            tabs.Add(chosen_contact.Name);
            var choice_manage = ManageContact(tabs);
            var calls = phonebook[chosen_contact];
            switch (choice_manage)
            {
                case "1":
                    tabs.Add("Ispis poziva");
                    Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
                    Console.WriteLine($"\nVRIJEME USPOSTAVE\t\tSTATUS");
                    var done_times = new List<DateTime>();                    
                    
                    //FOR PETLJA ZA ISPIS POZIVA PO REDU
                    for (int i = 0; i < calls.Count(); i++)
                    {
                        var newest_time = new DateTime();
                        var first_time = true;
                        foreach (var item in calls)
                        {
                            if (first_time && !done_times.Contains(item.Time))
                            {
                                first_time = false;
                                newest_time = item.Time;
                                continue;
                            }
                            else if (first_time)
                                continue;
                                
                            if(item.Time > newest_time && !done_times.Contains(item.Time))
                                newest_time = item.Time;
                        }
                        done_times.Add(newest_time);
                        foreach (var item in calls)
                        {
                            if(item.Time == newest_time)
                            {
                                Console.WriteLine($"{newest_time}\t\t{item.Status}");
                                break;
                            }
                        }
                    }
                    Console.WriteLine("\nZa povratak na glavni meni unesite bilo sto:");
                    temp = Console.ReadLine();
                    Console.Clear();
                    break;
                
                case "2":
                    tabs.Add("Kreiranje poziva");
                    Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
                    if(chosen_contact.Preference == "Blokiran")
                    {
                        Console.WriteLine($"\nKontakt {chosen_contact.Name} je blokiran.\nAko zelite uspostaviti poziv s ovim kontaktom, odblokirajte ga.");
                        Console.WriteLine("\nZa povratak na glavni meni unesite bilo sto:");
                        temp = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    //random odgovor na poziv, dodat u dictionary...

                    break;
                
                case "0":
                    Console.Clear();
                    break;
            }
            break; 
        
        case "6":
            break;
        
        case "0":
            break;
        
        default:
            Console.Clear();
            Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
            break;
    }
}