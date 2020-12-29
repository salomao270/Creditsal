//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

namespace Creditsal.Api.Models
{
    public class Customer
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Salario { get; set; }
        public Customer()
        {
        }
        public Customer(string _name, int _age, decimal _salary)
        {
            this.Nome = _name;
            this.Idade = _age;
            this.Salario = _salary;
        }
    }

}