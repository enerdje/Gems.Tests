using System;
using System.IO;

namespace QuadEq
{
    public class Program
    {
        static void Main()
        {
            #region Чтение из файла
            string s = "============================================";
            string path = Directory.GetCurrentDirectory() + @"\Tests.txt";
            if (File.Exists(path))
            {
                Console.WriteLine($"Вид квадратного уравнения: ax^2 + bx + c = 0\n{s}");
                using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                string inputLine;
                while ((inputLine = sr.ReadLine()) != null)
                {
                    if (CorrectWrite(inputLine, out double a, out double b, out double c))
                        Solution(a, b, c);
                    else Console.WriteLine($"Некорректная строка: {inputLine}\n{s}");
                }
            }
            else { Console.WriteLine("Создайте в папке с программой файл Tests.txt\nВведите в файл значения в формате \"4 7,4 2\"."); }
            #endregion
            #region Ручной ввод
            while (true)
            {
                Console.Write("Введите коэффициенты в формарте \"4 5,5 7\":");
                if (CorrectWrite(Console.ReadLine(), out double a, out double b, out double c))
                {
                    Solution(a, b, c);
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            #endregion
        }
        public static bool CorrectWrite(string input, out double a, out double b, out double c)
        {
            string[] x = input.Split();
            if (x.Length != 3 || !double.TryParse(x[0], out _) || !double.TryParse(x[1], out _)
                              || !double.TryParse(x[2], out _) || double.Parse(x[0]) == 0)
            {
                a = 0; b = 0; c = 0;
                return false;
            }
            else
            {
                a = double.Parse(x[0]); b = double.Parse(x[1]); c = double.Parse(x[2]);
                return true;
            }
        }
        public static bool Solution(double a, double b, double c)
        {
            double D = b * b - 4 * a * c;
            Console.WriteLine($"Считано на входе: ({a}) ({b}) ({c})");
            Console.WriteLine($"Составлено уравнение: {a}x^2 + {b}x + {c} = 0");
            Console.WriteLine($"Дискриминант равен: {D}");
            switch (D)
            {
                case double d when d > 0:
                    Console.WriteLine($"Первый корень равен: {((-b - Math.Sqrt(D)) / (2 * a))}\n" +
                                      $"Второй корень равен: {((-b + Math.Sqrt(D)) / (2 * a))}");
                    break;
                case double d when d == 0:
                    Console.WriteLine($"Корень равен: {(-b / (2 * a))}");
                    break;
                case double d when d < 0:
                    Console.WriteLine("Уравнение не имеет действительных решений.");
                    break;
            }
            Console.WriteLine("============================================");
            return (a == 0) ? false : true;
        }

        //Перегруженый метод для сверки значений.
        public static string Solution(double a, double b, double c, int _)
        {
            if (a != 0)
            {
                double D = b * b - 4 * a * c;
                switch (D)
                {
                    case double d when d > 0:
                        return $"{((-b - Math.Sqrt(D)) / (2 * a))} {((-b + Math.Sqrt(D)) / (2 * a))}";
                    case double d when d == 0:
                        return $"{(-b / (2 * a))}";
                    case double d when d < 0:
                        return "Уравнение не имеет действительных решений.";
                }
                return "";
            }
            else { return "Ошибка. Первый коэф. не может быть 0."; }
        }
    }
}