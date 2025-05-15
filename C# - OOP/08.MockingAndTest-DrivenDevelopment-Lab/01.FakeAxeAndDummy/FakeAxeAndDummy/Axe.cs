using FakeAxeAndDummy.Interfaces;
using System;

// Axe durability drop with 5 
public class Axe: IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        if (attack < 0) throw new ArgumentOutOfRangeException("Attacking points can't be below 0!");
        if (durability < 0) throw new ArgumentOutOfRangeException("Durability points can't be below 0!");

        this.attackPoints = attack;
        this.durabilityPoints = durability;
    }

    public int AttackPoints => this.attackPoints;

    public int DurabilityPoints => this.durabilityPoints;

    public void Attack(ITarget target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }
}
