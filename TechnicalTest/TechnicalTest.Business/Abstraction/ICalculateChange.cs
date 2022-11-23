using System;
using TechnicalTest.Models;

namespace TechnicalTest.Business.Abstraction
{
    public interface ICalculateChange
    {
        public List<Coins> CalculateChangeAmount(List<Coins> coins, decimal Cost, decimal payment);
    }
}

