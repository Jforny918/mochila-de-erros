🎒 Mochila de Erros

Plataforma para registrar, organizar e revisar erros cometidos durante o aprendizado de programação, transformando falhas em evolução contínua.

🚀 Sobre o Projeto

O Mochila de Erros é uma aplicação backend desenvolvida em .NET, com foco em:

Organização de aprendizados

Revisão periódica de erros

Gestão de mochilas por usuário

Controle de plano (Free / Pro)

A proposta é simples:

📌 Erros não são fracassos — são ativos de aprendizado.

🏗️ Arquitetura

O projeto segue princípios de:

Domain-Driven Design (DDD)

Clean Architecture

Separação clara entre camadas

Encapsulamento de regras de negócio no domínio

Estrutura de Pastas
src/
 ├── MochilaDeErros.Domain
 ├── MochilaDeErros.Application
 ├── MochilaDeErros.Infrastructure
 └── MochilaDeErros.API

📦 Camadas

Domain

Entidades ricas

Regras de negócio

Value Objects

Exceptions

Application

Use Cases

DTOs

Interfaces

Orquestração da regra

Infrastructure

Entity Framework Core

Repositórios

Persistência

API

Controllers

Configuração

Endpoints REST

🧠 Conceitos Aplicados

Encapsulamento de invariantes

Coleções protegidas (IReadOnlyCollection)

Repositórios separados (Read / Write)

Contagem eficiente via banco (evitando overfetching)

Enum para planos e frequência de revisão

DTOs para exposição segura de dados

🛠️ Tecnologias Utilizadas

.NET 8

C#

Entity Framework Core

SQL Server

Swagger

Clean Architecture

DDD

📌 Funcionalidades

✅ Criar usuário

✅ Criar mochila

✅ Adicionar tags

✅ Controle de plano (Free / Pro)

✅ Limite de mochilas por plano

✅ Cálculo percentual de uso do plano

📊 Exemplo de Resposta da API
{
  "limite": 5,
  "utilizadas": 2,
  "restantes": 3,
  "percentual": 40,
  "atingiuLimite": false
}

🎯 Regras de Negócio

Usuário Free pode criar até 5 mochilas

Usuário Pro pode criar até 100 mochilas

Mochilas possuem frequência de revisão

Tags não podem ser duplicadas

▶️ Como Executar
git clone https://github.com/seuusuario/mochila-de-erros.git
cd mochila-de-erros
dotnet restore
dotnet run


Acesse:

https://localhost:5001/swagger

🧩 Melhorias Futuras

🔐 Autenticação JWT

📆 Sistema de lembrete de revisão

📊 Dashboard de evolução

📱 Integração com frontend Angular

🧪 Testes unitários e de integração

👨‍💻 Autores

Júlia Forny de Souza Muniz
Victor Hugo Borba
