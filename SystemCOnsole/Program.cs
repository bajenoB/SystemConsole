using System;
using System.Diagnostics;
using System.IO;

namespace SystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = String.Empty;
            string choice = String.Empty;

            if (args?.Length > 0)
                Console.WriteLine("Test-Console");
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Введите путь: ");
            path = Console.ReadLine();

            FileInfo info = new FileInfo(path);
            do
            {
                if (path.Contains("\""))
                {
                    path = path.Replace("\"", " ");
                }
                if (info.Exists)
                {
                    try
                    {

                        Console.WriteLine($"Ваш путь - {path}\n");
                        Console.WriteLine($"Полное имя - {info.FullName}\nИмя - {info.Name}\nДиректория - {info.Directory}\nИмя директории - {info.DirectoryName}\n" +
                            $"Атрибуты - {info.Attributes}\nВремя создания - {info.CreationTime}\nТолько для чтения? - {info.IsReadOnly}\nРасширение? - {info.Extension}" +
                            $"\nПоследнее время доступа- {info.LastAccessTime}\n");

                        Console.WriteLine("Если хотите открыть введите  - Open");
                        choice = Console.ReadLine();
                        if (choice.ToLower() == "open")
                        {
                            try
                            {
                                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                        else
                        {
                            System.Threading.Thread.Sleep(3000);
                            Environment.Exit(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Не существует");
                }

            } while (choice.ToLower() != "open");


        }
    }
}