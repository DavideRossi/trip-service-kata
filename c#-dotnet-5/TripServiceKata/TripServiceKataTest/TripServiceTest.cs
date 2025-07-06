using NUnit.Framework;
using TripServiceKata.Services;
using TripServiceKata.Model;
using System.Collections.Generic;

namespace TripServiceKata.Tests;

[TestFixture]
public class TripServiceTest
{
    [Test]
    public void Foo()
    {
        List<string> list = ["a", "b", "c"];
        Assert.That(list, Is.EquivalentTo(["c", "b", "a"]));
    }
}
