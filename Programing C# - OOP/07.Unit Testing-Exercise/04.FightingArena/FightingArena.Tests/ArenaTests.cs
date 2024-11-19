namespace FightingArena.Tests;

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json.Bson;
using System.Xml.Linq;

[TestFixture]
public class ArenaTests
{
    private string _name;
    private int _damage, _hp;

    [Test]
    public void InitializationOfArena()
    {
        int numberOfWarriors = Random.Shared.Next(1, 10);
        Arena warriors = new Arena();
        for (int i = 0; i < numberOfWarriors; i++)
        {
            warriors.Enroll(GenerateRandomWarrior());
            Assert.That(warriors.Count, Is.EqualTo(i+1));
        }
        Assert.That(warriors, Is.Not.Null);
    }

    [Test]
    public void DoesAreanaWarriorGetterReturnTheSameCollection()
    {
        int numberOfWarriors = Random.Shared.Next(1, 10);
        Arena warriors = new Arena();
        List<Warrior> testWarrios = new List<Warrior>();
        for (int i = 0; i < numberOfWarriors; i++)
        {
            Warrior warriorTest = GenerateRandomWarrior();
            warriors.Enroll(warriorTest);
            testWarrios.Add(warriorTest);
        }

        int count = 0;
        foreach (Warrior warrior in warriors.Warriors)
            Assert.That(warrior, Is.EqualTo(testWarrios[count++]));

    }

    [Test]
    public void DoesEnrolMethodWorkProperly()
    {
        int numberOfWarriors = Random.Shared.Next(1, 10);
        Arena warriors = new Arena();
        for (int i = 0; i < numberOfWarriors; i++)
        {
            warriors.Enroll(GenerateRandomWarrior());
            Assert.That(warriors.Count, Is.EqualTo(i + 1));
        }
    }

    [Test]
    public void DoesEnrolMethodWorkThrowExceptionWhenEnrolsTheSameWarrior()
    {
        Arena warriors = new Arena();
        Warrior warrior = GenerateRandomWarrior();
        warriors.Enroll(warrior);

        var ex=Assert.Throws<InvalidOperationException>(() => warriors.Enroll(warrior));
        Assert.That(ex.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
    }

    [TestCase(70, 35)]
    public void DoFigthMethodWorksWhenAttackerDammageIsMorethanDeffenderHP(int damageForTest, int hpForTest)
    {
        Warrior warriorOneAttacker = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest * 2);
        Warrior warriorTwoDeffender = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);

        Arena arena = new Arena();
        arena.Enroll(warriorOneAttacker);
        arena.Enroll(warriorTwoDeffender);

        arena.Fight(warriorOneAttacker.Name,warriorTwoDeffender.Name);
        Assert.That(warriorTwoDeffender.HP, Is.Zero);

    }


    [TestCase(70, 70)]
    public void DoFigthMethodWorksWhenAttackerDammageIsLessthanDeffenderHPWhenHPIsZeroAfterAttack(int damageForTest, int hpForTest)
    {
        Warrior warriorOneAttacker = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);
        Warrior warriorTwoDeffender = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);

        Arena arena = new Arena();
        arena.Enroll(warriorOneAttacker);
        arena.Enroll(warriorTwoDeffender);

        arena.Fight(warriorOneAttacker.Name, warriorTwoDeffender.Name);
        Assert.That(warriorTwoDeffender.HP, Is.Zero);
    }

    [TestCase(75, 140), TestCase(100, 140)]
    public void DoFigthMethodWorksWhenAttackerDammageIsLessthanDeffenderHPWhenHPIsNotZeroAfterAttack(int damageForTest, int hpForTest)
    {
        Warrior warriorOneAttacker = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);
        Warrior warriorTwoDeffender = new Warrior(GenerateRandomStringName(), damageForTest, hpForTest);

        Arena arena = new Arena();
        arena.Enroll(warriorOneAttacker);
        arena.Enroll(warriorTwoDeffender);

        arena.Fight(warriorOneAttacker.Name, warriorTwoDeffender.Name);
        Assert.That(warriorTwoDeffender.HP, Is.LessThanOrEqualTo(warriorOneAttacker.Damage));
    }


    [Test]
    public void DoFigthMethodThrowExceptionWhenAttackerNameIsNull()
    {
        Warrior warriorTwoDeffender = GenerateRandomWarrior();

        Arena arena = new Arena();
        arena.Enroll(warriorTwoDeffender);

        string missingName = null;
        var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight(missingName, warriorTwoDeffender.Name));
        Assert.That(ex.Message, Is.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
    }

    [Test]
    public void DoFigthMethodThrowExceptionWhenDeffederNameIsNull()
    {
        Warrior warriorOneAttacker = GenerateRandomWarrior();

        Arena arena = new Arena();
        arena.Enroll(warriorOneAttacker);

        string missingName = null;
        var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorOneAttacker.Name, null));
        Assert.That(ex.Message, Is.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
    }


    private Warrior GenerateRandomWarrior()
    {
        this._name = GenerateRandomStringName();
        this._damage = GenerateRandomIntNumber();
        this._hp = GenerateRandomIntNumber();

        return new Warrior(this._name, this._damage, this._hp);
    }

    private string GenerateRandomStringName()
    {
        Random random = new Random();
        int leght = random.Next(0, 1000);
        string charectarsAll = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string result = new string(Enumerable.Repeat(charectarsAll, leght).Select(x => x[random.Next(x.Length)]).ToArray());
        return result;
    }

    private int GenerateRandomIntNumber() => Random.Shared.Next(1, 200);
}
