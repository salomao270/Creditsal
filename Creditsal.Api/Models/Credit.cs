//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

namespace Creditsal.Api.Models 
{
    public class Credit
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal CreditRequestByUser { get; set; }
        public decimal CreditProvided { get; set; }
        public int QuantityOfParcels { get; set; }
        public decimal ValueOfEachParcel { get; set; }        
        public Credit()
        {
            // default constructor
        }
        public Credit(string _name, decimal _salary, decimal _creditRequestByCustomer)
        {
            Name = _name;
            Salary = _salary;
            CreditRequestByUser = _creditRequestByCustomer;
            CreditProvided = 0;
            QuantityOfParcels = 0;
            ValueOfEachParcel = 0;
        }

    }
}