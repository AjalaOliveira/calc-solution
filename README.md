# calc-solution

API1 desenvolvida em ASP.NET Core 3.1 com uma funcionalidade:
- Endpoint /taxaJuros: Retornar a taxa de juros fixa no código.

API2 desenvolvida em ASP.NET Core 3.1 integrada com a API1 com três funcionalidades:
- Endpoint /showmethecode: Retornar a URL do repositório da aplicação no GitHub.

- Endpoint /calculajuros: Retornar o resultado de juros compostos aplicados ao valor inicial, em decimal, e a quantidade de meses informado, considerando a taxa retornada da API1.

- Endpoint /calculajurosstring: Retornar o resultado de juros compostos aplicados ao valor inicial, em string, e a quantidade de meses informado, considerando a taxa retornada da API1.

Comandos executar a imagem:
   - git clone https://github.com/AjalaOliveira/calc-solution
   - cd calc-solution
   - docker-compose build
   - docker-compose run
   
API1: http://localhost:4020/
API2: http://localhost:5020/

# Ajala Oliveira
- https://www.linkedin.com/in/ajala-oliveira-85917442/
