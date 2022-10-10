
namespace BQR.CS.Teste.Domain
{
    public class Portifolio
    {
        public DateTime DateReference { get; private set; }

        public int TradeAmmount { get; set; }

        public IEnumerable<Trade> Trade { get; private set; }

        public Portifolio(DateTime dateReference, int tradeAmmount, IEnumerable<Trade> trade)
        {
            DateReference = dateReference;
            Trade = trade;
            TradeAmmount = tradeAmmount;
        }
    }
}
