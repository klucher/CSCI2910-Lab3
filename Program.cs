using System.Collections;

public class Program
{
    public static ArrayList people = new ArrayList();
    public static void Main(string[] args)
    {
        // display menu and allow user to choose option
        int choice;
        do
        {
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
            Console.Clear();
            Console.Beep();
            DisplayMenu();
            Console.WriteLine("Please enter your selection: ");
            //choice = Convert.ToInt32(Console.ReadLine()); Try parse has inherit exception handling
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid selection.");
            }
            Console.WriteLine();
            MenuOption(choice);
        } while (choice != 0);
    }

    // display the menu
    public static void DisplayMenu()
    {
        Console.WriteLine("\n============ MENU ============");
        Console.WriteLine("1. Create Person Objects");
        Console.WriteLine("2. View Person Objects");
        Console.WriteLine("3. Remove Person Objects");
        Console.WriteLine("4. Random Last Name");
        Console.WriteLine("5. Random SSN");
        Console.WriteLine("6. Random Phone Number");
        Console.WriteLine("0. Exit");
        Console.WriteLine("==============================\n");
    }

    // choose from menu
    public static void MenuOption(int option)
    {
        switch (option)
        {
            case 0:
                // exit
                break;
            case 1:
                // create a person object
                CreatePerson();
                break;
            case 2:
                // view all person objects
                ViewPerson();
                break;
            case 3:
                // remove a person object
                RemovePerson();
                break;
            case 4:
                // randomLastName
                Person randomLastName = new Person();
                Console.WriteLine(randomLastName.LastName);
                break;
            case 5:
                // randomSSN
                Person randomSSN = new Person();
                Console.WriteLine(randomSSN.SSN);
                break;
            case 6:
                // randomPhone
                Person randomPhone = new Person();
                Console.WriteLine(randomPhone.Phone.Number);
                break;
            default:
                Console.WriteLine("Invalid menu choice. Please try again.");
                break;
        }
    }

    public static void CreatePerson()
    {
        // create any number of person objects
        Console.WriteLine("How many person objects would you like to create: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < choice; i++)
        {
            people.Add(new Person());
        }

        Console.WriteLine($"\nCreated {choice} person objects.");
    }

    public static void ViewPerson()
    {
        // see all available person objects
        if (people.Count == 0)
        {
            people.Add(new Person());
            Console.WriteLine(people[0]);
        }
        else
        {
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i]);
            }
        }

        // select person object to view
    }

    public static void RemovePerson()
    {
        // see all available person objects
        if (people.Count == 0)
        {
            Console.WriteLine("There are no objects to remove.");
        }
        else
        {
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine("Index " + i + ": \n" + people[i]);
            }

            Console.WriteLine("Please select the index associated with\n the person object you would like to remove: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (people[choice] == null)
            {
                Console.WriteLine("Invalid selection.");
            }
            else if (people[choice] != null)
            {
                people.Remove(people[choice]);
                Console.WriteLine($"\nRemoved person object at index {choice}");
            }

        }
    }
}