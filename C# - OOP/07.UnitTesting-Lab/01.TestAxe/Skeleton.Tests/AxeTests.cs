using NUnit.Framework;
using System;

namespace Skeleton.Tests;

[TestFixture]
public class AxeTests
{
    private int attackPoints, durabilityPoints;

    [SetUp]
    public void SetpUpAttackPointsAndDurabilityPoints()
    {
        this.attackPoints = Random.Shared.Next(1, 10);
        this.durabilityPoints = Random.Shared.Next(1, 10);
    }

    [Test]
    public void CreateIntanceOfAnAxeAndTestIfIntanceIsNotNull()
    {
        Axe axe = new Axe(attackPoints, durabilityPoints);
        Assert.IsNotNull(axe);

    }

    [Test]
    public void CreateIntanceOfAnAxeAndTestAttackPoints()
    {
        Axe axe = new Axe(attackPoints, durabilityPoints);
        Assert.That(axe.AttackPoints, Is.EqualTo(attackPoints));

    }

    [Test]
    public void CreateIntanceOfAnAxeAndTestDurabilityPoints()
    {
        Axe axe = new Axe(attackPoints, durabilityPoints);
        Assert.That(axe.AttackPoints, Is.EqualTo(attackPoints));

    }



    [Test]
    public void SingleTestIfAttackMethodWorks()
    {
        Axe axe = new Axe(attackPoints, durabilityPoints);
        Dummy dummy = new Dummy(attackPoints, 0);

        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints.Equals(this.durabilityPoints - 1));
    }

    [Test]
    public void TestIfAttackMethodWorks()
    {
        Axe axe = new Axe(attackPoints, durabilityPoints);

        for (int i = 0; i < durabilityPoints; i++)
        {
            Dummy dummy = new Dummy(attackPoints, 0);

            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints.Equals(this.durabilityPoints - (i + 1)));
        }
    }


    [TestCase(0)]
    [TestCase(-5)]
    public void TestIfAttackMethodThorwsAcceptionIfDummyIsDead(int durability)
    {
        Axe axe = new Axe(attackPoints,durability);

        Dummy dummy = new Dummy(attackPoints, 0);

        Assert.Throws<InvalidOperationException>(
            () => axe.Attack(dummy)
            );
    }

}