using System.Text;

namespace MortalKombat.Fighters
{
    public abstract class Fighter
    {
        int initialDamage;

        public int HP { get; set; }
        public int BasicDamage { get; set; }
        public int SpecialDamage { get; set; }
        public int SpecialAvailable { get; set; }
        public string FatalityQuote { get; set; }
        public int CritChance { get; set; }
        public int PassiveAvailable { get; set; }
        public int CriticalSucces { get; set; }
        public int DodgeSucces { get; set; }

        public Fighter(int hp, int basicDamage, int specialDamage, int specialAvailable, string fatalityQuote,
            int critChance)
        {
            HP = hp;
            BasicDamage = basicDamage;
            initialDamage = basicDamage;
            SpecialDamage = specialDamage;
            SpecialAvailable = specialAvailable;
            FatalityQuote = fatalityQuote;
            CritChance = critChance;
            PassiveAvailable = 0;
            CriticalSucces = 0;
            DodgeSucces = 0;
        }

        //nu cred ca acest constructor are vreo utilitate
        public Fighter()
        {
            HP = 0;
            BasicDamage = 0;
            SpecialDamage = 0;
            SpecialAvailable = 0;
            FatalityQuote = "";
        }

        public void CalculateCritical()
        {
            if (CritChance == 0)
            {
                return;
            }
            else
            {
                CriticalSucces = 0;
                BasicDamage = initialDamage;
                int range = (int)Math.Round(100.0 / CritChance);
                Random rand = new Random();
                // numele variabilei r nu ma ajuta sa inteleg ce ai vrut sa faci aici
                var r = rand.Next(1, range + 1);

                if (r == 1)
                {
                    CriticalSucces = 1;
                    BasicDamage *= 2;
                }
            }

        }

        public abstract void ApplyPassive();

        public event EventHandler<EventArgs> MissedHit;
        public event EventHandler<MessageEventArgs> BasicHit;
        public event EventHandler<EventArgs> SpecialHit;
        public event EventHandler<MessageEventArgs> CriticalHit;

        public void Hit(Fighter fighter)
        {
            //fighter ar putea fi null
            if(fighter == null)
            {
                throw new ArgumentNullException(nameof(fighter));
            }
            Random rand = new Random();
            //r ???
            var r = rand.Next(1, 100);

            //am curatat variabile ratacite

            ApplyPassive();

            if (fighter.DodgeSucces == 1)
            {
                OnMissedHit();

                fighter.DodgeSucces = 0;
                return;
            }
            if (r > 20 && r < 40 && SpecialAvailable == 1 && PassiveAvailable != 1)
            {
                OnSpecialHit();

                fighter.HP -= SpecialDamage;
                SpecialAvailable = 0;
            }
            else
            {
                CalculateCritical();
                if (CriticalSucces == 1)
                {
                    OnCriticalHit(BasicDamage);
                }
                else
                {
                    OnBasicHit(BasicDamage);
                }
                fighter.HP -= BasicDamage;
            }
        }

        protected virtual void OnMissedHit()
        {
            if (MissedHit != null)
            {
                MissedHit(this, null);
            }
        }

        protected virtual void OnSpecialHit()
        {
            if (SpecialHit != null)
            {
                SpecialHit(this, null);
            }
        }

        protected virtual void OnBasicHit(int damage)
        {
            if (BasicHit != null)
            {
                BasicHit(this, new MessageEventArgs() { Damage = damage });
            }
        }

        protected virtual void OnCriticalHit(int damage)
        {
            if (CriticalHit != null)
            {
                CriticalHit(this, new MessageEventArgs() { Damage = damage });
            }
        }
    }

    //cred ca ar fi meritat fisierul ei aceasta clasa
    public class MessageEventArgs : EventArgs
    {
        public int Damage { get; set; }
    }
}
