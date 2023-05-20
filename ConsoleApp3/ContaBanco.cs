using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuperBanco
{
    public class ContaBanco
    {
        public string Numero { get; }
        public string Dono { get; set; }
        public decimal Saldo { 
            get
            {
                decimal saldo = 0;
                foreach (var item in todasTransacoes) 
                {
                    saldo += item.Valor;               
                }
                return saldo;
            } 
        }

        public static int numeroConta = 2124214;
        
        private List<Transacao> todasTransacoes = new List<Transacao>();

        public ContaBanco( string nome, decimal valor) 
        {
            this.Dono = nome;
            numeroConta++;

            this.Numero = numeroConta.ToString();
            Depositar(valor, DateTime.Now, "Saldo inicial");

        }

        public void Depositar(decimal valor, DateTime data, string obs )
        {
            if ( valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor),"Nao aceitamos deposito negativo");
            }
            Transacao trans = new Transacao(valor, data, obs);
            todasTransacoes.Add(trans);
        }
        public void Sacar(decimal valor, DateTime data, string obs) 
        {
            if ( valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Nao aceitamos saque de valor negativo");
            }
            if(Saldo - valor < 0) 
            {
                throw new InvalidOperationException("Operacao nao é permitida");
            }

            Transacao trans = new Transacao(-valor, data, obs);
            todasTransacoes.Add(trans);
        }

        public string PegarMovimentacao() 
        {
            var movimentacoes = new StringBuilder();

            movimentacoes.AppendLine("Data\tValor\tObs");

            foreach (var item in todasTransacoes) 
            {
                movimentacoes.AppendLine($"{item.Data.ToShortDateString()}\t {item.Valor}\t {item.Obs}");
            }
            return movimentacoes.ToString();
        }
    }
}
