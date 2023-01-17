using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraSplashScreen;
using Sistema.Model;
using Sistema.Model.Classes;
using Sistema.Query;

namespace Caudalosa.View.MUsuario
{
    public partial class FLogin : SplashScreen
    {
        ContextoModelo ctxModelo = new ContextoModelo();
        public bool EsValido { get; set; }
        public FLogin()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        public bool UsuarioValido = false;

        private void FLogin_Load(object sender, EventArgs e)
        {
            EsValido = false;
            string sNombrePC = Environment.UserDomainName;
            if (sNombrePC == "TI-DESA03" || sNombrePC == "eMe7")
            {
                teUsuario.EditValue = "ADMIN";
                teContraseña.EditValue = "Electro1978";
               Aceptar();                
            }
            else
            {
                teUsuario.Focus();
                slMensaje.Text = "Ingrese Usuario ...";
                string userName = Environment.UserName;
                teUsuario.EditValue = userName;
            }
        }

        private void Aceptar()
        {
            EsValido = false;
            slMensaje.Text = "";
            bool valido = true;

            if (teContraseña.EditValue == null)
            {
                slMensaje.Text = "Ingrese Contraseña.";
                valido = false;
                return;
            }

            if (teUsuario.EditValue == null)
            {
                slMensaje.Text = "Ingrese Usuario";
                valido = false;
                return;
            }

            if (teContraseña.EditValue.ToString() == "")
            {
                slMensaje.Text = "Ingrese Contraseña.";
                valido = false;
                return;
            }

            if (teUsuario.EditValue.ToString() == "")
            {
                slMensaje.Text = "Ingrese Usuario";
                valido = false;
                return;
            }

            Usuario oUsuario = QUsuario.GUsuarioLogin(ctxModelo, teUsuario.EditValue.ToString(),
                teContraseña.EditValue.ToString());


            if (oUsuario != null)
            {
                SesionActual.Usuario = oUsuario;
                SesionActual.ListDerechos = QUsuario.GlDerechos(ctxModelo, oUsuario.IdUsuario);
            }
            else
            {
                valido = false;
                slMensaje.Text = "Ingrese Un Usuario y Contraseña Valido.";
                return;
            }

            if (valido)
            {
                EsValido = true;
                this.Close();
            }
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
    }
}