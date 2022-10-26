using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortalKombat.Fighters;

namespace MortalKombat
{
    internal class Helper
    {
        public void PrintStartMessage()
        {
            Console.WriteLine("\t\t\t\t\t\tWelcome To The Arena!");
            Console.WriteLine("\t\t\t\t\t\t Choose Your FIGHTER!");

            Console.WriteLine("\nFor Bruiser - Press \"B\", For Mage - Press \"M\", For Assassin - Press \"A\"");
        }
        public void PrintFormat(Fighter fighter1, Fighter fighter2)
        {
            string format = "{0,-25} {1,30}" + Environment.NewLine;
            var stringBuilder = new StringBuilder().AppendFormat(format, "Player1 - " + fighter1.GetType().Name, 
                                                                         "Player2 - " + fighter2.GetType().Name);
            format = "{0,10} {1,40}" + Environment.NewLine;

            if (fighter1.HP <= 0)
            {
                fighter1.HP = 0;
                stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
                Console.WriteLine(stringBuilder.ToString());
            } else if (fighter2.HP <= 0)
            {
                fighter2.HP = 0;
                stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
                Console.WriteLine(stringBuilder.ToString());
            } else
            {
                stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
                Console.WriteLine(stringBuilder.ToString());
                Console.WriteLine("...................................................................\n" +
                                  "...................................................................");
            }
        }
        public int FirstToGo()
        {
            Random rand = new Random();
            var r = rand.Next(1, 100);
            return r%2 + 1;
        }

        public void EndGame(Fighter fighter1, Fighter fighter2)
        {
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\t\t\tFINISH HIM!\n");

            Fighter winner, loser;

            if (fighter1.HP == 0)
            {
                winner = fighter2;
                loser = fighter1;
            } else
            {
                winner = fighter1;
                loser = fighter2;
            }

            string format = "{0,-25} {1,30}" + Environment.NewLine;
            var stringBuilder = new StringBuilder().AppendFormat(format, "Player1 - " + fighter1.GetType().Name,
                                                                         "Player2 - " + fighter2.GetType().Name);

            format = "{0,10} {1,40}" + Environment.NewLine;
            stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();

            string type = winner.GetType().Name;
            switch (type.Trim())
            {
                case "Mage":
                    format = "{0,39}" + Environment.NewLine;
                    break;
                case "Bruiser":
                    format = "{0,43}" + Environment.NewLine;
                    break;
                case "Assassin":
                    format = "{0,44}" + Environment.NewLine;
                    break;
                default:
                    throw new ArgumentException("Invalid type " + type);
            }
            stringBuilder = new StringBuilder().AppendFormat(format, winner.GetType().Name +
                                                    " Fatality hit for 999 HP");
            Console.WriteLine(stringBuilder.ToString());
            loser.HP = -999;

            format = "{0,-25} {1,30}" + Environment.NewLine;
            stringBuilder = new StringBuilder().AppendFormat(format, "Player1 - " + fighter1.GetType().Name,
                                                                         "Player2 - " + fighter2.GetType().Name);
            format = "{0,10} {1,40}" + Environment.NewLine;
            stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();
            Console.WriteLine("\t\t\t" + winner.GetType().Name + " won!" +
                              "\n\t\t " + " \"" + winner.FatalityQuote + "\"");
        }
    }
}
