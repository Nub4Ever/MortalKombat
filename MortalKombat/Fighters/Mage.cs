using System.Text;
//clean code :)

namespace MortalKombat.Fighters
{
    public class Mage : Fighter
    {
        public int TakenDamage { get; set; }
        public int NumberOfHits { get; set; }
        public int InitialHP { get; set; }

        public Mage() : base() { }
        public Mage(int hp, int basicDamage, int specialDamage, int specialAvailable, string fatalityQuote,
            int critChance) :
            base(hp, basicDamage, specialDamage, specialAvailable, fatalityQuote, critChance)
        {
            TakenDamage = 0;
            InitialHP = 100;
            NumberOfHits = 1;
        }


        public override void ApplyPassive()
        {
            PassiveAvailable = 0;

            if (NumberOfHits == 4)
            {
                PassiveAvailable = 1;
                string format = "{0,39}" + Environment.NewLine;
                var stringBuilder = new StringBuilder().AppendFormat(format, "Mage passive - Self Heal");
                Console.WriteLine(stringBuilder.ToString());
                TakenDamage = InitialHP - HP;
                HP += (int)Math.Round(15.0 / 100 * TakenDamage);
                InitialHP = HP;

                NumberOfHits = 0;
            }

            NumberOfHits++;
        }
    }
}
