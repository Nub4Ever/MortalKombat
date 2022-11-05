using System.Text;

namespace MortalKombat.Fighters
{
    public class Bruiser : Fighter
    {
        public int NumberOfHits { get; set; }
        public int InitialCritChance { get; set; }

        //nu cred ca acest constructor are vreo utilitate
        public Bruiser() : base() { }
        public Bruiser(int hp, int basicDamage, int specialDamage, int specialAvailable, string fatalityQuote,
            int critChance) :
            base(hp, basicDamage, specialDamage, specialAvailable, fatalityQuote, critChance)
        {
            InitialCritChance = critChance;
            NumberOfHits = 1;
        }

        public override void ApplyPassive()
        {
            CritChance = InitialCritChance;
            PassiveAvailable = 0;

            if (NumberOfHits == 3)
            {
                PassiveAvailable = 1;
                string format = "{0,41}" + Environment.NewLine;
                var stringBuilder = new StringBuilder().AppendFormat(format, "Bruiser passive - Critical");
                Console.WriteLine(stringBuilder.ToString());
                CritChance = 100;

                NumberOfHits = 0;
            }

            NumberOfHits++;
        }
    }
}
