using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfraVision2
{
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }
        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Full_name_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPasstextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void roles_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void acct_active_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void twofa_checkbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void passchangebox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void apienable_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
