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

        private string mWebMethod = "GET";

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

            this.cbMethod.SelectedIndex = 0;
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
                urlList.Add(cbUrl.Text);
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

        /*********************************************************************************
                                        访问Web的核心代码
        *********************************************************************************/
        private void VisitURL()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            while (this.IsRunning)
            {
                long resultLength = 0;
                string msg = "";
                Color msgColor = Color.Black;

                HttpWebResponse response = null;

                try
                {
                    sw.Restart();

                    HttpWebRequest request = CreateRequest();
                    response = request.GetResponse() as HttpWebResponse;
                    string result = GetResponseAsString(response);
                    resultLength = result.Length;

                    msg = "耗时ms：" + sw.ElapsedMilliseconds.ToString("00000");
                    msg += "\tStatus:" + "(" + (int)response.StatusCode + ")" + response.StatusCode;
                    msg += "\tHeader Date:" + DateTime.Parse(response.Headers["Date"]).ToString("yyyyMMdd hhmmss");
                    msg += "\t内容长度：" + resultLength;

                    System.Threading.Interlocked.Increment(ref this.mOkCount);
                }
                catch (Exception ex)
                {
                    msg = "耗时ms：" + sw.ElapsedMilliseconds.ToString("00000") + "\t";

                    Exception curEx = ex;
                    do
                    {
                        if (curEx is WebException)
                        {
                            WebException webEx = curEx as WebException;
                            msg += "Status:" + "(" + (int)webEx.Status + ")" + webEx.Status + "\t" + webEx.Message;
                            if (webEx.Response != null && webEx.Response.Headers != null && webEx.Response.Headers["Date"] != null)
                                msg += "\tHeader Data:" + DateTime.Parse(webEx.Response.Headers["Date"]).ToString("yyyyMMdd hhmmss");
                            msg += "\tResponse:" + GetResponseAsString(webEx.Response as HttpWebResponse);
                        }
                        else
                        {
                            msg += curEx.Message + "\t";
                        }
                        curEx = curEx.InnerException;
                    }
                    while (curEx != null);

                    Interlocked.Increment(ref this.mFailCount);
                    msgColor = Color.Red;
                }
                finally
                {
                    sw.Stop();

                    if (response != null) response.Close();
                }

                RefreshUI();
                ShowMsg(Thread.CurrentThread.ManagedThreadId, msg, msgColor);

                Thread.Sleep(Convert.ToInt32(this.nudVisitDelay.Value));
            }
        }


        private HttpWebRequest CreateRequest()
        {
            HttpWebRequest request = HttpWebRequest.Create(this.mTargetUri) as HttpWebRequest;
            request.Method = this.mWebMethod;
            request.Timeout = Convert.ToInt32(nudTimeout.Value);
            request.KeepAlive = true;
            request.UserAgent = "blzoom GoOnLoading";
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            return request;
        }


        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <returns>响应文本</returns>
        private string GetResponseAsString(HttpWebResponse rsp)
        {
            if (rsp == null) return "[无]";
            return GetResponseAsString(rsp, System.Text.Encoding.GetEncoding(rsp.CharacterSet));
        }


        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        private string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            if (rsp == null) return "[无]";

            System.IO.Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }


        private void RefreshUI()
        {
            if (tbMsg.InvokeRequired)
            {
                tbMsg.BeginInvoke(new Action(RefreshUI));
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
                //tbMsg.Invoke(new Action<int, string, Color>(ShowMsg), threadId, msg, color);
                tbMsg.BeginInvoke(new Action<int, string, Color>(ShowMsg), threadId, msg, color);
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

        private void cbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mWebMethod = cbMethod.SelectedItem as string;
        }
    }
}
