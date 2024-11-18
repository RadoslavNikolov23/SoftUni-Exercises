namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private long _id;
        private string _userName;
        private long GenerateRandomId()
        {
            return Random.Shared.Next(1, 100000);
        }
        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string result = new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
            return result;

        }

        private Person GenerateRandomPersons()
        {
            return new Person(GenerateRandomId(), GenerateRandomString(Random.Shared.Next(1, 100)));
        }

        [Test]
        public void InitializationOfPerson()
        {
            Person person = GenerateRandomPersons();
            Assert.IsNotNull(person);
        }

        [TestCase(16)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(1)]
        public void InitializationOfDataBaseWithLessThan16People(int length)
        {
            Person[] persons = new Person[length];
            for (int i = 0; i < length; i++)
                persons[i] = GenerateRandomPersons();

            Database db = new Database(persons);
            Assert.IsNotNull(db);

        }

        [TestCase(17)]
        [TestCase(20)]
        public void OutOfRangeExceptionTest(int lenght)
        {
            Person[] persons = new Person[lenght];
            for (int i = 0; i < lenght; i++)
                persons[i] = GenerateRandomPersons();

            Assert.Throws<ArgumentException>(
                () => new Database(persons));

        }

        [TestCase(17)]
        [TestCase(20)]
        public void AddRangeMethodChechIfOver16ThrownsAnException(int numberOfPeople)
        {
            Person[] persons = new Person[numberOfPeople];
            for (int i = 0; i < numberOfPeople; i++)
                persons[i] = GenerateRandomPersons();

            MethodInfo methods = typeof(Database).GetMethod("AddRange", BindingFlags.Instance | BindingFlags.NonPublic);

            Database database = new Database();

            //-- Short Version:
            Assert.That((Assert.Throws<TargetInvocationException>(() => methods.Invoke(database, new object[] { persons }))).InnerException.GetType(), Is.EqualTo(typeof(ArgumentException)));

            //-- Extendet Version:
            //var exception = Assert.Throws<TargetInvocationException>(() => methods.Invoke(database, new object[] { persons }));
            //Assert.That(exception.InnerException.GetType(), Is.EqualTo(typeof(ArgumentException)));

        }

        [Test]
        public void AddMethodDoesItWorkNormally()
        {
            Person persons = GenerateRandomPersons();
            Database db= new Database();

            db.Add(persons);
            
            Assert.IsTrue(db.Count==1);
        }

        [TestCase(4)]
        [TestCase(1)]
        public void AddMethodWhenCountisGreatherThan16(int personsToAddNumber)
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < 16; i++)
                persons[i] = GenerateRandomPersons();

            Database db = new Database(persons);

            for(int i=0;i<personsToAddNumber;i++)
            Assert.Throws<InvalidOperationException>(
                () => db.Add(GenerateRandomPersons()));

        }

        [Test]
        public void AddMethodIfPersonIdExist()
        {
            Person firstPerson= GenerateRandomPersons();
            long idPerson=firstPerson.Id;
            string namePerson = GenerateRandomString(50);

            Database db= new Database(firstPerson);
            Assert.Throws<InvalidOperationException>(
              () => db.Add(new Person(idPerson,namePerson)));
        }

        [Test]
        public void AddMethodIfPersonNameExist()
        {
            Person firstPerson = GenerateRandomPersons();
            long idPerson = GenerateRandomId();
            string namePerson = firstPerson.UserName;

            Database db = new Database(firstPerson);
            Assert.Throws<InvalidOperationException>(
              () => db.Add(new Person(idPerson, namePerson)));
        }

        [Test]
        public void RemoveMethodInDataBaseWorksProperly()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            db.Remove();

            Assert.That(db.Count, Is.EqualTo(0));
        }    
        
        [Test]
        public void RemoveMethodInDataBaseWorksProperlyIfTheresMoreThanOnePerson()
        {
            Person[] persons = new Person[] { GenerateRandomPersons(), GenerateRandomPersons(), GenerateRandomPersons() };
            int originalPersonsNumber= persons.Length;
            Database db = new Database(persons);
            db.Remove();

            Assert.That(db.Count, Is.LessThan(originalPersonsNumber));
        }

        [Test]
        public void RemoveMethodIfThereNoPersonsShouldThrowException()
        {
            Database db = new Database();

            Assert.Throws< InvalidOperationException>(()=>db.Remove());
        }

        [Test]
        public void FindByIdMethodsWorks()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            long id=person.Id;

            Person resultPerson= db.FindById(id);

            Assert.That(person.Equals(resultPerson));
        }

        [Test]
        public void FindByIDMethodDoesItThrowExceptionIfTheresNoUserWithGivenID()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            long id = GenerateRandomId();

            Assert.Throws<InvalidOperationException>(() => db.FindById(id));
        }   
        
        [TestCase(-1)]
        [TestCase(-100)]
        public void FindByIDMethodDoesItThrowExceptionIfIdIsLessThanZero(long numberForID)
        {
            Database db = new Database();
            long id = numberForID;

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(id));

        }

        [Test]
        public void FindBUserNameMethodsWorks()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            string userName=person.UserName;

            Person resultPerson = db.FindByUsername(userName);

            Assert.That(person.Equals(resultPerson));

        }

        [Test]
        public void FindByUserNameMethodDoesItThrowExceptionIfTheresNoUserWithGivenName()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            string userName = GenerateRandomString(1000);

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(userName));

        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByNameMethodDoesItThrowExceptionIfNameIsNullOrEmpty(string userName)
        {
            Database db = new Database();

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(userName));

        }

        [Test]
        public void FindByNameMethodIsItCaseSensative()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            string userName=person.UserName.ToLower();

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(userName));

        }

    }
}