//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

namespace Creditsal.Api.Models
{
    public class Customer : ICustomer
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Salario { get; set; }
        public Customer()
        {
        }
        public Customer(string nome, int idade, decimal salario)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Salario = salario;
        }
    }

}