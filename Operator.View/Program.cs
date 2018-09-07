using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operators.Service;
using Operators.Service.Model;
namespace Operator.View
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operators.Service.Model.Operator op =
            //    new Operators.Service.Model.Operator();

            //op.Name = "Kcell";
            //op.Logo = "data:image/jpeg;base64,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";
            //op.Percent = 10.3;
            //op.Prefixes.Add(777);
            //op.Prefixes.Add(705);

            //Service service =
            //    new Service("Test.xml");

            //if (service.CreateOperator(op))
            //{
            //    Console.WriteLine("Operator created successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Operator didn't created");
            //}

            //User user = new User();
            //user.FullName = "John Smith";
            //user.Login = "JSmith";
            //user.Password = "123456";

            //ServiceUser service =
            //    new ServiceUser("User.xml");
            //service.Registration(user);

            //User user1 =
            //service.LogOn(Console.ReadLine(), Console.ReadLine());

            //if (user1 != null)
            //{
            //    Console.Clear();
            //    Console.WriteLine($"Hello {user1.FullName}");
            //}
            //else
            //{
            //    Console.WriteLine("Wrong login and password");
            //}
            Menu();

        }

        public static void Menu()
        {
            bool inProgress = true;
            while (inProgress)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\t\tВыберите пункт меню:");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("1. Создать оператора");
                Console.WriteLine("2. Зарегистрироваться");
                Console.WriteLine("3. Найти пользователя");
                Console.WriteLine("4. Выход");
                Console.ForegroundColor = color;

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t1. Создать оператора");
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine(new string('-', 50));
                            Operators.Service.Model.Operator op =
                 new Operators.Service.Model.Operator();

                            op.Name = "Kcell";
                            op.Logo = "data:image/jpeg;base64,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";
                            op.Percent = 10.3;
                            op.Prefixes.Add(777);
                            op.Prefixes.Add(705);

                            Service service =
                                new Service("Test.xml");

                            if (service.CreateOperator(op))
                            {
                                Console.WriteLine("Operator created successfully");
                            }
                            else
                            {
                                Console.WriteLine("Operator didn't created");
                            }


                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t2. Зарегистрироваться");
                            Console.WriteLine(new string('-', 50));

                            User user = new User();

                            Console.Write("Введите имя и фамилию: ");
                            user.FullName = Console.ReadLine();
                            Console.Write("Введите логин: ");
                            user.Login = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            user.Password = Console.ReadLine();
                            //user.FullName = "John Smith";
                            //user.Login = "JSmith";
                            //user.Password = "123456";

                            ServiceUser service =
                                new ServiceUser("User.xml");
                            service.Registration(user);

                            //Console.WriteLine("");

                            //User user1 =
                            //service.LogOn(Console.ReadLine(), Console.ReadLine());

                            //if (user1 != null)
                            //{
                            //    Console.Clear();
                            //    Console.WriteLine($"Hello {user1.FullName}");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Wrong login and password");
                            //}

                        }
                        break;
                        
                    case 3:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t3. Найти пользовател");
                            Console.WriteLine(new string('-', 50));
                            ServiceUser service =
                                new ServiceUser("User.xml");
                            Console.WriteLine("Введите логин и пароль: ");
                            User user1 =
                            service.LogOn(Console.ReadLine(), Console.ReadLine());

                            if (user1 != null)
                            {
                                Console.Clear();
                                Console.WriteLine($"Hello {user1.FullName}");
                            }
                            else
                            {
                                Console.WriteLine("Wrong login and password");
                            }


                        }
                        break;
                    case 4:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t6. Выход");
                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Спасибо!");
                            Console.ForegroundColor = color;
                            inProgress = false;
                            Console.WriteLine(new string('-', 50));
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Выберите пункт меню");
                        }
                        break;
                }
            }
        }
    }
}
