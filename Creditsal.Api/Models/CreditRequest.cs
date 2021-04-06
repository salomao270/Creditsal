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
        private string Name { get; set; }
        private decimal CreditRequestByUser { get; set; }
        private Credit CreditObj { get; set; }
        public CreditRequest()
        {
            
        }
        public CreditRequest(string _name, decimal _creditRequestByUser)
        {
            this.Name = _name;
            this.CreditRequestByUser = _creditRequestByUser;
        }

        public Credit GetCredit(Customer _customer)
        {
            CreditObj = new Credit(_customer.Nome, _customer.Salario, this.CreditRequestByUser);

            CreditObj.CreditProvided =
                  _customer.Idade > 80 ? (_customer.Salario * 20 / 100)
                : _customer.Idade > 50 ? (_customer.Salario * 70 / 100)
                : _customer.Idade > 30 ? (_customer.Salario * 90 / 100)
                : _customer.Idade >= 20 ? (_customer.Salario * 100 / 100)
                : 0;

            CreditObj.ValueOfEachParcel =
                  _customer.Salario >= 1000.0M && _customer.Salario <= 2000.0M ? (_customer.Salario * 5 / 100)
                : _customer.Salario >= 2001.0M && _customer.Salario <= 3000.0M ? (_customer.Salario * 10 / 100)
                : _customer.Salario >= 3001.0M && _customer.Salario <= 4000.0M ? (_customer.Salario * 15 / 100)
                : _customer.Salario >= 4001.0M && _customer.Salario <= 5000.0M ? (_customer.Salario * 20 / 100)
                : _customer.Salario >= 5001.0M && _customer.Salario <= 6000.0M ? (_customer.Salario * 25 / 100)
                : _customer.Salario >= 6001.0M && _customer.Salario <= 7000.0M ? (_customer.Salario * 30 / 100)
                : _customer.Salario >= 7001.0M && _customer.Salario <= 8000.0M ? (_customer.Salario * 35 / 100)
                : _customer.Salario >= 8001.0M && _customer.Salario <= 9000.0M ? (_customer.Salario * 40 / 100)
                : _customer.Salario >= 9001.0M ? (_customer.Salario * 45 / 100)
                : 0;

            try
            {
                // Descobre qual a quantidade da parcela e valida se ao final resultará no valor do emprestimo total (resto desta divisao deve ser = 0).
                // se nao (resto desta divisao != 0, significa que após a ultima parcela sobrará algum valor para resultar no valor do emprestimo total), 
                // entao, este código decrementa o valor da parcela, até encontrar um valor de parcela que ao final resultará no valor do emprestimo total (resto desta divisão = 0)
                while ((CreditObj.CreditProvided % CreditObj.ValueOfEachParcel) != 0.0M)
                {
                    CreditObj.ValueOfEachParcel -= 0.1M;
                }

                // Calcula a quantidade de parcelas
                CreditObj.QuantityOfParcels = (int)(CreditObj.CreditProvided / CreditObj.ValueOfEachParcel);
            }
            catch (ArithmeticException e)
            {
                throw new Exception($"Error while calculating, please try again, error: ", e);
            }
            catch (Exception e) 
            {
                throw new Exception($"Error, please try again, error: ", e);
            }

            return CreditObj;
        }

    }
}