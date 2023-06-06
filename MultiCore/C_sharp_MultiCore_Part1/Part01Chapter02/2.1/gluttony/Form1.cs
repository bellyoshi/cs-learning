namespace gluttony
{
    public partial class Form1 : Form
    {
        private gluttony gluttonyObject = new ();
        public Form1()
        {
            InitializeComponent();
            EnabledControl();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            gluttonyObject.IsRunning = true;
            EnabledControl();
            gluttonyObject.WorkInfinite();
        }
        
        private void EnabledControl()
        {
            StartButton.Enabled = !gluttonyObject.IsRunning;
            StopButton.Enabled = gluttonyObject.IsRunning;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            gluttonyObject.IsRunning = false;
            EnabledControl();
        }
    }
}