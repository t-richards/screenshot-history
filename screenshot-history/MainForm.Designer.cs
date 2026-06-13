namespace ScreenshotHistory
{
    partial class MainForm
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.latestPictureBox = new System.Windows.Forms.PictureBox();
            this.previousPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latestPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousPictureBox)).BeginInit();
            this.SuspendLayout();
            //
            // splitContainer
            //
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            //
            // splitContainer.Panel1
            //
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.latestPictureBox);
            //
            // splitContainer.Panel2
            //
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.previousPictureBox);
            this.splitContainer.Size = new System.Drawing.Size(900, 600);
            this.splitContainer.SplitterDistance = 448;
            this.splitContainer.TabIndex = 0;
            //
            // latestPictureBox
            //
            this.latestPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.latestPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.latestPictureBox.Location = new System.Drawing.Point(0, 0);
            this.latestPictureBox.Name = "latestPictureBox";
            this.latestPictureBox.Size = new System.Drawing.Size(448, 600);
            this.latestPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.latestPictureBox.TabIndex = 0;
            this.latestPictureBox.TabStop = false;
            //
            // previousPictureBox
            //
            this.previousPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.previousPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previousPictureBox.Location = new System.Drawing.Point(0, 0);
            this.previousPictureBox.Name = "previousPictureBox";
            this.previousPictureBox.Size = new System.Drawing.Size(448, 600);
            this.previousPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previousPictureBox.TabIndex = 0;
            this.previousPictureBox.TabStop = false;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Screenshot History";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.latestPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox latestPictureBox;
        private System.Windows.Forms.PictureBox previousPictureBox;
    }
}
