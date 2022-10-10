using BQR.CS.Teste.Domain.Enum;
using BQR.CS.Teste.Domain.Interfaces;

namespace BQR.CS.Teste.Domain
{
    public class Trade : ITrade
    {
        private double _value;

        private string _clientSector;

        private DateTime _nextPaymentDate;

        public double Value => _value;

        public string ClientSector => _clientSector;

        public DateTime NextPaymentDate => _nextPaymentDate;

        public Trade(double value, string clientSector, DateTime nextPaymetDate)
        {
            _value = value;
            _clientSector = clientSector;
            _nextPaymentDate = nextPaymetDate;
        }

        public string GetCategory(DateTime referenceDate)
        {
            TimeSpan interval = new TimeSpan(NextPaymentDate.Subtract(referenceDate).Ticks);

            if (interval.TotalDays < -30) return EnumCategory.EXPIRED.ToString();

            if (Value > 1000000 && ClientSector == "Private") return EnumCategory.HIGHRISK.ToString();

            if (Value > 1000000 && ClientSector == "Public") return EnumCategory.MEDIUMRISK.ToString();

            return "";
        }
    }
}
