using System.Security.Cryptography;
using System.Text;

namespace BankingSystem.Api.Services;

public class HashProvider
{
    public string GenerateHash(string input)
    {
        if (input == null)
            throw new ArgumentNullException("Input can not be null");
        
        // Create a SHA256   
        using var sha256Hash = SHA512.Create();
        // ComputeHash - returns byte array  
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Convert byte array to a string   
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}