using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

/// <summary>
/// Author: Tomas Perers
/// Date : 2019-02-06
/// Updated a bit for the second attempt at the course.
/// </summary>
namespace AnimalMotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AnimalManager animalManager;
        private RecepieManager recepieManager;
        private bool hasBeenSaved = false;
        private string fileName;

        /// <summary>
        /// Constructor that will clear and initialize the GUI.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            animalManager = new AnimalManager();
            recepieManager = new RecepieManager();
            InitializeGUI();
        }

        /// <summary>
        /// Adds an amimal to the animal manager. Calls a function to check that we have input in all fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = null;
            animal = CreateAnimal(animal);
            if (animal != null)
            {
                animalManager.AddAnimal(animal);
                ClearInput();
                UpdateGUI();
            }
        }
        /// <summary>
        /// Setts all the information in an animal object
        /// </summary>
        /// <param name="animal">Animal</param>
        /// <returns>Animal</returns>
        private Animal CreateAnimal(Animal animal)
        {
            if (CheckInput())
            {
                switch (lstCategory.SelectedValue)
                {
                    case Category.Mammal:
                        animal = MammalFactory.CreateMammal((MammalSpecies)lstAnimals.SelectedValue);
                        break;
                    case Category.Bird:
                        animal = BirdFactory.CreateBird((BirdSpecies)lstAnimals.SelectedValue);
                        break;
                }
                if (!IsNumber(txtAge.Text))
                {
                    MessageBox.Show("Please input only numbers in age");
                    return null;
                }
                if (!IsNumber(txtCategorySpec.Text))
                {
                    MessageBox.Show("Please input only numbers in category information");
                    return null;
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
                        return null;

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
                        return null;
                    }

                }

                if (IsNumber(txtName.Text))
                {
                    MessageBox.Show("Please only input letters in the name");
                    return null;
                }
                else
                {
                    animal.Name = txtName.Text;
                }

                if (IsNumber(txtSpeciesSpec.Text))
                {
                    MessageBox.Show("Please only input letters in the species information.");
                    return null;
                }
                else
                {
                    animal.AddSpeciesInformation(txtSpeciesSpec.Text);
                }
                if (cboxGender.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose a gender");
                    return null;
                }

                animal.Gender = (Gender)cboxGender.SelectedValue;
                animal.CreateFoodSchedule();
            }
            return animal;
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
            if(lstAnimals.ItemsSource == null)
            {
                lstAnimals.Items.Clear();
            }
            else
            {
                lstAnimals.ItemsSource = null;
            }
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
            this.hasBeenSaved = false;
        }

        /// <summary>
        /// Update the GUI
        /// </summary>
        private void UpdateGUI()
        {
            lstRegisteredAnimals.Items.Clear();

            foreach (var item in animalManager.ToStringList())
            {
                lstRegisteredAnimals.Items.Add(item);
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
            if(lstAnimals.ItemsSource == null)
            {
                lstAnimals.Items.Clear();
            }
            

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
                    lblCategorySpec.Content = "Number of teeth";
                    break;
                case MammalSpecies.Dog:
                    lblSpeciesSpec.Content = "Favourite food";
                    lblCategorySpec.Content = "Number of teeth";
                    break;

                case BirdSpecies.Falcon:
                    lblSpeciesSpec.Content = "Favourite food";
                    lblCategorySpec.Content = "Flying speed";
                    break;
                case BirdSpecies.Parrot:
                    lblSpeciesSpec.Content = "Talking dialect";
                    lblCategorySpec.Content = "Flying speed";
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
                animalManager.DeleteAt(lstRegisteredAnimals.SelectedIndex);
                UpdateGUI();
            }
        }

        /// <summary>
        /// Update GUI to show all animals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbListAllAnimals_Checked(object sender, RoutedEventArgs e)
        {

            if (chbListAllAnimals.IsChecked == true)
            {
                lstCategory.Visibility = Visibility.Hidden;
                grpSpecification.Header = lstCategory.SelectedValue + " specification";
                txtCategorySpec.Visibility = Visibility.Visible;
                lblCategorySpec.Visibility = Visibility.Visible;
                if(lstAnimals.ItemsSource == null)
                {
                    lstAnimals.Items.Clear();
                }
                else
                {
                    lstAnimals.ItemsSource = null;
                }
                
                foreach (var item in Enum.GetValues(typeof(BirdSpecies)).Cast<BirdSpecies>())
                {
                    lstAnimals.Items.Add(item);
                }

                foreach (var item in Enum.GetValues(typeof(MammalSpecies)).Cast<MammalSpecies>())
                {
                    lstAnimals.Items.Add(item);
                }
            }
            else
            {
                lstCategory.Visibility = Visibility.Visible;
                InitializeGUI();
            }
        }

        /// <summary>
        /// Update the GUI to not show all the animals.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbListAllAnimals_Unchecked(object sender, RoutedEventArgs e)
        {
            lstCategory.Visibility = Visibility.Visible;
            InitializeGUI();
        }

        /// <summary>
        /// Update the GUI when an animal is selected in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstRegisteredAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstRegisteredAnimals.SelectedIndex;
            if (index > -1)
            {
                Animal animal = animalManager.GetAt(index);
                txtbEaterType.Text = animal.GetEaterType().ToString();
                txtbFeedingSchedule.Text = animal.GetFoodSchedule().ToString();
                txtName.Text = animal.Name;
                txtAge.Text = animal.Age.ToString();
                cboxGender.SelectedValue = animal.Gender;
                lstCategory.SelectedItem = animal.Category;
                lstAnimals_SelectionChanged(null, null);
                lstCategory_SelectionChanged(null, null);
                txtCategorySpec.Text = animal.CategoryInformation;
                txtSpeciesSpec.Text = animal.SpeciesInformation;

                switch (animal.Category)
                {
                    case Category.Bird:
                        lblCategorySpec.Content = "Flying speed";
                        animal = (Bird)animal;
                        if (animal.GetSpecies().Equals(BirdSpecies.Falcon.ToString()))
                        {
                            lblSpeciesSpec.Content = "Favourite food";
                            lblCategorySpec.Content = "Flying speed";
                            lstAnimals.SelectedItem = BirdSpecies.Falcon;
                        }
                        else if (animal.GetSpecies().Equals(BirdSpecies.Parrot.ToString()))
                        {
                            lblSpeciesSpec.Content = "Talking dialect";
                            lblCategorySpec.Content = "Flying speed";
                            lstAnimals.SelectedItem = BirdSpecies.Parrot;
                        }
                        break;
                    case Category.Mammal:
                        lblCategorySpec.Content = "Number of teeth";
                        animal = (Mammal)animal;
                        if (animal.GetSpecies().Equals(MammalSpecies.Cat.ToString()))
                        {
                            lblSpeciesSpec.Content = "Social behavour";
                            lblCategorySpec.Content = "Number of teeth";
                            lstAnimals.SelectedItem = MammalSpecies.Cat;
                        }
                        else if (animal.GetSpecies().Equals(MammalSpecies.Dog.ToString()))
                        {
                            lblSpeciesSpec.Content = "Favourite food";
                            lblCategorySpec.Content = "Number of teeth";
                            lstAnimals.SelectedItem = MammalSpecies.Dog;
                        }
                        break;
                }
            }
            txtSpeciesSpec.Visibility = Visibility.Visible;
            lblSpeciesSpec.Visibility = Visibility.Visible;
            txtCategorySpec.Visibility = Visibility.Visible;
            lblCategorySpec.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Change information for a selected animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
        int index = lstRegisteredAnimals.SelectedIndex;
        if (index > -1)
            {
                Animal animal = animalManager.GetAt(index);
                var id = animal.Id;
                animal = CreateAnimal(animal);
                animal.Id = id;
                animalManager.ChangeAt(animal, index);
                ClearInput();
                UpdateGUI();
            }
        }

        /// <summary>
        /// Shows the FoodForm and stores the recepie in the manager and displays it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddFood_Click(object sender, RoutedEventArgs e)
        {
            var food =  new FoodForm();
            food.ShowDialog();
            if (food.DialogResult.HasValue && food.DialogResult.Value)
            {
                Recepie newRecepie = new Recepie();
                newRecepie.Name = food.Recepie.Name;
                newRecepie.Ingredients = food.Recepie.Ingredients;
                recepieManager.Add(newRecepie);
                this.hasBeenSaved = false;
            }
            lstRecepie.Items.Clear();
            foreach (var item in recepieManager.ToStringList())
            {
                lstRecepie.Items.Add(item);
            }
        }

        /// <summary>
        /// Button to show form for staff and displays it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            var staffForm = new StaffForm(staff);
            staffForm.ShowDialog();
            if (staffForm.DialogResult.HasValue && staffForm.DialogResult.Value)
            {
                staff.Name = staffForm.Staff.Name;
                staff.Qualifications = staffForm.Staff.Qualifications;
                lstStaff.Items.Add(staff.ToString());
                this.hasBeenSaved = false;
            }
            lstRecepie.Items.Clear();
            foreach (var item in recepieManager.ToStringList())
            {
                lstRecepie.Items.Add(item);
            }
        }

        private void CreateNewAnimalMotel()
        {
            if (hasBeenSaved)
            {
                animalManager = new AnimalManager();
                recepieManager = new RecepieManager();
                InitializeGUI();
            }
            else
            {
                MessageBox.Show("You need to save your work first");
            }
        }
        
        private bool SaveWork()
        {
            if (BinSerializerUtility.Serialize(animalManager, this.fileName))
            {
                this.hasBeenSaved = true;
                return true;
            }
            return false;
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            if (this.hasBeenSaved)
            {
                CreateNewAnimalMotel();
            }
            else
            {
                MessageBox.Show("You need to save the data first");
            }
        }


        private void CommandBinding_New(object sender, ExecutedRoutedEventArgs e)
        {
            CreateNewAnimalMotel();
        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.fileName == null)
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var result = saveFileDialog.ShowDialog();
                if (result == false)
                {
                    this.hasBeenSaved = false;
                    return;
                }
                this.fileName = saveFileDialog.FileName;
            }
            SaveWork();
        }

        private void menuOpenTextFile_Click(object sender, RoutedEventArgs e)
        {

            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var result = openFileDialog.ShowDialog();
            if (result == false)
            {
                return;
            }
            this.fileName = openFileDialog.FileName;
        }

        private void menuBinaryFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var result = openFileDialog.ShowDialog();
            if (result == false)
            {
                return;
            }
            this.fileName = openFileDialog.FileName;
            animalManager = BinSerializerUtility.Deserialize<AnimalManager>(this.fileName);
            UpdateGUI();
        }

        private void menuSaveTextFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuSaveBinaryFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuImportXML_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuExportToXML_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            if (hasBeenSaved)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to save your work first");
                SaveWork();
            }
        }
    }
}

