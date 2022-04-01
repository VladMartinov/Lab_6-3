using System;
using System.IO;
class Lab
{
    static void Main()
    {
        string path1 = @"C:\SomeDir4";
        string path2 = @"C:\SomeDir4\Testing1.dat";
        string path3 = @"C:\SomeDir4\Testing2.dat";
        int Number = 0;
        DirectoryInfo dirInfo = new DirectoryInfo(path1);
        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }
        using (FileStream fs = new FileStream(@"C:\SomeDir4\Testing1.dat", FileMode.OpenOrCreate))
        using (FileStream fs1 = new FileStream(@"C:\SomeDir4\Testing2.dat", FileMode.OpenOrCreate))
            fs.Close();
        
        using (StreamReader sw = new StreamReader(path2, System.Text.Encoding.Default))
        using (StreamWriter sw1 = new StreamWriter(path3, false, System.Text.Encoding.Default))
        {
            string line;
            while ((line = sw.ReadLine()) != null)//(sw.BaseStream.Position < sw.BaseStream.Length)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsUpper(line[i]))
                    {
                        Number++;
                    }
                }
                sw1.WriteLine(line.ToLower());
                
            }
        }
        Console.WriteLine($"Количество заглавных букв : {Number}");
    }
}