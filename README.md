# 🍽️ API Receitas

API REST desenvolvida em **.NET** com o objetivo de **treinar a construção de APIs**, boas práticas de organização, versionamento e documentação, além de **auxiliar usuários (especialmente minha esposa ❤️)** a cadastrarem e visualizarem **receitas e seus modos de preparo**.

---

## 📌 Objetivo do Projeto

Este projeto foi criado com fins **educacionais e práticos**, visando:

* Aprimorar habilidades em desenvolvimento de **APIs REST com .NET**
* Aplicar conceitos como:

  * Controllers
  * DTOs
  * Versionamento de API
  * Documentação com Swagger
* Criar uma solução simples e funcional para:

  * Cadastro de receitas
  * Cadastro de tipos de receitas
  * Cadastro e consulta de modos de preparo

---

## 🛠️ Tecnologias Utilizadas

* **.NET 8.0 (Web API)**
* **Swagger / OpenAPI 2.0**
* **C#**
* **Entity Framework (se aplicável)**
* **JSON**

---

## 📖 Documentação da API

A documentação da API é gerada automaticamente via **Swagger**.

Após executar o projeto, acesse:

```
/swagger
```

Ou diretamente pelo arquivo:

```
/openapi/Receitas.json
```

---

## 📂 Estrutura de Funcionalidades

### 🔹 Modo de Preparo

Responsável por gerenciar os modos de preparo das receitas.

| Método | Endpoint                          | Descrição                        |
| ------ | --------------------------------- | -------------------------------- |
| GET    | `/ModoPreparo/ObterModoPreparo`   | Retorna um modo de preparo       |
| POST   | `/ModoPreparo/InserirModoPreparo` | Cadastra um novo modo de preparo |

---

### 🔹 Receitas

Gerenciamento completo das receitas.

| Método | Endpoint                   | Descrição                       |
| ------ | -------------------------- | ------------------------------- |
| POST   | `/Receitas/ListarReceitas` | Lista receitas conforme filtros |
| GET    | `/Receitas/ObterReceita`   | Retorna uma receita específica  |
| POST   | `/Receitas/InserirReceita` | Cadastra uma nova receita       |

---

### 🔹 Tipos de Receitas

Classificação das receitas (ex: doce, salgada, sobremesa, etc).

| Método | Endpoint                         | Descrição                        |
| ------ | -------------------------------- | -------------------------------- |
| GET    | `/Receitas/ListarTiposReceitas`  | Lista os tipos de receitas       |
| POST   | `/Receitas/InserirTiposReceitas` | Cadastra um novo tipo de receita |

---

## 🚀 Como Executar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/{SEU-USUARIO}/API.Core.Receitas.git
```

2. Acesse a pasta do projeto:

```bash
cd API.Core.Receitas
```

3. Execute a aplicação:

```bash
dotnet run
```

4. Acesse o Swagger:

```
http://localhost:{porta}/swagger
```

---

## 📌 Próximas Evoluções (Ideias)

* Autenticação e autorização (JWT)
* Relacionar receitas com usuários
* Upload de imagens das receitas
* Paginação e filtros avançados
* Testes unitários
* Versionamento mais avançado da API

---

## 🤝 Contribuições

Este projeto é aberto para estudos e melhorias.
Sinta-se à vontade para **abrir issues**, **pull requests** ou dar sugestões.

---

## ❤️ Agradecimentos

Projeto criado com carinho para **treino profissional** e para ajudar no dia a dia de quem gosta de cozinhar.

Se esse projeto te ajudou de alguma forma, ⭐ deixe uma estrela no repositório!

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
