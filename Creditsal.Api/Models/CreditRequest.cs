//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

using System;

namespace Creditsal.Api.Models
{
    public class CreditRequest
    {
        private string Nome { get; set; }
        private decimal ValorPedido { get; set; }
        private Credit credit { get; set; }
        public CreditRequest(string nome, decimal valorPedido)
        {
            this.Nome = nome;
            this.ValorPedido = valorPedido;
        }

        public Credit GetCredit(ICustomer customer)
        {
            credit = new Credit(customer.Nome, customer.Salario, this.ValorPedido);

            credit.ValorEmprestado =
                  customer.Idade > 80 ? (customer.Salario * 20 / 100)
                : customer.Idade > 50 ? (customer.Salario * 70 / 100)
                : customer.Idade > 30 ? (customer.Salario * 90 / 100)
                : customer.Idade > 20 ? (customer.Salario * 100 / 100)
                : 0;

            credit.ValorParcela =
                  customer.Salario >= 1000.0M && customer.Salario <= 2000.0M ? (customer.Salario * 5 / 100)
                : customer.Salario >= 2001.0M && customer.Salario <= 3000.0M ? (customer.Salario * 10 / 100)
                : customer.Salario >= 3001.0M && customer.Salario <= 4000.0M ? (customer.Salario * 15 / 100)
                : customer.Salario >= 4001.0M && customer.Salario <= 5000.0M ? (customer.Salario * 20 / 100)
                : customer.Salario >= 5001.0M && customer.Salario <= 6000.0M ? (customer.Salario * 25 / 100)
                : customer.Salario >= 6001.0M && customer.Salario <= 7000.0M ? (customer.Salario * 30 / 100)
                : customer.Salario >= 7001.0M && customer.Salario <= 8000.0M ? (customer.Salario * 35 / 100)
                : customer.Salario >= 8001.0M && customer.Salario <= 9000.0M ? (customer.Salario * 40 / 100)
                : customer.Salario >= 9001.0M ? (customer.Salario * 45 / 100)
                : 0;

            try
            {
                // descobre qual a quantidade da parcela e valida se ao final resultará no valor do emprestimo total (resto desta divisao deve ser = 0).
                // se nao (resto desta divisao != 0, significa que após a ultima parcela sobrará algum valor para resultar no valor do emprestimo total), 
                // entao, este código decrementa o valor da parcela, até encontrar um valor de parcela que ao final resultará no valor do emprestimo total (resto desta divisão = 0)
                while ((credit.ValorEmprestado % credit.ValorParcela) != 0.0M)
                {
                    credit.ValorParcela -= 0.1M;
                }

                // calcula a quantidade de parcelas
                credit.QuantidadeParcelas = (int)(credit.ValorEmprestado / credit.ValorParcela);
            }
            catch (ArithmeticException e)
            {
                throw new Exception(e.ToString());
            }

            return credit;
        }

    }
}