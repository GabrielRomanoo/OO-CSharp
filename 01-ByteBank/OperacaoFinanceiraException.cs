using System;
using System.Runtime.Serialization;

namespace _01_ByteBank
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {
        }

        public OperacaoFinanceiraException(string message) 
            : base(message)
        {
        }

        public OperacaoFinanceiraException(string message, Exception innerException) 
            : base(message, innerException) //passamos pra base (pro pai) porque os setter desses atributos sao privados
        {
        }

    }
}