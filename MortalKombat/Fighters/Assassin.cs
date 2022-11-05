using System.Text;

namespace MortalKombat.Fighters
{
    public class Assassin : Fighter
    {
        public int DodgeChance { get; set; }
        public int InitialCritChance { get; set; }

        //nu cred ca acest constructor are vreo utilitate
        public Assassin() : base() { }
        public Assassin(int hp, int basicDamage, int specialDamage, int specialAvailable, string fatalityQuote,
            int critChance) :
            base(hp, basicDamage, specialDamage, specialAvailable, fatalityQuote, critChance)
        {
            DodgeChance = 30;
            InitialCritChance = critChance;
        }

        public override void ApplyPassive()
        {
            CritChance = InitialCritChance;
            int range = (int)Math.Round(100.0 / DodgeChance);
            Random rand = new Random();
            // r ???
            var r = rand.Next(1, range + 1);

            if (r == 1) //dodge hit
            {
                string format = "{0,46}" + Environment.NewLine;
                var stringBuilder = new StringBuilder().AppendFormat(format, " Assassin passive - Dodge next hit");
                Console.WriteLine(stringBuilder.ToString());
                CritChance = 70;
                DodgeSucces = 1;
            }
        }
    }
}
