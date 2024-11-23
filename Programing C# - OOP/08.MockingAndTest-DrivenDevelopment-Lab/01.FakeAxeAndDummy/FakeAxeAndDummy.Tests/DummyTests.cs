using NUnit.Framework;
using System.Reflection;

[TestFixture]
public class DummyTests
{
    private int health;
    private int experience;

    [SetUp]
    public void SetUpHealthAndExperiencePoints()
    {
        this.health = Random.Shared.Next(1, 100);
        this.experience = Random.Shared.Next(1, 100);
    }
    [Test]
    public void InitializationOfDummy()
    {
        Dummy dummy = GenerateRandomDummy();

        Assert.That(dummy, Is.Not.Null);
        Assert.That(dummy.Health, Is.EqualTo(this.health));

        FieldInfo fieldExperiance = typeof(Dummy).GetField("experience", BindingFlags.Instance | BindingFlags.NonPublic);

        Assert.That(fieldExperiance.GetValue(dummy), Is.EqualTo(this.experience));
    }

    [TestCase(-15), TestCase(-1)]
    public void DoDummyConstructorThorwsException_WhenHealthIsBelowZero(int healthForTest)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Dummy(healthForTest, this.experience));

    }

    [TestCase(-15), TestCase(-1)]
    public void DoDummyConstructorThorwsException_WhenExperianceIsBelowZero(int experianceForTest)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Dummy(this.health, experianceForTest));

    }

    [TestCase(0)]
    public void IsDeadMethod_WorksProperly_RetursTrue(int healthForTest)
    {
        Dummy dummy = new Dummy(healthForTest, this.experience);
        Assert.That(dummy.IsDead(), Is.True);
    }

    [TestCase]
    public void IsDeadMethod_WorksProperly_RetursFalse()
    {
        Dummy dummy = GenerateRandomDummy();
        Assert.That(dummy.IsDead(), Is.False);
    }

    [TestCase(0)]
    public void GiveExperianceMethod_WorksProperly(int healthForTest)
    {
        Dummy dummy = new Dummy(healthForTest, this.experience);
        int experianceObtain = dummy.GiveExperience();

        FieldInfo fieldExperiance = typeof(Dummy).GetField("experience", BindingFlags.Instance | BindingFlags.NonPublic);

        Assert.That(fieldExperiance.GetValue(dummy), Is.EqualTo(experianceObtain));

    }

    [TestCase]
    public void GiveExperianceMethodThrowsException_WhenTargetIsNotDead()
    {
        Dummy dummy = GenerateRandomDummy();
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

    }

    [Test]
    public void TakeAttackMethod_WorksProperly_AndRetursZeroHealt()
    {
        Dummy dummy = GenerateRandomDummy();
        int attackPoints = this.health;
        dummy.TakeAttack(attackPoints);

        Assert.That(dummy.Health, Is.Zero);
    }

    [Test]
    public void TakeAttackMethodThrowsException_WhenDummyIsDead()
    {
        Dummy dummy = GenerateRandomDummy();
        int attackPoints = this.health*2;
        dummy.TakeAttack(attackPoints);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
    }

    private Dummy GenerateRandomDummy() => new Dummy(this.health, this.experience);
}
