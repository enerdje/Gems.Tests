using System;
using System.IO;

namespace QuadEq
{
    public class Program
    {
        public static readonly string s = "================================================================\n";
        static void Main()
        {
            string path = Directory.GetCurrentDirectory() + @"\Tests.txt";

            while (true)
            {
                Console.WriteLine($"{s}Вид квадратного уравнения: ax^2 + bx + c = 0");
                Console.Write($"Выберите режим ввода (1-чтение из файла; 2-ручной ввод):");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    switch (value)
                    {
                        #region Чтение из файла
                        case 1:
                            if (File.Exists(path))
                            {
                                using StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                                string inputLine;
                                while ((inputLine = sr.ReadLine()) != null)
                                {
                                    Solution(inputLine);
                                }
                            }
                            else { Console.WriteLine("В папке со сборкой не обнаружен файл Tests.txt."); }
                            break;
                        #endregion
                        #region Ручной ввод
                        case 2:
                            Console.Write($"{s}Введите коэффициенты в формарте \"A B C\":");
                            Solution(Console.ReadLine());
                            Console.WriteLine($"{s}Для продолжения нажмите любую клавишу.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        #endregion
                        default:
                            Console.WriteLine("Ошибка! Доступно только две режима (1 или 2).");
                            break;
                    }
                }
                else Console.WriteLine($"{s}Ошибка! Вы ввели не число.");
            }
        }
        //gfdgfdgdfgdfgfd
        public static string Solution(string input)
        {
            try
            {
                InputValidation(input, out double a, out double b, out double c);
                double D = b * b - 4 * a * c;
                Console.WriteLine($"{s}Считано на входе: ({a}) ({b}) ({c})");
                Console.WriteLine($"Составлено уравнение: {a}x^2 + {b}x + {c} = 0");
                Console.WriteLine($"Дискриминант равен: {D}");
                return D switch
                {
                    double d when d > 0 => $"{((-b - Math.Sqrt(D)) / (2 * a))} {((-b + Math.Sqrt(D)) / (2 * a))}",
                    double d when d == 0 => $"{(-b / (2 * a))}",
                    double d when d < 0 => "Уравнение не имеет действительных решений.",
                    _ => "",
                };
            }
            catch (Exception e)
            {
                return $"{s}Ошибка: {e.Message}";
            }
        }

        public static bool InputValidation(string input, out double a, out double b, out double c)
        {
            string[] values = input.Split();
            if (!double.TryParse(values[0], out _) || !double.TryParse(values[1], out _) || !double.TryParse(values[2], out _))
            {
                throw new Exception($"Входной/ые параметры  не являются числом! Строка: {input}");
            }
            if (values.Length != 3)
            {
                throw new Exception($"Входных параметров должно быть 3! Строка: {input}");
            }
            if (double.Parse(values[0]) == 0)
            {
                throw new Exception($"Входной коэффициент \"A\" не может быть 0! Строка: {input}");
            }
            a = double.Parse(values[0]); b = double.Parse(values[1]); c = double.Parse(values[2]);
            return true;
        }
    }
}