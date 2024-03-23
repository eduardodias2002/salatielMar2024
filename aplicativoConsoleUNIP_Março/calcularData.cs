using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class calcularData{
    double precoFinal; //preço final

    public void informarProduto(){
        Console.Clear();
        Console.WriteLine("Informações do Produto\n"); // todas as informações no objeto "produto" são exibidas na tela
        Console.WriteLine("Nome do Produto: " + objProduto._nome);
        Console.WriteLine("Valor: R$" + objProduto._valor);
        Console.WriteLine("Região do Produto: " + objProduto._origem);
        Console.WriteLine("Quantidade: " + objProduto._quantidade + " unidade(s)");
        Console.WriteLine("Data de Aquisição: " + objProduto._aquisicaoData.ToString("dd/MM/yyyy")); // convertido para não aparecer horas, minutos, e segundos
        Console.WriteLine("Data de Validade : " + objProduto._validadeData.ToString("MM/yyyy")); // mesmo
        Console.WriteLine("\nAperte qualquer tecla para prosseguir.");
        Console.ReadKey(); // aguarda até o usuário apertar qualquer tecla
        calcularMes(objProduto._aquisicaoData.Month);
    }

    private void calcularMes(int x){ 
        // compara para saber se é entre Janeiro até Julho
        if(x >= 1 && x <= 7){
            objProduto._valor -= (objProduto._valor*0.3); // desconta 30% do valor do objeto produto
            acrescimoRegiao(); 
        }
        // compara para saber se é entre Agosto até Dezembro
        else if (x >= 8 && x <= 12){
            objProduto._valor -= (objProduto._valor * 0.5); // desconta 50% do valor do objeto produto
            acrescimoRegiao(); // vai até a função de acrescimo de região
        }

    }

    private void acrescimoRegiao(){ //adiciona porcentagem considerando a origem do objeto produto

        switch (objProduto._origem){ 

            case "Norte":
                objProduto._valor += (objProduto._valor * 0.3);
                resultadoFinal();
                break;

            case "Nordeste":
                objProduto._valor += (objProduto._valor * 0.5);
                resultadoFinal();
                break;

            case "Centro-Oeste":
                objProduto._valor += (objProduto._valor * 0.2);
                resultadoFinal();
                break;

            case "Sudeste":
                objProduto._valor += (objProduto._valor * 0.1);
                resultadoFinal();
                break;

            case "Sul":
                objProduto._valor += (objProduto._valor * 0.4);
                resultadoFinal();
                break;
        }
        resultadoFinal(); // vai para resultado final após toda a checagem

    }

    private void resultadoFinal(){
        Console.Clear();
        Console.WriteLine("O produto {0}, região {1}, tem o valor final de R${2}\nObrigado por utilizar!", objProduto._nome, objProduto._origem, objProduto._valor);
        Console.WriteLine("\nAperte qualquer tecla para sair.");
        Console.ReadKey();
        Environment.Exit(0); //sai do programa
    }

}
