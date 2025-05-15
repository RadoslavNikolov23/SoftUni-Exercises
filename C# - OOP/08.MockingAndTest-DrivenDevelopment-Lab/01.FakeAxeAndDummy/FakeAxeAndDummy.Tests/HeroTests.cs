using FakeAxeAndDummy.Interfaces;
using Moq;

namespace FakeAxeAndDummy.Tests;

[TestFixture]
public class HeroTests
{

    [Test]
    public void InitializationOfAHero()
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        int attackPoints = Random.Shared.Next(1, 100);
        int durabilityPoints = Random.Shared.Next(1, 100);
        weapon.Setup(w => w.AttackPoints).Returns(attackPoints);
        weapon.Setup(w => w.DurabilityPoints).Returns(durabilityPoints);

        Mock<IHero> hero = new Mock<IHero>();
        string name = GenerateRandomName();
        hero.Setup(h => h.Name).Returns(name);
        hero.Setup(h => h.Experience).Returns(0);
        hero.Setup(h => h.Weapon).Returns(weapon.Object);

        Assert.That(hero.Object.Name, Is.EqualTo(name));
        Assert.That(hero.Object.Experience, Is.EqualTo(0));
        Assert.That(hero.Object.Weapon.AttackPoints, Is.EqualTo(weapon.Object.AttackPoints));
        Assert.That(hero.Object.Weapon.DurabilityPoints, Is.EqualTo(weapon.Object.DurabilityPoints));
    }

    [Test]
    public void AttackMethodOfHero_WorksProperly()
    {
        Mock<ITarget> target = new Mock<ITarget>();
        int targetHealth = 0;
        int targetExperiance = Random.Shared.Next(1, 100);
        target.Setup(t => t.Health).Returns(targetHealth);
        target.Setup(t => t.GiveExperience()).Returns(targetExperiance);
        target.Setup(t => t.IsDead()).Returns(true);


        Mock<IHero> hero = GenerateHero();
        hero.SetupProperty(h => h.Experience);
        hero.Setup(h => h.Attack(It.IsAny<ITarget>())).Callback<ITarget>(t =>
        {
            hero.Object.Experience += t.GiveExperience();
        });

        int heroExperiance=hero.Object.Experience;
        hero.Object.Attack(target.Object);

        Assert.That(hero.Object.Experience,Is.EqualTo(heroExperiance+targetExperiance));
    }

    [Test]
    public void AttackMethodOfHeroThrowsException_IfTargetIsNotDead()
    {
        Mock<ITarget> target = new Mock<ITarget>();
        int targetHealth = Random.Shared.Next(1,100);
        int targetExperiance = Random.Shared.Next(1, 100);
        target.Setup(t => t.Health).Returns(targetHealth);
        target.Setup(t => t.GiveExperience()).Returns(() => throw new InvalidOperationException("Target is not dead."));
        target.Setup(t => t.IsDead()).Returns(false);


        Mock<IHero> hero = GenerateHero();
        hero.SetupProperty(h => h.Experience);
        hero.Setup(h => h.Attack(It.IsAny<ITarget>())).Callback<ITarget>(t =>
        {
            hero.Object.Experience += t.GiveExperience();
        });
        
        Assert.Throws<InvalidOperationException>(() => hero.Object.Attack(target.Object));
    }

    private Mock<IHero> GenerateHero()
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        int attackPoints = Random.Shared.Next(1, 100);
        int durabilityPoints = Random.Shared.Next(1, 100);
        weapon.Setup(w => w.AttackPoints).Returns(attackPoints);
        weapon.Setup(w => w.DurabilityPoints).Returns(durabilityPoints);

        Mock<IHero> hero = new Mock<IHero>();
        string name = GenerateRandomName();
        hero.Setup(h => h.Name).Returns(name);
        hero.Setup(h => h.Experience).Returns(0);
        hero.Setup(h => h.Weapon).Returns(weapon.Object);

        return hero;

    }
    private string GenerateRandomName()
    {
        string symbols = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbvcxzasdfghjklpoiuytrewq1234567890";
        int index = Random.Shared.Next(0, symbols.Length);
        string result = new string(Enumerable.Repeat(symbols, index).Select(l => l[Random.Shared.Next(l.Length)]).ToArray());

        return result;
    }
}
