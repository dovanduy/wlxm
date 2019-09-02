namespace wlxm
{
    partial class Form1_mr
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpanduoxiancheng = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.duoxiancheng = new System.Windows.Forms.Button();
            this.quanliucheng = new System.Windows.Forms.Button();
            this.ceshi_button = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 371);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dpanduoxiancheng);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.duoxiancheng);
            this.tabPage1.Controls.Add(this.quanliucheng);
            this.tabPage1.Controls.Add(this.ceshi_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(361, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.ForeColor = System.Drawing.Color.DarkSalmon;
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.ForeColor = System.Drawing.Color.DarkSalmon;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 24F);
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(90, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // dpanduoxiancheng
            // 
            this.dpanduoxiancheng.Location = new System.Drawing.Point(22, 233);
            this.dpanduoxiancheng.Name = "dpanduoxiancheng";
            this.dpanduoxiancheng.Size = new System.Drawing.Size(80, 39);
            this.dpanduoxiancheng.TabIndex = 8;
            this.dpanduoxiancheng.Text = "D盘多线程";
            this.dpanduoxiancheng.UseVisualStyleBackColor = true;
            this.dpanduoxiancheng.Click += new System.EventHandler(this.dpanduoxiancheng_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // duoxiancheng
            // 
            this.duoxiancheng.Location = new System.Drawing.Point(22, 162);
            this.duoxiancheng.Name = "duoxiancheng";
            this.duoxiancheng.Size = new System.Drawing.Size(80, 39);
            this.duoxiancheng.TabIndex = 4;
            this.duoxiancheng.Text = "C盘多线程";
            this.duoxiancheng.UseVisualStyleBackColor = true;
            this.duoxiancheng.Click += new System.EventHandler(this.duoxiancheng_Click);
            // 
            // quanliucheng
            // 
            this.quanliucheng.Location = new System.Drawing.Point(196, 214);
            this.quanliucheng.Name = "quanliucheng";
            this.quanliucheng.Size = new System.Drawing.Size(67, 23);
            this.quanliucheng.TabIndex = 3;
            this.quanliucheng.Text = "全流程";
            this.quanliucheng.UseVisualStyleBackColor = true;
            this.quanliucheng.Click += new System.EventHandler(this.quanliucheng_Click);
            // 
            // ceshi_button
            // 
            this.ceshi_button.Location = new System.Drawing.Point(195, 259);
            this.ceshi_button.Name = "ceshi_button";
            this.ceshi_button.Size = new System.Drawing.Size(75, 36);
            this.ceshi_button.TabIndex = 0;
            this.ceshi_button.Text = "测试多线程";
            this.ceshi_button.UseVisualStyleBackColor = true;
            this.ceshi_button.Click += new System.EventHandler(this.ceshi_button_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 365);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button ceshi_button;
        private System.Windows.Forms.Button quanliucheng;
        private System.Windows.Forms.Button duoxiancheng;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dpanduoxiancheng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

