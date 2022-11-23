using Newtonsoft.Json;

namespace TechnicalTest.Util.Files;
public static class ConfigurationApplicationStore
{
    private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented };

    public static void SimpleWrite(object obj, string fileName)
    {
        var jsonString = JsonConvert.SerializeObject(obj, _options);
        File.WriteAllText(fileName, jsonString);
    }

    public static string IsAlreadyConfigured()
    {
            if (File.Exists("AppConfiguration.json"))
            {
                var text = File.ReadAllText("AppConfiguration.json");
                return text;
            }
            else
            {
            return "";
            }


    }

}

