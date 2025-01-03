namespace advent_of_code_2015.challenges;

public class Day03Challenges: IChallengeSolver
{
    private static string LoadData()
    {
        var data = File.ReadAllText("../../../inputs/input_03.txt");
        return data;
    }
    
    public void SolvePart01()
    {
        var instructions = LoadData();
        HashSet<(int, int)> locations = [(0, 0)];
        var currentLocation = (0, 0);
        Dictionary<char, (int, int)> deltaDict = new Dictionary<char, (int, int)>()
        {
            {'^',(0,1)},{'v',(0,-1)},{'<',(-1,0)},{'>',(1,0)}
        };
        foreach (var instruction in instructions)
        {
            var delta = deltaDict[instruction];
            currentLocation = (currentLocation.Item1 + delta.Item1, currentLocation.Item2 + delta.Item2);
            locations.Add(currentLocation);
        }
        Console.WriteLine($"Solution part 01: {locations.Count}");
    }

    public void SolvePart02()
    {
        var instructions = LoadData();
        HashSet<(int, int)> locations = [(0, 0)];
        var santaLocation = (0, 0);
        var robotLocation = (0, 0);
        Dictionary<char, (int, int)> deltaDict = new Dictionary<char, (int, int)>()
        {
            {'^',(0,1)},{'v',(0,-1)},{'<',(-1,0)},{'>',(1,0)}
        };
        foreach (var (instruction, index) in instructions.Select((instruction, index) => (instruction,index)))
        {
            var delta = deltaDict[instruction];
            if (index % 2 == 0)
            {
                santaLocation = (santaLocation.Item1 + delta.Item1, santaLocation.Item2 + delta.Item2);
                locations.Add(santaLocation);
            }
            else
            {
                robotLocation = (robotLocation.Item1 + delta.Item1, robotLocation.Item2 + delta.Item2);
                locations.Add(robotLocation);
            }
        }
        Console.WriteLine($"Solution part 02: {locations.Count}");
    }
}