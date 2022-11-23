using TechnicalTest.Business.Abstraction;
using TechnicalTest.Models;

namespace TechnicalTest.Business;
public class CalculateChange : ICalculateChange
{
   public  List<Coins> CalculateChangeAmount(List<Coins> coins, decimal Cost, decimal payment)
    {
        decimal result = payment - Cost;
        List<Coins> CoinsOrdered = coins.OrderByDescending(p => p.ValueCoin).ToList();
        List<Coins> Change = new List<Coins>();
        while(result != 0)
        {
            var valueCoin = CoinsOrdered.FirstOrDefault().ValueCoin;
            if(result >= valueCoin)
            {
                Change.Add(new Coins { ValueCoin = valueCoin });
                result = result- valueCoin;
            }
            else
            {
                CoinsOrdered.Remove(CoinsOrdered.FirstOrDefault());
            }
        }

        return Change;
    }
}

