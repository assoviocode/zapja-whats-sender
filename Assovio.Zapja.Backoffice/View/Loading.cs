namespace Backoffice.View
{
    public partial class Loading : Form
    {

        public Loading()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }


        public void Start()
        {
            Task.Run(() =>
            {
                this.TopMost = true;
                this.ShowDialog(Parent);
            });
        }

        public void Stop()
        {
            BeginInvoke((Action)delegate { this.Close(); });
        }

    }

}
