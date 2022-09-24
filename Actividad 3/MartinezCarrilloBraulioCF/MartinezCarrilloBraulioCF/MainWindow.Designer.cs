
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
            this.TViewGraph = new System.Windows.Forms.TreeView();
            this.BtnOpnMainImg = new System.Windows.Forms.Button();
            this.OpnFDlgMainImg = new System.Windows.Forms.OpenFileDialog();
            this.LblMessages = new System.Windows.Forms.Label();
            this.CboxInitVtx = new System.Windows.Forms.ComboBox();
            this.CboxFinalVtx = new System.Windows.Forms.ComboBox();
            this.LblInitVtx = new System.Windows.Forms.Label();
            this.LblFinalVtx = new System.Windows.Forms.Label();
            this.BtnAnimation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PteBoxMainImg
            // 
            this.PteBoxMainImg.BackColor = System.Drawing.SystemColors.Control;
            this.PteBoxMainImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PteBoxMainImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PteBoxMainImg.Location = new System.Drawing.Point(12, 12);
            this.PteBoxMainImg.Name = "PteBoxMainImg";
            this.PteBoxMainImg.Size = new System.Drawing.Size(641, 427);
            this.PteBoxMainImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PteBoxMainImg.TabIndex = 0;
            this.PteBoxMainImg.TabStop = false;
            // 
            // TViewGraph
            // 
            this.TViewGraph.Location = new System.Drawing.Point(659, 12);
            this.TViewGraph.Name = "TViewGraph";
            this.TViewGraph.Size = new System.Drawing.Size(181, 394);
            this.TViewGraph.TabIndex = 1;
            // 
            // BtnOpnMainImg
            // 
            this.BtnOpnMainImg.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnOpnMainImg.Location = new System.Drawing.Point(12, 445);
            this.BtnOpnMainImg.Name = "BtnOpnMainImg";
            this.BtnOpnMainImg.Size = new System.Drawing.Size(150, 27);
            this.BtnOpnMainImg.TabIndex = 2;
            this.BtnOpnMainImg.Text = "Cargar imagen";
            this.BtnOpnMainImg.UseVisualStyleBackColor = true;
            this.BtnOpnMainImg.Click += new System.EventHandler(this.BtnOpnMainImg_Click);
            // 
            // LblMessages
            // 
            this.LblMessages.AutoSize = true;
            this.LblMessages.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMessages.Location = new System.Drawing.Point(168, 452);
            this.LblMessages.Name = "LblMessages";
            this.LblMessages.Size = new System.Drawing.Size(106, 16);
            this.LblMessages.TabIndex = 3;
            this.LblMessages.Text = "LabelMessages";
            // 
            // CboxInitVtx
            // 
            this.CboxInitVtx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboxInitVtx.FormattingEnabled = true;
            this.CboxInitVtx.Location = new System.Drawing.Point(769, 412);
            this.CboxInitVtx.Name = "CboxInitVtx";
            this.CboxInitVtx.Size = new System.Drawing.Size(71, 23);
            this.CboxInitVtx.TabIndex = 4;
            this.CboxInitVtx.SelectedIndexChanged += new System.EventHandler(this.CboxInitVtx_SelectedIndexChanged);
            // 
            // CboxFinalVtx
            // 
            this.CboxFinalVtx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboxFinalVtx.FormattingEnabled = true;
            this.CboxFinalVtx.Location = new System.Drawing.Point(769, 445);
            this.CboxFinalVtx.Name = "CboxFinalVtx";
            this.CboxFinalVtx.Size = new System.Drawing.Size(71, 23);
            this.CboxFinalVtx.TabIndex = 5;
            this.CboxFinalVtx.SelectedIndexChanged += new System.EventHandler(this.CboxFinalVtx_SelectedIndexChanged);
            // 
            // LblInitVtx
            // 
            this.LblInitVtx.AutoSize = true;
            this.LblInitVtx.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInitVtx.Location = new System.Drawing.Point(727, 416);
            this.LblInitVtx.Name = "LblInitVtx";
            this.LblInitVtx.Size = new System.Drawing.Size(39, 16);
            this.LblInitVtx.TabIndex = 6;
            this.LblInitVtx.Text = "Inicio";
            // 
            // LblFinalVtx
            // 
            this.LblFinalVtx.AutoSize = true;
            this.LblFinalVtx.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblFinalVtx.Location = new System.Drawing.Point(738, 449);
            this.LblFinalVtx.Name = "LblFinalVtx";
            this.LblFinalVtx.Size = new System.Drawing.Size(27, 16);
            this.LblFinalVtx.TabIndex = 7;
            this.LblFinalVtx.Text = "Fin";
            // 
            // BtnAnimation
            // 
            this.BtnAnimation.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAnimation.Location = new System.Drawing.Point(659, 412);
            this.BtnAnimation.Name = "BtnAnimation";
            this.BtnAnimation.Size = new System.Drawing.Size(181, 61);
            this.BtnAnimation.TabIndex = 8;
            this.BtnAnimation.Text = "Comenzar recorrido";
            this.BtnAnimation.UseVisualStyleBackColor = true;
            this.BtnAnimation.Visible = false;
            this.BtnAnimation.Click += new System.EventHandler(this.BtnAnimation_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 479);
            this.Controls.Add(this.BtnAnimation);
            this.Controls.Add(this.LblFinalVtx);
            this.Controls.Add(this.LblInitVtx);
            this.Controls.Add(this.CboxFinalVtx);
            this.Controls.Add(this.CboxInitVtx);
            this.Controls.Add(this.LblMessages);
            this.Controls.Add(this.BtnOpnMainImg);
            this.Controls.Add(this.TViewGraph);
            this.Controls.Add(this.PteBoxMainImg);
            this.Name = "MainWindow";
            this.Text = "Actividad 3";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PteBoxMainImg;
        private System.Windows.Forms.TreeView TViewGraph;
        private System.Windows.Forms.Button BtnOpnMainImg;
        private System.Windows.Forms.OpenFileDialog OpnFDlgMainImg;
        private System.Windows.Forms.Label LblMessages;
        private System.Windows.Forms.ComboBox CboxInitVtx;
        private System.Windows.Forms.ComboBox CboxFinalVtx;
        private System.Windows.Forms.Label LblInitVtx;
        private System.Windows.Forms.Label LblFinalVtx;
        private System.Windows.Forms.Button BtnAnimation;
    }
}

