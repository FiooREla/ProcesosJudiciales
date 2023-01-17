using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
//using Sistema.Model;
using Sistema.Services.Modelo;

namespace Sistema.UI.Control
{
    public class clsMail
    {
        private Sistema.Model.ContextoModelo CtxModelo;

        public static void fnSendMail(List<Expediente> lExpedientes)
        {

            var fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var fCadena = fecha.ToString("dd/MM/yyyy");
            //var ctx = new ContextoModelo();
            var ctx = new Sistema.Model.ContextoModelo();
            var dbUserMail = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == "MAIL-USER");
            var dbUserMailJefe = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == "MAIL-USER-JEFE");

            foreach (var item in lExpedientes)
            {
                //fio
                //if (item.NroDiasCalc != item.NroDiasNotificacion) continue;

                if (item.TipoNotificacion == null) continue;

                var dbFecha = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == item.TipoNotificacion && x.Abreviado == item.Codigo);
                if(dbFecha!=null)
                if (dbFecha.Descripcion != null && dbFecha.Descripcion == fCadena) continue;
                if (dbFecha == null)
                {
                    TipoContenido tipo = new TipoContenido();
                    tipo.Descripcion = fCadena;
                    tipo.Abreviado = item.Codigo;
                    tipo.TipoInterno = item.TipoNotificacion;
                    //fio
                    //ctx.TipoContenido.AddObject(tipo);
                }
                else
                    dbFecha.Descripcion = fCadena;

                ctx.SaveChanges(); //ES LO MEJOR

                var asunto = "NOTIFICACIÓN - " + item.TipoNotificacionMail.ToString();
                var sb = new StringBuilder();
                //fio
                /*
                sb.AppendLine("<h3><u>Aviso - " + item.TipoNotificacionMail.ToString() + " tiene como fecha proxima  " + item.FechaProximaAudiencia.Value.ToShortDateString() + " " +
                              "</u><br/><br/></h3>");
                */
                sb.AppendLine("<table border='1px' style='width: 100 % '>");
                sb.AppendLine("<tr>" +
                              "<td><b> &nbsp;&nbsp;Nro. Expediente&nbsp;&nbsp; </b></td>" +
                              "<td><b> &nbsp;&nbsp;Fecha&nbsp;&nbsp; </b></td>" +
                              "<td><b> &nbsp;&nbsp;Descripción&nbsp;&nbsp; </b></td>" +
                                "<td><b> &nbsp;&nbsp;Monto&nbsp;&nbsp; </b></td>" +
                              "</tr>");


                var dataMail = ctx.TipoContenido.Where(x => x.TipoInterno == "TIPOCONTENIDO").ToList();

                //fio
                /*
                sb.AppendLine("<tr>" +
                              "<td><b>" + item.Codigo + "</b></td>" +
                              "<td>" + item.FechaInicio.Value.ToShortDateString() + "</td>" +
                              "<td>" + item.Descripcion + "</td>" +
                                "<td>" + item.MontoSoles + "</td>" +
                              "</tr>");
                sb.AppendLine("</table><br/><br/>");
                */

                // var to = "steverosale@gmail.com";//Cambiar por Supervisor JEFE
                var to = dbUserMailJefe.Abreviado.ToString();//Este es el corro de JEFE de AREA

                var body = sb.ToString();
                string from = dbUserMail.Abreviado, pass = dbUserMail.Descripcion;
                try
                {
                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress(from);
                        mail.To.Add(to);
                        mail.To.Add(item.TipoNotificacion); 
                        mail.Subject = asunto;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(from, pass);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    //ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Base.Ctrls.Msg.FnMessage("E", ex.Message);
                }


            }


            return;

        }

        public bool FnMail_DemandasExistentes(string sDemandante, List<Expediente> Lexpediente)
        {

            var fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var fCadena = fecha.ToString("dd/MM/yyyy");
            //añadi fio
            var ctx = new Sistema.Model.ContextoModelo();
            //var dbFecha = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == "MAIL-DEMANDANTE");
            //if (dbFecha.Descripcion != null && dbFecha.Descripcion== fCadena) return false;
            //dbFecha.Descripcion = fCadena;
            //ctx.SaveChanges(); //ES LO MEJOR

            var dbUserMail = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == "MAIL-USER");

            var dbUserMailJefe = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == "MAIL-USER-JEFE");
            var dbUserMailExiste = ctx.TipoContenido.FirstOrDefault(x => x.TipoInterno == "MAIL-USER-EXISTE");

            var asunto = "Demandante Encontrado en Expediente Anterior ";
            var sb = new StringBuilder();
            sb.AppendLine("<h3><u>El demandante " + sDemandante + " tiene los siguientes expedientes anteriores  " +
                          "</u><br/><br/></h3>");
            sb.AppendLine("<table border='1px' style='width: 100 % '>");
            sb.AppendLine("<tr>" +
                          "<td><b> &nbsp;&nbsp;Nro. Expediente&nbsp;&nbsp; </b></td>" +
                          "<td><b> &nbsp;&nbsp;Fecha&nbsp;&nbsp; </b></td>" +
                          "<td><b> &nbsp;&nbsp;Descripción&nbsp;&nbsp; </b></td>" +
                            "<td><b> &nbsp;&nbsp;Monto&nbsp;&nbsp; </b></td>" +
                          "</tr>");


            var dataMail = ctx.TipoContenido.Where(x => x.TipoInterno == "TIPOCONTENIDO").ToList();
            string codigo = "";
            foreach (var data in Lexpediente)
                try
                {
                    codigo = data.Codigo;
                    //fio
                    /*
                    string fechaDeInicioValido = data.FechaInicio == null ? "" : data.FechaInicio.Value.ToShortDateString();

                    sb.AppendLine("<tr>" +
                              "<td><b>" + data.Codigo + "</b></td>" +
                              "<td>" + fechaDeInicioValido + "</td>" +
                              "<td>" + data.Descripcion + "</td>" +
                                "<td>" + data.MontoSoles + "</td>" +
                              "</tr>");
                    */
                }
                catch (Exception ex)
                {

                    
                }
                
            sb.AppendLine("</table><br/><br/>");
            //sb.AppendLine("<a><img src='http://www.image-share.com/upload/3254/240.jpg'</a>");            
          //  var to = "steverosale@gmail.com";
            var to = dbUserMailJefe.Abreviado.ToString();//Este es el correo del Jefe de Area
            var toExiste = dbUserMailExiste.Abreviado.ToString();//Este es el correo del Jefe de Area

            var body = sb.ToString();
            string from = dbUserMail.Abreviado, pass = dbUserMail.Descripcion;
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(from);
                    mail.To.Add(to);
                    // mail.To.Add("ivaxxu@gmail.com");// cambiar 
                    mail.To.Add(toExiste);// Correo de Destinatario cuando Demandante Existe 

                    mail.Subject = asunto;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(from, pass);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                //ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Base.Ctrls.Msg.FnMessage("E", ex.Message);
            }

            return true;
        }

    }
}
