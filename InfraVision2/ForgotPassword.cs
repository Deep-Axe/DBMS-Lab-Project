#nullable disable
using System;
using System.Windows.Forms;

namespace InfraVision2
{
    public partial class ForgotPassword : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


        public ForgotPassword()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer(); 
            timer.Interval = 1000;
            timer.Tick += new EventHandler(UpdateDateTime);
            timer.Start();
        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            curr_date_time.Text = DateTime.Now.ToString("dddd, MMM dd yyyy | hh:mm:ss tt");
        }
    }
}
