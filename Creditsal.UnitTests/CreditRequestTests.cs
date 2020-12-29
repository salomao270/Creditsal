//==========================================
// Title:  Creditsal
// Author: Salomao Ferreira
// Date:   27 Feb 2020
//==========================================
using NUnit.Framework;
using Creditsal.Api.Models;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace Creditsal.UnitTests
{
    public class CreditRequestTests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region 1º FORMA UNIT TEST COM VALORES PARAMETRIZADOS POR IDADE E SALARIO
        [Test]
        public void GetCredit_IdadeMaiorQue20_ReturnsCredit100PorCentoSalario()
        {
            // {"Nome": "Andrea Marques","Idade": 25,"Salario": 8236.0}

            // Arrange
            var customer = new Customer("Andrea Marques", 25, 8236.0M);

            // Act
            var creditRequest = new CreditRequest("Andrea Marques", 2500.0M);
            var credit = creditRequest.GetCredit(customer);

            // Assert
            Assert.AreEqual(customer.Salario * 100 / 100, credit.CreditValueProvided);
            Assert.LessOrEqual(credit.ValueOfEachParcel, customer.Salario * 40 / 100);
        }

        [Test]
        public void GetCredit_IdadeMaiorQue30_ReturnsCredit90PorCentoSalario()
        {
            // {"Nome": "Cristina Reeves","Idade": 35,"Salario": 1933.0}

            // Arrange
            // parametros (nome, idade, salario)
            var customer = new Customer("Cristina Reeves", 35, 1933.0M);

            // Act
            var creditRequest = new CreditRequest("Cristina Reeves", 2500.0M);
            var credit = creditRequest.GetCredit(customer);

            // Assert
            Assert.AreEqual(customer.Salario * 90 / 100, credit.CreditValueProvided);
            Assert.LessOrEqual(credit.ValueOfEachParcel, customer.Salario * 5 / 100);
        }

        [Test]
        public void GetCredit_IdadeMaiorQue50_ReturnsCredit70PorCentoSalario()
        {
            // {"Nome": "Cristina Pereira","Idade": 54,"Salario": 4845.0}

            // Arrange
            // parametros (nome, idade, salario)
            var customer = new Customer("Cristina Pereira", 54, 4845.0M);     // customer object from API

            // Act
            var creditRequest = new CreditRequest("Cristina Pereira", 2500.0M);  // creditRequest object instantiated
            var credit = creditRequest.GetCredit(customer);

            // Assert
            Assert.AreEqual(customer.Salario * 70 / 100, credit.CreditValueProvided);
            Assert.LessOrEqual(credit.ValueOfEachParcel, customer.Salario * 20 / 100);
        }

        [Test]
        public void GetCredit_IdadeMaiorQue80_ReturnsCredit20PorCentoSalario()
        {
            // {"Nome": "Charles West","Idade": 83,"Salario": 9126.0}

            // Arrange
            var customer = new Customer("Charles West", 83, 9126.0M);     // customer object from API

            // Act
            var creditRequest = new CreditRequest("Cristina Pereira", 2500.0M);  // creditRequest object instantiated
            var credit = creditRequest.GetCredit(customer);

            // Assert
            Assert.AreEqual(customer.Salario * 20 / 100, credit.CreditValueProvided);
        }
        #endregion

        #region 2º FORMA UNIT TEST COM A LISTA DE CUSTOMERS RETORNADA DA API EXTERNA - POR VARIAVEL DE SALARIO, IDADE FIXA
        [Test]
        public void GetCredit_IdadeMaiorQue20_ReturnsCredit100PorCentoSalario_v2()
        {
            // Arrange
            var customers = GetExternalCustomers();
            var customersTest = customers.FindAll(c => c.Idade > 20 && c.Idade <= 30);

            // Act
            foreach (var customerTest in customersTest)
            {
                var creditRequest = new CreditRequest(customerTest.Nome, 2500.0M);
                var credit = creditRequest.GetCredit(customerTest);

            // Assert
                Assert.AreEqual(customerTest.Salario * 100 / 100, credit.CreditValueProvided);
            }
        }
        #endregion
        
        #region 2º FORMA UNIT TEST COM A LISTA DE CUSTOMERS RETORNADA DA API EXTERNA - POR VARIAVEL DE IDADE, SALARIO FIXO( <= 2000) = PARCELA ATÉ 5% DO SALARIO
        [Test]
        public void GetCredit_SalarioAte2000_ReturnParcela5PorCentoDoSalario()
        {
            // Arrange
            var customers = GetExternalCustomers();
            var customersTest = customers.FindAll(c => c.Salario <= 2000);

            // Act
            foreach (var customerTest in customersTest)
            {
                var creditRequest = new CreditRequest(customerTest.Nome, 2500.0M);
                var credit = creditRequest.GetCredit(customerTest);

            // Assert
                Assert.LessOrEqual(credit.ValueOfEachParcel, customerTest.Salario * 5 / 100);
            }
        }
        #endregion
        
        #region GET - CONSULTA API EXTERNA PARA POPULAR A LISTA DE CUSTOMERS PARA A SEGUNDA FORMA DE UNIT TEST
        // [HttpGet("api/credito")]
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