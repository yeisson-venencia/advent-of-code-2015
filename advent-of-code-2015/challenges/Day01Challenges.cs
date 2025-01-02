namespace advent_of_code_2015.challenges;

public class Day01Challenges: IChallengeSolver
{
    private static string ReadInputData()
    {
        var data = File.ReadAllText("../../../inputs/input_01.txt");
        
        return data;
    }
    public void SolvePart01()
    {
        var data = ReadInputData();
        var totalUp = 0;
        for (int i = 0; i < data.Length; i++)
        {
            totalUp += (data[i] == '(') ? 1 : 0;
        }

        var totalDown = data.Length - totalUp;
        Console.WriteLine("Result part 01: {0}", totalUp - totalDown);
    }
    
    public void SolvePart02()
    {
        var data = ReadInputData();
        var currentFloor = 0;
        var instruction = -1;
        for (int i = 0; i < data.Length; i++)
        {
            currentFloor += (data[i] == '(') ? 1 : -1;
            if (currentFloor == -1)
            {
                instruction = i + 1;
                break;
            }
        }
        Console.WriteLine("Result part 02: {0}", instruction);
    }
}