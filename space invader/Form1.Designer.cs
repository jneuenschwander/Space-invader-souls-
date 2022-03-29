namespace space_invader
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
            this.components = new System.ComponentModel.Container();
            this.timerdelmovimiento = new System.Windows.Forms.Timer(this.components);
            this.timerspawnenemigos = new System.Windows.Forms.Timer(this.components);
            this.gameover = new System.Windows.Forms.Panel();
            this.ganaste = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timerdelmovimiento
            // 
            this.timerdelmovimiento.Enabled = true;
            this.timerdelmovimiento.Interval = 50;
            this.timerdelmovimiento.Tick += new System.EventHandler(this.timerdelmovimiento_Tick);
            // 
            // timerspawnenemigos
            // 
            this.timerspawnenemigos.Interval = 750;
            this.timerspawnenemigos.Tick += new System.EventHandler(this.timerspawnenemigos_Tick);
            // 
            // gameover
            // 
            this.gameover.BackgroundImage = global::space_invader.Properties.Resources.game_over;
            this.gameover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameover.Location = new System.Drawing.Point(0, 0);
            this.gameover.Name = "gameover";
            this.gameover.Size = new System.Drawing.Size(1226, 543);
            this.gameover.TabIndex = 0;
            this.gameover.Visible = false;
            // 
            // ganaste
            // 
            this.ganaste.BackgroundImage = global::space_invader.Properties.Resources.ganaste;
            this.ganaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ganaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganaste.Location = new System.Drawing.Point(0, 0);
            this.ganaste.Name = "ganaste";
            this.ganaste.Size = new System.Drawing.Size(1226, 543);
            this.ganaste.TabIndex = 1;
            this.ganaste.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1226, 543);
            this.Controls.Add(this.ganaste);
            this.Controls.Add(this.gameover);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerdelmovimiento;
        private System.Windows.Forms.Timer timerspawnenemigos;
        private System.Windows.Forms.Panel gameover;
        private System.Windows.Forms.Panel ganaste;
    }
}

