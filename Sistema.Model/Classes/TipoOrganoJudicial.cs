using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoOrganoJudicial
    {
        public string Descripcion { get; set; }

        public static List<TipoOrganoJudicial> GLista()
        {
            List<TipoOrganoJudicial> lista = new List<TipoOrganoJudicial>();
            lista.Add(new TipoOrganoJudicial() { Descripcion = "Juzgado De Paz" });
            lista.Add(new TipoOrganoJudicial() { Descripcion = "Juzgado De Paz Letrado" });
            lista.Add(new TipoOrganoJudicial() { Descripcion = "Juzgado Especializado" });
            lista.Add(new TipoOrganoJudicial() { Descripcion = "Sala Superior" });
            lista.Add(new TipoOrganoJudicial() { Descripcion = "Sala Suprema" });
            lista.Add(new TipoOrganoJudicial() { Descripcion = "Tribunal Constitucional " });

            return lista;
        }
    }
}
