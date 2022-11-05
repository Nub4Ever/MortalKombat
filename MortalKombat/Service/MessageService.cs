using System.Text;
using MortalKombat.Fighters;

namespace MortalKombat.Service
{
    internal class MessageService
    {
        public void OnBasicHit(object source, MessageEventArgs e)
        {
            //source si e ar putea fi null
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            string type = source.GetType().Name;
            string format;
            StringBuilder stringBuilder;

            switch (type.Trim())
            {
                case "Mage":
                    format = "{0,39}" + Environment.NewLine;
                    break;
                case "Bruiser":
                    format = "{0,42}" + Environment.NewLine;
                    break;
                case "Assassin":
                    format = "{0,42}" + Environment.NewLine;
                    break;
                default:
                    throw new ArgumentException("Invalid type " + type);
            }
            stringBuilder = new StringBuilder().AppendFormat(format, type +
                                                    " Basic hit for " + e.Damage + " HP");
            Console.WriteLine(stringBuilder.ToString());
        }

        public void OnCriticalHit(object source, MessageEventArgs e)
        {
            //source si e ar putea fi null
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            string type = source.GetType().Name;
            string format;
            StringBuilder stringBuilder;

            switch (type.Trim())
            {
                case "Mage":
                    format = "{0,38}" + Environment.NewLine;
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
            stringBuilder = new StringBuilder().AppendFormat(format, type +
                                                    " Critical hit for " + e.Damage + " HP");
            Console.WriteLine(stringBuilder.ToString());
        }
        public void OnMissedHit(object source, EventArgs e)
        {
            //source si e ar putea fi null
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            string type = source.GetType().Name;
            string format;
            StringBuilder stringBuilder;

            switch (type.Trim())
            {
                case "Mage":
                    format = "{0,34}" + Environment.NewLine;
                    break;
                case "Bruiser":
                    format = "{0,35}" + Environment.NewLine;
                    break;
                case "Assassin":
                    format = "{0,36}" + Environment.NewLine;
                    break;
                default:
                    throw new ArgumentException("Invalid type " + type);
            }
            stringBuilder = new StringBuilder().AppendFormat(format, "Missed " + type);
            Console.WriteLine(stringBuilder.ToString());
        }

        public void OnSpecialHit(object source, EventArgs e)
        {
            //source si e ar putea fi null
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            string type = source.GetType().Name;
            string format;
            StringBuilder stringBuilder;

            switch (type.Trim())
            {
                case "Mage":
                    format = "{0,35}" + Environment.NewLine;
                    break;
                case "Bruiser":
                    format = "{0,37}" + Environment.NewLine;
                    break;
                case "Assassin":
                    format = "{0,38}" + Environment.NewLine;
                    break;
                default:
                    throw new ArgumentException("Invalid type " + type);
            }
            stringBuilder = new StringBuilder().AppendFormat(format, "Special hit " + type);
            Console.WriteLine(stringBuilder.ToString());

        }
    }
}
