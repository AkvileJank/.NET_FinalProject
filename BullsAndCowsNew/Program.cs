
namespace BullsAndCowsNew
{
    class Program
    {
        public static void Main(string[] args)
        {

            GameInstructions();

            Console.WriteLine("Enter difficulty level:");
            string difficulty = Console.ReadLine();
            difficulty = DifficultyInputCheck(difficulty);

            int arrayLength = ReturnDifficulty(difficulty);
            int[] randomNumber = new int[arrayLength];
            int totalBulls = arrayLength;
            int totalCows = arrayLength;
            int newNum = 0;
            CreateRandomArray(arrayLength, newNum, randomNumber);

            //this code is dummy just to see the random array
            Console.WriteLine("Array : ");
            Console.WriteLine(string.Join("", randomNumber));

            int counter = 0;
            bool notCorrect = true;
            while (notCorrect)
            {
                counter++;
                try
                {
                    Console.WriteLine("Enter your guess (separate each number with comma):");
                    string[] sYourGuess = Console.ReadLine().Split(",");
                    int[] iYourGuess = Array.ConvertAll(sYourGuess, s => Int32.Parse(s));
                    int bulls = CheckBulls(randomNumber, iYourGuess);
                    int cows = CheckCows(randomNumber, iYourGuess, bulls);

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

        public static string DifficultyInputCheck(string difficulty)
        {
            bool incorrectDifficultyInput = true;

            while (incorrectDifficultyInput)
            {
                if (ReturnDifficulty(difficulty) == -1)
                {
                    Console.WriteLine("Input is not valid. Please check again and enter correct letter for dificulty:");
                    difficulty = Console.ReadLine();
                }
                else
                    incorrectDifficultyInput = false;
            }
            return difficulty;
        }

        public static bool NotUniqueNumber(int[] randomNumbers, int randomGenerated)
        {
            foreach (int element in randomNumbers)
            {
                if (element == randomGenerated)
                {
                    return true;
                }
            }
            return false;
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

        public static void CreateRandomArray(int arrayLength, int newNum, int[] randomNumber)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                Random rRandomNum = new Random();

                //created newNum to check if it is not the same as previous numbers in array and only then add to array
                newNum = rRandomNum.Next(0, 10);

                while (NotUniqueNumber(randomNumber, newNum))
                {
                    newNum = rRandomNum.Next(0, 10);
                }

                randomNumber[i] = newNum;
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

        public static int CheckCows(int[] randomNumber, int[] yourGuess, int bulls)
        {
            int cows = 0;

            IEnumerable<int> numbersInBoth = randomNumber.Intersect(yourGuess);

            foreach (int i in numbersInBoth)
            {
                cows++;
            }
            // before if the number was bull, it was also counted as a cow
            return cows - bulls;
        }
    }
}


