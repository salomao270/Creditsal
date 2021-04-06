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

        [Test]
        public void GetCredit_AgeGreaterThan20_ReturnsCredit100PercentOfSalary()
        {
            // Arrange
            var customer = new Customer("Andrea Marques", 25, 8236.0M);

            // Act
            var creditRequest = new CreditRequest("Andrea Marques", 2500.0M);
            var credit = creditRequest.GetCredit(customer);

            // Assert
            Assert.AreEqual(8236.0, credit.CreditValueProvided);
            Assert.LessOrEqual(credit.ValueOfEachParcel, customer.Salario * 40 / 100);
        }

        [Test]
        public void GetCredit_AgeGreaterThan30_ReturnsCredit80PercentOfSalary()
        {
            var customer = new Customer("Cristina Reeves", 35, 1933.0M);

            var creditRequest = new CreditRequest("Cristina Reeves", 2500.0M);
            var credit = creditRequest.GetCredit(customer);

            Assert.AreEqual(1739.7, credit.CreditValueProvided);
            Assert.LessOrEqual(credit.ValueOfEachParcel, customer.Salario * 5 / 100);
        }

        [Test]
        public void GetCredit_AgeGreaterThan50_ReturnsCredit70PercentOfSalary()
        {
            var customer = new Customer("Cristina Pereira", 54, 4845.0M);

            var creditRequest = new CreditRequest("Cristina Pereira", 2500.0M);
            var credit = creditRequest.GetCredit(customer);

            Assert.AreEqual(3391.5, credit.CreditValueProvided);
            Assert.LessOrEqual(credit.ValueOfEachParcel, customer.Salario * 20 / 100);
        }

        [Test]
        public void GetCredit_AgeGreaterThan80_ReturnsCredit20PercentOfSalary()        
        {
            var customer = new Customer("Charles West", 83, 9126.0M);

            var creditRequest = new CreditRequest("Cristina Pereira", 2500.0M);
            var credit = creditRequest.GetCredit(customer);

            Assert.AreEqual(1825.2, credit.CreditValueProvided);
        }

    }
}