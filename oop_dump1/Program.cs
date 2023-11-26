/*
mozda nekako dodavat u listu npr. tabs i onda
Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
 */
using oop_dump1;
using System.Net.WebSockets;
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

static string ChoosePreference(List<string> preferences, List<string> tabs)
{
    var input = "";
    var first_time = true;
    while (!preferences.Contains(input))
    {
        Console.Clear();
        if(!first_time)
            Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
        first_time = false;
        Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
        Console.WriteLine("Unesite preferencu kontakta (Normalan/Favorit/Blokiran):");
        input = Console.ReadLine();
        input = input.ToLower();
    }
    return input;
}
static Contact ChooseContact(Dictionary<Contact, List<Call>> phonebook, List<string> tabs)
{
    var choice = "";
    while (true)
    {
        Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
        Console.WriteLine("Unesite ime kontakta:\n");
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



var default_contact = new Contact("Igor Ticinovic", "0958116868", "normalan");
var default_call = new Call(DateTime.Parse("11/24/2023 10:18:00 PM"), "zavrsen", 20);
var phonebook = new Dictionary<Contact, List<Call>>()
{
    {default_contact, new List<Call> {default_call} },
};

var tabs = new List<string>();
var preferences = new List<string> { "normalan", "favorit", "blokiran" };

var choice_main = "";
var temp = "";
var first_time = true;
var sure = "";
var flag = false;

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
    var chosen_contact = new Contact(new string(""), new string(""), new string(""));
    Console.Clear();
    tabs.Clear();
    switch (choice_main)
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
            tabs.Add("Dodavanje kontakta");
            Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
            Console.WriteLine("Unesite ime i prezime novog kontakta:");
            var new_contact_name = Console.ReadLine();
            var new_contact_number = "";
            int temp_int = 0;
            first_time = true;
            while (!int.TryParse(new_contact_number, out temp_int) || new_contact_number.Contains("-"))
            {
                Console.Clear();
                if(!first_time)
                    Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
                first_time = false;
                Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
                Console.WriteLine("Unesite telefonski broj novog kontakta:");
                new_contact_number = Console.ReadLine();
            }
            var new_contact_preference = ChoosePreference(preferences, tabs);
            first_time = true;
            sure = "";
            while (sure != "1" && sure != "0")
            {
                Console.Clear();
                if (!first_time)
                    Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
                first_time = false;
                Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
                Console.WriteLine($"Jeste li sigurni da zelite dodati novi kontakt({new_contact_name}, {new_contact_number}, {new_contact_preference})?\n1 - Da\n0 - Ne");
                sure = Console.ReadLine();
            }
            Console.Clear();
            if (sure == "1")
            {
                phonebook.Add(new Contact(new_contact_name, new_contact_number, new_contact_preference), new List<Call>());
                Console.WriteLine("Novi kontakt uspjesno dodan!\n");
            }
            else
                Console.WriteLine("Novi kontakt nije dodan\n");

            break; 
        
        case "3":
            tabs.Add("Brisanje kontakta");
            chosen_contact = ChooseContact(phonebook, tabs);
            first_time = true;
            sure = "";
            while (sure != "1" && sure != "0")
            {
                Console.Clear();
                if (!first_time)
                    Console.WriteLine("Nepravilan unos, pokusajte ponovo\n");
                first_time = false;
                Console.WriteLine("> " + String.Join(" > ", tabs.ToArray()));
                Console.WriteLine($"Jeste li sigurni da zelite izbrisati kontakt ({chosen_contact.Name}, {chosen_contact.Number}, {chosen_contact.Preference})?\n1 - Da\n0 - Ne");
                sure = Console.ReadLine();
            }
            Console.Clear();
            if (sure == "1")
            {
                phonebook.Remove(chosen_contact);
                Console.WriteLine("Kontakt uspjesno izbrisan!\n");
            }
            else
                Console.WriteLine("Kontakt nije izbrisan\n");

            break; 
        
        case "4":
            break; 
        
        case "5":
            tabs.Add("Upravljanje kontaktom");
            chosen_contact = ChooseContact(phonebook, tabs);
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
                        first_time = true;
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
                    if(chosen_contact.Preference == "blokiran")
                    {
                        Console.WriteLine($"\nKontakt {chosen_contact.Name} je blokiran.\nAko zelite uspostaviti poziv s ovim kontaktom, odblokirajte ga.");
                        Console.WriteLine("\nZa povratak na glavni meni unesite bilo sto:");
                        temp = Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    
                    foreach (var contact in phonebook)
                    {
                        foreach (var call in contact.Value)
                        {
                            if(call.Status == "u tijeku")
                            {
                                if ((DateTime.Now - call.Time).TotalSeconds < call.Length)
                                {
                                    Console.WriteLine("Nije moguce uspostaviti poziv: poziv u tijeku vec postoji");
                                    Console.WriteLine("\nZa povratak na glavni meni unesite bilo sto:");
                                    temp = Console.ReadLine();
                                    Console.Clear();
                                    flag = true;
                                    break;
                                }
                                else
                                    call.Status = "zavrsen";                                    
                            }
                        }
                        if (flag)
                            break;
                    }
                    if(flag) 
                        break;
                    
                    Random rnd = new Random();
                    var new_call_status = rnd.Next(3);
                    
                    switch(new_call_status)
                    {
                        case 1:
                            phonebook[chosen_contact].Add(new Call(DateTime.Now, "propusten", 0));
                            Console.Clear();
                            Console.WriteLine("Osoba se ne javlja, pokusajte kasnije\n");
                            break;
                        
                        case 2:
                            var new_call_length = rnd.Next(21);
                            phonebook[chosen_contact].Add(new Call(DateTime.Now, "u tijeku", new_call_length));
                            Console.Clear();
                            Console.WriteLine("Poziv uspjesno uspostavljen i u tijeku!\n");
                            break;
                    }

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