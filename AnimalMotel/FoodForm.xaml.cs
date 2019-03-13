using System.Windows;
using System.Windows.Controls;

namespace AnimalMotel
{
    /// <summary>
    /// Interaction logic for FoodForm.xaml
    /// </summary>
    public partial class FoodForm : Window
    {
        
        public Recepie Recepie { get; set; }

        public FoodForm()
        {
            InitializeComponent();
            Recepie = new Recepie();
        }

        public FoodForm(Recepie recepie)
        {
            InitializeComponent();
            Recepie = recepie;
        }

        private void TxtRecepie_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            var index = lstRecepie.SelectedIndex;
            if (index > -1)
            {
                var ingredient = txtIngredients.Text;
                Recepie.Ingredients.ChangeAt(ingredient, index);
                UpdateGui();
            }
            else
            {
                MessageBox.Show("No ingredient was selected");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Recepie.Ingredients.Add(txtIngredients.Text);
            UpdateGui();
        }

        private void BtnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            var index = lstRecepie.SelectedIndex;
            if (index > -1)
            {
                Recepie.Ingredients.DeleteAt(index);
                UpdateGui();
            }
            else
            {
                MessageBox.Show("No ingredient was selected");
            }
        }
        private void UpdateGui()
        {
            lstRecepie.Items.Clear();
            txtIngredients.Text = "";

            foreach (var item in Recepie.Ingredients.ToStringList())
            {
                lstRecepie.Items.Add(item);
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Recepie.Name = txtRecepieName.Text;
            DialogResult = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
