namespace Photoshop.BitmapTransform
{
    partial class SelectOnImage
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
            this.Panel = new System.Windows.Forms.Panel();
            this.ImageDisplay = new System.Windows.Forms.PictureBox();
            this.MakeSelectionButton = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.AutoScroll = true;
            this.Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel.Controls.Add(this.ImageDisplay);
            this.Panel.Location = new System.Drawing.Point(12, 12);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(368, 296);
            this.Panel.TabIndex = 0;
            // 
            // ImageDisplay
            // 
            this.ImageDisplay.Location = new System.Drawing.Point(0, 0);
            this.ImageDisplay.Name = "ImageDisplay";
            this.ImageDisplay.Size = new System.Drawing.Size(69, 69);
            this.ImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageDisplay.TabIndex = 0;
            this.ImageDisplay.TabStop = false;
            this.ImageDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageDisplay_Paint);
            this.ImageDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageDisplay_MouseDown);
            this.ImageDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageDisplay_MouseMove);
            // 
            // MakeSelectionButton
            // 
            this.MakeSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MakeSelectionButton.Location = new System.Drawing.Point(12, 314);
            this.MakeSelectionButton.Name = "MakeSelectionButton";
            this.MakeSelectionButton.Size = new System.Drawing.Size(368, 41);
            this.MakeSelectionButton.TabIndex = 1;
            this.MakeSelectionButton.Text = "Make Selection";
            this.MakeSelectionButton.UseVisualStyleBackColor = true;
            this.MakeSelectionButton.Click += new System.EventHandler(this.MakeSelectionButton_Click);
            // 
            // SelectOnImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 367);
            this.Controls.Add(this.MakeSelectionButton);
            this.Controls.Add(this.Panel);
            this.Name = "SelectOnImage";
            this.Text = "Select";
            this.Load += new System.EventHandler(this.SelectOnImage_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button MakeSelectionButton;
        private System.Windows.Forms.PictureBox ImageDisplay;
    }
}