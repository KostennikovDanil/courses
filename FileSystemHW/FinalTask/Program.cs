
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }

    class Program
    {
        static void BinaryFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (var fs = new FileStream("Students.dat", FileMode.Open))
                {
                    var newStudents = (Student[])formatter.Deserialize(fs);
                    DirectoryInfo directoryInfo = new DirectoryInfo($@"{path}\Students");
                    if (!Directory.Exists($@"{path}\Students"))
                    {
                        Directory.CreateDirectory($@"{path}\Students");
                    }
                    Console.WriteLine(newStudents.Length);
                    foreach (var newStudent in newStudents)
                    {
                        using (var file = new StreamWriter($@"{path}\Students\{newStudent.Group}.txt", true))
                        {
                            file.WriteLine($"{newStudent.Name}, {newStudent.DateOfBirth}");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception");
            }
            
        }
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter path to DeskTop");
            string path = Console.ReadLine();
            BinaryFile(path);
        }
    }
}
