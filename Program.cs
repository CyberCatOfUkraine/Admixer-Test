namespace ConsoleApp1
{
    internal class Program
    {
        /* В лісі живе популяція їжаків. 
         * Їжачки тут можуть бути лише одного з трьох кольорів - червоного, зеленого та синього. 
         * 
         * Коли зустрічаються два їжачки різних кольорів, вони
         * можуть змінити свій колір на третій (тобто, коли зустрічаються червоний і синій їжачок, вони
         * обидва можуть стати зеленими). Іншого способу змінити свій колір у їжаків немає (зокрема,
         * коли зустрічаються червоний і синій їжачок, вони не можуть стати обоє червоними, можна
         * припустити лише третій колір).
         * 
         * Їжачки хочуть стати одного певного кольору. 
         * Вони можуть планувати свої зустрічі, щоб досягти цієї мети.
         * 
         * Їжачки хочуть знати, як швидко можна досягти своєї мети (якщо її взагалі
         * можна досягнути).
         * 
         * Вхідні дані:
         * Колір задано цілим числом, 0 - червоний, 1 - зелений, 2 - синій. 
         * 
         * Початкова популяція їжаків задана у вигляді масиву з трьох цілих чисел з індексом, що відповідає кольору (тобто [8, 1, 9] означає 8 червоних, 1 зелених і 9 синіх їжачка). 
         * 
         * Всі числа невід'ємні, їх сума знаходиться між 1 та int.MaxValue (максимально можливе значення для типу int, іншими мовами).
         * 
         * Бажаний колір задається цілим числом від 0 до 2.
         * 
         * Виведіть:
         * Код повинен повернути мінімальну кількість зустрічей, необхідних для зміни всіх їжачків у
         * заданий колір, або -1, якщо це неможливо (наприклад, якщо всі їжачки спочатку одного
         * кольору).
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Увага!");
            Console.WriteLine("0 - червоний, 1 - зелений, 2 - синій.");
            Console.WriteLine("[8, 1, 9] означає 8 червоних, 1 зелених і 9 синіх їжачка");
            Console.WriteLine("Допустимо що змінити колір може лише пара їжачків на одній зустрічі а не більша їх кількість");
            Console.WriteLine();

            //Тест1
            int[] population1 = { 3, 4, 5 };
            int targetColor1 = 1;
            int expected1 = -1;

            //Тест2
            int[] population2 = { 8, 0, 0 };
            int targetColor2 = 0;
            int expected2 = -1;

            //Тест3
            int[] population3 = { 5, 5, 5 };
            int targetColor3 = 2;
            int expected3 = -1;

            //Тест4
            int[] population4 = { 1, 1, 1 };
            int targetColor4 = 1;
            int expected4 = 1;

            //Тест5
            int[] population5 = { 7, 5, 7 };
            int targetColor5 = 1;
            int expected5 = 7;

            //Тест6
            int[] population6 = { 0, 0, 10 };
            int targetColor6 = 2;
            int expected6 = -1;


            WriteTest(population1, targetColor1, expected1);
            WriteTest(population2, targetColor2, expected2);
            WriteTest(population3, targetColor3, expected3);
            WriteTest(population4, targetColor4, expected4);
            WriteTest(population5, targetColor5, expected5);
            WriteTest(population6, targetColor6, expected6);
        }
        private static int _testCount = 1;
        private static void WriteTest(int[] population, int targetColor, int expected)
        {
            var targetColorName = targetColor switch
            {
                0 => "Червоний",
                1 => "Зелений",
                2 => "Синій",
                _ => "Невідомий колір"
            };

            Console.WriteLine();
            Console.WriteLine("Тест №{0}", _testCount);
            Console.WriteLine();
            Console.WriteLine("[{0},{1},{2}] : {3}", population[0], population[1], population[2], targetColorName);
            Console.WriteLine("Expected: {0}", expected);
            Console.WriteLine("Actual:   {0}", MinimumMeetings(population, targetColor));
            Console.WriteLine();

            _testCount++;
        }
        private static int MinimumMeetings(int[] population, int desiredColor)
        {

            // 0 - червоний, 1 - зелений, 2 - синій. 

            //Перевірка на допустимість бажаного для популяції кольору
            int desiredColorMax = 2;
            if (desiredColor > desiredColorMax || desiredColor < 0)
            {
                throw new Exception("Невідомий бажаний колір для їжачків");
            }
            //Перевірка рамок популяції їжачків
            int populationLimit = 3;
            if (population.Length > populationLimit || population.Length < 0)
            {
                throw new Exception("В вашій популяції невірна кількість їжачків (кольорових)");
            }

            // Перевірка, чи всі їжачки вже мають бажаний колір
            if (population[desiredColor] == population.Sum())
                return -1;

            //Перевірка , чи немає від'ємної кількості їжачків
            for (int i = 0; i < population.Length; i++)
            {
                if (population[i] < 0)
                {
                    throw new Exception("В вашій популяції від'ємна кількість їжачків");
                }
            }

            //Перевірити чи існує мінімальна кількість зустрічей за які їжачки можуть змінити свій колір
            int minMeetingsCount;

            var redColor = 0;
            var greenColor = 1;
            var blueColor = 2;
            if (desiredColor == greenColor)
            {
                if (population[redColor] == population[blueColor])
                {
                    minMeetingsCount = population[redColor];
                }
                else
                {
                    minMeetingsCount = -1;
                }
            }
            else
            {
                minMeetingsCount = -1;
            }
            return minMeetingsCount;
        }
    }
}