//==========================================
// Title:  Creditsal
// Description:  
// Author:  Salomao Ferreira
// Date:   27 Feb 2020
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Creditsal.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Creditsal.Api.Controllers 
{
    public class CreditController : Controller
    {
        #region POST
        [HttpPost("api/credito/{nome}/{valorPedido}")]
        public IActionResult PostCredit (string nome, decimal valorPedido)
        {
            if (nome == "" || valorPedido <= 0)
            {
                return Content("Nome ou Valor Pedido invalido. Tente novamente");
            }

            // consulta todos os Customers na API externa
            var externalCustomers = new List<Customer>();
            externalCustomers = GetExternalCustomers();
            
            if (externalCustomers.Count == 0 )
            {
                throw new InvalidOperationException("Nao foram encontrados clientes cadastrados no sistema externo");
            }
            
            var foundCustomer = externalCustomers.Find(c => c.Nome == nome);

            if (foundCustomer is null)
            {
                return Content("Cliente não encontrado. Tente novamente");
            }
            
            var creditRequest = new CreditRequest(nome, valorPedido);
            
            // calcula o credito baseado no salario e idade do Customer filtrado e retorna um credito com os valores calculados
            var credit = creditRequest.GetCredit(foundCustomer);

            return Ok(credit);
        }
        #endregion

        #region GET - CONSULTA API EXTERNA
        [HttpGet("api/clientes")]
        public List<Customer> GetExternalCustomers() 
        {
            WebRequest request = HttpWebRequest.Create("http://www.mocky.io/v2/5e2b3b8d32000054001c7109");
        
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string customer_json = reader.ReadToEnd();

            var customers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(customer_json);
            
            return customers;
        }
        #endregion

    }
}