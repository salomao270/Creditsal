
Business rules of Credit project Web API

1. It is a system that receive a customer name and a desired credit value.

2. This system will consult an external API that returns a list of registered customers (name, age and salary).

3. Then it will search in that list the customer who was passed in API by parameter and calculate how much of credit value this customer may receive, how much of each parcel and how many parcels the credit will be paid.

4. Depending on customer age, the customer may receive only a percentage of his salary as credit value
	•	Age higher than 80, may receive until 20% of his salary
	•	Age higher than 50, may receive until 70% of his salary
	•	Age higher than 30, may receive until 90% of his salary
	•	Age higher than 20, may receive until 100% of his salary

5. Depending on customer salary, the parcel may be compromise only a percentage of his salary
	•	From 1000 to 2000 R$, the parcel may compromise 5% of his salary
	•	From 2001 to 3000 R$, the parcel may compromise 10% of his salary
	•	From 3001 to 4000 R$, the parcel may compromise 15% of his salary
	•	From 4001 to 5000 R$, the parcel may compromise 20% of his salary
	•	From 5001 to 6000 R$, the parcel may compromise 25% of his salary
	•	From 6001 to 7000 R$, the parcel may compromise 30% of his salary
	•	From 7001 to 8000 R$, the parcel may compromise 35% of his salary
	•	From 8001 to 9000 R$, the parcel may compromise 40% of his salary
	•	From 9001 R$, a parcela poderá comprometer 45% of his salary

6. It does not permit that API receive a negative credit value.

7. It does not permit that APi receive a zero credit value.

8. This Web API will have an input endpoint that respect the contact below:

Path: api/credito/{nome}/{valorPedido}
Response: 
{
    "nome": "string",
    "salario": 1.0, -- decimal
    "valorPedido": 1.0, -- decimal
    "valorEmprestado": 2.0, -- decimal
    "quantidadeParcelas": 4,  -- int
    "valorParcela": 5.0 -- decimal
}

Translation to english
    nome = name
    salario = salary
    valor Pedido = _credit request by customer
    valor Emprestado = credit value provided
    quantidade Parcelas = quantity of parcels
    valor parcel = value of each parcel

9. This Web API will have to consult an external API in the URL "http://www.mocky.io/v2/5e2b3b8d32000054001c7109" that has an object as response like bellow:

[
                {
                                "Nome": "string",
                                "Idade": 0, -- int
                                "Salario": 1.0 -- decimal
                }
]