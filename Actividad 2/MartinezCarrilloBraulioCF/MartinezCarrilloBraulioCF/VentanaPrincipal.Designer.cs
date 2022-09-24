
namespace MartinezCarrilloBraulioCF
{
    partial class VentanaPrincipal
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
            this.PteBoxPrincipal = new System.Windows.Forms.PictureBox();
            this.dialogoAbrirImagen = new System.Windows.Forms.OpenFileDialog();
            this.BtnCargarImagen = new System.Windows.Forms.Button();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.TviewGrafo = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // PteBoxPrincipal
            // 
            this.PteBoxPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PteBoxPrincipal.Location = new System.Drawing.Point(9, 9);
            this.PteBoxPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.PteBoxPrincipal.Name = "PteBoxPrincipal";
            this.PteBoxPrincipal.Size = new System.Drawing.Size(695, 369);
            this.PteBoxPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PteBoxPrincipal.TabIndex = 0;
            this.PteBoxPrincipal.TabStop = false;
            // 
            // BtnCargarImagen
            // 
            this.BtnCargarImagen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarImagen.Location = new System.Drawing.Point(728, 385);
            this.BtnCargarImagen.Name = "BtnCargarImagen";
            this.BtnCargarImagen.Size = new System.Drawing.Size(147, 27);
            this.BtnCargarImagen.TabIndex = 1;
            this.BtnCargarImagen.Text = "Cargar imagen";
            this.BtnCargarImagen.UseVisualStyleBackColor = true;
            this.BtnCargarImagen.Click += new System.EventHandler(this.BtnCargarImagen_Click);
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMensajes.Location = new System.Drawing.Point(12, 390);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(81, 16);
            this.lblMensajes.TabIndex = 2;
            this.lblMensajes.Text = "lblMensajes";
            // 
            // TviewGrafo
            // 
            this.TviewGrafo.Location = new System.Drawing.Point(707, 9);
            this.TviewGrafo.Name = "TviewGrafo";
            this.TviewGrafo.Size = new System.Drawing.Size(168, 369);
            this.TviewGrafo.TabIndex = 4;
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 422);
            this.Controls.Add(this.TviewGrafo);
            this.Controls.Add(this.lblMensajes);
            this.Controls.Add(this.BtnCargarImagen);
            this.Controls.Add(this.PteBoxPrincipal);
            this.MaximumSize = new System.Drawing.Size(902, 461);
            this.MinimumSize = new System.Drawing.Size(902, 461);
            this.Name = "VentanaPrincipal";
            this.Text = "Representacion de escenarios a traves de un grafo";
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PteBoxPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PteBoxPrincipal;
        private System.Windows.Forms.OpenFileDialog dialogoAbrirImagen;
        private System.Windows.Forms.Button BtnCargarImagen;
        private System.Windows.Forms.Label lblMensajes;
        private System.Windows.Forms.TreeView TviewGrafo;
    }
}

