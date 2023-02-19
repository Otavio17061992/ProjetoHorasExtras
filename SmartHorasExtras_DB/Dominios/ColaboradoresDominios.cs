using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHorasExtras_DB.Dominios
{
    public class ColaboradoresDominios
    {


        //key
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public int TipoUsuario { get; set; }
        public string Senha { get; set; }
        public bool EhValido { get; set; }

        public ColaboradoresDominios()
        {
            // construtor padrao
        }

        public ColaboradoresDominios(int id, string nome, string departamento)
        {
            // construtor com paramentros
            this.Id = id;
            this.Nome = nome;
            this.Departamento = departamento;
        }

        public ColaboradoresDominios(int id, string nome, string departamento, int tipoUsuario, string senha)
        {
            // // construtor com parametros adicionais
            this.Id = id;
            this.Nome = nome;
            this.Departamento = departamento;
            this.TipoUsuario = tipoUsuario;
            this.Senha = senha;
        }


        public ColaboradoresDominios(string NomeUsuario, string senha, int tipoColaborador)
        {
            this.Nome = NomeUsuario;
            this.Senha = senha;
            this.TipoUsuario = tipoColaborador;
        }


    }
}
