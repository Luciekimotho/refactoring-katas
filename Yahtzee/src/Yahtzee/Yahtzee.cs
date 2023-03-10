using System.Collections;

public class Yahtzee
{
    protected int[] dice;
    public Yahtzee(int d1, int d2, int d3, int d4, int d5)
    {
        dice = new int[5];
        dice[0] = d1;
        dice[1] = d2;
        dice[2] = d3;
        dice[3] = d4;
        dice[4] = d5;
    }

    public static int Chance(int d1, int d2, int d3, int d4, int d5)
    {
        int total = 0;
        return total + d1 + d2 + d3 + d4 + d5;
    }

    public static int YahtzeeRound2(params int[] dice)
    {
        int[] counts = new int[6];
        foreach (int die in dice)
            counts[die - 1]++;
        for (int i = 0; i <= dice.Length; i++)
            if (counts[i] == dice.Length)
                return 50;
        return 0;
    }

    public static int YahtzeeRound(params int[] dice)
    {
        foreach (int die in dice)
            if (die != dice[0])
                return 0;
        return 50;
    }

    public int SameTarget(int target)
    {
        int sum = 0;
        for (int i = 0; i != dice.Length; i++)
        {
            if (dice[i] == target)
            {
                sum += target;
            }
        }
        return sum;
    }

    public int ScorePair()
    {
        int[] counts = new int[6];
        foreach (int die in dice)
            counts[die - 1]++;

        for (int i = 0; i != dice.Length+1; i++)
            if (counts[dice.Length - i] >= 2)
                return (dice.Length + 1 - i) * 2;
        return 0;
    }

    public static int TwoPair(int d1, int d2, int d3, int d4, int d5)
    {
        int[] counts = new int[6];
        counts[d1 - 1]++;
        counts[d2 - 1]++;
        counts[d3 - 1]++;
        counts[d4 - 1]++;
        counts[d5 - 1]++;
        int n = 0;
        int score = 0;
        for (int i = 0; i < 6; i += 1)
            if (counts[6 - i - 1] == 2)
            {
                n++;
                score += (6 - i);
            }
        if (n == 2)
            return score * 2;
        else
            return 0;
    }

    public static int FourOfAKind(int _1, int _2, int d3, int d4, int d5)
    {
        int[] tallies;
        tallies = new int[6];
        tallies[_1 - 1]++;
        tallies[_2 - 1]++;
        tallies[d3 - 1]++;
        tallies[d4 - 1]++;
        tallies[d5 - 1]++;
        for (int i = 0; i < 6; i++)
            if (tallies[i] == 4)
                return (i + 1) * 4;
        return 0;
    }

    public static int ThreeOfAKind(int d1, int d2, int d3, int d4, int d5)
    {
        int[] t;
        t = new int[6];
        t[d1 - 1]++;
        t[d2 - 1]++;
        t[d3 - 1]++;
        t[d4 - 1]++;
        t[d5 - 1]++;
        for (int i = 0; i < 6; i++)
            if (t[i] == 3)
                return (i + 1) * 3;
        return 0;
    }

    public static int SmallStraight(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;
        if (tallies[0] == 1 &&
            tallies[1] == 1 &&
            tallies[2] == 1 &&
            tallies[3] == 1 &&
            tallies[4] == 1)
            return 15;
        return 0;
    }

    public static int LargeStraight(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;
        if (tallies[1] == 1 &&
            tallies[2] == 1 &&
            tallies[3] == 1 &&
            tallies[4] == 1
            && tallies[5] == 1)
            return 20;
        return 0;
    }

    public static int FullHouse(int d1, int d2, int d3, int d4, int d5)
    {
        int[] tallies;
        bool _2 = false;
        int i;
        int _2_at = 0;
        bool _3 = false;
        int _3_at = 0;




        tallies = new int[6];
        tallies[d1 - 1] += 1;
        tallies[d2 - 1] += 1;
        tallies[d3 - 1] += 1;
        tallies[d4 - 1] += 1;
        tallies[d5 - 1] += 1;

        for (i = 0; i != 6; i += 1)
            if (tallies[i] == 2)
            {
                _2 = true;
                _2_at = i + 1;
            }

        for (i = 0; i != 6; i += 1)
            if (tallies[i] == 3)
            {
                _3 = true;
                _3_at = i + 1;
            }

        if (_2 && _3)
            return _2_at * 2 + _3_at * 3;
        else
            return 0;
    }
}
