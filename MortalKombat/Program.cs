using System.Runtime.InteropServices;
using System.Text;
using MortalKombat.Factory;
using MortalKombat.Fighters;
using MortalKombat.Service;

namespace MortalKombat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            Arena arena = new Arena();
            arena.PrintStartMessage();

            Fighter player1 = arena.PickFighter();
            Fighter player2 = arena.PickFighter();

            int first = arena.FirstToGo();

            Console.ReadKey();
            Console.Clear();
            arena.PrintFormat(player1, player2);

            while (player1.HP > 0 && player2.HP > 0)
            {
                if (first == 1)
                {
                    Console.ReadKey();
                    player1.Hit(player2);
                    arena.PrintFormat(player1, player2);
                    if (player2.HP <= 0)
                    {
                        Console.WriteLine("\n\t\t\t FATALITY" +
                                          "\n\t\t\tFINISH HIM!");
                        arena.EndGame(player1, player2);
                        break;
                    }
                    

                    Console.ReadKey();
                    player2.Hit(player1);
                    arena.PrintFormat(player1, player2);
                    if (player1.HP <= 0)
                    {
                        Console.WriteLine("\n\t\t\t FATALITY" +
                                          "\n\t\t\tFINISH HIM!");
                        arena.EndGame(player1, player2);
                        break;
                    }
                } else
                {
                    Console.ReadKey();
                    player2.Hit(player1);
                    arena.PrintFormat(player1, player2);
                    if (player1.HP <= 0)
                    {
                        Console.WriteLine("\n\t\t\t FATALITY" +
                                          "\n\t\t\tFINISH HIM!");
                        arena.EndGame(player1, player2);
                        break;
                    }

                    Console.ReadKey();
                    player1.Hit(player2);
                    arena.PrintFormat(player1, player2);
                    if (player2.HP <= 0)
                    {
                        Console.WriteLine("\n\t\t\t FATALITY" +
                                          "\n\t\t\tFINISH HIM!");
                        arena.EndGame(player1, player2);
                        break;
                    }
                }
            }
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Exception caught by handler: {e.ExceptionObject}");
        }



    }
}