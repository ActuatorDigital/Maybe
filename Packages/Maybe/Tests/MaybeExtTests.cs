using System;
using Actuator;
using NUnit.Framework;

public class MaybeExtTests
{
    [Test]
    public void FirstOrNone_When123AndAskFor0_ShouldBeNone()
    {
        var maybe = new[] { 1, 2, 3 }.FirstOrNone(x => x == 0);

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void FirstOrNone_When123AndAskFor1_ShouldBeSome()
    {
        var maybe = new[] { 1, 2, 3 }.FirstOrNone(x => x == 1);

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void FirstOrNone_When_ShouldBeNone()
    {
        var maybe = Array.Empty<int>().FirstOrNone();

        Assert.IsTrue(maybe.IsNone);
    }
}
