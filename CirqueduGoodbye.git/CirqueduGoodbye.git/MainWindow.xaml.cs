using ApplicationCore.Interfaces;
using ApplicationCore.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CirqueduGoodbye.git
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SOLID dependency Inversion principle
        public ICircus Circus = new Circus();
        public MainWindow()
        {
            InitializeComponent();
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
            refreshAnimals();
        }

        private void refreshAnimals()
        {
            tbAnimals.Items.Clear();
            foreach (Animal animal in Circus.CircusAnimals)
            {
                tbAnimals.Items.Add(animal.Name.ToString());
            }
            tbAnimals.Items.Refresh();
        }

        private void refreshWagons(Train train)
        {
            lbWagons.Items.Clear();
            foreach (TrainWagon wagon in train.WagonList)
            {
                lbWagons.Items.Add(wagon.ToString());
            }
            lbWagons.Items.Refresh();
        }

        private void btnCalculateWagons_Click(object sender, RoutedEventArgs e)
        {
            refreshWagons(Circus.CalculateTrain());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbAnimals.SelectedIndex == -1)
            {
                MessageBox.Show("Select animal");
            }
            else
            {
                Circus.CircusAnimals.RemoveAt(tbAnimals.SelectedIndex);
                refreshAnimals();
            }
        }        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbAnimalName.Text == string.Empty || tbAnimalName.Text == null)
            {
                MessageBox.Show("Add name");
            }
            //Since checked for null override nullable
            Circus.AddAnimal(tbAnimalName.Text!, Circus.EquateSize(cbbSize.Text), cbbAnimalType.Text);
            refreshAnimals();
        }
    }
}
