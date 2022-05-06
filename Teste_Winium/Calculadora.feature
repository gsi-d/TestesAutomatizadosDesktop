Feature: Calculadora
	In order to avoid silly misatkes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Calculadora
	Given Que a calculadora esteja aberta
	When Informar um número <numero1>
	And Escolher o operador <operador>
	And Informar o segundo número <numero2>
	And Concluir o cálculo
	Then O resultado deve ser <resultado>
Examples:
| numero1 | numero2 | operador | resultado |
| 2       | 1       | *        | 2         |
| 2       | 2       | *        | 4         |
| 2       | 3       | *        | 6         |
| 2       | 4       | *        | 8         |
| 2       | 5       | *        | 10        |
| 2       | 6       | *        | 12        |
| 2       | 7       | *        | 14        |
| 2       | 8       | *        | 16        |
| 2       | 9       | *        | 18        |
| 2       | 10      | *        | 20        |