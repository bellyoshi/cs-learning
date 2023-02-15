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

        private void button1_Click(object sender, EventArgs e)
        {
            var createNewProcess = new CreateNewProcess();
            StartTimer();
            createNewProcess.RunAsync();
        }
        
        private System.Timers.Timer _timer;
        internal void StartTimer()
        {
            _timer = new ();
            _timer.SynchronizingObject = this;
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }
            this.components.Add(_timer);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
            _timer.Interval = 1000;
            _timer.Start();
        }

        public void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.label1.Text = $"åªç›éûçè{e.SignalTime.Second}";
        }
    }
}