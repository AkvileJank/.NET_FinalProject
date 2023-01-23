class Programm
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter dificulty:");
        Console.WriteLine("E - easy (3 numbers), M - medium (4 numbers), H - hard (5 numbers)");
        string difficulty = Console.ReadLine();
        int arrayLength = ReturnDifficulty(difficulty);
        int[] randomNumber = new int[arrayLength];
        int totalBulls = arrayLength;
        int totalCows = arrayLength;

        for (int i = 0; i < arrayLength; i++)
        {
            Random rRandomNum = new Random();
            randomNumber[i] = rRandomNum.Next(0, 10);
        }
        
        //this code is dummy just to see the random array
        Console.WriteLine("Array : ");
        Console.WriteLine(string.Join("", randomNumber));

        bool notCorrect = true;

        while (notCorrect)
        {
            Console.WriteLine("Enter your guess (separate each number with comma):");
            string[] sYourGuess = Console.ReadLine().Split(",");
            int[] iYourGuess = Array.ConvertAll(sYourGuess, s => Int32.Parse(s));

            int bulls = CheckBulls(randomNumber, iYourGuess);
            Console.WriteLine("Total amount of bulls is : " + bulls);

            int cows = CheckCows(randomNumber, iYourGuess);
            Console.WriteLine("Total amount of cows is : " + cows);

            if (bulls == totalBulls)
                notCorrect = false;

        }

        Console.WriteLine("Congratulations! You won!");


    }

    public static int ReturnDifficulty(string difficulty)
    {
        
        switch (difficulty)
        {
            case "E":
                return 3;
                break;
            case "M":
                return 4;
                break;
            case "H":
                return 5;
                break;
            default:
                return -1;
                break;                
        }
    }

    public static int CheckBulls(int[] randomNumber, int[] yourGuess)
    {
        int bulls = 0;
        for (int i = 0; i < randomNumber.Length; i++)
        {
            if (randomNumber[i] == yourGuess[i])
                bulls++;
        }

        return bulls;
    }

    public static int CheckCows(int[] randomNumber, int[] yourGuess)
    {
        int cows = 0;
        
        IEnumerable<int> numbersInBoth = randomNumber.Intersect(yourGuess);
        foreach (int i in numbersInBoth)
        {
            cows++;
        }

        return cows;
    }
}
