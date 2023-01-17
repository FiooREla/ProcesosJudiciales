using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BaseR.Ctrls
{
    public class ExtFile
    {
        public static byte[] FileToBits(string sRuta)
        {
            var fStream = new FileStream(sRuta, FileMode.Open);
            var fileBits = new byte[fStream.Length + 1];
            fStream.Read(fileBits, 0, (int) fStream.Length);
            fStream.Close();
            return fileBits;
        }

        public static void MostrarDocumentoCreado(byte[] bFile, string NameFile)
        {
            var Exepath = Assembly.GetExecutingAssembly().Location;
            var sDirectory = Path.GetDirectoryName(Exepath);

            if (Directory.Exists(sDirectory + "\\Files\\") == false)
                Directory.CreateDirectory(sDirectory + "\\Files\\");

            var RutaArchivo = sDirectory + "\\Files\\" + DateTime.Now.Ticks + NameFile;
            var Archivo = bFile;
            var mStream = new MemoryStream(Archivo);
            var strStreamW = default(Stream);
            strStreamW = File.Create(RutaArchivo);
            strStreamW.Write(Archivo, 0, (int) mStream.Length);
            strStreamW.Close();
            mStream.Close();
            var pIniciarArchivo = new Process();
            pIniciarArchivo.StartInfo.FileName = RutaArchivo;
            pIniciarArchivo.StartInfo.Arguments = "";
            pIniciarArchivo.Start();
            MessageBox.Show("Continuar con el Sistema", "[SISTEMA]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                pIniciarArchivo.Close();
                File.Delete(RutaArchivo);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                try
                {
                    File.Delete(RutaArchivo);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static string DocumentoCreadoFileMail(byte[] bFile, string NameFile)
        {
            var Exepath = Assembly.GetExecutingAssembly().Location;
            var sDirectory = Path.GetDirectoryName(Exepath);
            if (Directory.Exists(sDirectory + "\\FilesMail\\") == false)
                Directory.CreateDirectory(sDirectory + "\\FilesMail\\");

            var RutaArchivo = sDirectory + "\\FilesMail\\" + NameFile;
            var Archivo = bFile;
            var mStream = new MemoryStream(Archivo);
            var strStreamW = default(Stream);
            strStreamW = File.Create(RutaArchivo);
            strStreamW.Write(Archivo, 0, (int) mStream.Length);
            strStreamW.Close();
            mStream.Close();
            return RutaArchivo;
        }
    }
}