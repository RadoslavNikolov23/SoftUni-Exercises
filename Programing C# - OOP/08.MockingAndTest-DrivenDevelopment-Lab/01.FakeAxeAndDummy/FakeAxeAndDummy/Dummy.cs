using FakeAxeAndDummy.Interfaces;
using System;

public class Dummy : ITarget
{
    private int health;
    private int experience;

    public Dummy(int health, int experience)
    {
        if (health < 0) throw new ArgumentOutOfRangeException("Health can't be below zero!");
        if (experience < 0) throw new ArgumentOutOfRangeException("Experience can't be below zero!");

        this.health = health;
        this.experience = experience;
    }

    public int Health
    {
        get { return this.health; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }
}
