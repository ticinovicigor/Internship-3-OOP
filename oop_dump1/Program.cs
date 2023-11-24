/*
mozda nekako dodavat u listu npr. tabs i onda
String.Join(", ", tabs.ToArray());
 */
using oop_dump1;
using System.Xml.Serialization;


static string ChooseContact(Dictionary<Contact, List<Call>> phonebook)
{
    var choice = "";
    while (true)
    {
        Console.WriteLine("* svi_kontakti_ispisani *");
        choice = Console.ReadLine();
        choice = choice.ToLower();

        foreach (var item in phonebook)
        {
            if (choice == item.Key.Name.ToLower())
                return item.Key.Name;
        }
        Console.Clear();
        Console.WriteLine("Nepravilan unos, pokusajte ponovo\n\n");
    }
}
static string ManageContact(string contact)
{
    var choice = "";
    while (true)
    {
        Console.WriteLine("> Upravljanje kontaktom\n" +
            "1 - Ispis poziva s kontaktom\n" +
            "2 - Kreiranje novog poziva\n" +
            "0 - Natrag");

        choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
            case "2":
            case "0":
                return choice;
            
            default:
                Console.Clear();
                Console.WriteLine("Nepravilan unos, pokusajte ponovo\n\n");
                break;
        }
    }
}



var phonebook = new Dictionary<Contact, List<Call>>();

var choice_main = "";

while (choice_main != "0")
{
    Console.WriteLine("1 - Ispis svih kontakata\n" +
        "2 - Dodavanje novih kontakata u imenik\n" +
        "3 - Brisanje kontakata iz imenika\n " +
        "4 - Editiranje preference kontakta\n" +
        "5 - Upravljanje kontaktom ...\n" +
        "6 - Ispis svih poziva\n" +
        "0 - Izlaz iz aplikacije");
    
    choice_main = Console.ReadLine();

    switch(choice_main)
    {
        case "1":
            break;
        
        case "2":
            break; 
        
        case "3":
            break; 
        
        case "4":
            break; 
        
        case "5":
            var chosen_contact = ChooseContact(phonebook);
            var choice_manage = ManageContact(chosen_contact);
            break; 
        
        case "6":
            break;
        
        case "0":
            break;
        
        default:
            Console.Clear();
            Console.WriteLine("Nepravilan unos, pokusajte ponovo\n\n");
            break;
    }
}