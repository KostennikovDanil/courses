using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


            while (true)
            {
                int input = Convert.ToInt32(Console.ReadLine());


                if (input < 1 || input > 3)
                {
                    Console.WriteLine("Страницы не существует");
                }

                else
                {
                    var pageContent = phoneBook.Skip((input - 1) * 2).Take(2).OrderBy(c=> c.Name).ThenBy(c=> c.LastName);

                    foreach (var contact in pageContent)
                    {
                        Console.WriteLine($"{contact.Name} {contact.LastName} {contact.PhoneNumber} {contact.Email}");
                    }

                }
             
            }

        }

    }


   
}
