![CI](https://github.com/MarceloMFerreira/wake-api/actions/workflows/dotnet.yml/badge.svg)
# 🚀 WakeCommerce API - Desafio Técnico

API desenvolvida para processo seletivo, focada na gestão de catálogo de produtos. O projeto demonstra boas práticas de desenvolvimento, arquitetura em camadas e testes automatizados.

## 🛠️ Tecnologias Utilizadas
* **ASP.NET Core 8.0** (Web API)
* **Entity Framework Core** (ORM)
* **SQLite** (Banco de dados local)
* **xUnit & Moq** (Testes Unitários)
* **GitHub Actions** (CI/CD)

## 📌 Principais Funcionalidades
* **CRUD Completo** de Produtos.
* **Regra de Negócio:** Validação de preço (não permite valores negativos) na camada de Serviço.
* **Filtros Avançados:** Busca por nome (parcial) e ordenação dinâmica por nome, valor ou estoque.
* **Seed de Dados:** A base é populada automaticamente com 5 produtos ao iniciar a aplicação via EF Core.

## 🏗️ Arquitetura
O projeto segue uma estrutura desacoplada para facilitar a manutenção e testes:
1.  **Controllers:** Exposição dos endpoints REST e manipulação de requisições.
2.  **Services:** Camada de lógica de negócio e validações (onde residem as regras de domínio).
3.  **Repositories:** Comunicação com o banco de dados via EF Core utilizando a abordagem **Code-First**.

## 🔄 Integração Contínua (CI)

Pipeline configurado com **GitHub Actions** para validação automática do projeto:

✔ Restore  
✔ Build  
✔ Testes unitários  

O workflow é disparado automaticamente a cada push ou pull request.

## 📌 Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/produtos | Listar produtos |
| GET | /api/produtos/{id} | Buscar produto por ID |
| POST | /api/produtos | Criar produto |
| PUT | /api/produtos/{id} | Atualizar produto |
| DELETE | /api/produtos/{id} | Deletar produto |
### 🔍 Parâmetros de Consulta (GET /api/produtos)
Você pode refinar a listagem utilizando os seguintes parâmetros:
* `nome`: Filtra produtos que contenham o termo (Ex: `nome=Teclado`)
* `ordem`: Ordena os resultados (Valores aceitos: `nome`, `valor`, `estoque`)



## 🚀 Como Executar o Projeto

1.  **Clonar o repositório:**
    ```bash
    git clone https://github.com/MarceloMFerreira/wake-api.git
    ```
2.  **Restaurar dependências:**
    ```bash
    dotnet restore
    ```
3.  **Rodar Migrations (Opcional - o banco SQLite já é criado no início):**
    ```bash
    dotnet ef database update
    ```
4.  **Executar a API:**
    ```bash
    dotnet run --project WakeCommerce.Api
    ```
    *Acesse o Swagger para testar os endpoints em: `http://localhost:5079/swagger`*

## 🧪 Testes Unitários
Para garantir a qualidade das regras de negócio, utilize o comando:
```bash
dotnet test
