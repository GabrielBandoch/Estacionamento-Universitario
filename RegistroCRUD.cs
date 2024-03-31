using EstacioUniv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class RegistroCRUD
    {
        private Tela tela;
        private BancoDados bd;
        private DateTime data;
        private string placa;
        private string codigo;
        private string posicao;
        private string tipoEntradaSaida;//Tipo entrada ou saida
        private string tipoCliente;// A ideia disto consiste em passar o tipo do cliente se é aluno, professor, funcionario e ou visitante (se não me engano)
                                   // e dai printar na tela no emitir relatorio o tipo de cliente que entrou ou saiu,além da placa e codigo
                                   //(que no caso do visitante seré apenas mantido no relatorio)

        public RegistroCRUD(Tela tela, BancoDados banco)
        {
            this.tela = tela;
            this.bd = banco;
        }

        public void executarCRUDEntrada()
        {
            this.moldura();
            this.inserirPlaca();
            this.inserirCodigoCliente();
            //============================
            this.inserirTipoCliente();
            //============================
            int posicao = this.bd.buscarCodigoCliente(this.codigo);
            
            if( posicao >= 0)
            {
                this.tipoEntradaSaida = "Entrada";
                //===============================
                this.bd.GravarRegistro(new Registro(this.data, this.placa, this.codigo, this.tipoEntradaSaida, this.tipoCliente));
                //=================
            }
            else
            {
                Console.SetCursorPosition(23, 12);
                Console.WriteLine("Cadastro não encontrado. Não pode entrar!");
            }
        }
        public void executarCRUDSaida()
        {
            this.moldura();
            this.inserirPlaca();
            this.inserirCodigoCliente();

            //==================================================================================================
            this.inserirTipoCliente();
            //==================================================================================================

            int posicao = this.bd.buscarCodigoCliente(this.codigo);
            if (posicao >= 0)
            {
                this.tipoEntradaSaida = "Saída";

                //==================================================================================================
                this.bd.GravarRegistro(new Registro(this.data, this.placa, this.codigo, this.tipoEntradaSaida, this.tipoCliente));
                //==================================================================================================
            }
            else
            {
                Console.SetCursorPosition(23, 12);
                Console.WriteLine("Cadastro não encontrado. Não pode entrar!");
            }
        }
        //==================================================================================================
        public void emitirRelatorio()//Função para emitir relatorio

            //Dá para diminui esse codigo separando as funções, em metodos de inserir dados individuais
            //tipo inserir cada dado individualmente numa função

        {
            tela.limparTela();
            this.tela.moldRegistro();
            int posicaoTexto = 3;
            for (int i = 0; i < this.bd.getRegistros.Count; i++)//mudar a logica do i para ser responsiva(ao tamanho da lista, repetir o numero de vezzes necessario para printar tudo)
                                       //e ou mudar a logica  
            { 
                this.molduraRelatorio(posicaoTexto);
                Registro regis =this.bd.RecuperarRegistro(i);
                Console.SetCursorPosition(3, posicaoTexto);//estou usando posicao texto para o for continuar a printar os dados um enbaixo do outro
                                                           //porque se não só iria printar o ultimo, porque o for iria passar e colocar novos valores nas mesmas posições
                Console.Write($"========================================");//apenas para separar os relatorios, mas não sei se funciona
                Console.SetCursorPosition(23, posicaoTexto+1);
                Console.Write(regis.Data);
                Console.SetCursorPosition(23, posicaoTexto+2);
                Console.Write(regis.Codigo);
                Console.SetCursorPosition(23, posicaoTexto+3);
                Console.Write(regis.Placa);
                Console.SetCursorPosition(23, posicaoTexto+4);
                Console.Write(regis.TipoCliente);
                Console.SetCursorPosition(23,   posicaoTexto+5);
                Console.Write(regis.TipoEntradaSaida);
                posicaoTexto += 6;
            }
            Console.SetCursorPosition(3, posicaoTexto+1);
            Console.Write("Pressione qualquer tecla para sair...");
            Console.ReadKey();
            this.tela.limparTela();

        }

        
        public void molduraRelatorio(int posicaoTexto) //fazer moldura responsiva á quantidade de relatorios
        {
            tela.borda(2, 0, 80, 0, "");
            Console.SetCursorPosition(3, posicaoTexto+1);
            Console.Write("Horário:   : ");
            Console.SetCursorPosition(3,posicaoTexto+2);
            Console.Write("Código     : ");
            Console.SetCursorPosition(3, posicaoTexto+3);
            Console.Write("Placa:     : ");
            Console.SetCursorPosition(3, posicaoTexto+4);
            Console.Write("Cliente:   : ");
            Console.SetCursorPosition(3, posicaoTexto + 5);
            Console.Write("Tipo (E/S) : ");
        }
        //==============================================================================
       
        public void moldura()
        {
            tela.borda(9, 8, 60, 13, "Registro Entrada/Saída");
            Console.SetCursorPosition(10, 10);
            Console.Write("Placa      : ");
            Console.SetCursorPosition(10, 11);
            Console.Write("Código     : ");
            Console.SetCursorPosition(10, 12);
            Console.Write("Tipo       : ");
        }

        public void inserirPlaca()
        {
            Console.SetCursorPosition(23, 10);
            this.placa = Console.ReadLine();
        }

        public void inserirCodigoCliente()
        {
            Console.SetCursorPosition(23, 11);
            this.codigo = Console.ReadLine();
        }
        //===============================================================================
        public void inserirTipoCliente() 
        {
            Console.SetCursorPosition(23, 12);
            this.tipoCliente=Console.ReadLine();
        }
        //===================================================================================

    }
}
