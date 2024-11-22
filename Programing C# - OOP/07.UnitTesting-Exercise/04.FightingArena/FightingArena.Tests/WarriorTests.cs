namespace FightingArena.Tests;

using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class WarriorTests
{
    private string _name;
    private int _damage, _hp;

    [SetUp]
    public void SetUpAWarrior()
    {
        this._name = GenerateRandomStringName();
        this._damage = GenerateRandomIntNumber();
        this._hp = GenerateRandomIntNumber();
    }

    [Test]
    public void InitializationOfAWarrior()
    {
        Warrior warrior = new Warrior(this._name, this._damage, this._hp);

        Assert.IsNotNull(warrior);
        Assert.That(warrior.Name, Is.EqualTo(this._name));
        Assert.That(warrior.Damage, Is.EqualTo(this._damage));
        Assert.That(warrior.HP, Is.EqualTo(this._hp));
    }

    [TestCaseSource(nameof(RandomEmptyCases))]
    public void DoesNameThrowExceptionWhenIsNullOrEmpty(string nameNullEmpty) => Assert.Throws<ArgumentException>(() => new Warrior(nameNullEmpty, this._damage, this._hp));

    [TestCase(0), TestCase(-1), TestCase(-5)]
    public void DoesDamageThrowExceptionWhenIsZeroOrNegative(int damaneZeroOrNegative) => Assert.Throws<ArgumentException>(() => new Warrior(this._name, damaneZeroOrNegative, this._hp));

    [TestCase(-1), TestCase(-5)]
    public void DoesHPThrowExceptionWhenIsNegative(int hpNegative) => Assert.Throws<ArgumentException>(() => new Warrior(this._name, this._damage, hpNegative));

    [TestCase(70, 35)]
    public void AttackMethodWorkWhenDamageIsMoreThanHPAfterAttack(int damageForTest, int hpForTest)
    {
        Warrior warriorOne = new Warrior(this._name, damageForTest, hpForTest * 2);
        Warrior warriorTwo = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);

        warriorOne.Attack(warriorTwo);
        Assert.That(warriorTwo.HP, Is.Zero);
    }

    [TestCase(70, 70)]
    public void AttackMethodWorkWhenDamageIsLessThanHPAfterAttackwhenIsZero(int damageForTest, int hpForTest)
    {
        Warrior warriorOne = new Warrior(this._name, damageForTest, hpForTest);
        Warrior warriorTwo = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);

        warriorOne.Attack(warriorTwo);
        Assert.That(warriorTwo.HP, Is.Zero);
    }

    [TestCase(75, 140), TestCase(100, 140)]
    public void AttackMethodWorkWhenDamageIsLessThanHPAfterAttackIfIsNotZero(int damageForTest, int hpForTest)
    {
        Warrior warriorOne = new Warrior(this._name, damageForTest, hpForTest);
        Warrior warriorTwo = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);

        warriorOne.Attack(warriorTwo);
        Assert.That(warriorTwo.HP, Is.LessThanOrEqualTo(warriorOne.Damage));
    }

    [TestCase(10), TestCase(25), TestCase(4)]
    public void DoesAttackMethodThrowExceptionWhenHPOfOriginalWaririorisLessThanMin30(int hpForTest)
    {
        Warrior warriorOne = new Warrior(this._name, this._damage, hpForTest);
        Warrior warriorTwo = GenerateRandomWarrior();

        var ex = Assert.Throws<InvalidOperationException>(() => warriorOne.Attack(warriorTwo));
        Assert.That(ex.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
    }

    [TestCase(10), TestCase(25), TestCase(4)]
    public void DoesAttackMethodThrowExceptionWhenHPOfSecondlWaririorisLessThanMin30(int hpForTest)
    {
        Warrior warriorOne = new Warrior(this._name, this._damage, hpForTest + 30);
        Warrior warriorTwo = new Warrior(this._name, this._damage, hpForTest);

        var ex = Assert.Throws<InvalidOperationException>(() => warriorOne.Attack(warriorTwo));
        Assert.That(ex.Message, Is.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
    }

    [TestCase(31), TestCase(41), TestCase(51)]
    public void DoesAttackMethodThrowExceptionWhenTheDamageOfTheSecondWarriorIsGreatherthanOriginalWarriorHP(int hpForTest)
    {
        Warrior warriorOne = new Warrior(this._name, this._damage, this._hp= hpForTest);
        Warrior warriorTwo = new Warrior(this._name, this._damage*hpForTest, this._hp);

        var ex = Assert.Throws<InvalidOperationException>(() => warriorOne.Attack(warriorTwo));
        Assert.That(ex.Message, Is.EqualTo("You are trying to attack too strong enemy"));
    }

    private Warrior GenerateRandomWarrior() => new Warrior(this._name, this._damage, this._hp);

    private string GenerateRandomStringName()
    {
        Random random = new Random();
        int leght = random.Next(0, 1000);
        string charectarsAll = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string result = new string(Enumerable.Repeat(charectarsAll, leght).Select(x => x[random.Next(x.Length)]).ToArray());
        return result;
    }

    private int GenerateRandomIntNumber() => Random.Shared.Next(1, 200);

    private static IEnumerable<object[]> RandomEmptyCases()
    {
        yield return new object[] { null };
        yield return new object[] { string.Empty };
    }
}