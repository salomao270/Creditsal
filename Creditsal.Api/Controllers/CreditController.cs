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
        [HttpGet("")]
        [HttpGet("Home")]
        [HttpGet("Home/Index")]
        public IActionResult Index() 
        {
            return View();
        }

        #region POST
        // [HttpPost("api/credito/{nome}/{valorPedido}")]
        [HttpPost("api/credit/{name}/{creditRequestByUser}")]
        public IActionResult PostCredit (string name, decimal creditRequestByUser)
        {
            if (String.IsNullOrWhiteSpace(name) || creditRequestByUser <= 0)
            {
                return Content("Name or credit request is invalid. Try again.");
            }

            var customers = new List<Customer>();
            customers = GetCustomers();
            
            if (customers.Count == 0 )
            {
                throw new InvalidOperationException("No customers found");
            }
            
            var foundCustomer = customers.Find(c => c.Nome == name);

            if (foundCustomer is null)
            {
                return Content("No customer found");
            }
            
            var creditRequestObj = new CreditRequest(name, creditRequestByUser);
            
            // It calculates the credit available based on Customer age and salary - then return a Credit object
            var creditObj = creditRequestObj.GetCredit(foundCustomer);

            return Ok(creditObj);
        }
        #endregion

        #region GET CUSTOMER FROM EXTERNAL API
        [HttpGet("api/customers")]
        public List<Customer> GetCustomers() 
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