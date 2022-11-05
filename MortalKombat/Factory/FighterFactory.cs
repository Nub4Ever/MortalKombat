using MortalKombat.Fighters;

namespace MortalKombat.Factory
{
    internal class FighterFactory
    {
        public static Fighter ChoseFighter(char key)
        {
            switch (char.ToLower(key))
            {
                case 'b':
                    Console.WriteLine("\nYou chose Bruiser! Charge your punch...");
                    return new Bruiser(100, 10, 35, 1, "You Weak, Pathetic Fool!", 50);
                case 'm':
                    Console.WriteLine("\nYou chose Mage! Get your spells ready...");
                    return new Mage(100, 15, 30, 1, "Flawless Victory!", 0);
                case 'a':
                    Console.WriteLine("\nYou chose Asssassin! Darkness is your friend...");
                    return new Assassin(100, 10, 25, 1, "Subtle But Painful Death!", 30);
                default:
                    throw new ArgumentException("Invalid key(" + key + ")");
            }
        }

    }
}
