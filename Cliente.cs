using EstacioUniv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class Cliente
    {
        //propriedades
        private string tipo;
        private string nome;
        private string codigo;

        //getters
        public string Tipo { get => tipo; }
        public string Nome { get => nome; }
        public string Codigo { get => codigo; }
        


        //método construtor
        public Cliente(string tip, string nome, string cod)
        {
            this.tipo = tip;
            this.nome = nome;
            this.codigo = cod;
        }

    }
}

