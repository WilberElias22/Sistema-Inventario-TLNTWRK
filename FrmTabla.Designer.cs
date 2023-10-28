namespace Inventario_Tlntwrk
{
    partial class FrmTabla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTabla));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.lstMarca = new System.Windows.Forms.ListBox();
            this.lstModelo = new System.Windows.Forms.ListBox();
            this.lstProveedor = new System.Windows.Forms.ListBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.dtpLote = new System.Windows.Forms.DateTimePicker();
            this.BtnGuardar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BtnCancelar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMarca = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnModelo = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnProveedor = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(219, 95);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(51, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Marca";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(219, 148);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(60, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Modelo";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(219, 196);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(47, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Serial";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(219, 247);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(77, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Proveedor";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(219, 298);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(103, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Fecha de Lote";
            // 
            // lstMarca
            // 
            this.lstMarca.FormattingEnabled = true;
            this.lstMarca.Location = new System.Drawing.Point(389, 95);
            this.lstMarca.Name = "lstMarca";
            this.lstMarca.Size = new System.Drawing.Size(120, 30);
            this.lstMarca.TabIndex = 5;
            // 
            // lstModelo
            // 
            this.lstModelo.FormattingEnabled = true;
            this.lstModelo.Location = new System.Drawing.Point(389, 148);
            this.lstModelo.Name = "lstModelo";
            this.lstModelo.Size = new System.Drawing.Size(120, 30);
            this.lstModelo.TabIndex = 6;
            // 
            // lstProveedor
            // 
            this.lstProveedor.FormattingEnabled = true;
            this.lstProveedor.Location = new System.Drawing.Point(389, 247);
            this.lstProveedor.Name = "lstProveedor";
            this.lstProveedor.Size = new System.Drawing.Size(120, 30);
            this.lstProveedor.TabIndex = 7;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(389, 196);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(120, 20);
            this.txtSerial.TabIndex = 8;
            // 
            // dtpLote
            // 
            this.dtpLote.Location = new System.Drawing.Point(389, 298);
            this.dtpLote.Name = "dtpLote";
            this.dtpLote.Size = new System.Drawing.Size(200, 20);
            this.dtpLote.TabIndex = 9;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.AutoSize = true;
            this.BtnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnGuardar.Depth = 0;
            this.BtnGuardar.Icon = null;
            this.BtnGuardar.Location = new System.Drawing.Point(223, 358);
            this.BtnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Primary = true;
            this.BtnGuardar.Size = new System.Drawing.Size(84, 36);
            this.BtnGuardar.TabIndex = 10;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AutoSize = true;
            this.BtnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCancelar.Depth = 0;
            this.BtnCancelar.Icon = null;
            this.BtnCancelar.Location = new System.Drawing.Point(389, 358);
            this.BtnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Primary = true;
            this.BtnCancelar.Size = new System.Drawing.Size(91, 36);
            this.BtnCancelar.TabIndex = 11;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.AutoSize = true;
            this.btnMarca.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMarca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarca.Depth = 0;
            this.btnMarca.Icon = null;
            this.btnMarca.Location = new System.Drawing.Point(13, 87);
            this.btnMarca.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMarca.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Primary = false;
            this.btnMarca.Size = new System.Drawing.Size(117, 36);
            this.btnMarca.TabIndex = 12;
            this.btnMarca.Text = "Nueva Marca";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // btnModelo
            // 
            this.btnModelo.AutoSize = true;
            this.btnModelo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModelo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModelo.Depth = 0;
            this.btnModelo.Icon = null;
            this.btnModelo.Location = new System.Drawing.Point(13, 148);
            this.btnModelo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnModelo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnModelo.Name = "btnModelo";
            this.btnModelo.Primary = false;
            this.btnModelo.Size = new System.Drawing.Size(124, 36);
            this.btnModelo.TabIndex = 13;
            this.btnModelo.Text = "Nuevo Modelo";
            this.btnModelo.UseVisualStyleBackColor = true;
            this.btnModelo.Click += new System.EventHandler(this.btnModelo_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.AutoSize = true;
            this.btnProveedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor.Depth = 0;
            this.btnProveedor.Icon = null;
            this.btnProveedor.Location = new System.Drawing.Point(13, 247);
            this.btnProveedor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnProveedor.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Primary = false;
            this.btnProveedor.Size = new System.Drawing.Size(147, 36);
            this.btnProveedor.TabIndex = 14;
            this.btnProveedor.Text = "Nuevo Proveedor";
            this.btnProveedor.UseVisualStyleBackColor = true;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // FrmTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProveedor);
            this.Controls.Add(this.btnModelo);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.dtpLote);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.lstProveedor);
            this.Controls.Add(this.lstModelo);
            this.Controls.Add(this.lstMarca);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTabla";
            this.Text = "Ingreso de Datos";
            this.Load += new System.EventHandler(this.FrmTabla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.ListBox lstMarca;
        private System.Windows.Forms.ListBox lstModelo;
        private System.Windows.Forms.ListBox lstProveedor;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.DateTimePicker dtpLote;
        private MaterialSkin.Controls.MaterialRaisedButton BtnGuardar;
        private MaterialSkin.Controls.MaterialRaisedButton BtnCancelar;
        private MaterialSkin.Controls.MaterialFlatButton btnMarca;
        private MaterialSkin.Controls.MaterialFlatButton btnModelo;
        private MaterialSkin.Controls.MaterialFlatButton btnProveedor;
    }
}