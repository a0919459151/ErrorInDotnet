using System.Security.Cryptography;

namespace Core.Helpers;

public class RandomService
{
    public string GenerateToken(int length)
    {
        var byteArr = new byte[length];
        RandomNumberGenerator.Fill(byteArr);
        return Convert.ToBase64String(byteArr);
    }
}
