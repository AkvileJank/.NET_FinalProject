
namespace BullsAndCowsNew
{
    class Program
    {
        public static void Main(string[] args)
        {

            GameInstructions();

            Console.WriteLine("Enter difficulty level:");
            string difficultyInput = Console.ReadLine();
            difficultyInput = DifficultyInputCheck(difficultyInput);

            int arrayLength = ReturnDifficulty(difficultyInput);
            int[] randomGeneratedNumbers = new int[arrayLength];
            int totalBulls = arrayLength;
            int totalCows = arrayLength;
            int numberToCheck = 0;
            CreateRandomArray(arrayLength, numberToCheck, randomGeneratedNumbers);

            int counter = 0;
            bool notCorrect = true;

            while (notCorrect)
            {
                counter++;
                try
                {
                    Console.WriteLine("Enter your guess (separate each number with comma):");
                    string[] UserGuess = Console.ReadLine().Split(",");
                    int[] UserGuessConvertedToInt = Array.ConvertAll(UserGuess, s => Int32.Parse(s));
                    int bulls = CheckBulls(randomGeneratedNumbers, UserGuessConvertedToInt);
                    int cows = CheckCows(randomGeneratedNumbers, UserGuessConvertedToInt, bulls);

                    if (bulls == totalBulls)
                    {
                        notCorrect = false;
                        break;
                    }

                    Console.WriteLine(bulls + " Bull(s)");
                    Console.WriteLine(cows + " Cow(s)");
                }
                catch
                {
                    Console.WriteLine("Input is not correct.");
                }
            }

            Console.WriteLine("Congratulations! You won!");
            Console.WriteLine("It took you " + counter + " attempt(s)!");
        }

        public static void GameInstructions()
        {
            Console.WriteLine("Welcome to Bulls And Cows!" + "\n" + "Your goal is to guess a combination of unique numbers (all numbers are different)." +
               "\n" + "Hint meanings:" + "\n" + "Bull - amount of numbers guessed in a correct position;" + "\n" +
               "Cow - amount of numbers guessed correctly but in a wrong position" + "\n");
            Console.WriteLine("Difficulty levels: E - easy (3 numbers), M - medium (4 numbers), H - hard (5 numbers)");
        }

        public static string DifficultyInputCheck(string difficultyInput)
        {
            bool incorrectDifficultyInput = true;

            while (incorrectDifficultyInput)
            {
                if (ReturnDifficulty(difficultyInput) == -1)
                {
                    Console.WriteLine("Input is not valid. Please check again and enter correct letter for difficulty:");
                    difficultyInput = Console.ReadLine();
                }
                else
                    incorrectDifficultyInput = false;
            }
            return difficultyInput;
        }

        public static bool NotUniqueNumber(int[] randomGeneratedNumbers, int numberToCheck)
        {
            foreach (int element in randomGeneratedNumbers)
            {
                if (element == numberToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public static int ReturnDifficulty(string difficultyInput)
        {

            switch (difficultyInput)
            {
                case "E":
                    return 3;
                case "M":
                    return 4;
                case "H":
                    return 5;
                default:
                    return -1;
            }
        }

        public static void CreateRandomArray(int arrayLength, int numberToCheck, int[] randomGeneratedNumbers)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                Random rRandomNum = new Random();

                numberToCheck = rRandomNum.Next(0, 10);

                while (NotUniqueNumber(randomGeneratedNumbers, numberToCheck))
                {
                    numberToCheck = rRandomNum.Next(0, 10);
                }

                randomGeneratedNumbers[i] = numberToCheck;
            }
        }
        public static int CheckBulls(int[] randomGeneratedNumbers, int[] UserGuessConvertedToInt)
        {
            int bulls = 0;
            for (int i = 0; i < randomGeneratedNumbers.Length; i++)
            {
                if (randomGeneratedNumbers[i] == UserGuessConvertedToInt[i])
                    bulls++;
            }

            return bulls;
        }

        public static int CheckCows(int[] randomGeneratedNumbers, int[] UserGuessConvertedToInt, int bulls)
        {
            int cows = 0;

            IEnumerable<int> numbersInBoth = randomGeneratedNumbers.Intersect(UserGuessConvertedToInt);

            foreach (int i in numbersInBoth)
            {
                cows++;
            }
            return cows - bulls;
        }
    }
}


