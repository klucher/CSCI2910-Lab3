public class Dependent : Person
{
    public Dependent() : base()
    {
        Random rand = new Random();
        BirthDate = DateTime.Now.AddYears(rand.Next(11));
    }
}