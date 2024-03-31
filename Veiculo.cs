using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class Veiculo
    {
        // propriedades
        private string placa;
        private string tipo;
        private string codcliente;
        // getters e setters
        public string Placa { get => placa; set => placa = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Codcliente { get => codcliente; set => codcliente = value; }

        public Veiculo(string placa, string tip, string codcli)
        {
            this.placa = placa;
            this.tipo = tip;
            this.codcliente = codcli;
        }


    }
}
