﻿using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
/// <summary>
/// Author: Tomas Perers
/// Date : 2018-03-19
/// </summary>
namespace AnimalMotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AnimalManager animalManager;

        /// <summary>
        /// Constructor that will clear and initialize the GUI.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            animalManager = new AnimalManager();
            InitializeGUI();
        }

        /// <summary>
        /// Adds an amimal to the animal manager. Calls a function to check that we have input in all fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                Animal animal = null;
                switch (lstCategory.SelectedValue)
                {
                    case Category.Mammal:
                        animal = MammalFactory.CreateMammal((MammalSpecies)lstAnimals.SelectedValue);
                        break;
                    case Category.Bird:
                        animal = BirdFactory.CreateBird((BirdSpecies)lstAnimals.SelectedValue);
                        break;
                }
                if (! IsNumber(txtAge.Text))
                {
                    MessageBox.Show("Please input only numbers in age");
                    return;
                }
                if (! IsNumber(txtCategorySpec.Text))
                {
                    MessageBox.Show("Please input only numbers in category information");
                    return;
                }
                if (int.TryParse(txtAge.Text, out int age))
                {
                    if (age >= 0)
                    {
                        animal.Age = age;
                    }
                    else
                    {
                        MessageBox.Show("Age is negative");
                        return;

                    }
                }

                if (int.TryParse(txtCategorySpec.Text, out int result))
                {
                    if (result >= 0)
                    {
                        animal.AddCategoryInformation(txtCategorySpec.Text);
                    }
                    else
                    {
                        MessageBox.Show("Category information is negative");
                        return;
                    }

                }

                if (IsNumber(txtName.Text))
                {
                    MessageBox.Show("Please only input letters in the name");
                    return;                    
                }
                else
                {
                    animal.Name = txtName.Text;
                }

                if (IsNumber(txtSpeciesSpec.Text))
                {
                    MessageBox.Show("Please only input letters in the species information.");
                    return;
                }
                else
                {
                    animal.AddSpeciesInformation(txtSpeciesSpec.Text);
                }

                animal.Gender = (Gender) cboxGender.SelectedValue;
                animalManager.AddAnimal(animal);
                ClearInput();
                UpdateGUI();
            }
        }

        /// <summary>
        /// Returns true if all the chars in the string is a letter or false if they are numbers.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsNumber(string s)
        {
            return s.Any() && s.All(c => Char.IsDigit(c));
        }

        /// <summary>
        /// Add a picture to the GUI hopefully of an Animal :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics| *.jpg;*.jpeg;*.png|" + 
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + 
                "Portable Network Graphic (*.png)|*.png";
            if(op.ShowDialog() == true)
            {
                picAnimalImage.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        /// <summary>
        /// Initialize all the GUI
        /// </summary>
        private void InitializeGUI()
        {
            ClearInput();
            lstCategory.ItemsSource = Enum.GetValues(typeof(Category)).Cast<Category>();
            cboxGender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            lstRegisteredAnimals.Items.Clear();
        }

        /// <summary>
        /// Clears and rests all the input.
        /// </summary>
        private void ClearInput()
        {
            txtAge.Text = String.Empty;
            txtName.Text = String.Empty;
            txtCategorySpec.Text = String.Empty;
            txtSpeciesSpec.Text = String.Empty;

            lstAnimals.ItemsSource = null;
            lstCategory.SelectedIndex = -1;
            cboxGender.SelectedIndex = -1;
                        
            lblCategorySpec.Content = String.Empty;
            lblSpeciesSpec.Content = String.Empty;
            // Hide them until category and species has been selected.
            lblSpeciesSpec.Visibility = Visibility.Hidden;
            lblCategorySpec.Visibility = Visibility.Hidden;
            txtCategorySpec.Visibility = Visibility.Hidden;
            txtSpeciesSpec.Visibility = Visibility.Hidden;
            grpSpecification.Header = "Animal specefications";
            grpSpecification.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Update the GUI
        /// </summary>
        private void UpdateGUI()
        {
            lstRegisteredAnimals.Items.Clear();

            for (int i=0; i< animalManager.Count; i++)
            {
                lstRegisteredAnimals.Items.Add(animalManager.GetAnimal(i));
            }
        }

        /// <summary>
        /// Make sure no input is empty.
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (String.IsNullOrEmpty(txtAge.Text))
            {
                MessageBox.Show("No age has been entered");
                return false;
            }
            else if (String.IsNullOrEmpty(txtCategorySpec.Text))
            {
                MessageBox.Show("No specification for category has been entered");
                return false;
            }
            else if (String.IsNullOrEmpty(txtSpeciesSpec.Text))
            {
                MessageBox.Show("No specefication of species has been entered");
                return false;
            }
            else if(String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("No name has been entered");
                return false;
            }
            else if(lstAnimals.SelectedIndex == -1)
            {
                MessageBox.Show("No Animal species has been selected");
                return false;
            }
            else if(lstCategory.SelectedIndex == -1)
            {
                MessageBox.Show("No Animal Category has been selected");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// When changing or selecting a category update the list of species and extra information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grpSpecification.Visibility = Visibility.Visible;
            grpSpecification.Header = lstCategory.SelectedValue + " specification";
            txtCategorySpec.Visibility = Visibility.Visible;
            lblCategorySpec.Visibility = Visibility.Visible;

            switch (lstCategory.SelectedValue)
            {
                case Category.Bird:
                    lstAnimals.ItemsSource = Enum.GetValues(typeof(BirdSpecies)).Cast<BirdSpecies>();
                    lblCategorySpec.Content = "Flying speed";
                    break;
                case Category.Mammal:
                    lblCategorySpec.Content = "Number of teeth";
                    lstAnimals.ItemsSource = Enum.GetValues(typeof(MammalSpecies)).Cast<MammalSpecies>();
                    break;
            }
        }

        /// <summary>
        /// When selecting a species update the extra information input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSpeciesSpec.Visibility = Visibility.Visible;
            lblSpeciesSpec.Visibility = Visibility.Visible;

            switch (lstAnimals.SelectedValue)
            {
                case MammalSpecies.Cat:
                    lblSpeciesSpec.Content = "Social behavour";
                    break;
                case MammalSpecies.Dog:
                    lblSpeciesSpec.Content = "Favourite food";
                    break;

                case BirdSpecies.Falcon:
                    lblSpeciesSpec.Content = "Favourite food";
                    break;
                case BirdSpecies.Parrot:
                    lblSpeciesSpec.Content = "Talking dialect";
                    break;
            }
        }

        /// <summary>
        /// Remove the selected animal from the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstRegisteredAnimals.SelectedIndex > -1)
            {
                animalManager.RemoveAnimal(lstRegisteredAnimals.SelectedIndex);
                UpdateGUI();
            }
        }
    }
}
