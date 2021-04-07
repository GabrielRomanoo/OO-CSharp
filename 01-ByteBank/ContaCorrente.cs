using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class ContaCorrente
    {
        //private Cliente _titular;
        //public Cliente Titular
        //{
        //    get
        //    {
        //        return _titular;
        //    }
        //    set
        //    {
        //        _titular = value;
        //    }
        //}

        public Cliente Titular //mesma coisa da linha do bloco  de codigo acima
        {
            get;
            set;
        }

        private int _agencia;
        public int Agencia //propriedade
        {
            get
            {
                return _agencia;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                _agencia = value;
            }
        }

        public int Numero { get; set; }

        private double _saldo;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0) //value eh o atributo que vem de fora, que eh mandado para o set
                {
                    return;
                }
                _saldo = value;
            }
        }

        public static int TotalDeContasCriadas { get; private set; } //apenas o set eh private 

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia; //  vai usar o "set" do atributo agencia e consequentemente vai respeitar a regra de não permitir o valor negativo
            Numero = numero;

            ContaCorrente.TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (this._saldo >= valor)
            {
                this._saldo -= valor;
                return true;
            }
            return false;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this._saldo < valor)
            {
                return false;
            }
            this._saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
