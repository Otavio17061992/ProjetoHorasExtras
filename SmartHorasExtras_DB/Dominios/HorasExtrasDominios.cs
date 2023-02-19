using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHorasExtras_DB.Dominios
{
    public class HorasExtrasDominios
    {
        public string dia { get; set; }
        public string mes { get; set; }
        public string ano { get; set; }
        public string semana { get; set; }
        public string cliente { get; set; }

        /// <summary>
        /// horario de entrada do 1º periodo
        /// </summary>
        public string p1_entrada { get; set; }
        public string p1_saida { get; set; }
        public string p1_60 { get; set; }
        public string p1_20_1 { get; set; }
        public string p1_100 { get; set; }
        public string p1_20_2 { get; set; }

        /// <summary>
        /// horario de entrada do 2º periodo
        /// </summary>
        public string p2_entrada { get; set; }
        public string p2_saida { get; set; }
        public string p2_60 { get; set; }
        public string p2_20_1 { get; set; }
        public string p2_100 { get; set; }
        public string p2_20_2 { get; set; }

        public int id { get; set; }
        public DateTime data { get; set; }
        public TimeSpan horas_extra { get; set; }
        public int colaborador_id { get; set; }

        public ColaboradoresDominios Colaborador { get; set; }
    }
}
