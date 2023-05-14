using System.Text.Json;

namespace BankingSystem.UI.Extensions
{
    public static class JsonExtensions
    {
        public static string Serialize<T>(this T value)
            where T : class
        {
            var json = JsonSerializer.Serialize(value);
            return json;
        }
        public static T Deserialize<T>(this string input)
            where T : class
        {
            var result = JsonSerializer.Deserialize<T>(input);
            return result;
        }
    }
}
