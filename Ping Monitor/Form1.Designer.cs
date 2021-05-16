namespace SurveilNetwork
{
    partial class Surveil
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Surveil));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxS = new System.Windows.Forms.TextBox();
            this.labelS = new System.Windows.Forms.Label();
            this.checkBoxS = new System.Windows.Forms.CheckBox();
            this.labelCaption = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Transparency_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AcceptsTab = true;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxS
            // 
            resources.ApplyResources(this.textBoxS, "textBoxS");
            this.textBoxS.Name = "textBoxS";
            // 
            // labelS
            // 
            resources.ApplyResources(this.labelS, "labelS");
            this.labelS.Name = "labelS";
            // 
            // checkBoxS
            // 
            resources.ApplyResources(this.checkBoxS, "checkBoxS");
            this.checkBoxS.Name = "checkBoxS";
            this.checkBoxS.UseVisualStyleBackColor = true;
            this.checkBoxS.CheckedChanged += new System.EventHandler(this.checkBoxS_CheckedChanged);
            // 
            // labelCaption
            // 
            resources.ApplyResources(this.labelCaption, "labelCaption");
            this.labelCaption.Name = "labelCaption";
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Tag = "투명도";
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Transparency_Label
            // 
            resources.ApplyResources(this.Transparency_Label, "Transparency_Label");
            this.Transparency_Label.Name = "Transparency_Label";
            // 
            // Surveil
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Transparency_Label);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.checkBoxS);
            this.Controls.Add(this.labelS);
            this.Controls.Add(this.textBoxS);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Surveil";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxS;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.CheckBox checkBoxS;
        private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label Transparency_Label;
    }
}