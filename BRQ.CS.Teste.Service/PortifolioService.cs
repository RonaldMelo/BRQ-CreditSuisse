using BQR.CS.Teste.Domain;
using BRQ.CS.Teste.Service.Interface;

namespace BRQ.CS.Teste.Service
{
    public class PortifolioService : IPortifolioService
    {
        public List<string> ClassifyTradesProtifolio(Portifolio portifolio)
        {
            var listTradesClassifies = new List<string>();
            
            foreach(var trade in portifolio.Trade.ToList())
            {
                listTradesClassifies.Add(trade.GetCategory(portifolio.DateReference));
            }

            return listTradesClassifies;
        }
    }
}