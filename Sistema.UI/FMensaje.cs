using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraSplashScreen;
using Sistema.Model;
using Sistema.Model.Classes;
using Sistema.Query;

namespace Sistema.UI.Judicial
{
    public partial class FMensaje : SplashScreen
    {
        ContextoModelo ctxModelo = new ContextoModelo();
        public bool EsValido { get; set; }
        public FMensaje()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        public bool UsuarioValido = false;

        private void FLogin_Load(object sender, EventArgs e)
        {
            DateTime f = DateTime.Now;


        
           var expedientes = ctxModelo.Expediente.Where(x => x.FechaProximaAudiencia != null);
               // expedientes= expedientes.Where(x=> x.NroDiasCalc == x.NroDiasNotificacion);



            //List<templateEx> lTem = new List<templateEx>();
            //foreach (var item in expedientes)
            //{
            //    templateEx oT = new templateEx();
            //    oT.Codigo = item.Codigo;
            //    oT.FechaReg = item.FechaInicio.Value.ToShortDateString();
            //    oT.FechaVencimiento = item.FechaVencimiento == null ? "" : item.FechaVencimiento.Value.ToShortDateString();
            //    oT.Descripcion = item.Descripcion;

            //    lTem.Add(oT);
            //}

            bsExpediente.DataSource = expedientes;
            bsDEmo.DataSource = expedientes;
            //if (lTem.Count < 1) this.Close();


        }

        private void Aceptar()
        {

            this.Close();
        }

        private void sbCancelar_Click(object sender, EventArgs e)
        {
            EsValido = false;
            Application.ExitThread();
        }

        private void sbAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public class templateEx
    {
        public string Codigo { get; set; }
        public string FechaReg { get; set; }
        public string FechaVencimiento { get; set; }
        public string Descripcion { get; set; }

    }
}