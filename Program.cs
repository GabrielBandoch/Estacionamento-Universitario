using EstacioUniv;
using EstaUniv;
using System.Globalization;
using System.Runtime.CompilerServices;

Tela tela = new Tela();
BancoDados banco = new BancoDados();

ClienteCRUD cliente = new ClienteCRUD(tela, banco);
VeiculoCRUD veiculo = new VeiculoCRUD(tela, banco);
RegistroCRUD registro = new RegistroCRUD(tela, banco);

List<Estacionamento> estacionamentos = new List<Estacionamento>(); 

tela.limparTela();

//Criando o menu de entrada
string op;
List<string> menuInicial = new List<string>();
menuInicial.Add("Escolha a unidade de atuação");
menuInicial.Add(" ");
menuInicial.Add("1 - Joinville");
menuInicial.Add("2 - Jaraguá do Sul");
menuInicial.Add("3 - Florianópolis");
menuInicial.Add("4 - Pirabeiraba");
menuInicial.Add("5 - São Francisco");
menuInicial.Add("0 - Sair");

// Fazer um while para chegar no menu principal
while (true)
{
    tela.telaFundo("Católica");
    op = tela.montarMenu(menuInicial, 3, 3);

    // Para sair
    if (op == "0") break;

    // Menu para selecionar entre secretária e guarita
    if (op == "1" || op == "2" || op == "3" || op == "4" || op == "5")
    {
        while (true)
        {
            tela.limparLocal(3, 3, 35, 15);
            string op1;
            List<string> menuArea = new List<string>();
            menuArea.Add("Area          ");
            menuArea.Add("1 - Secretária");
            menuArea.Add("2 - Guarita");
            menuInicial.Add("0 - Sair");
            op1 = tela.montarMenu(menuArea, 3, 3);

            if (op1 == "0") break;

            // Menu da secretária
            if (op1 == "1")
            {
                while (true)
                {
                    tela.telaFundo("Católica");
                    tela.limparLocal(3, 3, 69, 15);
                    string op2;
                    List<string> menuSecreteria = new List<string>();
                    menuSecreteria.Add("Secretaria             ");
                    menuSecreteria.Add("1 - Cadastro do cliente");
                    menuSecreteria.Add("2 - Cadastro do veículo");
                    menuSecreteria.Add("3 - Relatório          ");
                    menuSecreteria.Add("0 - Sair               ");
                    op2 = tela.montarMenu(menuSecreteria, 3, 3);

                    if (op2 == "0") break;

                    // Faz um novo cadastro
                    if (op2 == "1") cliente.executarCRUD();

                    // Faz a edição dos cadastros
                    if (op2 == "2") veiculo.executarCRUDVeiculo();

                    // Emitir o relatorio de Entradas e saidas
                    if (op2 == "3") registro.emitirRelatorio();

                }
            }

            // menu da guarita
            if (op1 == "2")
            {
                while (true)
                {
                    tela.limparLocal(3, 3, 69, 15);
                    string op3;
                    List<string> menuGuarita = new List<string>();
                    menuGuarita.Add("Guarita                 ");
                    menuGuarita.Add("1 - Entrada");
                    menuGuarita.Add("2 - Saída");
                    menuGuarita.Add("3 - Visitante");
                    menuGuarita.Add("0 - Sair");

                    op3 = tela.montarMenu(menuGuarita, 3, 3);

                    if (op3 == "0") break;

                    // Faz a ação da entrada
                    if (op3 == "1") registro.executarCRUDEntrada();

                    // Faz a ação de saida
                    if (op3 == "2")registro.executarCRUDSaida();
 
                    // faz a ação de visitante
                    if (op3 == "3") cliente.executarCRUDVisitante();
                }
            }
        }
    }
}