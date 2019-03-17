using System.Windows;
/// <summary>
/// Author: Tomas Perers, ai2891
/// Date : 2019-03-16
/// </summary>
namespace AnimalMotel
{
    /// <summary>
    /// Interaction logic for StaffForm.xaml
    /// </summary>
    public partial class StaffForm : Window
    {
        public Staff Staff { get; set; }

        public StaffForm()
        {
            InitializeComponent();
            Staff = new Staff();
        }

        public StaffForm(Staff staff)
        {
            InitializeComponent();
            Staff = staff;
        }

        /// <summary>
        /// what to do when add is clicked. Add things to the list in the staff object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Staff.Qualifications.Add(txtQualification.Text);
            UpdateGui();
        }

        /// <summary>
        /// Change things in the list in the staff object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            var index = lstQualifications.SelectedIndex;
            if (index > -1)
            {
                var skill = txtQualification.Text;
                Staff.Qualifications.ChangeAt(skill, index);
                UpdateGui();
            }
            else
            {
                MessageBox.Show("No qualification was selected");
            }
        }

        /// <summary>
        /// Delete selected item from staff object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var index = lstQualifications.SelectedIndex;
            if (index > -1)
            {
                Staff.Qualifications.DeleteAt(index);
                UpdateGui();
            }
            else
            {
                MessageBox.Show("No qualification was selected");
            }
        }

        /// <summary>
        /// Updates the GUI.
        /// </summary>
        private void UpdateGui()
        {
            lstQualifications.Items.Clear();
            txtQualification.Text = "";

            foreach (var item in Staff.Qualifications.ToStringList())
            {
                lstQualifications.Items.Add(item);
            }
        }

        /// <summary>
        /// Exists the form by OK, and sets the name of staff object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Staff.Name = txtName.Text;
            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Exists the form by cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
