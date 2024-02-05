using System.Linq;
using Actuator;
using NUnit.Framework;

public class MaybeLinqTests
{
    [Test]
    public void ToMaybe_When123_ShouldAllBeSome()
    {
        var raised = new[] { 1, 2, 3 }.ToMaybe();

        Assert.IsTrue(raised.All(x => x.IsSome));
    }

    [Test]
    public void FirstOrNone_When123AndAskFor0_ShouldBeNone()
    {
        var set = new[] { 1, 2, 3 };

        var res = set.FirstOrNone(x => x == 0);

        Assert.IsTrue(res.IsNone);
    }

    [Test]
    public void ToMaybe_When123AndAskFor2_ShouldBeSome()
    {
        var set = new[] { 1, 2, 3 };

        var res = set.FirstOrNone(x => x == 2);

        Assert.IsTrue(res.IsSome);
    }
}
