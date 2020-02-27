//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

namespace Creditsal.Api.Models 
{
    public class Credit
    {
        public Credit()
        {
        }
        public Credit(string nome, decimal salario, decimal valorPedido)
        {
            Nome = nome;
            Salario = salario;
            ValorPedido = valorPedido;
            ValorEmprestado = 0;
            QuantidadeParcelas = 0;
            ValorParcela = 0;
        }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal ValorEmprestado { get; set; }
        public int QuantidadeParcelas { get; set; }
        public decimal ValorParcela { get; set; }
    }
}