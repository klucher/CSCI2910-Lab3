using System.Text;

// invalid social security information - https://secure.ssa.gov/poms.nsf/lnx/0110201035
public class SSN
{
    // stores the invalid social security number
    public string Number
    {
        get; init;
    }

    public SSN()
    {
        // first 3 digits are "000", "666", or in the 900 series
        // middle 2 digits are "00"
        // last 4 digits are "0000"
        Random rand = new Random();
        int random900 = rand.Next(900, 1000);
        string nineHundredSeries = Convert.ToString(random900);

        string[] invalidFirstSetArray = { "000", "666", nineHundredSeries };
        string invalidSecondSet = "00";
        string invalidLastSet = "0000";

        int index = rand.Next(0, invalidFirstSetArray.Length);
        string invalidFirstSet = invalidFirstSetArray[index];

        string[] invalidOptionsArray = { invalidFirstSet, invalidSecondSet, invalidLastSet };
        int invalidIndex = rand.Next(0, invalidOptionsArray.Length);

        var ssnBuilder = new StringBuilder();

        switch (invalidIndex)
        {
            case 0:
                ssnBuilder.Append(invalidFirstSet);
                for (int i = 0; i < 6; i++)
                {
                    ssnBuilder.Append(rand.Next(0, 10));
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    ssnBuilder.Append(rand.Next(0, 10));
                }
                ssnBuilder.Append(invalidSecondSet);
                for (int i = 0; i < 4; i++)
                {
                    ssnBuilder.Append(rand.Next(0, 10));
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    ssnBuilder.Append(rand.Next(0, 10));
                }
                ssnBuilder.Append(invalidLastSet);
                break;
            default:
                Console.WriteLine("Invalid index in array selected.");
                break;
        }

        Number = ssnBuilder.ToString();
    }

    public override string ToString()
    {
        string formattedSSN = Number;
        formattedSSN = formattedSSN.Insert(3, "-");
        formattedSSN = formattedSSN.Insert(6, "-");
        return formattedSSN;
    }
}