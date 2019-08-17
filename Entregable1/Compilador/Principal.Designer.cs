namespace Compilador
{
    partial class Principal
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
            this.PTable = new System.Windows.Forms.Panel();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbEntrada = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.PTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PTable
            // 
            this.PTable.Controls.Add(this.dgvSimbolos);
            this.PTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.PTable.Location = new System.Drawing.Point(425, 0);
            this.PTable.Name = "PTable";
            this.PTable.Size = new System.Drawing.Size(455, 577);
            this.PTable.TabIndex = 0;
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSimbolos.Location = new System.Drawing.Point(0, 0);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.RowTemplate.Height = 28;
            this.dgvSimbolos.Size = new System.Drawing.Size(455, 577);
            this.dgvSimbolos.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.rtbEntrada);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 577);
            this.panel1.TabIndex = 1;
            // 
            // rtbEntrada
            // 
            this.rtbEntrada.Location = new System.Drawing.Point(22, 12);
            this.rtbEntrada.Name = "rtbEntrada";
            this.rtbEntrada.Size = new System.Drawing.Size(366, 513);
            this.rtbEntrada.TabIndex = 0;
            this.rtbEntrada.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(313, 531);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 34);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PTable);
            this.Name = "Principal";
            this.Text = "Form1";
            this.PTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PTable;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbEntrada;
        private System.Windows.Forms.Button btnRun;
    }
}

