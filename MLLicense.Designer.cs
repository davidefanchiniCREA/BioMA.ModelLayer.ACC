namespace CRA.ModelLayer.ACC
{
    partial class MLLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MLLicense));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            chkLicense = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            chkIdoNotAccept = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(275, 27);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(124, 42);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Location = new System.Drawing.Point(43, 113);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(604, 74);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.Navy;
            label2.Location = new System.Drawing.Point(162, 85);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(326, 20);
            label2.TabIndex = 2;
            label2.Text = "Attribution Non-Commercial Share Alike";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            richTextBox1.Location = new System.Drawing.Point(47, 220);
            richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new System.Drawing.Size(600, 192);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // chkLicense
            // 
            chkLicense.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            chkLicense.AutoSize = true;
            chkLicense.Location = new System.Drawing.Point(50, 426);
            chkLicense.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkLicense.Name = "chkLicense";
            chkLicense.Size = new System.Drawing.Size(159, 19);
            chkLicense.TabIndex = 4;
            chkLicense.Text = "I accept the license terms";
            chkLicense.UseVisualStyleBackColor = true;
            chkLicense.CheckedChanged += chkLicense_CheckedChanged;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.Navy;
            label3.Location = new System.Drawing.Point(298, 187);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(71, 20);
            label3.TabIndex = 5;
            label3.Text = "License";
            // 
            // chkIdoNotAccept
            // 
            chkIdoNotAccept.AutoSize = true;
            chkIdoNotAccept.Location = new System.Drawing.Point(268, 425);
            chkIdoNotAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkIdoNotAccept.Name = "chkIdoNotAccept";
            chkIdoNotAccept.Size = new System.Drawing.Size(349, 19);
            chkIdoNotAccept.TabIndex = 6;
            chkIdoNotAccept.Text = "I do not accept the license term and will not use  the software";
            chkIdoNotAccept.UseVisualStyleBackColor = true;
            chkIdoNotAccept.CheckedChanged += chkIdoNotAccept_CheckedChanged;
            // 
            // MLLicense
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size(685, 462);
            ControlBox = false;
            Controls.Add(chkIdoNotAccept);
            Controls.Add(label3);
            Controls.Add(chkLicense);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MLLicense";
            ShowIcon = false;
            Text = "ModelLayer Software License";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkLicense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIdoNotAccept;
    }
}