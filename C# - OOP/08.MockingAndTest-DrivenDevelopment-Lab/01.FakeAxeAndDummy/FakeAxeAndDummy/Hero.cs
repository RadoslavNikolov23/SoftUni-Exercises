using FakeAxeAndDummy.Interfaces;

public class Hero : IHero
{
    private string name;
    private int experience;
    private IWeapon weapon;

    public Hero(string name)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = new Axe(10, 10);
    }

    public string Name => this.name;

    public int Experience
    {
        get => this.experience;
        set => this.experience = value;
    }

    public IWeapon Weapon => this.weapon;

    public void Attack(ITarget target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
