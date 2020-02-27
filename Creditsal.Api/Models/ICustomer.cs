//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

namespace Creditsal.Api.Models
{
    public interface ICustomer
    {
            string Nome { get; set; }
            int Idade { get; set; }
            decimal Salario { get; set; }
    }
}