﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using Sistema.Model;
using Sistema.Query;

namespace Sistema.UI.Judicial
{
    public partial class FSedeJudicial : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        public FSedeJudicial()
        {
            InitializeComponent();
            bsLista.DataSource = CtxModelo.SedeJudicial.Where(x=>x.TipoInterno=="SEDEJUDICIAL");
            Ctrls.Glue.FnGlueLocalidadConsulta(IdLocalidadGridLookUpEdit, null);
        }

        public override void FnEdicion()
        {
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                bsLista.Add(new SedeJudicial() { TipoInterno = "SEDEJUDICIAL" });
                bsLista.MoveLast();
            }
        }

        public override bool FnGrabar()
        {
            if (TipoEdicion == EnumEdicion.Borrar) bsLista.RemoveCurrent();
            bsLista.EndEdit();
            CtxModelo.SaveChanges();
            return true;
        }

        public override void FnCancelar()
        {
            if (TipoEdicion == EnumEdicion.Nuevo) bsLista.RemoveCurrent();
            bsLista.CancelEdit();
        }

        public override void FnImprimir()
        {
            PrintPreviewRibbonFormEx pViewEx = new PrintPreviewRibbonFormEx();
            pViewEx.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
            pViewEx.Show();
        }
    }
}
