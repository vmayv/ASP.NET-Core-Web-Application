using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork1
{
    class FileHandler
    {
        // можно добавить string path
        public void WriteToFileAndSave(string name, List<Post> posts)
        {
            if(File.Exists(name))
            {
                Console.WriteLine($"Файл с именем {name} уже существует. Работа завершена.");
                return;
            }

            else
            {
                StreamWriter streamWriter = new StreamWriter(name);
                foreach (var post in posts)
                {
                    streamWriter.WriteLine($"{post.UserId} \r\n{post.Id} \r\n{post.Title} \r\n{post.Body}\r\n");
                }
                streamWriter.Close();
                Console.WriteLine("Файл записан.");
            }
        }

    }
}
