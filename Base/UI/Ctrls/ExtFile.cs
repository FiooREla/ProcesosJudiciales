using System.IO;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars;
using System.Linq;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Base.UI;

namespace Ext
{
    public class ExtFile
    {
        public static byte[] FileToBits(string sRuta)
        {
            FileStream fStream = new FileStream(sRuta, FileMode.Open);
            byte[] fileBits = new byte[fStream.Length + 1];
            fStream.Read(fileBits, 0,(int) fStream.Length);
            fStream.Close();
            return fileBits;

        }

        public static void MostrarDocumentoCreado(byte[] bFile, string NameFile)
        {
            string Exepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string sDirectory = System.IO.Path.GetDirectoryName(Exepath);
           
            if (Directory.Exists(sDirectory + "\\Files\\") == false)
            {
                Directory.CreateDirectory(sDirectory + "\\Files\\");
            }

            string RutaArchivo = sDirectory + "\\Files\\" + System.DateTime.Now.Ticks + NameFile;
            byte[] Archivo = bFile;
            MemoryStream mStream = new MemoryStream(Archivo);
            Stream strStreamW = default(Stream);
            strStreamW = File.Create(RutaArchivo);
            strStreamW.Write(Archivo, 0,(int) mStream.Length);
            strStreamW.Close();
            mStream.Close();
            Process pIniciarArchivo = new Process();
            pIniciarArchivo.StartInfo.FileName = RutaArchivo;
            pIniciarArchivo.StartInfo.Arguments = "";
            pIniciarArchivo.Start();
            MessageBox.Show("Continuar con el Sistema", "[SISTEMA]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                pIniciarArchivo.Close();
                System.IO.File.Delete(RutaArchivo);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                try
                {
                    System.IO.File.Delete(RutaArchivo);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static string DocumentoCreadoFileMail(byte[] bFile, string NameFile)
        {
            
            string Exepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string sDirectory = System.IO.Path.GetDirectoryName(Exepath);

            if (Directory.Exists(sDirectory + "\\FilesMail\\") == false)
            {
                Directory.CreateDirectory(sDirectory + "\\FilesMail\\");
            }

            string RutaArchivo = sDirectory + "\\FilesMail\\" + NameFile;
            byte[] Archivo = bFile;
            MemoryStream mStream = new MemoryStream(Archivo);
            Stream strStreamW = default(Stream);
            strStreamW = File.Create(RutaArchivo);
            strStreamW.Write(Archivo, 0, (int) mStream.Length);
            strStreamW.Close();
            mStream.Close();
            return RutaArchivo;

        }

        
    }

  
}
