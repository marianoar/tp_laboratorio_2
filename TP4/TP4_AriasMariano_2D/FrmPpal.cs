using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;

namespace TP4_AriasMariano_2D
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            rtbMostrar.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        private void ListarPaquetes()
        {
            listBoxEstadoIngresado.Items.Clear();
            listBoxEstadoEnViaje.Items.Clear();
            listBoxEstadoEntregado.Items.Clear();

            for (int i = 0; i < correo.Paquetes.Count; i++)
            {
                if(correo.Paquetes[i].Estado == Paquete.EEstado.Ingresado)
                {
                    listBoxEstadoIngresado.Items.Add(correo.Paquetes[i].MostrarDatos(correo.Paquetes[i]));
                    
                }else if(correo.Paquetes[i].Estado == Paquete.EEstado.EnViaje)
                {
                    listBoxEstadoEnViaje.Items.Add(correo.Paquetes[i].MostrarDatos(correo.Paquetes[i]));
                }
                else if(correo.Paquetes[i].Estado == Paquete.EEstado.Entregado)
                {
                    listBoxEstadoEntregado.Items.Add(correo.Paquetes[i].MostrarDatos(correo.Paquetes[i]));
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(mtxtTrackingID.Text))
            {
                MessageBox.Show("Numero de ID o direccion no pueden quedar vacios");
            }
            else
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

                nuevoPaquete.InformaEstado += paq_InformaEstado;
                try
                {
                    this.correo += nuevoPaquete;
                }
                catch (TrackingIDRepetidoException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ListarPaquetes();
                txtDireccion.Clear();
                mtxtTrackingID.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btmMostrarTodos_Click(object sender, EventArgs e)
        {
            MostrarInformacion<List<Paquete>> ((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(Object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                DelegadoEstado del = new DelegadoEstado(paq_InformaEstado);
                this.Invoke(del, new object[] { sender, e });
            }
            else
            {
                ListarPaquetes();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    this.rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Se ha producido un error");
                }
            }
        }
        /// <summary>
        /// llama a metodo FinEntregas para cerrar todos los hilos activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                rtbMostrar.Text = correo.Paquetes[listBoxEstadoEntregado.SelectedIndex].ToString();
            }
            catch
            {
                MessageBox.Show("Seleccione paquete");
            }
        }
    }
}
