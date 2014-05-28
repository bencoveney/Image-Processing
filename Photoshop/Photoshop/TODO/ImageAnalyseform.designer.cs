namespace Photoshop
{
    partial class ImageAnalyseform
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
            this.OrigImagepictureBox = new System.Windows.Forms.PictureBox();
            this.BluePixelValuetextBox = new System.Windows.Forms.TextBox();
            this.GreenPixelLocationtextBox = new System.Windows.Forms.TextBox();
            this.RedPixelValuetextBox = new System.Windows.Forms.TextBox();
            this.XPixelLocationtextBox = new System.Windows.Forms.TextBox();
            this.YPixelLocationtextBox = new System.Windows.Forms.TextBox();
            this.XPixelLocationlabel = new System.Windows.Forms.Label();
            this.YPixelLocationlabel = new System.Windows.Forms.Label();
            this.RedPixelValuelabel = new System.Windows.Forms.Label();
            this.GreenPixelLocationlabel = new System.Windows.Forms.Label();
            this.BluePixelLocationlabel = new System.Windows.Forms.Label();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.Backbutton = new System.Windows.Forms.Button();
            this.OpenFiletextBox = new System.Windows.Forms.TextBox();
            this.OpenFilebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrigImagepictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OrigImagepictureBox
            // 
            this.OrigImagepictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OrigImagepictureBox.Location = new System.Drawing.Point(412, 198);
            this.OrigImagepictureBox.Name = "OrigImagepictureBox";
            this.OrigImagepictureBox.Size = new System.Drawing.Size(512, 512);
            this.OrigImagepictureBox.TabIndex = 0;
            this.OrigImagepictureBox.TabStop = false;
            this.OrigImagepictureBox.Click += new System.EventHandler(this.OrigImagepictureBox_Click);
            // 
            // BluePixelValuetextBox
            // 
            this.BluePixelValuetextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BluePixelValuetextBox.Location = new System.Drawing.Point(306, 302);
            this.BluePixelValuetextBox.Name = "BluePixelValuetextBox";
            this.BluePixelValuetextBox.Size = new System.Drawing.Size(100, 20);
            this.BluePixelValuetextBox.TabIndex = 1;
            // 
            // GreenPixelLocationtextBox
            // 
            this.GreenPixelLocationtextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GreenPixelLocationtextBox.Location = new System.Drawing.Point(306, 276);
            this.GreenPixelLocationtextBox.Name = "GreenPixelLocationtextBox";
            this.GreenPixelLocationtextBox.Size = new System.Drawing.Size(100, 20);
            this.GreenPixelLocationtextBox.TabIndex = 2;
            // 
            // RedPixelValuetextBox
            // 
            this.RedPixelValuetextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RedPixelValuetextBox.Location = new System.Drawing.Point(306, 250);
            this.RedPixelValuetextBox.Name = "RedPixelValuetextBox";
            this.RedPixelValuetextBox.Size = new System.Drawing.Size(100, 20);
            this.RedPixelValuetextBox.TabIndex = 3;
            // 
            // XPixelLocationtextBox
            // 
            this.XPixelLocationtextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.XPixelLocationtextBox.Location = new System.Drawing.Point(306, 198);
            this.XPixelLocationtextBox.Name = "XPixelLocationtextBox";
            this.XPixelLocationtextBox.Size = new System.Drawing.Size(100, 20);
            this.XPixelLocationtextBox.TabIndex = 4;
            // 
            // YPixelLocationtextBox
            // 
            this.YPixelLocationtextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.YPixelLocationtextBox.Location = new System.Drawing.Point(306, 224);
            this.YPixelLocationtextBox.Name = "YPixelLocationtextBox";
            this.YPixelLocationtextBox.Size = new System.Drawing.Size(100, 20);
            this.YPixelLocationtextBox.TabIndex = 5;
            // 
            // XPixelLocationlabel
            // 
            this.XPixelLocationlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.XPixelLocationlabel.AutoSize = true;
            this.XPixelLocationlabel.Location = new System.Drawing.Point(217, 201);
            this.XPixelLocationlabel.Name = "XPixelLocationlabel";
            this.XPixelLocationlabel.Size = new System.Drawing.Size(83, 13);
            this.XPixelLocationlabel.TabIndex = 6;
            this.XPixelLocationlabel.Text = "X Pixel Location";
            // 
            // YPixelLocationlabel
            // 
            this.YPixelLocationlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.YPixelLocationlabel.AutoSize = true;
            this.YPixelLocationlabel.Location = new System.Drawing.Point(217, 227);
            this.YPixelLocationlabel.Name = "YPixelLocationlabel";
            this.YPixelLocationlabel.Size = new System.Drawing.Size(83, 13);
            this.YPixelLocationlabel.TabIndex = 7;
            this.YPixelLocationlabel.Text = "Y Pixel Location";
            // 
            // RedPixelValuelabel
            // 
            this.RedPixelValuelabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RedPixelValuelabel.AutoSize = true;
            this.RedPixelValuelabel.Location = new System.Drawing.Point(218, 253);
            this.RedPixelValuelabel.Name = "RedPixelValuelabel";
            this.RedPixelValuelabel.Size = new System.Drawing.Size(82, 13);
            this.RedPixelValuelabel.TabIndex = 8;
            this.RedPixelValuelabel.Text = "Red Pixel Value";
            // 
            // GreenPixelLocationlabel
            // 
            this.GreenPixelLocationlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GreenPixelLocationlabel.AutoSize = true;
            this.GreenPixelLocationlabel.Location = new System.Drawing.Point(209, 279);
            this.GreenPixelLocationlabel.Name = "GreenPixelLocationlabel";
            this.GreenPixelLocationlabel.Size = new System.Drawing.Size(91, 13);
            this.GreenPixelLocationlabel.TabIndex = 9;
            this.GreenPixelLocationlabel.Text = "Green Pixel Value";
            // 
            // BluePixelLocationlabel
            // 
            this.BluePixelLocationlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BluePixelLocationlabel.AutoSize = true;
            this.BluePixelLocationlabel.Location = new System.Drawing.Point(217, 305);
            this.BluePixelLocationlabel.Name = "BluePixelLocationlabel";
            this.BluePixelLocationlabel.Size = new System.Drawing.Size(83, 13);
            this.BluePixelLocationlabel.TabIndex = 10;
            this.BluePixelLocationlabel.Text = "Blue Pixel Value";
            // 
            // Exitbutton
            // 
            this.Exitbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Exitbutton.Location = new System.Drawing.Point(669, 12);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(100, 50);
            this.Exitbutton.TabIndex = 56;
            this.Exitbutton.Text = "Exit";
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // Backbutton
            // 
            this.Backbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Backbutton.Location = new System.Drawing.Point(563, 12);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(100, 50);
            this.Backbutton.TabIndex = 55;
            this.Backbutton.Text = "Back";
            this.Backbutton.UseVisualStyleBackColor = true;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // OpenFiletextBox
            // 
            this.OpenFiletextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenFiletextBox.Location = new System.Drawing.Point(457, 68);
            this.OpenFiletextBox.Name = "OpenFiletextBox";
            this.OpenFiletextBox.Size = new System.Drawing.Size(100, 20);
            this.OpenFiletextBox.TabIndex = 58;
            // 
            // OpenFilebutton
            // 
            this.OpenFilebutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenFilebutton.Location = new System.Drawing.Point(457, 12);
            this.OpenFilebutton.Name = "OpenFilebutton";
            this.OpenFilebutton.Size = new System.Drawing.Size(100, 50);
            this.OpenFilebutton.TabIndex = 57;
            this.OpenFilebutton.Text = "Open File";
            this.OpenFilebutton.UseVisualStyleBackColor = true;
            this.OpenFilebutton.Click += new System.EventHandler(this.OpenFilebutton_Click);
            // 
            // ImageAnalyseform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 722);
            this.Controls.Add(this.OpenFiletextBox);
            this.Controls.Add(this.OpenFilebutton);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.BluePixelLocationlabel);
            this.Controls.Add(this.GreenPixelLocationlabel);
            this.Controls.Add(this.RedPixelValuelabel);
            this.Controls.Add(this.YPixelLocationlabel);
            this.Controls.Add(this.XPixelLocationlabel);
            this.Controls.Add(this.YPixelLocationtextBox);
            this.Controls.Add(this.XPixelLocationtextBox);
            this.Controls.Add(this.RedPixelValuetextBox);
            this.Controls.Add(this.GreenPixelLocationtextBox);
            this.Controls.Add(this.BluePixelValuetextBox);
            this.Controls.Add(this.OrigImagepictureBox);
            this.Name = "ImageAnalyseform";
            this.Text = "ImageAnalyseform";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.OrigImagepictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OrigImagepictureBox;
        private System.Windows.Forms.TextBox BluePixelValuetextBox;
        private System.Windows.Forms.TextBox GreenPixelLocationtextBox;
        private System.Windows.Forms.TextBox RedPixelValuetextBox;
        private System.Windows.Forms.TextBox XPixelLocationtextBox;
        private System.Windows.Forms.TextBox YPixelLocationtextBox;
        private System.Windows.Forms.Label XPixelLocationlabel;
        private System.Windows.Forms.Label YPixelLocationlabel;
        private System.Windows.Forms.Label RedPixelValuelabel;
        private System.Windows.Forms.Label GreenPixelLocationlabel;
        private System.Windows.Forms.Label BluePixelLocationlabel;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.TextBox OpenFiletextBox;
        private System.Windows.Forms.Button OpenFilebutton;
    }
}