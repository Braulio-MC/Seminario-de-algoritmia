
namespace MartinezCarrilloBraulioCF
{
    partial class ventanaPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pteBoxImagenProc = new System.Windows.Forms.PictureBox();
            this.btnAbrirImagen = new System.Windows.Forms.Button();
            this.dialogoSelecImagen = new System.Windows.Forms.OpenFileDialog();
            this.btnProcesarImagen = new System.Windows.Forms.Button();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.cboxOrdenar = new System.Windows.Forms.ComboBox();
            this.pteBoxCircProc = new System.Windows.Forms.PictureBox();
            this.lstBoxCircs = new System.Windows.Forms.ListBox();
            this.lblOrdenarPor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pteBoxImagenProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pteBoxCircProc)).BeginInit();
            this.SuspendLayout();
            // 
            // pteBoxImagenProc
            // 
            this.pteBoxImagenProc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pteBoxImagenProc.Location = new System.Drawing.Point(12, 12);
            this.pteBoxImagenProc.Name = "pteBoxImagenProc";
            this.pteBoxImagenProc.Size = new System.Drawing.Size(338, 244);
            this.pteBoxImagenProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pteBoxImagenProc.TabIndex = 0;
            this.pteBoxImagenProc.TabStop = false;
            // 
            // btnAbrirImagen
            // 
            this.btnAbrirImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirImagen.Location = new System.Drawing.Point(12, 262);
            this.btnAbrirImagen.Name = "btnAbrirImagen";
            this.btnAbrirImagen.Size = new System.Drawing.Size(338, 26);
            this.btnAbrirImagen.TabIndex = 2;
            this.btnAbrirImagen.Text = "Seleccionar imagen";
            this.btnAbrirImagen.UseVisualStyleBackColor = true;
            this.btnAbrirImagen.Click += new System.EventHandler(this.btnAbrirImagen_Click);
            // 
            // dialogoSelecImagen
            // 
            this.dialogoSelecImagen.FileName = "openFileDialog1";
            // 
            // btnProcesarImagen
            // 
            this.btnProcesarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesarImagen.Location = new System.Drawing.Point(12, 294);
            this.btnProcesarImagen.Name = "btnProcesarImagen";
            this.btnProcesarImagen.Size = new System.Drawing.Size(338, 26);
            this.btnProcesarImagen.TabIndex = 5;
            this.btnProcesarImagen.Text = "Procesar mapa de bits";
            this.btnProcesarImagen.UseVisualStyleBackColor = true;
            this.btnProcesarImagen.Click += new System.EventHandler(this.btnProcesarImagen_Click);
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvertencia.Location = new System.Drawing.Point(12, 333);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(39, 18);
            this.lblAdvertencia.TabIndex = 6;
            this.lblAdvertencia.Text = "Text";
            // 
            // cboxOrdenar
            // 
            this.cboxOrdenar.FormattingEnabled = true;
            this.cboxOrdenar.ItemHeight = 13;
            this.cboxOrdenar.Items.AddRange(new object[] {
            "Eje X",
            "Eje Y",
            "Tamaño"});
            this.cboxOrdenar.Location = new System.Drawing.Point(590, 441);
            this.cboxOrdenar.Name = "cboxOrdenar";
            this.cboxOrdenar.Size = new System.Drawing.Size(105, 21);
            this.cboxOrdenar.TabIndex = 8;
            this.cboxOrdenar.SelectedIndexChanged += new System.EventHandler(this.cboxOrdenar_SelectedIndexChanged);
            // 
            // pteBoxCircProc
            // 
            this.pteBoxCircProc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pteBoxCircProc.Location = new System.Drawing.Point(357, 12);
            this.pteBoxCircProc.Name = "pteBoxCircProc";
            this.pteBoxCircProc.Size = new System.Drawing.Size(338, 244);
            this.pteBoxCircProc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pteBoxCircProc.TabIndex = 0;
            this.pteBoxCircProc.TabStop = false;
            // 
            // lstBoxCircs
            // 
            this.lstBoxCircs.FormattingEnabled = true;
            this.lstBoxCircs.Location = new System.Drawing.Point(357, 262);
            this.lstBoxCircs.Name = "lstBoxCircs";
            this.lstBoxCircs.Size = new System.Drawing.Size(338, 173);
            this.lstBoxCircs.TabIndex = 10;
            this.lstBoxCircs.SelectedIndexChanged += new System.EventHandler(this.lstBoxCircs_SelectedIndexChanged);
            // 
            // lblOrdenarPor
            // 
            this.lblOrdenarPor.AutoSize = true;
            this.lblOrdenarPor.Location = new System.Drawing.Point(510, 444);
            this.lblOrdenarPor.Name = "lblOrdenarPor";
            this.lblOrdenarPor.Size = new System.Drawing.Size(74, 13);
            this.lblOrdenarPor.TabIndex = 12;
            this.lblOrdenarPor.Text = "Ordenar por";
            // 
            // ventanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 469);
            this.Controls.Add(this.lblOrdenarPor);
            this.Controls.Add(this.lstBoxCircs);
            this.Controls.Add(this.pteBoxCircProc);
            this.Controls.Add(this.cboxOrdenar);
            this.Controls.Add(this.lblAdvertencia);
            this.Controls.Add(this.btnProcesarImagen);
            this.Controls.Add(this.btnAbrirImagen);
            this.Controls.Add(this.pteBoxImagenProc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(723, 508);
            this.MinimumSize = new System.Drawing.Size(723, 508);
            this.Name = "ventanaPrincipal";
            this.Text = "Circulos";
            this.Load += new System.EventHandler(this.ventanaPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pteBoxImagenProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pteBoxCircProc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pteBoxImagenProc;
        private System.Windows.Forms.Button btnAbrirImagen;
        private System.Windows.Forms.OpenFileDialog dialogoSelecImagen;
        private System.Windows.Forms.Button btnProcesarImagen;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.ComboBox cboxOrdenar;
        private System.Windows.Forms.PictureBox pteBoxCircProc;
        private System.Windows.Forms.ListBox lstBoxCircs;
        private System.Windows.Forms.Label lblOrdenarPor;
    }
}

