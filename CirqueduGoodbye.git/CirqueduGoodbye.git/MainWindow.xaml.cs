using ApplicationCore;
using ApplicationCore.Interfaces;
using ApplicationCore.ObjectClasses;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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
        public ICircus _circus;
        public ICircusService _circusService;
        public IAnimalService _animalService;
        public MainWindow(IAnimalService animalService, ICircusService circusService)
        {
            InitializeComponent();
            _circusService = circusService;
            _animalService = animalService;
            refreshAnimals();
        }

        private void refreshAnimals()
        {
            _circus = _circusService.GetCircusById(1);
            _circus.CircusAnimals.AddRange(_animalService.GetAnimals());

            tbAnimals.Items.Clear();
            foreach (ApplicationCore.ObjectClasses.Animal animal in _circus.CircusAnimals)
            {
                tbAnimals.Items.Add(animal.Name.ToString());
            }
            tbAnimals.Items.Refresh();
        }

        private void refreshWagons(ApplicationCore.ObjectClasses.Train train)
        {
            lbWagons.Items.Clear();
            foreach (ApplicationCore.ObjectClasses.TrainWagon wagon in train.WagonList)
            {
                lbWagons.Items.Add(wagon.ToString());
            }
            lbWagons.Items.Refresh();
        }

        private void btnCalculateWagons_Click(object sender, RoutedEventArgs e)
        {
            refreshWagons(_circus.CalculateTrain());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (tbAnimals.SelectedIndex == -1)
            {
                MessageBox.Show("Select animal");
            }
            else
            {
                _animalService.DeleteAnimal(_circus.CircusAnimals[tbAnimals.SelectedIndex]);
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
            _animalService.AddAnimal(tbAnimalName.Text!, _circus.EquateSize(cbbSize.Text), cbbAnimalType.Text, _circus.Id);
            refreshAnimals();
        }
    }
}
