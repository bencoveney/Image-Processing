namespace Photoshop
{
    partial class Cropform
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
            this.Exitbutton = new System.Windows.Forms.Button();
            this.Backbutton = new System.Windows.Forms.Button();
            this.SaveFiletextBox = new System.Windows.Forms.TextBox();
            this.OpenFiletextBox = new System.Windows.Forms.TextBox();
            this.SaveFilebutton = new System.Windows.Forms.Button();
            this.NewImagepictureBox = new System.Windows.Forms.PictureBox();
            this.OrigImagepictureBox = new System.Windows.Forms.PictureBox();
            this.OpenFilebutton = new System.Windows.Forms.Button();
            this.HeighttextBox = new System.Windows.Forms.TextBox();
            this.WidthtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NewImagepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigImagepictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Exitbutton
            // 
            this.Exitbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Exitbutton.Location = new System.Drawing.Point(672, 11);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(100, 50);
            this.Exitbutton.TabIndex = 54;
            this.Exitbutton.Text = "Exit";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Backbutton
            // 
            this.Backbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Backbutton.Location = new System.Drawing.Point(566, 10);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(100, 50);
            this.Backbutton.TabIndex = 52;
            this.Backbutton.Text = "Back";
            this.Backbutton.UseVisualStyleBackColor = true;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // SaveFiletextBox
            // 
            this.SaveFiletextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveFiletextBox.Location = new System.Drawing.Point(950, 66);
            this.SaveFiletextBox.Name = "SaveFiletextBox";
            this.SaveFiletextBox.Size = new System.Drawing.Size(100, 20);
            this.SaveFiletextBox.TabIndex = 51;
            // 
            // OpenFiletextBox
            // 
            this.OpenFiletextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenFiletextBox.Location = new System.Drawing.Point(277, 66);
            this.OpenFiletextBox.Name = "OpenFiletextBox";
            this.OpenFiletextBox.Size = new System.Drawing.Size(100, 20);
            this.OpenFiletextBox.TabIndex = 50;
            // 
            // SaveFilebutton
            // 
            this.SaveFilebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveFilebutton.Location = new System.Drawing.Point(950, 10);
            this.SaveFilebutton.Name = "SaveFilebutton";
            this.SaveFilebutton.Size = new System.Drawing.Size(100, 50);
            this.SaveFilebutton.TabIndex = 49;
            this.SaveFilebutton.Text = "Save File";
            this.SaveFilebutton.UseVisualStyleBackColor = true;
            this.SaveFilebutton.Click += new System.EventHandler(this.SaveFilebutton_Click);
            // 
            // NewImagepictureBox
            // 
            this.NewImagepictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewImagepictureBox.Location = new System.Drawing.Point(816, 198);
            this.NewImagepictureBox.Name = "NewImagepictureBox";
            this.NewImagepictureBox.Size = new System.Drawing.Size(512, 512);
            this.NewImagepictureBox.TabIndex = 47;
            this.NewImagepictureBox.TabStop = false;
            // 
            // OrigImagepictureBox
            // 
            this.OrigImagepictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OrigImagepictureBox.Location = new System.Drawing.Point(12, 198);
            this.OrigImagepictureBox.Name = "OrigImagepictureBox";
            this.OrigImagepictureBox.Size = new System.Drawing.Size(512, 512);
            this.OrigImagepictureBox.TabIndex = 60;
            this.OrigImagepictureBox.TabStop = false;
            this.OrigImagepictureBox.Click += new System.EventHandler(this.OrigImagepictureBox_Click);
            // 
            // OpenFilebutton
            // 
            this.OpenFilebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenFilebutton.Location = new System.Drawing.Point(277, 10);
            this.OpenFilebutton.Name = "OpenFilebutton";
            this.OpenFilebutton.Size = new System.Drawing.Size(100, 50);
            this.OpenFilebutton.TabIndex = 46;
            this.OpenFilebutton.Text = "Open File";
            this.OpenFilebutton.UseVisualStyleBackColor = true;
            this.OpenFilebutton.Click += new System.EventHandler(this.OpenFilebutton_Click);
            // 
            // HeighttextBox
            // 
            this.HeighttextBox.Location = new System.Drawing.Point(566, 134);
            this.HeighttextBox.Name = "HeighttextBox";
            this.HeighttextBox.Size = new System.Drawing.Size(100, 20);
            this.HeighttextBox.TabIndex = 56;
            // 
            // WidthtextBox
            // 
            this.WidthtextBox.Location = new System.Drawing.Point(672, 134);
            this.WidthtextBox.Name = "WidthtextBox";
            this.WidthtextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthtextBox.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(691, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Height";
            // 
            // Cropform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 722);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthtextBox);
            this.Controls.Add(this.HeighttextBox);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.SaveFiletextBox);
            this.Controls.Add(this.OpenFiletextBox);
            this.Controls.Add(this.SaveFilebutton);
            this.Controls.Add(this.NewImagepictureBox);
            this.Controls.Add(this.OrigImagepictureBox);
            this.Controls.Add(this.OpenFilebutton);
            this.Name = "Cropform";
            this.Text = "Cropform";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.NewImagepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigImagepictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.TextBox SaveFiletextBox;
        private System.Windows.Forms.TextBox OpenFiletextBox;
        private System.Windows.Forms.Button SaveFilebutton;
        private System.Windows.Forms.PictureBox NewImagepictureBox;
        private System.Windows.Forms.PictureBox OrigImagepictureBox;
        private System.Windows.Forms.Button OpenFilebutton;
        private System.Windows.Forms.TextBox HeighttextBox;
        private System.Windows.Forms.TextBox WidthtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}