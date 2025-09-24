using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();

        while (true)
        {
            Console.WriteLine("Enter a list of number, type 0 when finished.");
            string input = Console.ReadLine();
            int Addnumber = int.Parse(input);

            if (Addnumber == 0)
            {
                break;
            }
            numberList.Add(Addnumber);
            Console.WriteLine($"Added number {Addnumber}");

        }
        int sum = numberList.Sum();
            float avg;
            if (numberList.Count > 0)
            {
                avg = (float)sum / numberList.Count;
            }
            else
            {
                avg = 0f;
            }
        Console.WriteLine($"The Sum of your numbers is {sum}");
        Console.WriteLine($"The Average of your numbers is {avg}");
    }
}