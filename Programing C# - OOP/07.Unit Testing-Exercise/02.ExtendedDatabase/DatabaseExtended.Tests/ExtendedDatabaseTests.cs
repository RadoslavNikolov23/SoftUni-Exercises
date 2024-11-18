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
        private const int MaxSizeOfPersonsInDataBase = 16;

        [Test]
        public void InitializationOfPerson()
        {
            Person person = GenerateRandomPersons();
            Assert.IsNotNull(person);
        }

        [TestCase(1), TestCase(5), TestCase(10), TestCase(MaxSizeOfPersonsInDataBase)]
        public void InitializationOfDataBaseWithLessThan16People(int length)
        {
            Person[] persons = GenerateRandomPersonsArray(length);
            Database db = new Database(persons);

            Assert.IsNotNull(db);

        }

        [TestCase(17), TestCase(20)]
        public void OutOfRangeExceptionTest(int lenght)
        {
            Person[] persons = GenerateRandomPersonsArray(lenght);
            Assert.Throws<ArgumentException>(
                () => new Database(persons));

        }

        [TestCase(17), TestCase(20)]
        public void AddRangeMethodChechIfOver16ThrownsAnException(int numberOfPeople)
        {
            Person[] persons = GenerateRandomPersonsArray(numberOfPeople);

            MethodInfo methods = typeof(Database).GetMethod("AddRange", BindingFlags.Instance | BindingFlags.NonPublic);

            Database database = new Database();

            //-- Short Version:
            Assert.That((Assert.Throws<TargetInvocationException>(() => methods.Invoke(database, new object[] { persons }))).InnerException.GetType(), Is.EqualTo(typeof(ArgumentException)));

            //-- Extendet Version:
            //var exception = Assert.Throws<TargetInvocationException>(() => methods.Invoke(database, new object[] { persons }));
            //Assert.That(exception.InnerException.GetType(), Is.EqualTo(typeof(ArgumentException)));

        }

        [TestCase(1), TestCase(6), TestCase(10), TestCase(MaxSizeOfPersonsInDataBase)]
        public void AddMethodDoesItWorkNormally(int numberOfPeople)
        {
            Person[] persons = GenerateRandomPersonsArray(numberOfPeople);
            Database db = new Database();

            for (int i = 0; i < persons.Length; i++)
            {
                db.Add(persons[i]);
            }
            Assert.IsTrue(db.Count == persons.Length);
        }

        [TestCase(4), TestCase(1), TestCase(10)]
        public void AddMethodWhenCountisGreatherThan16(int personsToAddNumber)
        {
            Person[] persons = GenerateRandomPersonsArray(MaxSizeOfPersonsInDataBase);
            Database db = new Database(persons);

            for (int i = 0; i < personsToAddNumber; i++)
                Assert.Throws<InvalidOperationException>(
                    () => db.Add(GenerateRandomPersons()));

        }

        [Test]
        public void AddMethodIfPersonIdExist()
        {
            Person firstPerson = GenerateRandomPersons();
            long idPerson = firstPerson.Id;
            string namePerson = GenerateRandomString();

            Database db = new Database(firstPerson);
            Assert.Throws<InvalidOperationException>(
              () => db.Add(new Person(idPerson, namePerson)));
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

        [TestCase(4), TestCase(1), TestCase(10)]
        public void RemoveMethodInDataBaseWorksProperly(int numberOfPeople)
        {
            Person[] persons = GenerateRandomPersonsArray(numberOfPeople);
            int originalPersonsNumber = persons.Length;
            Database db = new Database(persons);

            for (int i = 0; i < persons.Length; i++)
                db.Remove();

            Assert.That(db.Count, Is.LessThan(originalPersonsNumber));
            Assert.That(db.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMethodIfThereNoPersonsShouldThrowException()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FindByIdMethodsWorks()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            long id = person.Id;

            Person resultPerson = db.FindById(id);

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

        [TestCase(-1), TestCase(-100)]
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
            string userName = person.UserName;

            Person resultPerson = db.FindByUsername(userName);

            Assert.That(person.Equals(resultPerson));
        }

        [Test]
        public void FindByUserNameMethodDoesItThrowExceptionIfTheresNoUserWithGivenName()
        {
            Person person = GenerateRandomPersons();
            Database db = new Database(person);
            string userName = GenerateRandomString();

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(userName));
        }

        [TestCase(""), TestCase(null)]
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
            string userName = person.UserName.ToLower();

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(userName));
        }

        private long GenerateRandomId()
        {
            return Random.Shared.Next(1, 100000);
        }

        private string GenerateRandomString()
        {
            Random random = new Random();
            int length = Random.Shared.Next(52);
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string result = new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
            return result;

        }

        private Person GenerateRandomPersons()
        {
            return new Person(GenerateRandomId(), GenerateRandomString());
        }

        private Person[] GenerateRandomPersonsArray(int lenght)
        {
            Person[] persons = new Person[lenght];
            for (int i = 0; i < lenght; i++)
                persons[i] = GenerateRandomPersons();

            return persons;
        }

    }
}