# Amostras Mvp24Hours - NET8 (v8.2.101)
Amostras para construção rápida de produtos utilizando: Banco de dados relacional (SQL Server, PostgreSql, MySql); Banco de dados NoSql (MongoDb); Banco de dados de valores-chave (Redis); Corretor de Mensagens (RabbitMQ); Pipeline (padrão Pipe e Filtros); Documentação (Swagger); Mapeamento (AutoMapper); Registro (NLog); Padrões de validação de dados (FluentValidation e Data Annotations), notificação (Notification pattern) e especificações (Specification pattern), unidade de trabalho, repositório, entre outros.
Em cada projeto existe um arquivo com a descrição dos recursos e referências implementadas. Leia o arquivo "Readme.md" na pasta "...WebAPI".

## Estude, compartilhe e contribua:
Visite: https://mvp24hours.dev/

## Projetos - NLayers

### Minimal API
Projeto utilizado para desenvolver APIs enxutas.

#### Banco de dados relacional (MySql, PostgreSql, SqlServer)
**[CRUD - EF - Minimal API](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/minimal-crud-ef-customer-api/CustomerAPI)**
API enxuta que permite pesquisar com paginação, obter um item, criar, alterar e excluir em um banco de dados relacional (MySql, PostgreSql, SqlServer).

#### Banco de dados NoSql - MongoDb
**[CRUD - MongoDb - Minimal API](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/minimal-crud-mongodb-customer-api/CustomerAPI)**
API enxuta que permite pesquisar com paginação, obter um item, criar, alterar e excluir em um banco de dados MongoDb.

#### Pipeline
**[Pipeline - Minimal API](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/minimal-pipeline-customer-api/CustomerAPI)**
API enxuta para pipeline com operações simples.

### Simples
Projeto de N camadas utilizado para desenvolver APIs onde o negócio precisa aplicar regras simples.

#### Banco de dados relacional (MySql, PostgreSql, SqlServer)
**[CRUD - EF - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-crud-ef-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir. As operações são realizadas transitando uma entidade de banco de dados. Caso pretenda desenvolver um produto que será consumido publicamente (fora de uma rede privada), utilize CRUD - EF - Complex.

**[CRUD - EF - Dapper - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-crud-ef-dapper-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação e obter um item (com navegação) usando Dapper. As operações de criação, alteração e exclusão são realizadas com EF e trafegam uma entidade de banco de dados. Se você pretende desenvolver um produto que será consumido publicamente (fora de uma rede privada), utilize CRUD - EF - Dapper - Complex.

**[CRUD - EF - Log de entidade - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-crud-ef-entitylog-customer-api/CustomerAPI.WebAPI )**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir. As operações são realizadas transitando uma entidade de banco de dados. A arquitetura coordena os campos de log criados/por, modificados/por e removidos/por. Vale ressaltar que todas as consultas conterão o filtro removido, levando em consideração a referência do SoftDelete. Caso pretenda desenvolver um produto que será consumido publicamente (fora de uma rede privada), utilize CRUD - EF - Entity Log - Complex.

#### Banco de dados NoSql - MongoDb
**[CRUD - MongoDb - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-crud-mongodb-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir. As operações são realizadas transitando uma entidade de banco de dados. Vale ressaltar que devemos criar estratégias de registro de dados já que não existe relacionamento. Caso pretenda desenvolver um produto que será consumido publicamente (fora de uma rede privada), utilize CRUD - MongoDb - Complex.

#### Banco de dados NoSql - Redis
**[CRUD - Redis - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-crud-redis-customer-api/CustomerAPI.WebAPI)**
Permite que você obtenha um item, crie e exclua. As operações são executadas referenciando uma chave para esse banco de dados de valores-chave. Freqüentemente usamos essa solução para gerenciamento de cache, pois Redis é um banco de dados na memória com desempenho incrível.

#### Corretor de mensagens - RabbitMQ
**[CRUD - EF - RabbitMQ - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-rabbitmq-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir. As operações são realizadas de forma assíncrona a partir de uma fila gerenciada pelo RabbitMQ. Utilizamos HostedService para consumir mensagens RabbitMQ do projeto web, ou seja, as mensagens serão processadas enquanto a API estiver em execução.

#### Pipeline
**[Pipeline - Simples](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/simple-pipeline-customer-api/CustomerAPI.WebAPI)**
Padrão de pipeline com operações simples.

### Complexo
Projeto N-tier utilizado para desenvolvimento de APIs onde o negócio precisa aplicar regras complexas, maior nível de segurança, menor tráfego de dados, validação de dados sensíveis e separação de responsabilidades ou consumo por outras tecnologias e projetos.

#### Banco de dados relacional (MySql, PostgreSql, SqlServer)
**[CRUD - EF - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-crud-ef-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir.

**[CRUD - EF - Dapper - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-crud-ef-dapper-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação e obter um item (com navegação) usando Dapper. As operações de criação, alteração e exclusão são realizadas com EF.

**[CRUD - EF - Somente Entidade - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-crud-ef-only-entity-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir. Não criamos objeto para tráfego e mapeamento. Usamos a própria entidade do banco de dados.

**[CRUD - EF - Log de entidade - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-crud-ef-entitylog-customer-api/CustomerAPI.WebAPI )**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir.

#### Banco de dados NoSql - MongoDb
**[CRUD - MongoDb - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-crud-mongodb-customer-api/CustomerAPI.WebAPI)**
Permite pesquisar com paginação, obter um item, criar, alterar e excluir.

#### Pipeline
**[Pipeline - Construtor - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-pipeline-builder-customer-api/CustomerAPI.WebAPI)**
Padrão de pipeline com operações registradas por meio de construtores. Excelente estratégia para casos de uso.

**[Pipeline - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-pipeline-customer-api/CustomerAPI.WebAPI)**
Padrão de pipeline com operações simples em camadas.

**[Pipeline - Portas e adaptadores - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-pipeline-ports-adapters-customer-api/CustomerAPI.WebAPI)**
Padrão de pipeline com operações registradas por meio de construtores. Associamos essa estratégia ao modelo de arquitetura de portas e adaptadores fracamente acoplados.

**[Pipeline - EF (MySql, PostgreSql, SqlServer) - Complexo](https://github.com/kallebelins/mvp24hours-dotnet-samples/tree/main/src/complex-pipeline-ef-customer-api/CustomerAPI.WebAPI)**
Geralmente o usamos para integração de serviços. O conceito de pipeline é excelente para rastrear todas as etapas (operações/filtros) realizadas em uma integração (adaptador/mediador/registro/filtro). Nesta solução obtemos os dados em uma integração e cadastramos em um banco de dados com EF.

## Doações
Por favor, considere fazer uma doação se você acha que esta biblioteca é útil para você ou que meu trabalho é valioso. Fico feliz se você puder me ajudar [comprar uma xícara de café](https://www.paypal.com/donate/?hosted_button_id=EKA2L256GJVQC). :coração:

## Comunidade
Usuários, interessados, estudantes, entusiastas, desenvolvedores, programadores [conectem-se no LinkedIn](https://www.linkedin.com/in/kallebelins/) para acompanhar de perto nosso crescimento!

## Patrocinadores
Seja um patrocinador escolhendo este projeto para acelerar seus produtos.