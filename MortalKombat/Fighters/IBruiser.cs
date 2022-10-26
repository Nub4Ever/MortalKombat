namespace MortalKombat.Fighters
{
    public interface IBruiser
    {
        int InitialCritChance { get; set; }
        int NumberOfHits { get; set; }

        void ApplyPassive();
    }
}