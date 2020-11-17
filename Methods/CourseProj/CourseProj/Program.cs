using System;

namespace CourseProj
{

   
    class Program
    {
        static string[] Pets(int numberOfPets)
        {
            string[] result = new string[numberOfPets];
            for (int i = 0; i < numberOfPets; i++)
            {
                Console.WriteLine("Введите имя питомца");
                result[i] = Console.ReadLine();
            }
            return result;
        }


        static string[] Colors(int numberOfColors)
        {
            string[] result = new string[numberOfColors];
            for (int i = 0; i < numberOfColors; i++) 
            {
                Console.WriteLine("Введите название цвета");
                result[i] = Console.ReadLine();
            }
            return result;
        }

        static bool RightInput(int value)
        {
            if (value == 0)
                return true;
            else
                return false;
        }

        
        static (string FirstName, string LastName, int Age, bool HasPet, string[] NamesOfPets, string[] FavoriteColors) Pars()
        {
            (string FirstName, string LastName, int Age, bool HasPet, string[] NamesOfPets, string[] FavoriteColors) User;
           
            Console.WriteLine("Введите имя");
            User.FirstName = Console.ReadLine();

            Console.WriteLine("Введите фамилю");
            User.LastName = Console.ReadLine();

            int age = new int();
            do
            {
                Console.WriteLine("Введите возраст");
                age = Convert.ToInt32(Console.ReadLine());
            } while (RightInput(age));
            User.Age = age;
            


            Console.WriteLine("Есть ли у вас питомец(ы)? 0 -да , 1 - нет");
            int hasPet = Convert.ToInt32(Console.ReadLine());


            if (hasPet == 0)
            {
                int numberOfPets = new int();
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                    numberOfPets = Convert.ToInt32(Console.ReadLine());
                } while (RightInput(numberOfPets));
                User.NamesOfPets = Pets(numberOfPets);
                User.HasPet = true;
                
            }
            else
            {
                User.HasPet = false;
                User.NamesOfPets = null;
            }

            int numberOfColors;
            do
            {
                Console.WriteLine("Введите количество любимых цветов");
                numberOfColors = Convert.ToInt32(Console.ReadLine());
            } while (RightInput(numberOfColors));
            
            User.FavoriteColors = Colors(numberOfColors);

            return User;
        }


        static void Main(string[] args)
        {
            var user = Pars();
            Console.WriteLine("Имя: {0}\nФамилия: {1}\nВозраст: {2}\nИмеет питомца: {3}", user.FirstName, user.LastName, user.Age, user.HasPet);
            if (user.HasPet)
            {
                for (int i = 0; i < user.NamesOfPets.Length; i++)
                    Console.WriteLine("Имя питомца {0}: {1} ", i + 1, user.NamesOfPets[i]);
            }

            for (int i = 0; i < user.FavoriteColors.Length; i++)
                Console.WriteLine("Цвет {0}: {1} ", i + 1, user.FavoriteColors[i]);
        }
    }
}
