namespace MortalKombat.Fighters
{
    public interface IFighter
    {
        int BasicDamage { get; set; }
        int CritChance { get; set; }
        int CriticalSucces { get; set; }
        int DodgeSucces { get; set; }
        string FatalityQuote { get; set; }
        int HP { get; set; }
        int PassiveAvailable { get; set; }
        int SpecialAvailable { get; set; }
        int SpecialDamage { get; set; }

        event EventHandler<MessageEventArgs> BasicHit;
        event EventHandler<MessageEventArgs> CriticalHit;
        event EventHandler<EventArgs> MissedHit;
        event EventHandler<EventArgs> SpecialHit;

        void ApplyPassive();
        void CalculateCritical();
        void Hit(Fighter fighter);
    }
}