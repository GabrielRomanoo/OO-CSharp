using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaGabriela = new ContaCorrente();
            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.numero = 863452;

            ContaCorrente contaDaGabrielaCosta = new ContaCorrente();
            contaDaGabrielaCosta.titular = "Gabriela";
            contaDaGabrielaCosta.agencia = 863;
            contaDaGabrielaCosta.numero = 863452;

            ContaCorrente contaDoBruno = new ContaCorrente();

            contaDoBruno.titular = "Bruno";
            contaDoBruno.saldo = 100.0;

            Console.WriteLine(contaDoBruno.saldo);
            contaDoBruno.Sacar(50);
            Console.WriteLine(contaDoBruno.saldo);
            contaDoBruno.Depositar(300);
            Console.WriteLine(contaDoBruno.saldo);

            Console.ReadLine();



        }
    }
}
