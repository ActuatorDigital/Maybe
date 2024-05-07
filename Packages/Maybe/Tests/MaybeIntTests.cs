using Actuator;
using NUnit.Framework;

public class MaybeIntTests
{
    [Test]
    public void ctor_WhenEmpty_ShouldBeNone()
    {
        var maybe = default(Maybe<int>);

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void ctor_WhenDefaultValue_ShouldBeSome()
    {
        var maybe = new Maybe<int>(default);

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void None_WhenEmpty_ShouldBeNone()
    {
        var maybe = Maybe.None<int>();

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void Some_WhenDefaultValue_ShouldBeSome()
    {
        var maybe = Maybe.Some(default(int));

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void Value_WhenZero_ShouldBeZero()
    {
        var exptected = 0;
        var maybe = new Maybe<int>(exptected);

        Assert.AreEqual(exptected, maybe.Value());
    }

    [Test]
    public void ValueOr_WhenZero_ShouldBeZero()
    {
        var exptected = 0;
        var notExpected = 1;
        var maybe = new Maybe<int>(exptected);

        Assert.AreEqual(exptected, maybe.ValueOr(notExpected));
    }

    [Test]
    public void ValueOr_WhenSome_ShouldNotInvoke()
    {
        var exptected = 0;
        var invoked = false;
        var maybe = new Maybe<int>(exptected);

        var res = maybe.ValueOr(() => { invoked = true; return 1; });

        Assert.AreEqual(exptected, res);
        Assert.IsFalse(invoked);
    }

    [Test]
    public void ValueOr_WhenNone_ShouldInvoke()
    {
        var exptected = 1;
        var invoked = false;
        var maybe = Maybe.None<int>();

        var res = maybe.ValueOr(() => { invoked = true; return 1; });

        Assert.AreEqual(exptected, res);
        Assert.IsTrue(invoked);
    }

    [Test]
    public void MatchSome_WhenEmpty_ShouldNotInvoke()
    {
        var wasInvoked = false;
        var maybe = default(Maybe<int>);

        maybe.MatchSome(x => wasInvoked = true);

        Assert.IsFalse(wasInvoked);
    }

    [Test]
    public void MatchSome_WhenSome_ShouldInvoke()
    {
        var wasInvoked = false;
        var maybe = new Maybe<int>(1);

        maybe.MatchSome(x => wasInvoked = true);

        Assert.IsTrue(wasInvoked);
    }

    [Test]
    public void MatchNone_WhenEmpty_ShouldInvoke()
    {
        var wasInvoked = false;
        var maybe = default(Maybe<int>);

        maybe.MatchNone(() => wasInvoked = true);

        Assert.IsTrue(wasInvoked);
    }

    [Test]
    public void Match_WhenEmpty_ShouldInvokeNone()
    {
        var status = 0;
        var someStatus = 1;
        var noneStatus = 2;
        var maybe = default(Maybe<int>);

        maybe.Match(
            some: x => status = someStatus,
            none: () => status = noneStatus);

        Assert.AreEqual(noneStatus, status);
    }

    [Test]
    public void Match_WhenDefault_ShouldInvokeSome()
    {
        var status = 0;
        var someStatus = 1;
        var noneStatus = 2;
        var maybe = new Maybe<int>(default);

        maybe.Match(
            some: x => status = someStatus,
            none: () => status = noneStatus);

        Assert.AreEqual(someStatus, status);
    }

    [Test]
    public void TryOrNone_WhenThrows_ShouldBeNone()
    {
        var maybe = Maybe.TryOrNone<int>(() => throw new System.Exception());

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void TryOrNone_WhenDoesNotThrow_ShouldBeSome()
    {
        var maybe = Maybe.TryOrNone<int>(() => 1);

        Assert.IsTrue(maybe.IsSome);
    }
}
