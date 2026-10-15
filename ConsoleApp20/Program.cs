using System;
using System.IO;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n Блокнот ");
                Console.WriteLine("1. Открыть файл и показать");
                Console.WriteLine("2. Изменить файл");
                Console.WriteLine("3. Переименовать файл");
                Console.WriteLine("4. Переместить файл");
                Console.WriteLine("5. Создать новый файл");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowFile(); break;
                    case "2": EditFile(); break;
                    case "3": RenameFile(); break;
                    case "4": MoveFile(); break;
                    case "5": CreateFile(); break;
                    case "0": running = false; Console.WriteLine("Выход"); break;
                    default: Console.WriteLine("Неверный пункт."); break;
                }
            }
        }

        static string AskPath()
        {
            Console.Write("Введите путь к файлу: ");
            return Console.ReadLine();
        }

        static string ReadText()
        {
            Console.WriteLine("Введите текст, конец - enter");
            string result = "";
            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                if (line == "") break;
                if (result != "") result += "\n";
                result += line;
            }
            return result;
        }

        static void ShowFile()
        {
            string path = AskPath();

            if (File.Exists(path) == false)
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            Console.WriteLine("\n Содержимое ");
            Console.WriteLine(File.ReadAllText(path));
        }

        static void EditFile()
        {
            string path = AskPath();

            if (File.Exists(path) == false)
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            Console.WriteLine("1 - перезаписать, 2 - добавить в конец");
            string action = Console.ReadLine();
            string text = ReadText();

            if (action == "1")
            {
                File.WriteAllText(path, text);
                Console.WriteLine("Файл перезаписан.");
            }
            else if (action == "2")
            {
                File.AppendAllText(path, "\n" + text);
                Console.WriteLine("Текст добавлен.");
            }
        }

        static void RenameFile()
        {
            string path = AskPath();

            if (File.Exists(path) == false)
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            Console.Write("Новое имя файла: ");
            string newName = Console.ReadLine();

            string folder = Path.GetDirectoryName(path);
            string newPath = Path.Combine(folder, newName);

            File.Move(path, newPath);
            Console.WriteLine("Файл переименован.");
        }

        static void MoveFile()
        {
            string path = AskPath();

            if (File.Exists(path) == false)
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            Console.Write("Куда переместить: ");
            string folder = Console.ReadLine();

            string fileName = Path.GetFileName(path);
            string newPath = Path.Combine(folder, fileName);

            File.Move(path, newPath);
            Console.WriteLine("Файл перемещён.");
        }

        static void CreateFile()
        {
            Console.Write("Путь и имя нового файла: ");
            string path = Console.ReadLine();

            string text = ReadText();

            File.WriteAllText(path, text);
            Console.WriteLine("Файл создан.");
        }
    }
}