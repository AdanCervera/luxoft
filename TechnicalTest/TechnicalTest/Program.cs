using Newtonsoft.Json;
using TechnicalTest.Models;
using TechnicalTest.Util.Files;
using TechnicalTest.Business;
Console.WriteLine("WELCOME TO THE NEW POS SYSTEM");
CoinsConfiguration? configuration = new CoinsConfiguration();

string config = ConfigurationApplicationStore.IsAlreadyConfigured();
if (config != "")
{
    configuration = JsonConvert.DeserializeObject<CoinsConfiguration>(config);
}
else
{

    Console.WriteLine("This systems is not already configured a country or coins");
    Console.WriteLine("Please write the country that you want to configure: ");
    configuration.Country = Console.ReadLine();
    List<Coins>? coins = new List<Coins>();
    Console.WriteLine("Please enter the coins value that you want to register, press ENTER to finish ");
    string coin = "0.0";
    while (coin != "")
    {
        coin = Console.ReadLine();
        if (coin != "")
            coins.Add(new Coins { ValueCoin = Convert.ToDecimal(coin) });
    }
    configuration.Coins = coins;

    ConfigurationApplicationStore.SimpleWrite(configuration, "AppConfiguration.json");
}

Console.WriteLine("Enter de product value");
decimal costProduct = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Enter the amount the client provide");
decimal amount = Convert.ToDecimal(Console.ReadLine());
CalculateChange calcuateChange = new CalculateChange();
List<Coins> change = calcuateChange.CalculateChangeAmount(configuration.Coins, costProduct, amount);
decimal totalChange = 0;
change.ForEach(p =>
{
    totalChange += p.ValueCoin;
    Console.WriteLine("$ " + p.ValueCoin);
});

Console.WriteLine("TOTAL CHANGE: $ " + totalChange);