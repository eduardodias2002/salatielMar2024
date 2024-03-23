using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

internal class informeProduto
{
    public static string descricaoRegiao, nome;
    public static double valor;
    public static int quantidade;
    public static DateTime validade, aquisicao;

    public void informarProduto(){
        //Insira o nome do produto
        Console.WriteLine("Bem-vindo!\nPor favor insira o nome do produto.");
        nome = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(nome)){ // caso o nome seja um espaço vazio
            Console.WriteLine("Nome inválido, por favor insira um nome.");
            Console.ReadKey();
            Console.Clear();
            informarProduto();
        }
        informarDataValidade();
    }
    public void informarDataValidade(){ // limpa o console
        Console.Clear();
        informeData();
        Console.Clear();
        informarOrigem();
    }
    public void informarOrigem(){ // informe região
        Console.Clear();
        Console.WriteLine("Insira a origem do produto.\n<1>. Norte\n<2>. Nordeste\n<3>. Centro-Oeste\n<4>. Sudeste\n<5>. Sul");
        string inputUsuario = Console.ReadLine();
        descricaoRegiao = informarRegiao(Convert.ToInt16(inputUsuario)); // o usuário insere uma região de 1-5, a função informarRegiao é utilizada

        if (descricaoRegiao == "Invalido"){ 
            Console.WriteLine("Região inválida, por favor insira uma região válida. (1-5)");
            Console.ReadKey();
            Console.Clear();
            descricaoRegiao = null; // caso for um erro, descrição erro é colocada como nulo, e a função repete novamente
            informarOrigem();
        }
        descricaoRegiao = informarRegiao(Convert.ToInt16(inputUsuario)); 
        valorProduto();
    }

    public void informeData(){
        int validadeDia, validadeMes, validadeAno; //variáveis com dia, mês, e ano
        string inputUsuario; // o que o usuário vai inserir na linha 56
        do{
            Console.WriteLine("Informe dia de validade (01-31): ");
            inputUsuario = Console.ReadLine(); //variável de input do usuário é repetido para dia, mês, e ano

            // se for um espaço vazio, um dia menor que 0, ou maior de 31, ou algo que for string
            if (!int.TryParse(inputUsuario, out validadeDia) || validadeDia < 1 || validadeDia > 31 || string.IsNullOrWhiteSpace(inputUsuario)){ 
                Console.WriteLine("Dia inválido, por favor insira um dia entre 01 e 31.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (validadeDia < 1 || validadeDia > 31);
        validadeDia = Convert.ToInt16(inputUsuario); // caso for bem sucedido, input do usuário vai para validadeDia

        do{
            Console.WriteLine("Informe mês de validade (01-12): "); 
            inputUsuario = Console.ReadLine(); // mesmo processo...

            if (!int.TryParse(inputUsuario, out validadeMes) || validadeMes < 1 || validadeMes > 12 || string.IsNullOrWhiteSpace(inputUsuario)){
                Console.WriteLine("Mês inválido, por favor insira um mês entre 01 e 12.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (validadeMes < 1 || validadeMes > 12);
        validadeMes = Convert.ToInt16(inputUsuario);

        do{
            Console.WriteLine("Informe ano de validade (Entre 2023 e 2100):");
            inputUsuario = Console.ReadLine(); 

            if (!int.TryParse(inputUsuario, out validadeAno) || validadeAno < 2023 || validadeAno > 2100 || string.IsNullOrWhiteSpace(inputUsuario)){
                Console.WriteLine("Ano inválido ou produto vencido, por favor insira um ano entre 2023 e 2100.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (validadeAno < 2023 || validadeAno > 2100);
        validade = new DateTime(validadeAno, validadeMes, validadeDia, 0, 0, 0); //após tudo for inserido e válido, as variáveis de dia, mês, e ano vão para a validade final DateTime
        informarOrigem(); // informar origem
    }

    public static string informarRegiao(int x){ // retorna a região para 
        switch (x){
            case 1:
                return "Norte";
            case 2:
                return "Nordeste";
            case 3:
                return "Centro-Oeste";
            case 4:
                return "Sudeste";
            case 5:
                return "Sul";
            default:
                return "Invalido";
        }
    }

    public void valorProduto(){ // o usuário insere o valor do produto
        do{
            Console.Clear();
            Console.WriteLine("Insira o valor do produto.");
            valor = Convert.ToDouble(Console.ReadLine());

            if (valor <= 0){ // não é possível inserir um valor negativo, ou um valor igual a 0
                Console.WriteLine("Valor inválido, insira um valor superior a 0.");
                Console.ReadKey();
                Console.Clear();
                valorProduto();
            }
        }
        while (valor <= 0); // se repete até o processo dar certo
        quantidadeProduto();
    }

    public void quantidadeProduto(){ // o usuário insere a quantidade do prpoduto
        do{
            Console.Clear();
            Console.WriteLine("Insira a quantidade do produto."); 
            quantidade = Convert.ToInt32(Console.ReadLine());

            if (quantidade <= 0){ // não é possível ter um produto inferior ou igual a 0.
                Console.WriteLine("Quantidade inválida, insira uma quantidade superior a 0.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (quantidade < 0); // se repete até dar certo
        informeMesEano();
    }

    public void informeMesEano(){ // mesmo processo utilizado para data de validade, porém encurtado
        int aquisicaoMes, aquisicaoAno;
        string inputUsuario;
        do{
            Console.Clear();
            Console.WriteLine("Mês de aquisição (01-12): ");
            inputUsuario = Console.ReadLine();

            if (!int.TryParse(inputUsuario, out aquisicaoMes) || aquisicaoMes < 1 || aquisicaoMes > 12 || string.IsNullOrWhiteSpace(inputUsuario)){
                Console.WriteLine("Mês inválido, por favor insira um mês entre 01 e 12.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (aquisicaoMes < 1 || aquisicaoMes > 12);
        aquisicaoMes = Convert.ToInt16(inputUsuario);

        do{
            Console.WriteLine("Ano de aquisição: (Entre 2023 e 2100)");
            inputUsuario = Console.ReadLine();

            if (!int.TryParse(inputUsuario, out aquisicaoAno) || aquisicaoAno < 2023 || aquisicaoAno > 2100 || string.IsNullOrWhiteSpace(inputUsuario)){ 
                Console.WriteLine("Ano inválido ou produto vencido, por favor insira um ano entre 2023 e 2100.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (aquisicaoAno < 2023 || aquisicaoAno > 2100);
        aquisicao = new DateTime(aquisicaoAno, aquisicaoMes, 1, 0, 0, 0); // caso tudo estiver válido, a aquisicaofinal obtém o mês e ano do input do usuário
        fim();
    }

    private void fim(){ //quando todo o processo tiver terminado, o objeto calcularData é utilizado, e o produto recebe todas as variáveis que o usuário inseriu
        calcularData calcularData = new calcularData();
        objProduto objProduto = new objProduto(nome, descricaoRegiao, valor, quantidade, validade, aquisicao);
        calcularData.informarProduto(); // função é chamada
    }
}
