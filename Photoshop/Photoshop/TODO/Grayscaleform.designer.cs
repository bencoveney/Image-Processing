namespace Photoshop
{
    partial class Grayscaleform
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
            this.Startbutton = new System.Windows.Forms.Button();
            this.NewImagepictureBox = new System.Windows.Forms.PictureBox();
            this.OrigImagepictureBox = new System.Windows.Forms.PictureBox();
            this.OpenFilebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NewImagepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigImagepictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Exitbutton
            // 
            this.Exitbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Exitbutton.Location = new System.Drawing.Point(726, 47);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(100, 50);
            this.Exitbutton.TabIndex = 36;
            this.Exitbutton.Text = "Exit";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Backbutton
            // 
            this.Backbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Backbutton.Location = new System.Drawing.Point(620, 46);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(100, 50);
            this.Backbutton.TabIndex = 34;
            this.Backbutton.Text = "Back";
            this.Backbutton.UseVisualStyleBackColor = true;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // SaveFiletextBox
            // 
            this.SaveFiletextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveFiletextBox.Location = new System.Drawing.Point(912, 77);
            this.SaveFiletextBox.Name = "SaveFiletextBox";
            this.SaveFiletextBox.Size = new System.Drawing.Size(100, 20);
            this.SaveFiletextBox.TabIndex = 33;
            // 
            // OpenFiletextBox
            // 
            this.OpenFiletextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenFiletextBox.Location = new System.Drawing.Point(293, 84);
            this.OpenFiletextBox.Name = "OpenFiletextBox";
            this.OpenFiletextBox.Size = new System.Drawing.Size(100, 20);
            this.OpenFiletextBox.TabIndex = 32;
            // 
            // SaveFilebutton
            // 
            this.SaveFilebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveFilebutton.Location = new System.Drawing.Point(912, 21);
            this.SaveFilebutton.Name = "SaveFilebutton";
            this.SaveFilebutton.Size = new System.Drawing.Size(100, 50);
            this.SaveFilebutton.TabIndex = 31;
            this.SaveFilebutton.Text = "Save File";
            this.SaveFilebutton.UseVisualStyleBackColor = true;
            this.SaveFilebutton.Click += new System.EventHandler(this.SaveFilebutton_Click);
            // 
            // Startbutton
            // 
            this.Startbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Startbutton.Location = new System.Drawing.Point(514, 46);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(100, 50);
            this.Startbutton.TabIndex = 30;
            this.Startbutton.Text = "Start Program";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // NewImagepictureBox
            // 
            this.NewImagepictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewImagepictureBox.Location = new System.Drawing.Point(816, 198);
            this.NewImagepictureBox.Name = "NewImagepictureBox";
            this.NewImagepictureBox.Size = new System.Drawing.Size(512, 512);
            this.NewImagepictureBox.TabIndex = 29;
            this.NewImagepictureBox.TabStop = false;
            // 
            // OrigImagepictureBox
            // 
            this.OrigImagepictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OrigImagepictureBox.Location = new System.Drawing.Point(12, 198);
            this.OrigImagepictureBox.Name = "OrigImagepictureBox";
            this.OrigImagepictureBox.Size = new System.Drawing.Size(512, 512);
            this.OrigImagepictureBox.TabIndex = 35;
            this.OrigImagepictureBox.TabStop = false;
            // 
            // OpenFilebutton
            // 
            this.OpenFilebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenFilebutton.Location = new System.Drawing.Point(293, 28);
            this.OpenFilebutton.Name = "OpenFilebutton";
            this.OpenFilebutton.Size = new System.Drawing.Size(100, 50);
            this.OpenFilebutton.TabIndex = 28;
            this.OpenFilebutton.Text = "Open File";
            this.OpenFilebutton.UseVisualStyleBackColor = true;
            this.OpenFilebutton.Click += new System.EventHandler(this.OpenFilebutton_Click);
            // 
            // Grayscaleform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 722);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.SaveFiletextBox);
            this.Controls.Add(this.OpenFiletextBox);
            this.Controls.Add(this.SaveFilebutton);
            this.Controls.Add(this.Startbutton);
            this.Controls.Add(this.NewImagepictureBox);
            this.Controls.Add(this.OrigImagepictureBox);
            this.Controls.Add(this.OpenFilebutton);
            this.Name = "Grayscaleform";
            this.Text = "Grayscaleform";
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
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.PictureBox NewImagepictureBox;
        private System.Windows.Forms.PictureBox OrigImagepictureBox;
        private System.Windows.Forms.Button OpenFilebutton;
    }
}