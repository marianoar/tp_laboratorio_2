namespace TP4_AriasMariano_2D
{
    partial class FrmPpal
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
            this.groupBoxEstadoPaquetes = new System.Windows.Forms.GroupBox();
            this.lblEstadoEntregado = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEstadoEnViaje = new System.Windows.Forms.Label();
            this.lblEstadoIngresado = new System.Windows.Forms.Label();
            this.listBoxEstadoEntregado = new System.Windows.Forms.ListBox();
            this.listBoxEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.listBoxEstadoIngresado = new System.Windows.Forms.ListBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.groupBoxPaquete = new System.Windows.Forms.GroupBox();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.btmMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBoxEstadoPaquetes.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxPaquete.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEstadoPaquetes
            // 
            this.groupBoxEstadoPaquetes.Controls.Add(this.lblEstadoEntregado);
            this.groupBoxEstadoPaquetes.Controls.Add(this.lblEstadoEnViaje);
            this.groupBoxEstadoPaquetes.Controls.Add(this.lblEstadoIngresado);
            this.groupBoxEstadoPaquetes.Controls.Add(this.listBoxEstadoEntregado);
            this.groupBoxEstadoPaquetes.Controls.Add(this.listBoxEstadoEnViaje);
            this.groupBoxEstadoPaquetes.Controls.Add(this.listBoxEstadoIngresado);
            this.groupBoxEstadoPaquetes.Location = new System.Drawing.Point(43, 21);
            this.groupBoxEstadoPaquetes.Name = "groupBoxEstadoPaquetes";
            this.groupBoxEstadoPaquetes.Size = new System.Drawing.Size(714, 264);
            this.groupBoxEstadoPaquetes.TabIndex = 0;
            this.groupBoxEstadoPaquetes.TabStop = false;
            this.groupBoxEstadoPaquetes.Text = "Estado Paquetes";
            // 
            // lblEstadoEntregado
            // 
            this.lblEstadoEntregado.AutoSize = true;
            this.lblEstadoEntregado.ContextMenuStrip = this.contextMenuStrip;
            this.lblEstadoEntregado.Location = new System.Drawing.Point(506, 41);
            this.lblEstadoEntregado.Name = "lblEstadoEntregado";
            this.lblEstadoEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEstadoEntregado.TabIndex = 5;
            this.lblEstadoEntregado.Text = "Entregado";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // lblEstadoEnViaje
            // 
            this.lblEstadoEnViaje.AutoSize = true;
            this.lblEstadoEnViaje.Location = new System.Drawing.Point(267, 41);
            this.lblEstadoEnViaje.Name = "lblEstadoEnViaje";
            this.lblEstadoEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEstadoEnViaje.TabIndex = 4;
            this.lblEstadoEnViaje.Text = "En Viaje";
            // 
            // lblEstadoIngresado
            // 
            this.lblEstadoIngresado.AutoSize = true;
            this.lblEstadoIngresado.Location = new System.Drawing.Point(31, 41);
            this.lblEstadoIngresado.Name = "lblEstadoIngresado";
            this.lblEstadoIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblEstadoIngresado.TabIndex = 3;
            this.lblEstadoIngresado.Text = "Ingresado";
            // 
            // listBoxEstadoEntregado
            // 
            this.listBoxEstadoEntregado.ContextMenuStrip = this.contextMenuStrip;
            this.listBoxEstadoEntregado.FormattingEnabled = true;
            this.listBoxEstadoEntregado.Location = new System.Drawing.Point(509, 60);
            this.listBoxEstadoEntregado.Name = "listBoxEstadoEntregado";
            this.listBoxEstadoEntregado.Size = new System.Drawing.Size(188, 186);
            this.listBoxEstadoEntregado.TabIndex = 7;
            // 
            // listBoxEstadoEnViaje
            // 
            this.listBoxEstadoEnViaje.FormattingEnabled = true;
            this.listBoxEstadoEnViaje.Location = new System.Drawing.Point(270, 60);
            this.listBoxEstadoEnViaje.Name = "listBoxEstadoEnViaje";
            this.listBoxEstadoEnViaje.Size = new System.Drawing.Size(188, 186);
            this.listBoxEstadoEnViaje.TabIndex = 6;
            // 
            // listBoxEstadoIngresado
            // 
            this.listBoxEstadoIngresado.FormattingEnabled = true;
            this.listBoxEstadoIngresado.Location = new System.Drawing.Point(31, 60);
            this.listBoxEstadoIngresado.Name = "listBoxEstadoIngresado";
            this.listBoxEstadoIngresado.Size = new System.Drawing.Size(188, 186);
            this.listBoxEstadoIngresado.TabIndex = 5;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(43, 306);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(386, 120);
            this.rtbMostrar.TabIndex = 8;
            this.rtbMostrar.Text = "";
            // 
            // groupBoxPaquete
            // 
            this.groupBoxPaquete.Controls.Add(this.mtxtTrackingID);
            this.groupBoxPaquete.Controls.Add(this.txtDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblDireccion);
            this.groupBoxPaquete.Controls.Add(this.lblTrackingID);
            this.groupBoxPaquete.Controls.Add(this.btmMostrarTodos);
            this.groupBoxPaquete.Controls.Add(this.btnAgregar);
            this.groupBoxPaquete.Location = new System.Drawing.Point(456, 306);
            this.groupBoxPaquete.Name = "groupBoxPaquete";
            this.groupBoxPaquete.Size = new System.Drawing.Size(301, 120);
            this.groupBoxPaquete.TabIndex = 2;
            this.groupBoxPaquete.TabStop = false;
            this.groupBoxPaquete.Text = "Paquete";
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(13, 49);
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(100, 20);
            this.mtxtTrackingID.TabIndex = 1;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(9, 93);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(10, 77);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(6, 33);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 2;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // btmMostrarTodos
            // 
            this.btmMostrarTodos.Location = new System.Drawing.Point(164, 90);
            this.btmMostrarTodos.Name = "btmMostrarTodos";
            this.btmMostrarTodos.Size = new System.Drawing.Size(120, 23);
            this.btmMostrarTodos.TabIndex = 4;
            this.btmMostrarTodos.Text = "Mostrar Todos";
            this.btmMostrarTodos.UseVisualStyleBackColor = true;
            this.btmMostrarTodos.Click += new System.EventHandler(this.btmMostrarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(164, 46);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxPaquete);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.groupBoxEstadoPaquetes);
            this.Name = "FrmPpal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Correo UTN por Arias Mariano 2D";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPpal_FormClosing);
            this.groupBoxEstadoPaquetes.ResumeLayout(false);
            this.groupBoxEstadoPaquetes.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxPaquete.ResumeLayout(false);
            this.groupBoxPaquete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEstadoPaquetes;
        private System.Windows.Forms.Label lblEstadoEntregado;
        private System.Windows.Forms.Label lblEstadoEnViaje;
        private System.Windows.Forms.Label lblEstadoIngresado;
        private System.Windows.Forms.ListBox listBoxEstadoEntregado;
        private System.Windows.Forms.ListBox listBoxEstadoEnViaje;
        private System.Windows.Forms.ListBox listBoxEstadoIngresado;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.GroupBox groupBoxPaquete;
        private System.Windows.Forms.Button btmMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

