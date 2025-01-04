using System.Collections;
using System.Text.RegularExpressions;

namespace advent_of_code_2015.challenges;

public class Day06Challenges: IChallengeSolver
{
    private static (char op, int sx, int sy, int ex, int ey) GetInstruction(string line)
    {
        char op = 'T';
        if (line.Contains("on"))
        {
            op = 'O';
        } else if (line.Contains("off"))
        {
            op = 'F';
        }
        
        string pattern = @"\d+";
        var regex = new Regex(pattern);
        var matches = regex.Matches(line);

        var sx = int.Parse(matches[0].Value);
        var sy = int.Parse(matches[1].Value);
        var ex = int.Parse(matches[2].Value);
        var ey = int.Parse(matches[3].Value);

        return (op, sx, sy, ex, ey);
    }
    
    private static List<(char op, int sx, int sy, int ex, int ey)> LoadData()
    {
        return File.ReadAllLines("../../../inputs/input_06.txt")
            .Select(GetInstruction).ToList();
    }

    private static List<List<bool>> CreateMatrix()
    {
        var matrix = new List<List<bool>>();
        for (var i = 0; i < 1000; i++)
        {
            var row = new List<bool>();
            for (var j = 0; j < 1000; j++)
            {
                row.Add(false);
            }
            matrix.Add(row);
        }
        return matrix;
    }

    private static bool OperateValue(bool value, char op)
    {
        if (op == 'O')
        {
            return true;
        }
        
        if (op == 'F')
        {
            return false;
        }

        return !value;
    }

    private static void ProcessInstruction(List<List<bool>> matrix, (char op, int sx, int sy, int ex, int ey) instruction )
    {
        for (var j = instruction.sy; j <= instruction.ey; j++)
        {
            for (var i = instruction.sx; i <= instruction.ex; i++)
            {
                matrix[j][i] = OperateValue(matrix[j][i], instruction.op);
            }
        }
    }
    
    public void SolvePart01()
    {
        var data = LoadData();
        var matrix = CreateMatrix();
        foreach (var instruction in data)
        {
            ProcessInstruction(matrix, instruction);
        }

        var total = matrix.Sum(row => row.Sum(value => value ? 1 : 0));
        
        Console.WriteLine($"Solution part 01 : {total}");
    }

    public void SolvePart02()
    {
        throw new NotImplementedException();
    }
}