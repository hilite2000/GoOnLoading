using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoOnLoading
{
    public partial class MainForm : Form
    {
        private string mUrlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "url.txt");

        /// <summary>
        /// 要访问的目标地址
        /// </summary>
        private Uri mTargetUri;

        System.Threading.SynchronizationContext mSyncContext;

        private bool mIsRunning;

        /// <summary>
        /// 在运行中
        /// </summary>
        public bool IsRunning
        {
            get { return mIsRunning; }
            set
            {
                mIsRunning = value;

                btnBeginLoad.Enabled = !this.mIsRunning;
                btnStopLoad.Enabled = this.mIsRunning;

                Application.DoEvents();
            }
        }


        private int mOkCount = 0;
        private int mFailCount = 0;

        public MainForm()
        {
            InitializeComponent();

            this.mSyncContext = System.Threading.SynchronizationContext.Current;

            this.IsRunning = false;
            this.mOkCount = this.mFailCount = 0;
            RefreshUI();
        }

        private void cbUrl_Leave(object sender, EventArgs e)
        {
            string oldUrl = cbUrl.Text;

            if (cbUrl.Text.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) == false)
                cbUrl.Text = "http://" + cbUrl.Text;

            try
            {
                this.mTargetUri = new Uri(cbUrl.Text);
                cbUrl.Text = this.mTargetUri.AbsoluteUri;

                List<string> urlList = new List<string>();
                foreach (string item in cbUrl.Items) urlList.Add(item);
                cbUrl.Items.Clear();
                cbUrl.Items.AddRange(urlList.Distinct().ToArray());

            }
            catch (UriFormatException)
            {
                MessageBox.Show("不正确的URL格式", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbUrl.Text = oldUrl;
            }
        }

        private void btnBeginLoad_Click(object sender, EventArgs e)
        {
            if (this.IsRunning == true) return;

            this.mOkCount = this.mFailCount = 0;
            this.IsRunning = !this.IsRunning;
            RefreshUI();


            for (int idx = 0; idx < nudThreadCount.Value; idx++)
            {
                System.Threading.Thread thd = new System.Threading.Thread(new System.Threading.ThreadStart(VisitURL));
                thd.IsBackground = true;
                thd.Name = "v" + idx.ToString("000");
                thd.Start();
            }
        }

        private void btnStopLoad_Click(object sender, EventArgs e)
        {
            if (this.IsRunning == false) return;

            this.IsRunning = !this.IsRunning;

            RefreshUI();
        }

        private void VisitURL()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            while (this.IsRunning)
            {
                long resultLength = 0;
                string msg = "";
                Color msgColor = Color.Black;

                try
                {
                    sw.Restart();

                    //System.Net.WebClient wc = new System.Net.WebClient();
                    //string result = wc.DownloadString(this.mTargetUri);
                    //resultLength = result.Length;

                    HttpWebRequest request = HttpWebRequest.Create(this.mTargetUri) as HttpWebRequest;
                    request.Timeout = Convert.ToInt32(nudTimeout.Value);
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    resultLength = response.ContentLength;
                    response.Close();

                    msg = "耗时ms：" + sw.ElapsedMilliseconds.ToString("00000") + "\t内容长度：" + resultLength;

                    System.Threading.Interlocked.Increment(ref this.mOkCount);
                }
                catch (Exception ex)
                {
                    msg = "耗时ms：" + sw.ElapsedMilliseconds.ToString("00000") + "\t";

                    Exception curEx = ex;
                    do
                    {
                        msg += curEx.Message + "\t";
                        curEx = curEx.InnerException;
                    }
                    while (curEx != null);

                    Interlocked.Increment(ref this.mFailCount);
                    msgColor = Color.Red;
                }
                finally
                {
                    sw.Stop();
                }

                RefreshUI();
                ShowMsg(Thread.CurrentThread.ManagedThreadId, msg, msgColor);

                Thread.Sleep(Convert.ToInt32(this.nudVisitDelay.Value));
            }
        }

        private void RefreshUI()
        {
            if (tbMsg.InvokeRequired)
            {
                tbMsg.Invoke(new Action(RefreshUI));
            }
            else
            {
                lblOKCount.Text = "成功：" + this.mOkCount;
                lblFailCount.Text = "失败：" + this.mFailCount;
            }
        }

        private void ShowMsg(int threadId, string msg, Color color)
        {
            if (tbMsg.InvokeRequired)
            {
                tbMsg.Invoke(new Action<int, string, Color>(ShowMsg), threadId, msg, color);
            }
            else
            {
                int orgLength = tbMsg.Text.Length;

                string result = "[" + DateTime.Now.ToString("hh:mm:ss.fff") + "]";
                result += "[" + threadId + "]  ";
                result += msg;
                tbMsg.AppendText(result);

                tbMsg.Select(orgLength, result.Length);
                tbMsg.SelectionColor = color;
                tbMsg.AppendText(Environment.NewLine);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.IsRunning = false;

            List<string> urlList = new List<string>();
            foreach (string item in cbUrl.Items)
                urlList.Add(item);

            File.WriteAllLines(this.mUrlFileName, urlList.Distinct().ToArray());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(this.mUrlFileName))
            {
                string[] urlList = File.ReadAllLines(this.mUrlFileName);
                cbUrl.Items.AddRange(urlList);
            }
        }
    }
}
