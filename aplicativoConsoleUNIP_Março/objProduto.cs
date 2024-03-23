using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
public class objProduto{
    public static string _nome;
    public static DateTime _validadeData;
    public static string _origem;
    public static double _valor;
    public static int _quantidade;
    public static DateTime _aquisicaoData;

    public string Nome{
        get { return _nome; }
        set { _nome = value; }
    }

    public DateTime validadeData{
        get { return _validadeData; }
        set { _validadeData = value; }
    }

    public string Origem{
        get { return _origem; }
        set { _origem = value; }
    }

    public double Valor{
        get { return _valor; }
        set { _valor = value; }
    }

    public int Quantidade{
        get { return _quantidade; }
        set { _quantidade = value; }
    }

    public DateTime aquisicaoData{
        get { return _aquisicaoData; }
        set { _aquisicaoData = value; }
    }

    public objProduto(string nome, string origem, double valor, int quantidade, DateTime validadedata, DateTime aquisicaodata){
        Nome = nome;
        Origem = origem;
        Valor = valor;
        Quantidade = quantidade;
        validadeData = validadedata;
        aquisicaoData = aquisicaodata;
    }
}

