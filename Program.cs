using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Менеджер файлов ===");
            Console.WriteLine("1. Показать файлы в папке");
            Console.WriteLine("2. Создать файл");
            Console.WriteLine("3. Удалить файл");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowFiles();
                    break;
                case "2":
                    CreateFile();
                    break;
                case "3":
                    DeleteFile();
                    break;
                default:
                    Console.WriteLine("Выход...");
                    break;
            }
        }

        static void ShowFiles()
        {
            string path = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(path);
            Console.WriteLine($"\nФайлы в папке {path}:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        static void CreateFile()
        {
            Console.Write("Введите имя файла (например, test.txt): ");
            string name = Console.ReadLine();
            if (File.Exists(name))
            {
                Console.WriteLine("Файл уже существует!");
                return;
            }
            File.WriteAllText(name, "Привет, мир!");
            Console.WriteLine("Файл успешно создан!");
        }

        static void DeleteFile()
        {
            Console.Write("Введите имя файла для удаления: ");
            string name = Console.ReadLine();
            if (File.Exists(name))
            {
                File.Delete(name);
                Console.WriteLine("Файл удален!");
            }
            else
            {
                Console.WriteLine("Файл не найден!");
            }
        }
    }
}
