using NUnit.Framework;

[TestFixture]
public class YahzeeTest
{
    [Test]
    public void Test_Chance()
    {
        int expected = 15;
        int actual = Yahtzee.Chance(2, 3, 4, 5, 1);
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(16, Yahtzee.Chance(3, 3, 4, 5, 1));
    }

    [Test]
    public void Test_Yahtzee_Round()
    {
        int expected = 50;
        int actual = Yahtzee.YahtzeeRound(4, 4, 4, 4, 4);
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(50, Yahtzee.YahtzeeRound(6, 6, 6, 6, 6));
        Assert.AreEqual(0, Yahtzee.YahtzeeRound(6, 6, 6, 6, 3));
    }

    [Test]
    public void Test_Ones()
    {
        Assert.IsTrue(new Yahtzee(1, 2, 3, 4, 5).SameTarget(1) == 1);
        Assert.AreEqual(2, new Yahtzee(1, 2, 1, 4, 5).SameTarget(1));
        Assert.AreEqual(0, new Yahtzee(6, 2, 2, 4, 5).SameTarget(1));
        Assert.AreEqual(4, new Yahtzee(1, 2, 1, 1, 1).SameTarget(1));
    }

    [Test]
    public void Test_Twos()
    {
        Assert.AreEqual(4, new Yahtzee(1, 2, 3, 2, 6).SameTarget(2));
        Assert.AreEqual(10, new Yahtzee(2, 2, 2, 2, 2).SameTarget(2));
    }

    [Test]
    public void Test_Threes()
    {
        Assert.AreEqual(6, new Yahtzee(1, 2, 3, 2, 3).SameTarget(3));
        Assert.AreEqual(12, new Yahtzee(2, 3, 3, 3, 3).SameTarget(3));
    }

    [Test]
    public void Test_Fours()
    {
        Assert.AreEqual(12, new Yahtzee(4, 4, 4, 5, 5).SameTarget(4));
        Assert.AreEqual(8, new Yahtzee(4, 4, 5, 5, 5).SameTarget(4));
        Assert.AreEqual(4, new Yahtzee(4, 5, 5, 5, 5).SameTarget(4));
    }

    [Test]
    public void Test_Fives()
    {
        Assert.AreEqual(10, new Yahtzee(4, 4, 4, 5, 5).SameTarget(5));
        Assert.AreEqual(15, new Yahtzee(4, 4, 5, 5, 5).SameTarget(5));
        Assert.AreEqual(20, new Yahtzee(4, 5, 5, 5, 5).SameTarget(5));
    }

    [Test]
    public void Test_Sixes()
    {
        Assert.AreEqual(0, new Yahtzee(4, 4, 4, 5, 5).SameTarget(6));
        Assert.AreEqual(6, new Yahtzee(4, 4, 6, 5, 5).SameTarget(6));
        Assert.AreEqual(18, new Yahtzee(6, 5, 6, 6, 5).SameTarget(6));
    }

    [Test]
    public void one_pair()
    {
        Assert.AreEqual(6, new Yahtzee(3, 4, 3, 5, 6).ScorePair());
        Assert.AreEqual(10, new Yahtzee(5, 3, 3, 3, 5).ScorePair());
        Assert.AreEqual(12, new Yahtzee(5, 3, 6, 6, 5).ScorePair());
    }

    [Test]
    public void two_Pair()
    {
        Assert.AreEqual(16, Yahtzee.TwoPair(3, 3, 5, 4, 5));
        Assert.AreEqual(0, Yahtzee.TwoPair(3, 3, 5, 5, 5));
    }

    [Test]
    public void three_of_a_kind()
    {
        Assert.AreEqual(9, Yahtzee.ThreeOfAKind(3, 3, 3, 4, 5));
        Assert.AreEqual(15, Yahtzee.ThreeOfAKind(5, 3, 5, 4, 5));
        Assert.AreEqual(0, Yahtzee.ThreeOfAKind(3, 3, 3, 3, 5));
    }

    [Test]
    public void four_of_a_knd()
    {
        Assert.AreEqual(12, Yahtzee.FourOfAKind(3, 3, 3, 3, 5));
        Assert.AreEqual(20, Yahtzee.FourOfAKind(5, 5, 5, 4, 5));
        Assert.AreEqual(0, Yahtzee.FourOfAKind(3, 3, 3, 3, 3));
    }

    [Test]
    public void smallStraight()
    {
        Assert.AreEqual(15, Yahtzee.SmallStraight(1, 2, 3, 4, 5));
        Assert.AreEqual(15, Yahtzee.SmallStraight(2, 3, 4, 5, 1));
        Assert.AreEqual(0, Yahtzee.SmallStraight(1, 2, 2, 4, 5));
    }

    [Test]
    public void largeStraight()
    {
        Assert.AreEqual(20, Yahtzee.LargeStraight(6, 2, 3, 4, 5));
        Assert.AreEqual(20, Yahtzee.LargeStraight(2, 3, 4, 5, 6));
        Assert.AreEqual(0, Yahtzee.LargeStraight(1, 2, 2, 4, 5));
    }

    [Test]
    public void fullHouse()
    {
        Assert.AreEqual(18, Yahtzee.FullHouse(6, 2, 2, 2, 6));
        Assert.AreEqual(0, Yahtzee.FullHouse(2, 3, 4, 5, 6));
    }
}

