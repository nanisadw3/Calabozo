namespace Calabozo
{
    partial class Form1
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
            this.txt_mapa = new System.Windows.Forms.TextBox();
            this.txt_info = new System.Windows.Forms.TextBox();
            this.txt_vidaP = new System.Windows.Forms.TextBox();
            this.txt_posiciones = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_mapa
            // 
            this.txt_mapa.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_mapa.Enabled = false;
            this.txt_mapa.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mapa.ForeColor = System.Drawing.Color.White;
            this.txt_mapa.Location = new System.Drawing.Point(168, 66);
            this.txt_mapa.Multiline = true;
            this.txt_mapa.Name = "txt_mapa";
            this.txt_mapa.Size = new System.Drawing.Size(533, 433);
            this.txt_mapa.TabIndex = 0;
            this.txt_mapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_info
            // 
            this.txt_info.Enabled = false;
            this.txt_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_info.Location = new System.Drawing.Point(727, 100);
            this.txt_info.Multiline = true;
            this.txt_info.Name = "txt_info";
            this.txt_info.Size = new System.Drawing.Size(86, 56);
            this.txt_info.TabIndex = 1;
            // 
            // txt_vidaP
            // 
            this.txt_vidaP.Enabled = false;
            this.txt_vidaP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vidaP.Location = new System.Drawing.Point(727, 68);
            this.txt_vidaP.Multiline = true;
            this.txt_vidaP.Name = "txt_vidaP";
            this.txt_vidaP.Size = new System.Drawing.Size(144, 26);
            this.txt_vidaP.TabIndex = 2;
            // 
            // txt_posiciones
            // 
            this.txt_posiciones.Enabled = false;
            this.txt_posiciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_posiciones.Location = new System.Drawing.Point(727, 179);
            this.txt_posiciones.Multiline = true;
            this.txt_posiciones.Name = "txt_posiciones";
            this.txt_posiciones.Size = new System.Drawing.Size(86, 54);
            this.txt_posiciones.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 574);
            this.Controls.Add(this.txt_posiciones);
            this.Controls.Add(this.txt_vidaP);
            this.Controls.Add(this.txt_info);
            this.Controls.Add(this.txt_mapa);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_mapa;
        private System.Windows.Forms.TextBox txt_info;
        private System.Windows.Forms.TextBox txt_vidaP;
        private System.Windows.Forms.TextBox txt_posiciones;
    }
}

