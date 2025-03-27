# 🎮 VideoGames Management API

## 📋 Descrição do Projeto
Uma API robusta de gerenciamento de videogames desenvolvida com ASP.NET Core, projetada com foco em segurança, escalabilidade e boas práticas de desenvolvimento.

## 🚀 Tecnologias Principais
![.NET Core](https://img.shields.io/badge/.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=json-web-tokens&logoColor=white)

## ✨ Recursos Principais
- 🔒 Autenticação JWT
- 🛡️ Autorização baseada em roles
- 📊 Operações CRUD completas
- 🌐 Arquitetura REST

## 📦 Entidades
- VideoGame
- Developer
- Publisher
- Genre
- User
- Review

## 🔐 Segurança
- Autenticação JWT
- Autorização diferenciada para administradores e usuários
- Proteção de rotas sensíveis

## 🛠️ Tecnologias e Ferramentas
- Backend: ASP.NET Core
- ORM: Entity Framework Core
- Autenticação: JWT (JSON Web Tokens)
- Arquitetura: REST API

## 🚦 Endpoints Principais
- `GET /api/videogames`: Listar jogos
- `POST /api/videogames`: Criar novo jogo
- `PUT /api/videogames/{id}`: Atualizar jogo
- `DELETE /api/videogames/{id}`: Remover jogo

## 📦 Pré-requisitos
- .NET 6.0 ou superior
- SQL Server
- Visual Studio ou VS Code

## 🔧 Instalação
```bash
# Clonar o repositório
git clone https://github.seu-usuario/videogames-api.git

# Restaurar pacotes
dotnet restore

# Configurar banco de dados
dotnet ef database update

# Executar a aplicação
dotnet run
```

## 📄 Licença
Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
