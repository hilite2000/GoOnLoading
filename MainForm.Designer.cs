namespace GoOnLoading
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBeginLoad = new System.Windows.Forms.Button();
            this.btnStopLoad = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudThreadCount = new System.Windows.Forms.NumericUpDown();
            this.nudVisitDelay = new System.Windows.Forms.NumericUpDown();
            this.lblOKCount = new System.Windows.Forms.Label();
            this.lblFailCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.cbUrl = new System.Windows.Forms.ComboBox();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVisitDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            // 
            // btnBeginLoad
            // 
            this.btnBeginLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeginLoad.Location = new System.Drawing.Point(473, 11);
            this.btnBeginLoad.Name = "btnBeginLoad";
            this.btnBeginLoad.Size = new System.Drawing.Size(73, 23);
            this.btnBeginLoad.TabIndex = 1;
            this.btnBeginLoad.Text = "开始";
            this.btnBeginLoad.UseVisualStyleBackColor = true;
            this.btnBeginLoad.Click += new System.EventHandler(this.btnBeginLoad_Click);
            // 
            // btnStopLoad
            // 
            this.btnStopLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopLoad.Location = new System.Drawing.Point(552, 11);
            this.btnStopLoad.Name = "btnStopLoad";
            this.btnStopLoad.Size = new System.Drawing.Size(73, 23);
            this.btnStopLoad.TabIndex = 1;
            this.btnStopLoad.Text = "停止";
            this.btnStopLoad.UseVisualStyleBackColor = true;
            this.btnStopLoad.Click += new System.EventHandler(this.btnStopLoad_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMsg.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbMsg.Location = new System.Drawing.Point(5, 94);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(796, 322);
            this.tbMsg.TabIndex = 2;
            this.tbMsg.Text = "";
            this.tbMsg.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "访问线程数：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "访问间隔ms：";
            // 
            // nudThreadCount
            // 
            this.nudThreadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudThreadCount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.nudThreadCount.Location = new System.Drawing.Point(732, 8);
            this.nudThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreadCount.Name = "nudThreadCount";
            this.nudThreadCount.Size = new System.Drawing.Size(57, 21);
            this.nudThreadCount.TabIndex = 4;
            this.nudThreadCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudVisitDelay
            // 
            this.nudVisitDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudVisitDelay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.nudVisitDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudVisitDelay.Location = new System.Drawing.Point(732, 35);
            this.nudVisitDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudVisitDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVisitDelay.Name = "nudVisitDelay";
            this.nudVisitDelay.Size = new System.Drawing.Size(57, 21);
            this.nudVisitDelay.TabIndex = 4;
            this.nudVisitDelay.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // lblOKCount
            // 
            this.lblOKCount.AutoSize = true;
            this.lblOKCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblOKCount.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOKCount.Location = new System.Drawing.Point(66, 35);
            this.lblOKCount.Name = "lblOKCount";
            this.lblOKCount.Size = new System.Drawing.Size(152, 27);
            this.lblOKCount.TabIndex = 5;
            this.lblOKCount.Text = "lblOKCount";
            // 
            // lblFailCount
            // 
            this.lblFailCount.AutoSize = true;
            this.lblFailCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblFailCount.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFailCount.Location = new System.Drawing.Point(66, 64);
            this.lblFailCount.Name = "lblFailCount";
            this.lblFailCount.Size = new System.Drawing.Size(180, 27);
            this.lblFailCount.TabIndex = 6;
            this.lblFailCount.Text = "lblFailCount";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "连接超时ms：";
            // 
            // nudTimeout
            // 
            this.nudTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTimeout.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.nudTimeout.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTimeout.Location = new System.Drawing.Point(732, 62);
            this.nudTimeout.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudTimeout.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(57, 21);
            this.nudTimeout.TabIndex = 4;
            this.nudTimeout.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            // 
            // cbUrl
            // 
            this.cbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUrl.DropDownHeight = 300;
            this.cbUrl.DropDownWidth = 300;
            this.cbUrl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbUrl.FormattingEnabled = true;
            this.cbUrl.IntegralHeight = false;
            this.cbUrl.Location = new System.Drawing.Point(73, 9);
            this.cbUrl.Name = "cbUrl";
            this.cbUrl.Size = new System.Drawing.Size(394, 24);
            this.cbUrl.TabIndex = 7;
            this.cbUrl.Leave += new System.EventHandler(this.cbUrl_Leave);
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownHeight = 100;
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.DropDownWidth = 100;
            this.cbMethod.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.IntegralHeight = false;
            this.cbMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.cbMethod.Location = new System.Drawing.Point(5, 9);
            this.cbMethod.MaxDropDownItems = 3;
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(62, 24);
            this.cbMethod.TabIndex = 7;
            this.cbMethod.SelectedIndexChanged += new System.EventHandler(this.cbMethod_SelectedIndexChanged);
            this.cbMethod.Leave += new System.EventHandler(this.cbUrl_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 417);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.cbUrl);
            this.Controls.Add(this.lblFailCount);
            this.Controls.Add(this.lblOKCount);
            this.Controls.Add(this.nudTimeout);
            this.Controls.Add(this.nudVisitDelay);
            this.Controls.Add(this.nudThreadCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.btnStopLoad);
            this.Controls.Add(this.btnBeginLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "持续加载";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVisitDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnBeginLoad;
        private System.Windows.Forms.Button btnStopLoad;
        private System.Windows.Forms.RichTextBox tbMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudThreadCount;
        private System.Windows.Forms.NumericUpDown nudVisitDelay;
        private System.Windows.Forms.Label lblOKCount;
        private System.Windows.Forms.Label lblFailCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.ComboBox cbUrl;
        private System.Windows.Forms.ComboBox cbMethod;
    }
}

