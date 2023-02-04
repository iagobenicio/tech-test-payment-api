# O Projeto 

Este projeto trata-se de um desafio final do bootcamp Pottencial .NET, na DIO. O projeto foi entregue no Gitlab: https://gitlab.com/iagobensen/tech-test-payment-api
O projeto trata-se de uma API que simula uma venda. O mesmo não precisava ser persistindo em um banco de dados, porém tinha como foco de avaliação: testes unitários, 
código limpo, SOLID, etc... 

O projeto foi fetio em .NET, onde trabalhei com SOLUTION pois fiz 2 projetos, um para testes e outro para a API. 

Iniciando o projeto da API, resolvi primeiramente separa as camdas, onde coloquei uma camda de repositories para os dados. A camda de controller ficou responsável
por controlar o fluxo, requisitando os dados para o repositorie e os retornando. 

#  Implementações

- Camda de repositoires para a inserção de dados, consultar dado, e atualizar, utilizando uma lista para fazer as operações. 
- Endpoints em um controller com os metódos: POTS, GET e PATCH, para, respectivamente, Registrar uma venda, consultar venda através do seu ID, e atualizar o status de uma venda, passando um novo status e seu id. No Controller foi feita uma injeção de dependência do repository. 
- Validações nos Modelos através do "ComponentModel.DataAnnotations"
- Casos de testes unitários, utilizando o XUnit, tanto para a camada controller, bem como para o repositories, utilizando Moq, implementado testes de "caminho feliz" e "caminho triste",
ou seja, teste para caso que de certo, e teste simulando um erro. 
- Classes para trabalhar com Exceptions costumizados.  

# Apredizados. 

Neste projeto pude aprender como posso ta fazendo validações através do DataAnnotions, onde pode retornar mensagens de erro. 
Pude aprender também como implementar casos de testes unitários utilizando o Xunit. Nos testes unitários em alguns casos eu também utilizo Moqs.  

# O Teste

- Construir uma API REST utilizando .Net Core, Java ou NodeJs (com Typescript);
- A API deve expor uma rota com documentação swagger (http://.../api-docs).
- A API deve possuir 3 operações:
  1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2) Buscar venda: Busca pelo Id da venda;
  3) Atualizar venda: Permite que seja atualizado o status da venda.
     * OBS.: Possíveis status: `Pagamento aprovado` | `Enviado para transportadora` | `Entregue` | `Cancelada`.
- Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
- O vendedor deve possuir id, cpf, nome, e-mail e telefone;
- A inclusão de uma venda deve possuir pelo menos 1 item;
- A atualização de status deve permitir somente as seguintes transições: 
  - De: `Aguardando pagamento` Para: `Pagamento Aprovado`
  - De: `Aguardando pagamento` Para: `Cancelada`
  - De: `Pagamento Aprovado` Para: `Enviado para Transportadora`
  - De: `Pagamento Aprovado` Para: `Cancelada`
  - De: `Enviado para Transportador`. Para: `Entregue`
- A API não precisa ter mecanismos de autenticação/autorização;
- A aplicação não precisa implementar os mecanismos de persistência em um banco de dados, eles podem ser persistidos "em memória".


