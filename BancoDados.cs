using EstacioUniv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class BancoDados
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Veiculo> veiculos = new List<Veiculo>();
        private List<Registro> registros = new List<Registro>();

        public List<Registro> getRegistros { get { return registros; } }
        public BancoDados() {
            this.clientes.Add(new Cliente("aluno", "Gabriel", "123"));
            this.clientes.Add(new Cliente("funcionário", "Felipe", "456"));
            this.clientes.Add(new Cliente("professor", "Pedro", "789"));
            this.veiculos.Add(new Veiculo("123","C", ""));
            this.veiculos.Add(new Veiculo("456", "C", ""));
            this.veiculos.Add(new Veiculo("789", "C", "789"));
            this.registros.Add(new Registro(DateTime.Now, "123", "123", "entrada", "Gabriel"));
            this.registros.Add(new Registro(DateTime.Now, "456", "456", "entrada", "Felipe"));
            this.registros.Add(new Registro(DateTime.Now, "789", "789", "entrada", "Pedro"));
            this.registros.Add(new Registro(DateTime.Now, "123", "123", "saida", "Gabriel"));
            this.registros.Add(new Registro(DateTime.Now, "789", "789", "saida", "Pedro"));
            this.registros.Add(new Registro(DateTime.Now, "456", "456", "saida", "Felipe"));
        }



        public int buscarPlacaVeiculo(string pla)
        {
            int pos = -1;
            for (int i = 0; i < veiculos.Count; i++)
            {
                if (veiculos[i].Placa == pla)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }


        public string recuperarNomeCliente(string cod)
        {
            string nomeCliente = "não encontrado";
            int pos = this.buscarCodigoCliente(cod);
            if (pos >= 0) nomeCliente = this.clientes[pos].Nome;
            return nomeCliente;
        }

        public void gravarVeiculo(Veiculo veic)
        {
            this.veiculos.Add(veic);
        }

        public void alterarVeiculo(int pos, Veiculo veic)
        {
            this.veiculos[pos] = veic;
        }

        public void exluirVeiculo(int pos)
        {
            this.veiculos.RemoveAt(pos);
        }


        public int buscarCodigoCliente(string cod)
        {
            int pos = -1;
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Codigo == cod)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }


        public Cliente recuperarCliente(int pos)
        { 
            return clientes[pos]; 
        }


        public void excluirCliente(int pos)
        {
            this.clientes.RemoveAt(pos);
        }


        public void alterarCliente(int pos, Cliente cli)
        {
            this.clientes[pos] = cli;
        }


        public void gravarCliente(Cliente cli)
        {
            this.clientes.Add(cli);
        }

        public void GravarRegistro(Registro registros)
        {
            this.registros.Add(registros);
        }

        //==============================================================================
        public Registro RecuperarRegistro(int pos)
        {
            Registro reg= this.registros[pos];
            return reg;
        }
        //==============================================================================

    }
}
