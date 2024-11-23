using FakeAxeAndDummy.Interfaces;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private int attackPoints;
    private int durabilityPoints;

    [SetUp]
    public void SetUpAttackAndDurabiltyPoints()
    {
        this.attackPoints = Random.Shared.Next(0, 100);
        this.durabilityPoints = Random.Shared.Next(0, 100);
    }
    [Test]
    public void InitializationOfAnObjectAxe()
    {
        Axe axe= GenerateRandomAxe();

        Assert.That(axe,Is.Not.Null);
        Assert.That(axe.AttackPoints,Is.EqualTo(this.attackPoints));
        Assert.That(axe.DurabilityPoints,Is.EqualTo(this.durabilityPoints));
    }   
    
    [TestCase(-1), TestCase(-10)]
    public void DoAxeConstructorThrowExcetion_WhenAttackPointsAreBelowZero(int attackPointsBelowZero)
    {
       Assert.Throws<ArgumentOutOfRangeException>(()=> new Axe(attackPointsBelowZero, this.durabilityPoints));
    } 

    [TestCase(-1), TestCase(-10)]
    public void DoAxeConstructorThrowExcetion_WhenDurabilityPointsAreBelowZero(int durabilityPointsBelowZero)
    {
       Assert.Throws<ArgumentOutOfRangeException>(()=> new Axe(this.attackPoints, durabilityPointsBelowZero));

    }

    [Test]
    public void DoAttackMethod_WorksPropertly()
    {

        Axe axe= new Axe(this.attackPoints, this.durabilityPoints+1);
        Dummy dummy = (Dummy)GenerateRandomITarget();
        int originalHealt=dummy.Health;
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints,Is.LessThan(this.durabilityPoints+1));
        Assert.That(axe.DurabilityPoints,Is.EqualTo(this.durabilityPoints));
        Assert.That(dummy.Health,Is.EqualTo(originalHealt-axe.AttackPoints));

    }

    private Axe GenerateRandomAxe()=>new Axe(this.attackPoints,this.durabilityPoints);

    private ITarget GenerateRandomITarget() => new Dummy(Random.Shared.Next(1,100),Random.Shared.Next());
}