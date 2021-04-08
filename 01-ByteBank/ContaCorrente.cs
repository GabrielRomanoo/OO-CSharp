using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class ContaCorrente
    {
        /*
        private Cliente _titular;
        public Cliente Titular
        {
            get
            {
                return _titular;
            }
            set
            {
                _titular = value;
            }
        } */

        public Cliente Titular //mesma coisa da linha do bloco  de codigo acima
        {
            get;
            set;
        }
        //propriedade abaixo
        public int Agencia { get; } // readonly

        public int Numero { get; } //ele fica readonly, podendo ser apenas lido e setado uma unica vez, no construtor

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
        
        public static double TaxaOperacao { get; private set; } //propriedade
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }



        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia; 
            Numero = numero;

            ContaCorrente.TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;

        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferencia.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                //throw; //passa pra frente a excecao, sem exlcuir o rastro anterior na pilha
                //trow ex; //exclui o rastro anteior da pilha e considera a  pilha a partir daqui
                throw new OperacaoFinanceiraException("Operação nao realizada.", ex); //innerExcpetion (execao interna)
            }

            contaDestino.Depositar(valor);
            return true;
        }
    }
}
