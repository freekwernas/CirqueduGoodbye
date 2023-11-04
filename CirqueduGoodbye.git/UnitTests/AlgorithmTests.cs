using ApplicationCore.ObjectClasses;

namespace UnitTests
{
    [TestClass]
    public class AlgorithmTests
    {
        Circus Circus = new Circus();


        [TestMethod]
        public void LoadWagonTest()
        {
            Circus.CircusAnimals.Add(new Carnivore("Lion", 5));
            Circus.CircusAnimals.Add(new Herbivore("Hippo", 5));
            Circus.CircusAnimals.Add(new Carnivore("Cheeta", 3));
            Circus.CircusAnimals.Add(new Herbivore("Giraffe", 5));
            Circus.CircusAnimals.Add(new Carnivore("Tiger", 5));
            Circus.CircusAnimals.Add(new Carnivore("Piranha", 1));
            Circus.CircusAnimals.Add(new Carnivore("Piranha", 1));
            Circus.CircusAnimals.Add(new Herbivore("Chicken", 1));
            Circus.CircusAnimals.Add(new Carnivore("Dog", 3));
            Circus.CircusAnimals.Add(new Herbivore("Squirrel", 1));
            Circus.CircusAnimals.Add(new Herbivore("Goat", 3));

            Train train = new Train();
            TrainWagon wagon1 = new TrainWagon(10);
            wagon1.Animals.AddRange(new List<Animal> { new Herbivore("Hippo", 5), new Herbivore("Giraffe", 5) });
            train.WagonList.Add(wagon1);
            TrainWagon wagon2 = new TrainWagon(10);
            wagon2.Animals.AddRange(new List<Animal> { new Herbivore("Goat", 3), new Herbivore("Chicken", 1), new Herbivore("Squirrel", 1) });
            train.WagonList.Add(wagon2);
            TrainWagon wagon3 = new TrainWagon(10);
            wagon3.Animals.AddRange(new List<Animal> { new Carnivore("Lion", 5) });
            train.WagonList.Add(wagon3);
            TrainWagon wagon4 = new TrainWagon(10);
            wagon4.Animals.AddRange(new List<Animal> { new Carnivore("Tiger", 5) });
            train.WagonList.Add(wagon4);
            TrainWagon wagon5 = new TrainWagon(10);
            wagon5.Animals.AddRange(new List<Animal> { new Carnivore("Cheeta", 3) });
            train.WagonList.Add(wagon5);
            TrainWagon wagon6 = new TrainWagon(10);
            wagon6.Animals.AddRange(new List<Animal> { new Carnivore("Dog", 3) });
            train.WagonList.Add(wagon6);
            TrainWagon wagon7 = new TrainWagon(10);
            wagon7.Animals.AddRange(new List<Animal> { new Carnivore("Piranha", 1) });
            train.WagonList.Add(wagon7);
            TrainWagon wagon8 = new TrainWagon(10);
            wagon8.Animals.AddRange(new List<Animal> { new Carnivore("Piranha", 1) });
            train.WagonList.Add(wagon8);

            //Serialize object into JSON format, because the CollectionAssert uses a reference in the object.Equals method from IEnumerable
            var expectedString = Newtonsoft.Json.JsonConvert.SerializeObject(train.WagonList);
            var actualString = Newtonsoft.Json.JsonConvert.SerializeObject(Circus.CalculateTrain().WagonList);

            Assert.AreEqual(expectedString, actualString); 
        }
    }
}