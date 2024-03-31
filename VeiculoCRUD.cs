using EstacioUniv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class VeiculoCRUD
    {
        private BancoDados bd;
        private Tela tl;
        private string placa, tipo, codcliente;
        private int posicao;


        public VeiculoCRUD(Tela tela, BancoDados banco) 
        {
            this.tl = tela;
            this.bd = banco;
        }

        
        public void executarCRUDVeiculo()
        {
            string resp;

            this.molduraV();
            this.inserirPlaca();
            this.posicao = this.bd.buscarPlacaVeiculo(this.placa);

            if (this.posicao >= 0)
            {
                this.verDadosV();
                resp = tl.opcao(10, 14, "Deseja alterar, excluir ou voltar A/E/V: ");

                if (resp.ToUpper() == "A")
                {
                    tl.limparLocal(10, 12, 59, 14);
                    resp = tl.opcao(10, 14, "Confirmar (S/N): ");

                    if (resp.ToUpper() == "S")
                    {
                        this.bd.alterarVeiculo(this.posicao, new Veiculo(this.placa, this.tipo, this.codcliente));
                    }
                }

                if (resp.ToUpper() == "E")
                {
                    resp = tl.opcao(10, 14, "Confirmar exclusão (S/N): ");
                    if (resp.ToUpper() == "S")
                    {
                        this.bd.exluirVeiculo(this.posicao);
                    }
                }
            }
            else
            {
                resp = tl.opcao(10, 14, "Placa não encontrada. Deseja cadastrar (S/N): ");

                if (resp.ToUpper() == "S")
                {
                    //outra coisa aqui
                    this.inserirEntradaV();
                    resp = tl.opcao(10, 14, "Confirmar (S/N): ");

                    if (resp.ToUpper() == "S")
                    {
                        this.bd.gravarVeiculo(new Veiculo(this.placa, this.tipo, this.codcliente));
                    }
                }

            }
                
            
        }
        //aqui para baixo é pra o cadastro de veiculo

        public void molduraV()
        {
            tl.borda(9, 8, 60, 15, "Cadastro Veiculo");
            Console.SetCursorPosition(10, 10);
            Console.Write("Placa      : ");
            Console.SetCursorPosition(10, 11);
            Console.Write("Tipo C/M   : ");
            Console.SetCursorPosition(10, 12);
            Console.Write("Cod cliente: ");
        }


        public void inserirPlaca()
        {
            Console.SetCursorPosition(23, 10);
            this.placa = Console.ReadLine();
        }



        public void inserirEntradaV()
        {
            Console.SetCursorPosition(23, 11);
            this.tipo = Console.ReadLine();
            
            Console.SetCursorPosition(23, 12);
            this.codcliente = Console.ReadLine();

            Console.SetCursorPosition(23 + this.codcliente.Length, 12);
            string nome = this.bd.recuperarNomeCliente(this.codcliente);
            Console.Write(" - " + nome);
        }

        public void verDadosV()
        {
            Console.SetCursorPosition(23, 11);
            Console.WriteLine(this.placa);
            Console.SetCursorPosition(23, 12);
            Console.Write(this.tipo);
            Console.SetCursorPosition(23, 14);
            Console.Write(this.codcliente);
        }


    }

}
