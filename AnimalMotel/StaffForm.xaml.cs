using System.Windows;

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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Staff.Qualifications.Add(txtQualification.Text);
        }

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
        private void UpdateGui()
        {
            lstQualifications.Items.Clear();
            txtQualification.Text = "";

            foreach (var item in Staff.Qualifications.ToStringList())
            {
                lstQualifications.Items.Add(item);
            }
        }
       

    private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Staff.Name = txtName.Text;
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
