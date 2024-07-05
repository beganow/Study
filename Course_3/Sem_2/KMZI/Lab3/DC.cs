using System;
using System.IO;
using System.Text;

namespace DocumentConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Проверка наличия аргументов командной строки
            if (args.Length < 2)
            {
                Console.WriteLine("Не указан входной файл или текстовая строка, или выходной файл.");
                return;
            }

            string input = args[0]; // Входной файл или текстовая строка
            string output = args[1]; // Выходной файл

            string base64Output = ConvertToBase64(input);

            // Запись результата в выходной файл
            File.WriteAllText(output, base64Output);

            Console.WriteLine("Конвертация завершена. Результат записан в файл: " + output);
        }

        static string ConvertToBase64(string input)
        {
            if (File.Exists(input))
            {
                // Если указан путь к существующему файлу

                // Определение расширения файла
                string extension = Path.GetExtension(input).ToLower();

                // Чтение содержимого файла в зависимости от его расширения
                byte[] fileBytes;
                if (extension == ".txt")
                {
                    fileBytes = File.ReadAllBytes(input);
                }
                else if (extension == ".doc" || extension == ".docx" || extension == ".ppt" || extension == ".pptx" || extension == ".pdf" || extension == ".zip" || extension == ".rar" || extension == ".7z")
                {
                    // Преобразование документов в бинарный формат
                    using (FileStream fs = new FileStream(input, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            fileBytes = br.ReadBytes((int)fs.Length);
                        }
                    }
                }
                else
                {
                    throw new NotSupportedException("Формат файла не поддерживается.");
                }

                return Convert.ToBase64String(fileBytes);
            }
            else
            {
                // Если передана текстовая строка
                byte[] textBytes = Encoding.UTF8.GetBytes(input);
                return Convert.ToBase64String(textBytes);
            }
        }
    }
}