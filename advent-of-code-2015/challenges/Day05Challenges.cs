namespace advent_of_code_2015.challenges;

public class Day05Challenges: IChallengeSolver
{
    private static string[] LoadData()
    {
        return File.ReadAllLines("../../../inputs/input_05.txt");
    }

    private static bool IsValidWord(string word)
    {
        const string vowels = "aeiou";
        var vowelCounter = word.Sum(x => vowels.Contains(x)? 1 : 0);
        if (vowelCounter < 3)
        {
            return false;
        }

        string[] forbiddenStrings = ["ab", "cd", "pq", "xy"];
        if (forbiddenStrings.Any(combination => word.Contains(combination)))
        {
            return false;
        }

        for (var i = 0; i < word.Length - 1; i++)
        {
            if (word[i] == word[i + 1])
            {
                return true;
            }
        }
        
        return false;
    }
    
    public void SolvePart01()
    {
        var data = LoadData();
        var validWords = data.Sum(word => IsValidWord(word) ? 1 : 0);
        Console.WriteLine($"Solution part 01: {validWords}");
    }

    private static bool IsValidWordPart02(string word)
    {
        var containsPair = false;
        for (var i = 0; i < word.Length - 1; i++)
        {
            var combination = word.Substring(i, 2);
            var remainingWord = word[(i + 2)..];
            if (remainingWord.Contains(combination))
            {
                containsPair = true;
                break;
            }
        }
        if (!containsPair)
        {
            return false;
        }
        
        for (var i = 0; i < word.Length - 2; i++)
        {
            if (word[i] == word[i + 2])
            {
                return true;
            }
        }

        return false;
    }

    public void SolvePart02()
    {
        var data = LoadData();
        var validWords = data.Sum(word => IsValidWordPart02(word) ? 1 : 0);
        Console.WriteLine($"Solution part 02: {validWords}");
    }
}