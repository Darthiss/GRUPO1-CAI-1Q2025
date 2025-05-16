namespace TemplateTPCorto
{
    partial class Form2
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseñaActual = new System.Windows.Forms.TextBox();
            this.txtConstraseñaNueva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContraseñaNueva2 = new System.Windows.Forms.TextBox();
            this.btnCambiarContraseña = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(386, 120);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(213, 26);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Text = "de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // txtContraseñaActual
            // 
            this.txtContraseñaActual.Location = new System.Drawing.Point(386, 194);
            this.txtContraseñaActual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraseñaActual.Name = "txtContraseñaActual";
            this.txtContraseñaActual.Size = new System.Drawing.Size(213, 26);
            this.txtContraseñaActual.TabIndex = 4;
            // 
            // txtConstraseñaNueva
            // 
            this.txtConstraseñaNueva.Location = new System.Drawing.Point(386, 255);
            this.txtConstraseñaNueva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConstraseñaNueva.Name = "txtConstraseñaNueva";
            this.txtConstraseñaNueva.Size = new System.Drawing.Size(213, 26);
            this.txtConstraseñaNueva.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña nueva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Repetir contraseña nueva";
            // 
            // txtContraseñaNueva2
            // 
            this.txtContraseñaNueva2.Location = new System.Drawing.Point(386, 333);
            this.txtContraseñaNueva2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraseñaNueva2.Name = "txtContraseñaNueva2";
            this.txtContraseñaNueva2.Size = new System.Drawing.Size(213, 26);
            this.txtContraseñaNueva2.TabIndex = 9;
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.Location = new System.Drawing.Point(386, 395);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(213, 29);
            this.btnCambiarContraseña.TabIndex = 10;
            this.btnCambiarContraseña.Text = "Cambiar contraseña";
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.btnCambiarContraseña);
            this.Controls.Add(this.txtContraseñaNueva2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConstraseñaNueva);
            this.Controls.Add(this.txtContraseñaActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseñaActual;
        private System.Windows.Forms.TextBox txtConstraseñaNueva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContraseñaNueva2;
        private System.Windows.Forms.Button btnCambiarContraseña;
    }
}