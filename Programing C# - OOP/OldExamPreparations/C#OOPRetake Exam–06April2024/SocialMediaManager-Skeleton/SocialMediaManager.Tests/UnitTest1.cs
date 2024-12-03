using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {

        [Test]
        public void InfuencerRepositoryInitialization()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Assert.IsNotNull(influencerRepository);
            Assert.That(influencerRepository.Influencers.Count(), Is.EqualTo(0));
        }

        [Test]
        public void RegisterInfluencer_WorksCorrelcy()
        {
            Influencer influencer = new Influencer("Tom", 50);
            InfluencerRepository influencerRepository = new InfluencerRepository();

            Assert.That(influencerRepository.Influencers.Count(), Is.EqualTo(0));

            string result=influencerRepository.RegisterInfluencer(influencer);
            Assert.That(influencerRepository.Influencers.Count(), Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Successfully added influencer {influencer.Username} with {influencer.Followers}"));

        }

        [Test]
        public void RegisterInfluencer_ThrowsExceptionWhenInfluencerIsNull()
        {
            Influencer influencer = null;
            InfluencerRepository influencerRepository = new InfluencerRepository();

            
            var exception=Assert.Throws<ArgumentNullException>(()=>influencerRepository.RegisterInfluencer(influencer));
            Assert.That(exception.Message, Is.EqualTo("Influencer is null (Parameter 'influencer')"));
     

        }


        [Test]
        public void RegisterInfluencer_ThrowsException_WhenTheInfuencerIsAlreadyExistet()
        {
            Influencer influencer = new Influencer("Tom", 50);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            string result = influencerRepository.RegisterInfluencer(influencer);
            var exception = Assert.Throws<InvalidOperationException>(() => influencerRepository.RegisterInfluencer(influencer));
            Assert.That(exception.Message, Is.EqualTo($"Influencer with username {influencer.Username} already exists"));

        }


        [Test]
        public void RemoveInfluencer_WorksCorrelcy()
        {
            Influencer influencer = new Influencer("Tom", 50);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencer);
            bool isRemoved = influencerRepository.RemoveInfluencer(influencer.Username);
            
            Assert.That(isRemoved, Is.EqualTo(true));

            Assert.That(influencerRepository.Influencers.Count(), Is.EqualTo(0));

        }



        [Test]
        public void RemoveInfluencer_WorksCorrelcy_ButReturnsFalse()
        {
            Influencer influencer = new Influencer("Tom", 50);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencer);
            bool isRemoved = influencerRepository.RemoveInfluencer("Rado");

            Assert.That(isRemoved, Is.EqualTo(false));

            Assert.That(influencerRepository.Influencers.Count(), Is.EqualTo(1));

        }

        [Test]
        public void RemoveInfluencer_ThrowsException_WhenNameIsNull()
        {
            Influencer influencer = new Influencer("Tom", 50);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencer);
            var exception = Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(null));
            Assert.That(exception.Message, Is.EqualTo("Username cannot be null (Parameter 'username')"));


        }



        [Test]
        public void RemoveInfluencer_ThrowsException_WhenNameIsWhiteSpace()
        {
            Influencer influencer = new Influencer("Tom", 50);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencer);
            var exception = Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(" "));
            Assert.That(exception.Message, Is.EqualTo("Username cannot be null (Parameter 'username')"));


        }

        [Test]
        public void GetInfluencerWithMostFollowers_WorksCorrelcy()
        {
            Influencer influencerTom = new Influencer("Tom", 50);
            Influencer influencerJerry = new Influencer("Jerry", 5500);
            Influencer influencerSpike = new Influencer("Spike", 1050);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencerTom);
            influencerRepository.RegisterInfluencer(influencerJerry);
            influencerRepository.RegisterInfluencer(influencerSpike);

            Influencer higthesFollowers=influencerRepository.GetInfluencerWithMostFollowers();
            Assert.That(higthesFollowers, Is.EqualTo(influencerJerry));
            Assert.That(higthesFollowers.Username, Is.EqualTo(influencerJerry.Username));
            Assert.That(higthesFollowers.Followers, Is.EqualTo(influencerJerry.Followers));
    

        }

        [Test]
        public void GetInfluencerWithMostFollowers_ThrowsException()
        {
            
            InfluencerRepository influencerRepository = new InfluencerRepository();


            Assert.Throws<IndexOutOfRangeException>(()=>influencerRepository.GetInfluencerWithMostFollowers());



        }


        [Test]
        public void GetInfluencer_WorksCorrelcy()
        {
            Influencer influencerTom = new Influencer("Tom", 50);
            Influencer influencerJerry = new Influencer("Jerry", 5500);
            Influencer influencerSpike = new Influencer("Spike", 1050);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencerTom);
            influencerRepository.RegisterInfluencer(influencerJerry);
            influencerRepository.RegisterInfluencer(influencerSpike);

            Influencer tomTheInfluencer = influencerRepository.GetInfluencer("Tom");
            Assert.That(tomTheInfluencer, Is.EqualTo(influencerTom));
            Assert.That(tomTheInfluencer.Username, Is.EqualTo(influencerTom.Username));
            Assert.That(tomTheInfluencer.Followers, Is.EqualTo(influencerTom.Followers));


        }


        [Test]
        public void GetInfluencer_WorksCorrelcy_ButReturnsNull()
        {
            Influencer influencerTom = new Influencer("Tom", 50);
            Influencer influencerJerry = new Influencer("Jerry", 5500);
            Influencer influencerSpike = new Influencer("Spike", 1050);
            InfluencerRepository influencerRepository = new InfluencerRepository();


            influencerRepository.RegisterInfluencer(influencerTom);
            influencerRepository.RegisterInfluencer(influencerJerry);
            influencerRepository.RegisterInfluencer(influencerSpike);

            Influencer tomTheInfluencer = influencerRepository.GetInfluencer("Duke");
            Assert.That(tomTheInfluencer, Is.Null);
        


        }

    }
}