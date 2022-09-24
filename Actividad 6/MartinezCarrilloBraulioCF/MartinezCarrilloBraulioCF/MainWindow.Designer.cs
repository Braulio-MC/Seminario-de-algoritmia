
namespace MartinezCarrilloBraulioCF
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PteBoxMainImg = new System.Windows.Forms.PictureBox();
            this.LblMessages = new System.Windows.Forms.Label();
            this.BtnOpnMainImg = new System.Windows.Forms.Button();
            this.OpnFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.BtnAnimation = new System.Windows.Forms.Button();
            this.GBoxProcessing = new System.Windows.Forms.GroupBox();
            this.GBoxAnimation = new System.Windows.Forms.GroupBox();
            this.LblPredatorRdrSz = new System.Windows.Forms.Label();
            this.NUpDwnPredRdrSz = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).BeginInit();
            this.GBoxProcessing.SuspendLayout();
            this.GBoxAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDwnPredRdrSz)).BeginInit();
            this.SuspendLayout();
            // 
            // PteBoxMainImg
            // 
            this.PteBoxMainImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PteBoxMainImg.Location = new System.Drawing.Point(12, 12);
            this.PteBoxMainImg.Name = "PteBoxMainImg";
            this.PteBoxMainImg.Size = new System.Drawing.Size(735, 431);
            this.PteBoxMainImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PteBoxMainImg.TabIndex = 0;
            this.PteBoxMainImg.TabStop = false;
            this.PteBoxMainImg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PteBoxMainImg_MouseClick);
            // 
            // LblMessages
            // 
            this.LblMessages.AutoSize = true;
            this.LblMessages.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMessages.Location = new System.Drawing.Point(12, 455);
            this.LblMessages.Name = "LblMessages";
            this.LblMessages.Size = new System.Drawing.Size(90, 16);
            this.LblMessages.TabIndex = 1;
            this.LblMessages.Text = "LblMessages";
            // 
            // BtnOpnMainImg
            // 
            this.BtnOpnMainImg.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOpnMainImg.Location = new System.Drawing.Point(6, 22);
            this.BtnOpnMainImg.Name = "BtnOpnMainImg";
            this.BtnOpnMainImg.Size = new System.Drawing.Size(151, 29);
            this.BtnOpnMainImg.TabIndex = 2;
            this.BtnOpnMainImg.Text = "Cargar imagen";
            this.BtnOpnMainImg.UseVisualStyleBackColor = true;
            this.BtnOpnMainImg.Click += new System.EventHandler(this.BtnOpnMainImg_Click);
            // 
            // BtnAnimation
            // 
            this.BtnAnimation.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAnimation.Location = new System.Drawing.Point(6, 22);
            this.BtnAnimation.Name = "BtnAnimation";
            this.BtnAnimation.Size = new System.Drawing.Size(149, 29);
            this.BtnAnimation.TabIndex = 3;
            this.BtnAnimation.Text = "Comenzar animacion";
            this.BtnAnimation.UseVisualStyleBackColor = true;
            this.BtnAnimation.Click += new System.EventHandler(this.BtnAnimation_Click);
            // 
            // GBoxProcessing
            // 
            this.GBoxProcessing.Controls.Add(this.BtnOpnMainImg);
            this.GBoxProcessing.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GBoxProcessing.Location = new System.Drawing.Point(753, 12);
            this.GBoxProcessing.Name = "GBoxProcessing";
            this.GBoxProcessing.Size = new System.Drawing.Size(164, 94);
            this.GBoxProcessing.TabIndex = 4;
            this.GBoxProcessing.TabStop = false;
            this.GBoxProcessing.Text = "Procesamiento";
            // 
            // GBoxAnimation
            // 
            this.GBoxAnimation.Controls.Add(this.LblPredatorRdrSz);
            this.GBoxAnimation.Controls.Add(this.NUpDwnPredRdrSz);
            this.GBoxAnimation.Controls.Add(this.BtnAnimation);
            this.GBoxAnimation.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GBoxAnimation.Location = new System.Drawing.Point(753, 112);
            this.GBoxAnimation.Name = "GBoxAnimation";
            this.GBoxAnimation.Size = new System.Drawing.Size(164, 110);
            this.GBoxAnimation.TabIndex = 5;
            this.GBoxAnimation.TabStop = false;
            this.GBoxAnimation.Text = "Animacion";
            // 
            // LblPredatorRdrSz
            // 
            this.LblPredatorRdrSz.AutoSize = true;
            this.LblPredatorRdrSz.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPredatorRdrSz.Location = new System.Drawing.Point(6, 59);
            this.LblPredatorRdrSz.Name = "LblPredatorRdrSz";
            this.LblPredatorRdrSz.Size = new System.Drawing.Size(104, 15);
            this.LblPredatorRdrSz.TabIndex = 5;
            this.LblPredatorRdrSz.Text = "Tamaño del radar";
            // 
            // NUpDwnPredRdrSz
            // 
            this.NUpDwnPredRdrSz.Location = new System.Drawing.Point(6, 77);
            this.NUpDwnPredRdrSz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUpDwnPredRdrSz.Name = "NUpDwnPredRdrSz";
            this.NUpDwnPredRdrSz.Size = new System.Drawing.Size(149, 23);
            this.NUpDwnPredRdrSz.TabIndex = 4;
            this.NUpDwnPredRdrSz.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUpDwnPredRdrSz.ValueChanged += new System.EventHandler(this.NUpDwnPredRdrSz_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 484);
            this.Controls.Add(this.GBoxAnimation);
            this.Controls.Add(this.GBoxProcessing);
            this.Controls.Add(this.LblMessages);
            this.Controls.Add(this.PteBoxMainImg);
            this.MaximumSize = new System.Drawing.Size(945, 523);
            this.MinimumSize = new System.Drawing.Size(945, 523);
            this.Name = "MainWindow";
            this.Text = "Actividad 6";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).EndInit();
            this.GBoxProcessing.ResumeLayout(false);
            this.GBoxAnimation.ResumeLayout(false);
            this.GBoxAnimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUpDwnPredRdrSz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PteBoxMainImg;
        private System.Windows.Forms.Label LblMessages;
        private System.Windows.Forms.Button BtnOpnMainImg;
        private System.Windows.Forms.OpenFileDialog OpnFileDlg;
        private System.Windows.Forms.Button BtnAnimation;
        private System.Windows.Forms.GroupBox GBoxProcessing;
        private System.Windows.Forms.GroupBox GBoxAnimation;
        private System.Windows.Forms.Label LblPredatorRdrSz;
        private System.Windows.Forms.NumericUpDown NUpDwnPredRdrSz;
    }
}

