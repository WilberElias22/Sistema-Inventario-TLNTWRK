namespace Inventario_Tlntwrk
{
    partial class Proveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedor));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNombreProveedor = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 86);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(124, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Nuevo Proveedor";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Depth = 0;
            this.txtNombreProveedor.Hint = "";
            this.txtNombreProveedor.Location = new System.Drawing.Point(177, 86);
            this.txtNombreProveedor.MaxLength = 32767;
            this.txtNombreProveedor.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.PasswordChar = '\0';
            this.txtNombreProveedor.SelectedText = "";
            this.txtNombreProveedor.SelectionLength = 0;
            this.txtNombreProveedor.SelectionStart = 0;
            this.txtNombreProveedor.Size = new System.Drawing.Size(143, 23);
            this.txtNombreProveedor.TabIndex = 1;
            this.txtNombreProveedor.TabStop = false;
            this.txtNombreProveedor.UseSystemPasswordChar = false;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(16, 140);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(83, 36);
            this.materialFlatButton1.TabIndex = 2;
            this.materialFlatButton1.Text = "Agregar";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 223);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.txtNombreProveedor);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Proveedor";
            this.Text = "Proveedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombreProveedor;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}