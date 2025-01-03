using System.Security.Cryptography;
using System.Text;

namespace advent_of_code_2015.challenges;

public class Day04Challenges: IChallengeSolver
{
    private const string Input = "yzbqklnj";

    private static string GetMd5Hash(MD5 hash, string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var data = hash.ComputeHash(inputBytes);
        var sBuilder = new StringBuilder();
        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }
        return sBuilder.ToString();
    }
    
    public void SolvePart01()
    {
        var md5Hasher = MD5.Create();
        var counter = 0;
        while (true)
        {
            var hash = GetMd5Hash(md5Hasher,$"{Input}{counter}");
            if (hash.StartsWith("00000"))
            {
                break;
            }
            counter++;
        }
        Console.WriteLine($"Solution part 01 : {counter}");
    }

    public void SolvePart02()
    {
        var md5Hasher = MD5.Create();
        var counter = 0;
        while (true)
        {
            var hash = GetMd5Hash(md5Hasher,$"{Input}{counter}");
            if (hash.StartsWith("000000"))
            {
                break;
            }
            counter++;
        }
        Console.WriteLine($"Solution part 02 : {counter}");
    }
}