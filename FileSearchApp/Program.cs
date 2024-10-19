using System;
using System.IO;
using System.IO.Compression;

namespace FileSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к папке для поиска: ");
            string path = Console.ReadLine();

            Console.Write("Введите имя файла для поиска: ");
            string filename = Console.ReadLine();

            // Поиск файла
            string filePath = FindFile(path, filename);

            if (!string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine($"Файл найден: {filePath}");

                // Вывод содержимого файла
                Console.WriteLine("Содержимое файла:");
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fs))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }

                // Сжатие файла
                Console.Write("Хотите сжать файл? (да/нет): ");
                string compressResponse = Console.ReadLine();

                if (compressResponse.Equals("да", StringComparison.OrdinalIgnoreCase))
                {
                    string compressedFilePath = filePath + ".gz";
                    using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open))
                    using (FileStream compressedFileStream = File.Create(compressedFilePath))
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                    Console.WriteLine($"Файл сжат и сохранён как: {compressedFilePath}");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        static string FindFile(string path, string filename)
        {
            try
            {
                foreach (var file in Directory.GetFiles(path, filename, SearchOption.AllDirectories))
                {
                    return file; // Возвращаем первый найденный файл
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске: {ex.Message}");
            }
            return null;
        }
    }
}
