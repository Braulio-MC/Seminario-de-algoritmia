
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
            this.BtnChargeMainImg = new System.Windows.Forms.Button();
            this.OpnFileDlgMainImg = new System.Windows.Forms.OpenFileDialog();
            this.LblMessages = new System.Windows.Forms.Label();
            this.GBoxARMOptions = new System.Windows.Forms.GroupBox();
            this.RBtnCompareKruskalPrim = new System.Windows.Forms.RadioButton();
            this.RBtnPrimsARM = new System.Windows.Forms.RadioButton();
            this.RBtnKruskalsARM = new System.Windows.Forms.RadioButton();
            this.PteBoxTmp = new System.Windows.Forms.PictureBox();
            this.CBoxInitVertex = new System.Windows.Forms.ComboBox();
            this.LblInitVertex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).BeginInit();
            this.GBoxARMOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxTmp)).BeginInit();
            this.SuspendLayout();
            // 
            // PteBoxMainImg
            // 
            this.PteBoxMainImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PteBoxMainImg.Location = new System.Drawing.Point(12, 12);
            this.PteBoxMainImg.Name = "PteBoxMainImg";
            this.PteBoxMainImg.Size = new System.Drawing.Size(652, 411);
            this.PteBoxMainImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PteBoxMainImg.TabIndex = 0;
            this.PteBoxMainImg.TabStop = false;
            // 
            // BtnChargeMainImg
            // 
            this.BtnChargeMainImg.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnChargeMainImg.Location = new System.Drawing.Point(490, 429);
            this.BtnChargeMainImg.Name = "BtnChargeMainImg";
            this.BtnChargeMainImg.Size = new System.Drawing.Size(174, 48);
            this.BtnChargeMainImg.TabIndex = 1;
            this.BtnChargeMainImg.Text = "Cargar imagen";
            this.BtnChargeMainImg.UseVisualStyleBackColor = true;
            this.BtnChargeMainImg.Click += new System.EventHandler(this.BtnChargeMainImg_Click);
            // 
            // LblMessages
            // 
            this.LblMessages.AutoSize = true;
            this.LblMessages.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMessages.Location = new System.Drawing.Point(12, 485);
            this.LblMessages.Name = "LblMessages";
            this.LblMessages.Size = new System.Drawing.Size(90, 16);
            this.LblMessages.TabIndex = 2;
            this.LblMessages.Text = "LblMessages";
            // 
            // GBoxARMOptions
            // 
            this.GBoxARMOptions.Controls.Add(this.RBtnCompareKruskalPrim);
            this.GBoxARMOptions.Controls.Add(this.RBtnPrimsARM);
            this.GBoxARMOptions.Controls.Add(this.RBtnKruskalsARM);
            this.GBoxARMOptions.Location = new System.Drawing.Point(12, 429);
            this.GBoxARMOptions.Name = "GBoxARMOptions";
            this.GBoxARMOptions.Size = new System.Drawing.Size(472, 48);
            this.GBoxARMOptions.TabIndex = 3;
            this.GBoxARMOptions.TabStop = false;
            this.GBoxARMOptions.Text = "Opciones para ARM";
            // 
            // RBtnCompareKruskalPrim
            // 
            this.RBtnCompareKruskalPrim.AutoSize = true;
            this.RBtnCompareKruskalPrim.Location = new System.Drawing.Point(236, 23);
            this.RBtnCompareKruskalPrim.Name = "RBtnCompareKruskalPrim";
            this.RBtnCompareKruskalPrim.Size = new System.Drawing.Size(229, 19);
            this.RBtnCompareKruskalPrim.TabIndex = 2;
            this.RBtnCompareKruskalPrim.TabStop = true;
            this.RBtnCompareKruskalPrim.Text = "Comparar resultados de Kruskal y Prim";
            this.RBtnCompareKruskalPrim.UseVisualStyleBackColor = true;
            this.RBtnCompareKruskalPrim.CheckedChanged += new System.EventHandler(this.RBtnCompareKruskalPrim_CheckedChanged);
            // 
            // RBtnPrimsARM
            // 
            this.RBtnPrimsARM.AutoSize = true;
            this.RBtnPrimsARM.Location = new System.Drawing.Point(128, 22);
            this.RBtnPrimsARM.Name = "RBtnPrimsARM";
            this.RBtnPrimsARM.Size = new System.Drawing.Size(102, 19);
            this.RBtnPrimsARM.TabIndex = 1;
            this.RBtnPrimsARM.TabStop = true;
            this.RBtnPrimsARM.Text = "ARM con Prim";
            this.RBtnPrimsARM.UseVisualStyleBackColor = true;
            this.RBtnPrimsARM.CheckedChanged += new System.EventHandler(this.RBtnPrimsARM_CheckedChanged);
            // 
            // RBtnKruskalsARM
            // 
            this.RBtnKruskalsARM.AutoSize = true;
            this.RBtnKruskalsARM.Location = new System.Drawing.Point(7, 23);
            this.RBtnKruskalsARM.Name = "RBtnKruskalsARM";
            this.RBtnKruskalsARM.Size = new System.Drawing.Size(115, 19);
            this.RBtnKruskalsARM.TabIndex = 0;
            this.RBtnKruskalsARM.TabStop = true;
            this.RBtnKruskalsARM.Text = "ARM con Kruskal";
            this.RBtnKruskalsARM.UseVisualStyleBackColor = true;
            this.RBtnKruskalsARM.CheckedChanged += new System.EventHandler(this.RBtnKruskalsARM_CheckedChanged);
            // 
            // PteBoxTmp
            // 
            this.PteBoxTmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PteBoxTmp.Location = new System.Drawing.Point(338, 12);
            this.PteBoxTmp.Name = "PteBoxTmp";
            this.PteBoxTmp.Size = new System.Drawing.Size(327, 411);
            this.PteBoxTmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PteBoxTmp.TabIndex = 4;
            this.PteBoxTmp.TabStop = false;
            this.PteBoxTmp.Visible = false;
            // 
            // CBoxInitVertex
            // 
            this.CBoxInitVertex.FormattingEnabled = true;
            this.CBoxInitVertex.Location = new System.Drawing.Point(569, 483);
            this.CBoxInitVertex.Name = "CBoxInitVertex";
            this.CBoxInitVertex.Size = new System.Drawing.Size(95, 23);
            this.CBoxInitVertex.TabIndex = 5;
            this.CBoxInitVertex.Visible = false;
            this.CBoxInitVertex.SelectedIndexChanged += new System.EventHandler(this.CBoxInitVertex_SelectedIndexChanged);
            // 
            // LblInitVertex
            // 
            this.LblInitVertex.AutoSize = true;
            this.LblInitVertex.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInitVertex.Location = new System.Drawing.Point(490, 486);
            this.LblInitVertex.Name = "LblInitVertex";
            this.LblInitVertex.Size = new System.Drawing.Size(79, 15);
            this.LblInitVertex.TabIndex = 6;
            this.LblInitVertex.Text = "Vértice inicio:";
            this.LblInitVertex.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 514);
            this.Controls.Add(this.LblInitVertex);
            this.Controls.Add(this.CBoxInitVertex);
            this.Controls.Add(this.PteBoxTmp);
            this.Controls.Add(this.GBoxARMOptions);
            this.Controls.Add(this.LblMessages);
            this.Controls.Add(this.BtnChargeMainImg);
            this.Controls.Add(this.PteBoxMainImg);
            this.Name = "MainWindow";
            this.Text = "Actividad 4";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxMainImg)).EndInit();
            this.GBoxARMOptions.ResumeLayout(false);
            this.GBoxARMOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxTmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PteBoxMainImg;
        private System.Windows.Forms.Button BtnChargeMainImg;
        private System.Windows.Forms.OpenFileDialog OpnFileDlgMainImg;
        private System.Windows.Forms.Label LblMessages;
        private System.Windows.Forms.GroupBox GBoxARMOptions;
        private System.Windows.Forms.RadioButton RBtnCompareKruskalPrim;
        private System.Windows.Forms.RadioButton RBtnPrimsARM;
        private System.Windows.Forms.RadioButton RBtnKruskalsARM;
        private System.Windows.Forms.PictureBox PteBoxTmp;
        private System.Windows.Forms.ComboBox CBoxInitVertex;
        private System.Windows.Forms.Label LblInitVertex;
    }
}

