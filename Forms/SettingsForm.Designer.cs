
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LabelRed = new System.Windows.Forms.Label();
            this.LabelBlack = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(49, 10);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 0;
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
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(163, 10);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown2.TabIndex = 2;
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.LabelBlack);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.LabelRed);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label LabelRed;
        private System.Windows.Forms.Label LabelBlack;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button ButtonRefresh;
    }
}