public class Person
{
    private string[] _arrayOfFirstNames = { "Bob", "Robert", "Rob", "Bobert", "Bobothy", "Bobbery", "Rob-omb", "Bobber", "Bobo", "Sephiroth" };
    private Dependent[] _dependents;

    // contains a random first name from array
    public string FirstName
    {
        get; init; 
    }

    // contains a random last name from enum
    public string LastName
    {
        get; init;
    }

    // contains a random birthdate 18 - 80 years from today
    public DateTime BirthDate
    {
        get; init;
    }

    // contains a random invalid social security number
    public SSN SSN
    {
        get; init;
    }
    
    // contains a random phone number
    public Phone Phone
    {
        get; init;
    }

    // constructor class
    public Person()
    {
        Random rand = new Random();
        int index = rand.Next(_arrayOfFirstNames.Length);
        FirstName = _arrayOfFirstNames[index];

        Array lastNames = Enum.GetValues(typeof(LastName));
        var last = (LastName?)lastNames.GetValue(rand.Next(lastNames.Length));
        LastName = "" + last.ToString();

        DateTime start = new DateTime(1942, 1, 1);
        DateTime end = new DateTime(2004, 1, 1);
        int range = (end - start).Days;
        BirthDate = start.AddDays(rand.Next(range));

        this.SSN = new SSN();

        this.Phone = new Phone();

        _dependents = new Dependent[10];
    }

    // returns the person's age
    public int Age()
    {
        int todayDate = int.Parse(DateTime.Now.ToString("yyyMMdd"));
        int dateOfBirth = int.Parse(BirthDate.ToString("yyyMMdd"));
        int age = (todayDate - dateOfBirth) / 10000;
        return age;
    }

    // aggregates a dependent to the person
    public void AddDependent()
    {
        if (_dependents[0] == null)
        {
            _dependents[0] = new Dependent();
        }
        while (_dependents[0] != null)
        {
            for(int i = 1; i < _dependents.Length; i++)
            {
                if (_dependents[i] == null)
                {
                    _dependents[i] = new Dependent();
                    return;
                }
            }
        }
    }

    public override string ToString()
    {
        return $"-----------------------------------\n" +
               $"First Name:\t{FirstName}\n" +
               $"Last Name:\t{LastName}\n" +
               $"BirthDate:\t{BirthDate.ToShortDateString()}\n" +
               $"Age:\t\t" + Age() + "\n" +
               $"SSN:\t\t{SSN}\n" +
               $"Phone Number:\t{Phone.Number}\n" +
               $"Dependents:\t{_dependents.Count(s => s != null)}\n" +
               $"-----------------------------------\n";
    }

}