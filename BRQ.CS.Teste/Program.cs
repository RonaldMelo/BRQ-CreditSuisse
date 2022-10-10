// See https://aka.ms/new-console-template for more information
using BQR.CS.Teste.Domain;
using BRQ.CS.Teste.Service;
using System.Globalization;

string stringFormat = "MM/dd/yyyy";

Console.WriteLine("Informe a data de referência");

string sDataReferencia = Console.ReadLine();
DateTime DataReferencia = DateTime.ParseExact(sDataReferencia, stringFormat, CultureInfo.InvariantCulture);

Console.WriteLine("Informe a quantidade de trades");

string sQuantidadeTrades = Console.ReadLine();
int QuantidadeTrades = Convert.ToInt32(sQuantidadeTrades);

var listTrade = new List<Trade>();

for (int i = 1; i <= QuantidadeTrades; i++)
{
    Console.WriteLine($"Informe o valor do Trade {i} : ");

    string sValue = Console.ReadLine();
    double Value = Convert.ToDouble(sValue);

    Console.WriteLine($"Informe o Setor do Cliente do Trade {i} : ");
    string ClientSector = Console.ReadLine();

    Console.WriteLine($"Informe o Setor do NextPaymentDate do Trade {i} : ");
    string sNextPaymentDate = Console.ReadLine();

    DateTime NextPaymentDate = DateTime.ParseExact(sNextPaymentDate, stringFormat, CultureInfo.InvariantCulture);

    var trade = new Trade(Value, ClientSector, NextPaymentDate);

    listTrade.Add(trade);
}


var portifolio = new Portifolio(DataReferencia, QuantidadeTrades, listTrade.ToArray());

var portifolioService = new PortifolioService();
var tradesClassifies = portifolioService.ClassifyTradesProtifolio(portifolio);

foreach (var tradeClassify in tradesClassifies)
{
    Console.WriteLine(tradeClassify);

}
