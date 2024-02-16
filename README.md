# Maybe

<img src="https://img.shields.io/badge/unity-2021.3-green.svg?style=flat-square" alt="unity 2021.3">

A Maybe type for use in Unity.

## What is it and why should I use it?

A Maybe, or [Option Type](https://en.wikipedia.org/wiki/Option_type), provides a generic mechanism for working with a return (or field etc.) that may or may not have a value in it.

- It's a struct, so avoids the potential for many tiny allocations that may occur if using a nullable int.
- Includes a number of extension methods for Linq, allowing for functional and [Railway](https://fsharpforfunandprofit.com/rop/) style programming.
- Tested against Unity specifics. So it handles things like GetComponent returning an object that says it's null but isn't `is null`.
- A git url package with source code, so no random dlls cluttering up your unity project or repo.

If you aren't in Unity or you don't need Unity specifics accounted for, you should go use [language-ext](https://github.com/louthy/language-ext/), or [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions), or perhaps [Optional](https://github.com/nlkl/Optional).

## Installation / Minimum required Setup

The required library is distributed as a git package ([How to install package from git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html))

### Git URL

```
https://github.com/ActuatorDigital/Maybe.git?path=Packages/Maybe
```

## Code Example

```csharp

go.GetComponentOrNone<Rigidbody>()
    .MatchSome(x => x.AddForce(Vector3.up));

```

The Tests in the package folder are also a great way to see what the package provides.
