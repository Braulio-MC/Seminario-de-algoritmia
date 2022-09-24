
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
            this.OpnFileMainImg = new System.Windows.Forms.OpenFileDialog();
            this.BtnOpnMainImg = new System.Windows.Forms.Button();
            this.GBoxProcessOptions = new System.Windows.Forms.GroupBox();
            this.BtnAnimation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).BeginInit();
            this.GBoxProcessOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // PteBoxMainImg
            // 
            this.PteBoxMainImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PteBoxMainImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PteBoxMainImg.Location = new System.Drawing.Point(12, 12);
            this.PteBoxMainImg.Name = "PteBoxMainImg";
            this.PteBoxMainImg.Size = new System.Drawing.Size(706, 402);
            this.PteBoxMainImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PteBoxMainImg.TabIndex = 0;
            this.PteBoxMainImg.TabStop = false;
            this.PteBoxMainImg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PteBoxMainImg_MouseClick);
            this.PteBoxMainImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PteBoxMainImg_MouseMove);
            // 
            // LblMessages
            // 
            this.LblMessages.AutoSize = true;
            this.LblMessages.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMessages.Location = new System.Drawing.Point(12, 423);
            this.LblMessages.Name = "LblMessages";
            this.LblMessages.Size = new System.Drawing.Size(90, 16);
            this.LblMessages.TabIndex = 1;
            this.LblMessages.Text = "LblMessages";
            // 
            // BtnOpnMainImg
            // 
            this.BtnOpnMainImg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOpnMainImg.Location = new System.Drawing.Point(6, 22);
            this.BtnOpnMainImg.Name = "BtnOpnMainImg";
            this.BtnOpnMainImg.Size = new System.Drawing.Size(129, 27);
            this.BtnOpnMainImg.TabIndex = 3;
            this.BtnOpnMainImg.Text = "Abrir imagen";
            this.BtnOpnMainImg.UseVisualStyleBackColor = true;
            this.BtnOpnMainImg.Click += new System.EventHandler(this.BtnOpnMainImg_Click);
            // 
            // GBoxProcessOptions
            // 
            this.GBoxProcessOptions.Controls.Add(this.BtnAnimation);
            this.GBoxProcessOptions.Controls.Add(this.BtnOpnMainImg);
            this.GBoxProcessOptions.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GBoxProcessOptions.Location = new System.Drawing.Point(443, 420);
            this.GBoxProcessOptions.Name = "GBoxProcessOptions";
            this.GBoxProcessOptions.Size = new System.Drawing.Size(275, 55);
            this.GBoxProcessOptions.TabIndex = 4;
            this.GBoxProcessOptions.TabStop = false;
            this.GBoxProcessOptions.Text = "Procesamiento";
            // 
            // BtnAnimation
            // 
            this.BtnAnimation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAnimation.Location = new System.Drawing.Point(141, 22);
            this.BtnAnimation.Name = "BtnAnimation";
            this.BtnAnimation.Size = new System.Drawing.Size(129, 27);
            this.BtnAnimation.TabIndex = 4;
            this.BtnAnimation.Text = "Iniciar recorrido";
            this.BtnAnimation.UseVisualStyleBackColor = true;
            this.BtnAnimation.Click += new System.EventHandler(this.BtnAnimation_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 481);
            this.Controls.Add(this.GBoxProcessOptions);
            this.Controls.Add(this.LblMessages);
            this.Controls.Add(this.PteBoxMainImg);
            this.Name = "MainWindow";
            this.Text = "Actividad 5";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).EndInit();
            this.GBoxProcessOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PteBoxMainImg;
        private System.Windows.Forms.Label LblMessages;
        private System.Windows.Forms.OpenFileDialog OpnFileMainImg;
        private System.Windows.Forms.Button BtnOpnMainImg;
        private System.Windows.Forms.GroupBox GBoxProcessOptions;
        private System.Windows.Forms.Button BtnAnimation;
    }
}

