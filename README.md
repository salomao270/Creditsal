
Business rules of Credit project Web API

<p>1. It is a system that receive a customer name and a desired credit value.

<p>2. This system will consult an external API that returns a list of registered customers (name, age and salary).

<p>3. Then it will search in that list the customer who was passed in API by parameter and calculate how much of credit value this customer may receive, how much of each parcel and how many parcels the credit will be paid.

<p>4. Depending on customer age, the customer may receive only a percentage of his salary as credit value
	<p>&nbsp;&nbsp;&nbsp;•	Age higher than 80, may receive until 20% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	Age higher than 50, may receive until 70% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	Age higher than 30, may receive until 90% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	Age higher than 20, may receive until 100% of his salary

<p>5. Depending on customer salary, the parcel may be compromise only a percentage of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 1000 to 2000 R$, the parcel may compromise 5% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 2001 to 3000 R$, the parcel may compromise 10% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 3001 to 4000 R$, the parcel may compromise 15% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 4001 to 5000 R$, the parcel may compromise 20% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 5001 to 6000 R$, the parcel may compromise 25% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 6001 to 7000 R$, the parcel may compromise 30% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 7001 to 8000 R$, the parcel may compromise 35% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 8001 to 9000 R$, the parcel may compromise 40% of his salary
	<p>&nbsp;&nbsp;&nbsp;•	From 9001 R$, a parcela poderá comprometer 45% of his salary
<br/><br/>
6. It does not permit that API receive a negative credit value.
<br/><br/>
7. It does not permit that APi receive a zero credit value.
<br/><br/>
8. This Web API will have an input endpoint that respect the contact below:
<br/><br/>
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

Translation to english:
    <br/>nome = name
    <br/>salario = salary
    <br/>valor Pedido = credit value request by customer
    <br/>valor Emprestado = credit value provided
    <br/>quantidade Parcelas = quantity of parcels
    <br/>valor parcela = value of each parcel
<br/><br/>
9. This Web API has to consult an external API in the URL "http://www.mocky.io/v2/5e2b3b8d32000054001c7109" that has an JSON object as response like bellow:
<br/>[
<br/>&nbsp;                {
<br/>&nbsp;&nbsp;                                "Nome": "string",
<br/>&nbsp;&nbsp;                                "Idade": 0, -- int
<br/>&nbsp;&nbsp;                                "Salario": 1.0 -- decimal
<br/>&nbsp;                }
<br/>]
