# NerdStore
Projeto desenvolvido com finalidade de estudos sobre DDD (Domain-Drovem Design) e Event Sourcing. <br/>
NerdStore é a implementação de uma loja virtual utilizando os conceitos de DDD e Event Sourcing no curso o intrutor utiliza .NET Core 3.1.  essa minha versão fiz em NET5. <br/>
A estrutura do projeto está dividida em contextos, são eles: catalogo, vendas, pagamentos e core. <br/>

Catalogo: Esse contexto é o responsável por gerenciar todo os estoque dos produtos com regras de validação e garantir que não aconteça nenhum inconsistência no banco de dados. <br/>
Vendas: Esse contexto é o responsável por gerenciar os pedidos dos clientes. <br/>
Pagamentos: Esse contexto é o responsável por realizar a integração com uma api de pagamentos e finalizar ou recusar o pedido do cliente. <br/>
Core: Esse contexto é o responsável por realizar a comunicação entre todos os contextos da aplicação através de eventos de integração. <br/>
Projeto desenvolvido durante o curso de domínio ricos ministrado por Eduardo Pires. <br/>

Link do curso: https://desenvolvedor.io/curso/modelagem-de-dominios-ricos
