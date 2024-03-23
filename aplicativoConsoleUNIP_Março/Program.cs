using System;
using System.ComponentModel.DataAnnotations;

namespace HelloWorldApp{
    class UNIP{
        static void Main(string[] args){
            //iniciar informar produto
            informeProduto informeProduto = new informeProduto();
            informeProduto.informarProduto();
        }
    }
}