namespace advent_of_code_2015.challenges;

public class Day02Challenges: IChallengeSolver
{
    private static List<(int l, int w, int h)> ReadInput()
    {
        var data = File.ReadAllLines("../../../inputs/input_02.txt");
        List<(int l, int w, int h)> boxes  = [];
        foreach (var line in data)
        {
            var values = line.Split('x');
            var l = int.Parse(values[0]);
            var w = int.Parse(values[1]);
            var h = int.Parse(values[2]);
            boxes.Add((l,w,h));
        }

        return boxes;
    }

    private static int GetBoxWrapper((int l,int w,int h) box)
    {
        int[] faces = [box.w * box.h, box.w * box.l, box.h * box.l];
        return 2 * faces.Sum() + faces.Min();
    }
    
    private static int GetBoxRibbon((int l,int w,int h) box)
    {
        int[] facePerimeters = [2*box.w + 2*box.h,2*box.w + 2*box.l, 2*box.h + 2*box.l];
        var volume = box.l * box.w * box.h;
        return  volume + facePerimeters.Min();
    }
    
    public void SolvePart01()
    {
        var data = ReadInput();
        Int32 total = data.Sum(GetBoxWrapper);
        Console.WriteLine($"Result part 01: {total}");
    }

    public void SolvePart02()
    {
        var data = ReadInput();
        var totalRibbons = (from line in data select GetBoxRibbon(line)).Sum();
        Console.WriteLine($"Result part 02: {totalRibbons}");
    }
}