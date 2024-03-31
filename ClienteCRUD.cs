using EstacioUniv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class ClienteCRUD
    {
        //private VeiculoCRUD veiculos;
        private string tipo;
        private string nome;
        private string codigo;
        private int posicao;
        private Tela tl;
        private BancoDados bd;

        public ClienteCRUD(Tela tela, BancoDados banco)
        {
            this.tl = tela;
            this.bd = banco;
        }

        public void executarCRUD()
        {
            string resp;

            //pergunta se tem cadastro
            this.moldura();
            this.inserirCodigo();
            this.posicao = this.bd.buscarCodigoCliente(this.codigo);

            //
            if (this.posicao >= 0)
            {
                //mostra os dados cadastrados
                this.verDados();

                resp = tl.opcao(10, 13, "Deseja  A/E/V: ");

                // mostra cada escolha
                // Alteração
                if (resp.ToUpper() == "A")
                {
                    tl.limparLocal(23, 11, 59, 13);

                    this.inserirEntrada();

                    resp = tl.opcao(10, 13, "Confirmar (S/N): ");

                    if (resp.ToUpper() == "S")
                    {
                        this.bd.alterarCliente(this.posicao, new Cliente(this.tipo, this.nome, this.codigo));
                    }
                }

                // Exclusão
                if (resp.ToUpper() == "E")
                {
                    resp = tl.opcao(10, 13, "Comfirmar exclusão (S/N): ");
                    if (resp.ToUpper() == "S")
                    {
                        this.bd.excluirCliente(this.posicao);
                        
                    }
                }
            }
            else
            {
                //caso não seja encontrado nenhum cadastro
                //pergunta se quer fazer um
                resp = tl.opcao(10, 13, "Não encontrado. Deseja cadastrar(S/N): ");

                if (resp.ToUpper() == "S")
                {
                    //pede os novos dados
                    this.inserirEntrada();

                    //resp = tl.opcao("Confirmar (S/N): ", 10, 13);
                    Console.SetCursorPosition(10, 13);
                    Console.Write("Confirmar (S/N): ");
                    resp = Console.ReadLine();

                    if (resp.ToUpper() == "S")
                    {
                        this.bd.gravarCliente(new Cliente(this.tipo, this.nome, this.codigo));
                    }
                }
            }
        }

        public void moldura()
        {
            tl.borda(9, 8, 60, 14, "Cadastro cliente");
            Console.SetCursorPosition(10, 10);
            Console.Write("Código     : ");
            Console.SetCursorPosition(10, 11);
            Console.Write("Tipo  P/F/A: ");
            Console.SetCursorPosition(10, 12);
            Console.Write("Nome       : ");
        }


        public void inserirCodigo()
        {
            Console.SetCursorPosition(23, 10);
            this.codigo = Console.ReadLine();
        }


        public void verDados()
        {
            Cliente cli = this.bd.recuperarCliente(this.posicao);

            Console.SetCursorPosition(23, 11);
            Console.Write(cli.Tipo);
            Console.SetCursorPosition(23, 12);
            Console.Write(cli.Nome);
        }

        public void inserirEntrada()
        {
            Console.SetCursorPosition(23, 11);
            this.tipo = Console.ReadLine();
            Console.SetCursorPosition(23, 12);
            this.nome = Console.ReadLine();
        }

        // daqui para baixo é visitante

        public void executarCRUDVisitante()
        {
            this.moldVisitante();
            this.inserirDadosVisitante();

            string resp = this.tl.opcao(10, 14, "Confirmar (S/N): ");



            if (resp.ToUpper() == "S")
            {
                this.bd.gravarCliente(new Cliente(this.tipo, this.nome, this.codigo));
            }
        }

        public void moldVisitante()
        {
            tl.borda(9, 8, 60, 15, "Cadastro Visitante");
            Console.SetCursorPosition(10, 10);
            Console.Write("Nome       : ");
            Console.SetCursorPosition(10, 11);
            Console.Write("Placa      : ");
            Console.SetCursorPosition(10, 12);
            Console.Write("Tipo (C/M) : ");
            Console.SetCursorPosition(10, 13);
            Console.Write("Cod cliente: ");
        }



        public void inserirDadosVisitante()
        {
            this.nome = "Visitante";
            this.codigo = this.gerarCodigo().ToString();
            Console.SetCursorPosition(23, 10);
            Console.Write(this.nome);
            Console.SetCursorPosition(23, 11);
            string placa = Console.ReadLine();
            Console.SetCursorPosition(23, 12);
            this.tipo = Console.ReadLine();
            Console.SetCursorPosition(23, 13);
            Console.Write(this.codigo);
        }


        int z = 600;
        public int gerarCodigo()
        {
            z++;
            return z;
        }

    }
}

