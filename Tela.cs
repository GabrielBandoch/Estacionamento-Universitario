using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacioUniv
{
    public class Tela
    {
        // Construtor
        public Tela() 
        {
            this.limparTela();
        }

        // Limpar a tela
        public void limparTela()
        {
            Console.Clear();
        }

        // montar a tela de fundo
        public void telaFundo(string titulo = "titulo")
        {
            this.borda(0, 0, 80, 30);
            this.sublinhado(0, 2, 80);
            this.aoCentro(0, 1, 80, titulo);
        }

        //montar o menu
        public string montarMenu(List<string> menu, int ce, int la)
        {                   // lb= linha baixo
            int cd, lb, x;  // cd= coluna direita
            string op;

            // calcula a posição da coluna e linha finais
            cd = ce + menu[0].Length + 1;
            lb = la + menu.Count() + 2;

            // monta a estrutura da moldura
            this.borda(ce, la, cd , lb);

            // Mostra as opções do menu
            for (x = 0; x < menu.Count(); x++)
            {
                Console.SetCursorPosition(ce + 1, la + x + 1);
                Console.Write(menu[x]);
            }
            Console.SetCursorPosition(ce + 1, la + x + 1);
            Console.Write("Opção: ");
            op = Console.ReadLine();
            return op;
        }

        // monta a estrutura da moldura
        public void borda(int ce, int la, int cd, int lb, string txt = "")
        {
            int col, lin;

            // Limpar o local onde será feito o sobreposto
            this.limparLocal(ce, la, cd, lb);

            // Linhas horizontais
            for(col = ce; col <= cd; col++)
            {
                Console.SetCursorPosition(col, la);
                Console.Write("-");
                Console.SetCursorPosition(col, lb);
                Console.Write("-");
            }
            // Colunas
            for(lin = la; lin <= lb; lin++)
            {
                Console.SetCursorPosition(ce, lin);
                Console.Write("|");
                Console.SetCursorPosition(cd, lin);
                Console.Write("|");
            }
            //Fazer as quinas
            Console.SetCursorPosition(ce, la); Console.Write("+");
            Console.SetCursorPosition(ce, lb); Console.Write("+");
            Console.SetCursorPosition(cd, la); Console.Write("+");
            Console.SetCursorPosition(cd, lb); Console.Write("+");

            // Caso tenha alguma mensagem centralizar
            if(txt != "")
            {
                this.aoCentro(ce, la + 1, cd, txt);
            }

        }

        // faz a centralização do titulo da tela de fundo
        public void aoCentro(int ce, int la, int cd, string txt)
        {
            int col;
            col = ce + (cd - ce - txt.Length) / 2;
            Console.SetCursorPosition(col, la);
            Console.Write(txt);
        }

        // Faz uma sub linha para dividir o titulo do espaço aberto da tela de fundo
        public void sublinhado(int ce, int la, int cd)
        {
            int col;
            //faz a sub linha
            for (col = ce; col <= cd; col++)
            {
                Console.SetCursorPosition(col, la);
                Console.WriteLine("-");
            }
            // ajeita as pontas para poder encaixar no quadro geral
            Console.SetCursorPosition(ce, la);
            Console.WriteLine("+");
            Console.SetCursorPosition(cd, la);
            Console.WriteLine("+");
        }

        // Limpa o espaço onde será criado um menu sobreposto
        public void limparLocal(int ce, int la, int cd, int lb)
        {
            int col, lin;

            // Fzer uma matriz para limpar o espaço delimitado
            for(col = ce; col <= cd; col++)
            {
                for(lin = la; lin <= lb; lin++)
                {
                    Console.SetCursorPosition(col, lin);
                    Console.Write(" ");
                }
            }
        }
        // cria um espaço para realizar as alterações do CRUD
 
        public string opcao(int col, int lin, string pergunta)
        {
            string resposta;
            Console.SetCursorPosition(col, lin);
            Console.Write(pergunta);
            resposta = Console.ReadLine();
            this.limparLocal(col, lin, col + pergunta.Count() + 3, lin);
            return resposta;
        }

        public void moldRegistro( string txt =" Lista de Registro")
        {
            this.limparTela();
            this.borda(0,0,0,0);
            this.sublinhado(2,2,80);
            this.aoCentro(2, 1, 80, txt);

        }



    }
}
