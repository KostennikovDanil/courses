
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {

        [Serializable]
        class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Student (string name,string group,DateTime dateOfBirth)
            {
                Name = name;
                Group = group;
                DateOfBirth = dateOfBirth;
            }
        }
        static void BinaryFile(string path)
        {
            if(File.Exists(path))
            {
                string Name;
                string Group;
                DateTime DateOfBirth;

                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    Name = reader.ReadString();
                    //Group = reader.
                }

                foreach(var name in Name)
                {
                    Console.WriteLine(Name);
                }
                

            }
        }
        static void Main(string[] args)
        {
            //BinaryFile(@"C:\Users\Rio\Desktop\Students.dat");
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(@"C:\Users\Rio\Desktop\Students.dat", FileMode.Open))
            {
                var newStudent = (Student)formatter.Deserialize(fs);
                Console.WriteLine($"Name: {newStudent.Name}");
                Console.WriteLine($"Group: {newStudent.Group}");
                Console.WriteLine($"DateOfBirth: {newStudent.DateOfBirth}");
            }
        }
    }
}
