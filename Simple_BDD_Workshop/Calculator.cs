namespace Simple_BDD_Workshop;

public class Calculator
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public int Result { get; set; }

    public void Add()
    {
        Result = FirstNumber + SecondNumber;
    }
}