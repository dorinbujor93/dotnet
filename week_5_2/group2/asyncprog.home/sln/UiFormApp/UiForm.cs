using System;
using System.Threading.Tasks;

namespace UiFormApp
{
    using System.Diagnostics;
    using System.Net;
    using System.Windows.Forms;

    public partial class UiForm : Form
    {
        TaskScheduler _uiScheduler;
        public UiForm()
        {
            this.InitializeComponent();
        }

        private void DownloadBtnLeft_Click(object sender, System.EventArgs e)
        {
            // Get the UI scheduler for the thread that created the form:
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            var url = this.urlTextBoxLeft.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

          Task<string>.Factory.StartNew(() => this.DownloadString(url)).ContinueWith(ant =>
            {
                this.contentTxbLeft.Text = ant.Result;
                this.logLabelLeft.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
            }, _uiScheduler);


        }

        private async void DownloadBtnRight_Click(object sender, System.EventArgs e)
        {
            // Get the UI scheduler for the thread that created the form:
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            var url = this.urlTextBoxLeft.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            this.contentTxbRight.Text = await DownloadStringAsync(url);
           this.logLabelRight.Text = $@"Downloaded in {stopwatch.ElapsedMilliseconds} ms";
         
        }

        private string DownloadString(string url)
        {

            return new WebClient().DownloadString(url);
        }
        private Task<string> DownloadStringAsync(string url)
        {

            return Task.Run(() => DownloadString(url));
        }
    }
}
