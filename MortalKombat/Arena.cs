using MortalKombat.Factory;
using MortalKombat.Fighters;
using MortalKombat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat
{
    public class Arena
    {
        int count = 0;
        public Fighter PickFighter()
        {
            var messageService = new MessageService();

            Console.WriteLine("\nPlayer" + ++count + " Pick: ");
            char type = Console.ReadKey().KeyChar;
            Fighter fighter = FighterFactory.ChoseFighter(type);
            fighter.MissedHit += messageService.OnMissedHit;
            fighter.SpecialHit += messageService.OnSpecialHit;
            fighter.BasicHit += messageService.OnBasicHit;
            fighter.CriticalHit += messageService.OnCriticalHit;

            return fighter;
        }

        public int FirstToGo()
        {
            Random rand = new Random();
            var r = rand.Next(1, 100);
            r = r % 2 + 1;

            Console.WriteLine("\n\t\t\t\t\tLet The Fight Begin! First goes player" + r + "\n");

            return r;
        }

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
            }
            else if (fighter2.HP <= 0)
            {
                fighter2.HP = 0;
                stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
                Console.WriteLine(stringBuilder.ToString());
            }
            else
            {
                stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");
                Console.WriteLine(stringBuilder.ToString());
                Console.WriteLine("...................................................................\n" +
                                  "...................................................................");
            }
        }

        public Fighter EndGame(Fighter fighter1, Fighter fighter2)
        {
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\t\t\tFINISH HIM!\n");

            Fighter winner, loser;

            if (fighter1.HP == 0)
            {
                winner = fighter2;
                loser = fighter1;
            }
            else
            {
                winner = fighter1;
                loser = fighter2;
            }

            var stringBuilder = GetStatus(fighter1, fighter2);
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();

            string type = winner.GetType().Name;
            string format;
            switch (type.Trim())
            {
                case "Mage":
                    format = "{0,39}" + Environment.NewLine;
                    break;
                case "Bruiser":
                    format = "{0,42}" + Environment.NewLine;
                    break;
                case "Assassin":
                    format = "{0,43}" + Environment.NewLine;
                    break;
                default:
                    throw new ArgumentException("Invalid type " + type);
            }
            stringBuilder = new StringBuilder().AppendFormat(format, winner.GetType().Name +
                                                    " Fatality hit for 999 HP");
            Console.WriteLine(stringBuilder.ToString());
            loser.HP = -999;

            stringBuilder = GetStatus(fighter1, fighter2);
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();
            Console.WriteLine("\t\t\t" + winner.GetType().Name + " won!" +
                              "\n\t\t " + " \"" + winner.FatalityQuote + "\"");

            return winner;
        }

        private StringBuilder GetStatus(Fighter fighter1, Fighter fighter2)
        {
            string format = "{0,-25} {1,30}" + Environment.NewLine;
            var stringBuilder = new StringBuilder().AppendFormat(format, "Player1 - " + fighter1.GetType().Name,
                                                                         "Player2 - " + fighter2.GetType().Name);

            format = "{0,10} {1,40}" + Environment.NewLine;
            stringBuilder.AppendFormat(format, fighter1.HP + " HP", fighter2.HP + " HP");

            return stringBuilder;
        }
    }

}
