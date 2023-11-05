using Project;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string optiune;

            Console.WriteLine("Menu");
            Console.WriteLine("1. Laborator1");
            Console.WriteLine("2. Laborator2");
            Console.WriteLine("3. Laborator3");
            Console.Write("Select an option: ");

            optiune = Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    Console.WriteLine("\nTastele functionale:\r\n" +
                            " ESC - Exit\r\n" +
                            " F11 - Fullscreen\r\n" +
                            " S - Modifica viewpoint-ul\r\n" +
                            " R - Reseteaza viewpoint-ul\r\n");
                    using (Laborator1 example = new Laborator1())
                    {
                        example.Run(30.0, 0.0);
                    }
                    break;
                case "2":
                  Console.WriteLine("\nTastele functionale:\r\n" +
                            " ESC - Exit\r\n" +
                            " F11 - Fullscreen\r\n" +
                            " S - Modifica viewpoint-ul\r\n" +
                            " R - Reseteaza viewpoint-ul\r\n");
                    using (Laborator2 example = new Laborator2())
                    {
                        example.Run(60.0, 0.0);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
