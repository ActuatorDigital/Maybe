using Actuator;
using NUnit.Framework;

public class MaybeObjectTests
{
    [Test]
    public void ctor_WhenEmpty_ShouldBeNone()
    {
        var maybe = default(Maybe<object>);

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void ctor_WhenDefaultValue_ShouldBeNone()
    {
        var maybe = new Maybe<object>(default);

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void ctor_WhenZero_ShouldBeSome()
    {
        var maybe = new Maybe<object>(0);

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void Value_WhenZero_ShouldBeZero()
    {
        var exptected = 0;
        var maybe = new Maybe<object>(exptected);

        Assert.AreEqual(exptected, maybe.Value());
    }

    [Test]
    public void ValueOr_WhenZero_ShouldBeZero()
    {
        var exptected = 0;
        var notExpected = 1;
        var maybe = new Maybe<object>(exptected);

        Assert.AreEqual(exptected, maybe.ValueOr(notExpected));
    }

    [Test]
    public void MatchSome_WhenEmpty_ShouldNotInvoke()
    {
        var wasInvoked = false;
        var maybe = default(Maybe<object>);

        maybe.MatchSome(x => wasInvoked = true);

        Assert.IsFalse(wasInvoked);
    }

    [Test]
    public void MatchNone_WhenEmpty_ShouldInvoke()
    {
        var wasInvoked = false;
        var maybe = default(Maybe<object>);

        maybe.MatchNone(() => wasInvoked = true);

        Assert.IsTrue(wasInvoked);
    }

    [Test]
    public void Match_WhenEmpty_ShouldInvokeNone()
    {
        var status = 0;
        var someStatus = 1;
        var noneStatus = 2;
        var maybe = default(Maybe<object>);

        maybe.Match(
            some: x => status = someStatus,
            none: () => status = noneStatus);

        Assert.AreEqual(noneStatus, status);
    }

    [Test]
    public void Match_WhenDefault_ShouldInvokeNone()
    {
        var status = 0;
        var someStatus = 1;
        var noneStatus = 2;
        var maybe = new Maybe<object>(default);

        maybe.Match(
            some: x => status = someStatus,
            none: () => status = noneStatus);

        Assert.AreEqual(noneStatus, status);
    }

    [Test]
    public void Match_WhenZero_ShouldInvokeSome()
    {
        var status = 0;
        var someStatus = 1;
        var noneStatus = 2;
        var maybe = new Maybe<object>(0);

        maybe.Match(
            some: x => status = someStatus,
            none: () => status = noneStatus);

        Assert.AreEqual(someStatus, status);
    }
}