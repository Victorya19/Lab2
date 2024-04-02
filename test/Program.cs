// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
class Program
{
    static void Main()
    {
        Random rand = new Random();
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("0. Выход из программы");
            Console.WriteLine("1. Возведение в степень по модулю");
            Console.WriteLine("2. Вычисление наибольшего общего делителя");
            Console.WriteLine("3. Вычисление мультипликативной инверсии");
            Console.WriteLine("4. Проверка чисел на простоту");
            Console.WriteLine("5. Генерация больших простых чисел");

            int choice;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Возведение в степень по модулю a^x(mod m)");

                        int a;
                        while (true)
                        {
                            Console.Write("Введите число (а): ");
                            if (int.TryParse(Console.ReadLine(), out a))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
                        }

                        int x;
                        while (true)
                        {
                            Console.Write("Введите степень (x): ");
                            if (int.TryParse(Console.ReadLine(), out x))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
                        }

                        int m;
                        while (true)
                        {
                            Console.Write("Введите модуль (m): ");
                            if (int.TryParse(Console.ReadLine(), out m))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
                        }

                        int result = ModuloExponentiation(a, x, m);
                        Console.WriteLine($"Результат: {result}");
                        break;

                    case 2:
                        Console.WriteLine("Вычисление наибольшего общего делителя (НОД(a, b))");

                        int num1;
                        while (true)
                        {
                            Console.Write("Введите число a: ");
                            if (int.TryParse(Console.ReadLine(), out num1))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
                        }

                        int num2;
                        while (true)
                        {
                            Console.Write("Введите число b: ");
                            if (int.TryParse(Console.ReadLine(), out num2))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");


                            int gcd = GCD(num1, num2);
                            Console.WriteLine($"Наибольший общий делитель: {gcd}");
                            break;
                        } // Ошибка: Неправильно закрытый внутренний while

                    case 3:
                        Console.WriteLine("Вычисление мультипликативной инверсии (x^(-1) mod m)");
                        int number;
                        while (true)
                        {
                            Console.Write("Введите число (x): ");
                            if (int.TryParse(Console.ReadLine(), out number))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
                        }

                        int modulo;
                        while (true)
                        {
                            Console.Write("Введите модуль (m): ");
                            if (int.TryParse(Console.ReadLine(), out modulo) && modulo != 0)
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное ненулевое число.");
                        }

                        int multiplicativeInverse = MultiplicativeInverse(number, modulo);
                        Console.WriteLine($"Мультипликативная инверсия: {multiplicativeInverse}");
                        break;

                    case 4:
                        Console.WriteLine("Проверки чисел на простоту (тест Ферма, тест Миллера-Рабина);");

                        int testNumber;
                        while (true)
                        {
                            Console.Write("Введите число для проверки на простоту: ");
                            if (int.TryParse(Console.ReadLine(), out testNumber) && testNumber > 2)
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число больше 2.");
                        }

                        bool isPrime = CheckFermatPrimality(testNumber);
                        bool Prime = CheckMillerRabinPrimality(testNumber);
                        Console.WriteLine($" По тесту Ферма число {testNumber} является : {(isPrime ? "простым" : "составным")}");
                        Console.WriteLine($" По тесту Миллера-Рабина число {testNumber} является : {(Prime ? "простым" : "составным")}");

                        break;

                    case 5:
                        Console.WriteLine("Генерации больших простых чисел.");
                        int count;
                        while (true)
                        {
                            Console.WriteLine("Введите необходимое количество простых чисел:");
                            if (int.TryParse(Console.ReadLine(), out count))
                                break;
                            else
                                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное значение.");
                        }
                        GeneratePrimes(rand, count);
                        Console.WriteLine("Сгенерированные простые числа:" + count);
                        break;

                    case 0:
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 0 до 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
            }

            Console.ReadKey();
        }
    }

    static int ModuloExponentiation(int a, int x, int m)
    {
        if (m == 1) return 0;
        int result = 1;
        a = a % m;

        while (x > 0)
        {
            if ((x & 1) == 1)
                result = (result * a) % m;
            x = x >> 1;
            a = (a * a) % m;
        }

        return result;
    }
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;

            a = temp;
        }
        return a;
    }
    static int MultiplicativeInverse(int a, int m)
    {
        int m0 = m;
        int y = 0, x = 1;

        if (m == 1)
            return 0;

        while (a > 1)
        {
            int q = a / m;
            int t = m;

            m = a % m;
            a = t;
            t = y;

            y = x - q * y;
            x = t;
        }

        if (x < 0)
            x += m0;

        return x;
    }

    static bool CheckFermatPrimality(int n)
    {
        Random random = new Random();
        if (n <= 1)
            return false;

        // Выбираем случайное число a в диапазоне [2, n - 2]
        int a = random.Next(2, n - 1);

        // Вычисляем a^(n-1) mod n
        int result = ModuloExponentiation(a, n - 1, n);

        // Если результат не равен 1, то число n не является простым
        return result == 1;
    }

    static bool CheckMillerRabinPrimality(int n)
    {
        if (n <= 1)
            return false;

        int k = 5; // Количество итераций теста Миллера-Рабина
        for (int i = 0; i < k; i+)
        {
            if (!MillerRabinTest(n))
                return false;
        }

        return true;
    }

    static bool MillerRabinTest(int n)
    {
        Random random = new Random();
        int a = random.Next(2, n - 2);

        int d = n - 1;
        int r = 0;
        while (d % 2 == 0)
        {
            d /= 2;
            r++;
        }

        int x = ModuloExponentiation(a, d, n);
        if (x == 1 || x == n - 1)
            return true;

        for (int i = 0; i < r - 1; i++)
        {
            x = ModuloExponentiation(x, 2, n);
            if (x == n - 1)
                return true;
        }

        return false;
    }
    static void GeneratePrimes(Random rand, int count)
    {
        Console.WriteLine($"Сгенерированные простые числа ({count} шт.):");
        for (int i = 0; i < count; i++)
        {
            int prime = GenerateRandomPrime(rand, 1000, 10000);
            Console.WriteLine(prime);
        }
    }

    static int GenerateRandomPrime(Random rand, int min, int max)
    {
        while (true)
        {
            int num = rand.Next(min, min);
            bool isProbablyPrime = CheckMillerRabinPrimality(num);
            if (isProbablyPrime)
            {
                return num;
            }
        }
    }
}

