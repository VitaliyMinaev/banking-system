using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UI.Extensions
{
    public static class ErrorMessagesExtensions
    {
        public static string BuildErrorMessage(this string[] errorMessages)
        {
            var builder = new StringBuilder();
            foreach (var item in errorMessages)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
    }
}
