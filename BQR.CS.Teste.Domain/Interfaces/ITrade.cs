
namespace BQR.CS.Teste.Domain.Interfaces
{
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }
}
