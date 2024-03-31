using EstaUniv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class Registro
    {
        private DateTime data;
        private string placa;
        private string codigo;

        //==============================================================================
        private string tipoEntradaSaida;//Tipo entrada ou saida
        private string tipoCliente;
        //==============================================================================
        public DateTime Data { get => data; }

        public string Placa {  get => placa; }
        public string Codigo { get => codigo; }

        //==============================================================================
        public string TipoEntradaSaida { get => tipoEntradaSaida; }
        public string TipoCliente { get => tipoCliente; }
        //==============================================================================
        
        public Registro(DateTime data,string placa,string codigo,string tipoEntradaSaida,string tipoCliente)
        {
            this.data = DateTime.Now;
            this.placa = placa;
            this.codigo = codigo;
            //==============================================================================
            this.tipoEntradaSaida = tipoEntradaSaida;
            this.tipoCliente = tipoCliente;
            //==============================================================================
        }
    }
}
