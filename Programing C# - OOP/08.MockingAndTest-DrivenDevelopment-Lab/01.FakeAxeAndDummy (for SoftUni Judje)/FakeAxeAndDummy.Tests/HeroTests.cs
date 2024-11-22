using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private Mock<IWeapon> weapon;
        private Mock<ITarget> target;
        private Hero hero;

        [SetUp]
        public void Setup()
        {
            this.weapon = new Mock<IWeapon>();
            this.target = new Mock<ITarget>();
            this.hero = new Hero("Tom", this.weapon.Object);
        }

        [Test]
        public void DoesHeroGainExperiance_WhenTargetIsDead()
        {
            int experiancePoints = 50;

            this.target.Setup(t => t.Health).Returns(0);
            this.target.Setup(t => t.GiveExperience()).Returns(experiancePoints);
            this.target.Setup(target => target.IsDead()).Returns(true);

            this.hero.Attack(this.target.Object);

            Assert.That(this.hero.Experience, Is.EqualTo(experiancePoints));
        }
    }
}
