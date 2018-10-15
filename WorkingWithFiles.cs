using System;
using System.IO;

namespace CreateFile
{
    class Program
    {
        public static void Main()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName;
            string path;
            try
            {
                do
                {
                    Console.WriteLine("Enter new file name -");
                    fileName = Console.ReadLine();
                    path = Path.Combine(desktop, fileName);
                    
                    if(File.Exists(path))
                    {
                        Console.WriteLine("The file name already exists, do you want to reply it?");
                        string key = Console.ReadLine()
                        
                        if(key == "Yes")
                        {
                            File.Delete(path);
                        }
                    }
                }
                while(File.Exists(path))
                {
                    // Create the file
                    FileStream fs = File.Create(path);
                    fs.Close();
                    
                    // Write in file
                    Console.WriteLine("Write some text in your document");
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine(Console.ReadLine());
                    sw.Close();
                    
                    // Read from file
                    StreamReader sr = File.OpenText(path);
                    string textLine = sr.ReadLine();
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine(textLine);
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Process Failed" + ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
