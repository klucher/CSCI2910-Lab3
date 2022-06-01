using System.Text;

public class Phone
{
    public string Number
    {
        get; init;
    }

    public Phone()
    {
        Number = Format();
    }

    public string Format(char seperator = '-')
    {
        Random rand = new Random();
        var phoneString = new StringBuilder();

        phoneString.Append(rand.Next(2, 10));
        for (int i = 0; i < 9; i++)
        {
            phoneString.Append(rand.Next(0, 10));
        }

        string formattedString = phoneString.ToString();
        formattedString = formattedString.Insert(3, seperator.ToString());
        formattedString = formattedString.Insert(7, seperator.ToString());
        return formattedString;
    }
}