using NUnit.Framework;
using System;

namespace Skeleton.Tests;

[TestFixture]
public class DummyTests
{
    private int healt, experience;

    [SetUp]
    public void SetUpThePropertiesHealtAndExperiance()
    {
        this.healt = Random.Shared.Next(1, 10);
        this.experience = Random.Shared.Next(1, 10);
    }

    [Test]
    public void TestIfIntanceDummyIsNotNull()
    {
        Dummy dummy = new Dummy(this.healt, this.experience);
        Assert.IsNotNull(dummy);

    }

    [Test]
    public void TestIfIntanceDummyHealtIsSet()
    {
        Dummy dummy = new Dummy(this.healt, this.experience);
        Assert.That(dummy.Health.Equals(this.healt));

    }

    [Test]
    public void TestIfDummysIsDead()
    {
        Dummy dummy = new Dummy(0, 0);
        Assert.That(dummy.IsDead(), Is.True);
    }

    [Test]
    public void TestCanDummyLoseHealtIfAttacked()
    {
        int attackPoints = this.healt - 1;
        Dummy dummy = new Dummy(this.healt, this.experience);
        dummy.TakeAttack(attackPoints);

        Assert.That(dummy.Health.Equals(this.healt - attackPoints));
    }

    [Test]
    public void TestDeadDummyThrowsAnExceptionAsExcecuted()
    {
        //•	Dead Dummy throws an exception if attacked

        int attackPoints = Random.Shared.Next(1, 10);
        Dummy dummy = new Dummy(0, this.experience);

        Assert.Throws<InvalidOperationException>(
            () => dummy.TakeAttack(attackPoints)
            );
    }

    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(-1)]
    public void TestIfDeadDummyCanGiveXP(int healtDead)
    {
        Dummy dummy = new Dummy(healtDead, this.experience);

        int expectedXP = dummy.GiveExperience();
        Assert.That(expectedXP.Equals(this.experience));
    }



    [Test]
    public void TestIfAliveDummyCantGiveXP()
    {
        Dummy dummy = new Dummy(this.healt, this.experience);

        int givenXP;

        Assert.Throws<InvalidOperationException>(
            () => givenXP = dummy.GiveExperience()
            );
    }
}