
namespace tabletcka.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.numericUpDownRed = new System.Windows.Forms.NumericUpDown();
			this.LabelRed = new System.Windows.Forms.Label();
			this.LabelBlack = new System.Windows.Forms.Label();
			this.numericUpDownBlack = new System.Windows.Forms.NumericUpDown();
			this.ButtonRefresh = new System.Windows.Forms.Button();
			this.checkBoxKeepRedBlackRatio = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlack)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownRed
			// 
			this.numericUpDownRed.Location = new System.Drawing.Point(49, 10);
			this.numericUpDownRed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownRed.Name = "numericUpDownRed";
			this.numericUpDownRed.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownRed.TabIndex = 0;
			this.numericUpDownRed.ValueChanged += new System.EventHandler(this.numericUpDownRed_ValueChanged);
			// 
			// LabelRed
			// 
			this.LabelRed.AutoSize = true;
			this.LabelRed.Location = new System.Drawing.Point(13, 12);
			this.LabelRed.Name = "LabelRed";
			this.LabelRed.Size = new System.Drawing.Size(30, 13);
			this.LabelRed.TabIndex = 1;
			this.LabelRed.Text = "Red:";
			// 
			// LabelBlack
			// 
			this.LabelBlack.AutoSize = true;
			this.LabelBlack.Location = new System.Drawing.Point(120, 12);
			this.LabelBlack.Name = "LabelBlack";
			this.LabelBlack.Size = new System.Drawing.Size(37, 13);
			this.LabelBlack.TabIndex = 3;
			this.LabelBlack.Text = "Black:";
			// 
			// numericUpDownBlack
			// 
			this.numericUpDownBlack.Location = new System.Drawing.Point(163, 10);
			this.numericUpDownBlack.Name = "numericUpDownBlack";
			this.numericUpDownBlack.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownBlack.TabIndex = 2;
			this.numericUpDownBlack.ValueChanged += new System.EventHandler(this.numericUpDownBlack_ValueChanged);
			// 
			// ButtonRefresh
			// 
			this.ButtonRefresh.Location = new System.Drawing.Point(13, 126);
			this.ButtonRefresh.Name = "ButtonRefresh";
			this.ButtonRefresh.Size = new System.Drawing.Size(75, 23);
			this.ButtonRefresh.TabIndex = 4;
			this.ButtonRefresh.Text = "Refresh";
			this.ButtonRefresh.UseVisualStyleBackColor = true;
			this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
			// 
			// checkBoxKeepRedBlackRatio
			// 
			this.checkBoxKeepRedBlackRatio.AutoSize = true;
			this.checkBoxKeepRedBlackRatio.Location = new System.Drawing.Point(16, 36);
			this.checkBoxKeepRedBlackRatio.Name = "checkBoxKeepRedBlackRatio";
			this.checkBoxKeepRedBlackRatio.Size = new System.Drawing.Size(181, 17);
			this.checkBoxKeepRedBlackRatio.TabIndex = 5;
			this.checkBoxKeepRedBlackRatio.Text = "Keep red and black window ratio";
			this.checkBoxKeepRedBlackRatio.UseVisualStyleBackColor = true;
			this.checkBoxKeepRedBlackRatio.CheckedChanged += new System.EventHandler(this.checkBoxKeepRedBlackRatio_CheckedChanged);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 161);
			this.Controls.Add(this.checkBoxKeepRedBlackRatio);
			this.Controls.Add(this.ButtonRefresh);
			this.Controls.Add(this.LabelBlack);
			this.Controls.Add(this.numericUpDownBlack);
			this.Controls.Add(this.LabelRed);
			this.Controls.Add(this.numericUpDownRed);
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlack)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownRed;
        private System.Windows.Forms.Label LabelRed;
        private System.Windows.Forms.Label LabelBlack;
        private System.Windows.Forms.NumericUpDown numericUpDownBlack;
        private System.Windows.Forms.Button ButtonRefresh;
		private System.Windows.Forms.CheckBox checkBoxKeepRedBlackRatio;
	}
}