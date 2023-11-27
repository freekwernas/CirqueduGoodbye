using ApplicationCore.ObjectClasses;
using ApplicationCore.Interfaces;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class AlgorithmTests
    {
        


        [TestMethod]
        public void LoadWagonTest()
        {
            
            Circus Circus = new Circus(1);
            Circus.CircusAnimals.Add(new Carnivore("Lion", 5, 1));
            Circus.CircusAnimals.Add(new Herbivore("Hippo", 5, 1));
            Circus.CircusAnimals.Add(new Carnivore("Cheeta", 3, 1));
            Circus.CircusAnimals.Add(new Herbivore("Giraffe", 5, 1));
            Circus.CircusAnimals.Add(new Carnivore("Tiger", 5, 1));
            Circus.CircusAnimals.Add(new Carnivore("Piranha", 1, 1));
            Circus.CircusAnimals.Add(new Carnivore("Piranha", 1, 1));
            Circus.CircusAnimals.Add(new Herbivore("Chicken", 1, 1));
            Circus.CircusAnimals.Add(new Carnivore("Dog", 3, 1));
            Circus.CircusAnimals.Add(new Herbivore("Squirrel", 1, 1));
            Circus.CircusAnimals.Add(new Herbivore("Goat", 3, 1));

            //Optimal solution
            Train train = new Train();
            TrainWagon wagon1 = new TrainWagon(10);
            wagon1.TryAddAnimal( new Carnivore("Lion", 5, 1) );
            train.AddWagon(wagon1);
            TrainWagon wagon2 = new TrainWagon(10);
            wagon2.TryAddAnimal(new Carnivore("Tiger", 5, 1) );
            train.AddWagon(wagon2);
            TrainWagon wagon3 = new TrainWagon(10);
            wagon3.TryAddAnimal(new Carnivore("Cheeta", 3, 1));
            wagon3.TryAddAnimal(new Herbivore("Hippo", 5, 1));
            train.AddWagon(wagon3);
            TrainWagon wagon4 = new TrainWagon(10);
            wagon4.TryAddAnimal(new Carnivore("Dog", 3, 1));
            wagon4.TryAddAnimal(new Herbivore("Giraffe", 5, 1));
            train.AddWagon(wagon4);
            TrainWagon wagon5 = new TrainWagon(10);
            wagon5.TryAddAnimal(new Carnivore("Piranha", 1, 1));
            wagon5.TryAddAnimal(new Herbivore("Goat", 3, 1));
            train.AddWagon(wagon5);
            TrainWagon wagon6 = new TrainWagon(10);
            wagon6.TryAddAnimal(new Carnivore("Piranha", 1, 1) );
            train.AddWagon(wagon6);
            TrainWagon wagon7 = new TrainWagon(10);
            wagon7.TryAddAnimal(new Herbivore("Chicken", 1, 1));
            wagon7.TryAddAnimal(new Herbivore("Squirrel", 1, 1));
            train.AddWagon(wagon7);

            //Serialize object into JSON format, because the CollectionAssert uses a reference in the object.Equals method from IEnumerable
            var expectedString = Newtonsoft.Json.JsonConvert.SerializeObject(train.WagonList);
            var actualString = Newtonsoft.Json.JsonConvert.SerializeObject(Circus.CalculateTrain().WagonList);

            Assert.AreEqual(expectedString, actualString); 
        }

        [TestMethod]
        public void TestCarnivoreConstraint()
        {
            //Clean instance
            Circus CarnivoreCircus = new Circus(1);
            CarnivoreCircus.CircusAnimals.Add(new Carnivore("Lion", 5, 1));
            CarnivoreCircus.CircusAnimals.Add(new Carnivore("Tiger", 5, 1));

            Train CarnivoreTrain = CarnivoreCircus.CalculateTrain();

            //Clean unstance
            Circus HerbivoreCircus = new Circus(1);
            HerbivoreCircus.CircusAnimals.Add(new Herbivore("Hippo", 5, 1));
            HerbivoreCircus.CircusAnimals.Add(new Herbivore("Giraffe", 5, 1));

            Train HerbivoreTrain = HerbivoreCircus.CalculateTrain();

            //Checks to see if any carnivores have been put together
            Assert.IsTrue(CarnivoreTrain.WagonList.Count > HerbivoreTrain.WagonList.Count);
        }

        [TestMethod]
        public void TestOtherAnimalConsumptionSingular()
        {
            Carnivore carnivore = new Carnivore("Cheeta", 3, 1);

            Animal testanimalOne = new Herbivore("Hippo", 5, 1);
            Animal testanimalTwo = new Herbivore("Chicken", 1, 1);
            Animal testanimalThree = new Carnivore("Dog", 3, 1);

            Assert.IsFalse(carnivore.WillEatAnimal(testanimalOne));
            Assert.IsTrue(carnivore.WillEatAnimal(testanimalTwo));
            Assert.IsTrue(carnivore.WillEatAnimal(testanimalThree));
        }

        [TestMethod]
        public void TestOtherAnimalConsumptionMultiple()
        {
            Carnivore carnivore = new Carnivore("Cheeta", 3, 1);
            List<IAnimal> animalsOne = new List<IAnimal> { new Carnivore("Dog", 3, 1), new Herbivore("Giraffe", 5, 1) };
            List<IAnimal> animalsTwo = new List<IAnimal> { new Herbivore("Hippo", 5, 1), new Herbivore("Giraffe", 5, 1) };

            Assert.IsFalse(carnivore.WillEatAnyAnimal(animalsTwo));
            Assert.IsTrue(carnivore.WillEatAnyAnimal(animalsOne));
        }

        [TestMethod]
        public void TestGetConsumedByAnimalSingular()
        {
            Herbivore herbivore = new Herbivore("sheep", 3, 1);

            Animal testanimalOne = new Carnivore("Piranha", 1, 1);
            Animal testanimalTwo = new Carnivore("Lion", 5, 1);
            Animal testanimalThree = new Carnivore("Dog", 3, 1);

            Assert.IsFalse(herbivore.WillGetEatenAnimal(testanimalOne));
            Assert.IsTrue(herbivore.WillGetEatenAnimal(testanimalTwo));
            Assert.IsTrue(herbivore.WillGetEatenAnimal(testanimalThree));
        }

        [TestMethod]
        public void TestGetConsumedByAnimalMultiple()
        {
            Herbivore herbivore = new Herbivore("sheep", 3, 1);
            List<IAnimal> animalsOne = new List<IAnimal> { new Carnivore("Dog", 3, 1), new Herbivore("Giraffe", 5, 1) };
            List<IAnimal> animalsTwo = new List<IAnimal> { new Herbivore("Hippo", 5, 1), new Herbivore("Giraffe", 5, 1) };
            List<IAnimal> animalsThree = new List<IAnimal> { new Herbivore("Hippo", 5, 1), new Carnivore("Piranha", 1, 1) };

            Assert.IsFalse(herbivore.WillGetEatenAnyAnimal(animalsTwo));
            Assert.IsFalse(herbivore.WillGetEatenAnyAnimal(animalsThree));
            Assert.IsTrue(herbivore.WillGetEatenAnyAnimal(animalsOne));
        }

        [TestMethod]
        public void TestCapacityBreach()
        {
            TrainWagon wagonOne = new TrainWagon(10);
            TrainWagon wagonTwo = new TrainWagon(10);
            wagonOne.TryAddAnimal(new Herbivore("Sheep", 3, 1));
            wagonOne.TryAddAnimal(new Herbivore("Giraffe", 5, 1));

            wagonTwo.TryAddAnimal(new Herbivore("Giraffe", 5, 1));
            wagonTwo.TryAddAnimal(new Herbivore("Hippo", 5, 1));

            Animal animal = new Carnivore("Piranha", 1, 1);

            Assert.IsFalse(wagonOne.CapcityBreached(animal));
            Assert.IsTrue(wagonTwo.CapcityBreached(animal));
        }
    }
}