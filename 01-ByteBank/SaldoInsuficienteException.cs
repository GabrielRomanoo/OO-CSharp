using System;
using System.Runtime.Serialization;

namespace _01_ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get; } //readonly (faz o set apenas no construtor)
        public double ValorSaque { get; } //estas propriedades desta classe podem ser acessadas por quem receber a execao
        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque no valor de " + valorSaque + " em uma conta com saldo de " + saldo) //o this vai chamar o construtor abaixo
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        public SaldoInsuficienteException(string message)
            : base(message)
        {

        }

        public SaldoInsuficienteException(string message, Exception innerException)
            : base(message, innerException) //passamos pra base (pro pai) porque os setter desses atributos sao privados
        {
        }


    }
}