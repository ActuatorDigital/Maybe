using Actuator;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MaybeUnityObjectTests
{
    [Test]
    public void ctor_WhenGameObject_ShouldBeSome()
    {
        var go = new GameObject();

        var maybe = new Maybe<GameObject>(go);

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void ctor_WhenGetComponentPresent_ShouldBeSome()
    {
        var go = new GameObject();

        var maybe = new Maybe<Transform>(go.GetComponent<Transform>());

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void None_WhenEmpty_ShouldBeNone()
    {
        var maybe = Maybe.None<GameObject>();

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void Some_WhenDefaultValue_ShouldBeSome()
    {
        var maybe = Maybe.Some(new GameObject());

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void ctor_WhenGetComponentNotPresent_ShouldBeNone()
    {
        var go = new GameObject();

        var maybe = new Maybe<Rigidbody>(go.GetComponent<Rigidbody>());

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void GetComponentOrNone_WhenGetComponentPresent_ShouldBeSome()
    {
        var go = new GameObject();

        var maybe = go.GetComponentOrNone<Transform>();

        Assert.IsTrue(maybe.IsSome);
    }

    [Test]
    public void GetComponentOrNone_WhenGetComponentNotPresent_ShouldBeNone()
    {
        var go = new GameObject();

        var maybe = go.GetComponentOrNone<Rigidbody>();

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void GetComponentOrNone_WhenInterfaceNotPresent_ShouldBeNone()
    {
        var go = new GameObject();

        var maybe = go.GetComponentOrNone<ILayoutElement>();

        Assert.IsTrue(maybe.IsNone);
    }

    [Test]
    public void GetComponentOrNone_WhenInterfaceIsPresent_ShouldBeSome()
    {
        var go = new GameObject("testObj", typeof(Image));

        var maybe = go.GetComponentOrNone<ILayoutElement>();

        Assert.IsTrue(maybe.IsSome);
    }
}