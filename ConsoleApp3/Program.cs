// See https://aka.ms/new-console-template for more information

using System;

namespace MeuSuperBanco
{
    class Program
    {
        static void Main(string[] args) 
        {
            MeuSuperBanco.ContaBanco contaB = new ContaBanco("Thiago", 2000);
            Console.WriteLine($"Nome: {contaB.Dono} Saldo: {contaB.Saldo} numero da conta: {contaB.Numero}");

            Console.WriteLine($"O saldo é {contaB.Saldo}");

            contaB.Sacar(1000, DateTime.Now, "Saquei para comprar carro");

            contaB.Sacar(100, DateTime.Now, "Saque aluguel");

            contaB.Sacar(200, DateTime.Now, "Saque");

            try
            {
                contaB.Sacar(1000, DateTime.Now, "Saquei para comida");
                Console.WriteLine($"A conta esta com {contaB.Saldo}");

            }
            catch (ArgumentOutOfRangeException ex) 
            {
                Console.WriteLine(ex.Message);

            }catch (InvalidOperationException ex) 
            {
                Console.WriteLine(ex.Message);

            }catch(Exception ) 
            {
                Console.WriteLine("Operacao inválida");
            }
  
            Console.WriteLine(contaB.PegarMovimentacao());
        }
    }
}
