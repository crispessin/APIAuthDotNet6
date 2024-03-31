# Projeto de API ASP.NET Core 6

Este é um projeto de API construído em ASP.NET Core 6, utilizando PostgreSQL 13 como banco de dados, Entity Framework Core para acesso aos dados, paginação para melhorar o desempenho da API, autenticação com tokens JWT para segurança, Unit of Work para gerenciar transações e validações de domínio para garantir a integridade dos dados.

# Requisitos
* .NET SDK 6.x
* PostgreSQL 13.x
  
# Configuração do Banco de Dados
1 - Instale o PostgreSQL 13 em sua máquina.

2 - Crie um banco de dados no PostgreSQL para a aplicação.

3 - Configure a string de conexão no arquivo appsettings.json:

```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=DotNet6API;User Id=postgres;Password=root"
}
```

# Gerar Tokem de Autenticação JWT
1  - Passe as credenciais no endPoint **USER**
```
Email: teste@teste.com.br
Password : 123456
```

# Configuração da Paginação
A paginação está configurada na API para limitar o número de itens retornados em cada consulta.

# Executando a Aplicação
1 - Clone este repositório:
```
git clone https://github.com/seu-usuario/seu-projeto.git
```

2 - Navegue até o diretório do projeto:
```
cd seu-projeto
```

3 - Execute a aplicação:
```
dotnet run
```

# Testando a Aplicação
Acesse http://localhost:5000/swagger para testar os endpoints da API usando o Swagger UI.

# Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir um pull request com melhorias, correções de bugs, novos recursos, etc.
