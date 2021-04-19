namespace Reversi_PO
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Scene = new System.Windows.Forms.PictureBox();
            this.PlayerFranekPoints = new System.Windows.Forms.Label();
            this.BotTomaszPoints = new System.Windows.Forms.Label();
            this.Winner = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).BeginInit();
            this.SuspendLayout();
            // 
            // Scene
            // 
            this.Scene.Location = new System.Drawing.Point(208, 75);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(338, 299);
            this.Scene.TabIndex = 0;
            this.Scene.TabStop = false;
            this.Scene.Paint += new System.Windows.Forms.PaintEventHandler(this.Scene_Paint);
            this.Scene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseClick);
            // 
            // PlayerFranekPoints
            // 
            this.PlayerFranekPoints.AutoSize = true;
            this.PlayerFranekPoints.Location = new System.Drawing.Point(353, 414);
            this.PlayerFranekPoints.Name = "PlayerFranekPoints";
            this.PlayerFranekPoints.Size = new System.Drawing.Size(35, 13);
            this.PlayerFranekPoints.TabIndex = 1;
            this.PlayerFranekPoints.Text = "label1";
            // 
            // BotTomaszPoints
            // 
            this.BotTomaszPoints.AutoSize = true;
            this.BotTomaszPoints.Location = new System.Drawing.Point(353, 48);
            this.BotTomaszPoints.Name = "BotTomaszPoints";
            this.BotTomaszPoints.Size = new System.Drawing.Size(35, 13);
            this.BotTomaszPoints.TabIndex = 2;
            this.BotTomaszPoints.Text = "label2";
            // 
            // Winner
            // 
            this.Winner.AutoSize = true;
            this.Winner.Location = new System.Drawing.Point(588, 156);
            this.Winner.Name = "Winner";
            this.Winner.Size = new System.Drawing.Size(35, 13);
            this.Winner.TabIndex = 3;
            this.Winner.Text = "Gracz";
            this.Winner.Visible = false;
            // 
            // Reset
            // 
            this.Reset.AutoSize = true;
            this.Reset.Location = new System.Drawing.Point(591, 218);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(128, 13);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Kliknij R aby zrestartowac";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Winner);
            this.Controls.Add(this.BotTomaszPoints);
            this.Controls.Add(this.PlayerFranekPoints);
            this.Controls.Add(this.Scene);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Scene;
        private System.Windows.Forms.Label PlayerFranekPoints;
        private System.Windows.Forms.Label BotTomaszPoints;
        private System.Windows.Forms.Label Winner;
        private System.Windows.Forms.Label Reset;
    }
}

