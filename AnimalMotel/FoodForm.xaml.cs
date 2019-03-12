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
using System.Windows.Shapes;

namespace AnimalMotel
{
    /// <summary>
    /// Interaction logic for FoodForm.xaml
    /// </summary>
    public partial class FoodForm : Window
    {
        Recepie recepie;

        internal Recepie Recepie { get => recepie; }

        public FoodForm()
        {
            InitializeComponent();
            recepie = new Recepie();
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
                recepie.Ingredients.ChangeAt(ingredient, index);
            }
            else
            {
                MessageBox.Show("No recepie was selected");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            recepie.Ingredients.Add(txtIngredients.Text);
            UpdateGui();
        }

        private void BtnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            var index = lstRecepie.SelectedIndex;
            if (index > -1)
            {
                recepie.Ingredients.DeleteAt(index);
            }
            else
            {
                MessageBox.Show("No recepie was selected");
            }
            UpdateGui();
        }
        private void UpdateGui()
        {
            lstRecepie.Items.Clear();
            txtIngredients.Text = "";
            for (int i=0; i < recepie.Ingredients.Count; i++)
            {
                lstRecepie.Items.Add(recepie.Ingredients.GetAt(i));
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
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
