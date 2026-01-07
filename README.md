# Sistema de Almoxarifado

Sistema web pra gerenciar solicitações de material do almoxarifado. Foi feito usando Blazor Server e Entity Framework Core.

## O que faz

Basicamente permite cadastrar e gerenciar solicitações de materiais (tipo papel, caneta, monitor, essas coisas). Da pra aprovar ou negar as solicitações e filtrar por setor ou status.

## Tecnologias

- .NET 8
- Blazor Server
- Entity Framework Core
- SQL Server

## Como rodar

Primeiro precisa ter o .NET 8 SDK instalado e um SQL Server rodando (pode ser LocalDB também).

1. Clone o repositório
```bash
git clone https://github.com/van-dik/almoxarife-web.git
cd almoxarife-web
```

2. Ajusta a connection string no `appsettings.json` se necessário

3. Roda o projeto
```bash
dotnet run
```

O banco de dados é criado automaticamente na primeira execução.

Acessa pelo navegador em `https://localhost:5001` (ou a porta que aparecer no terminal).

## Funcionalidades

- Cadastro de solicitações com nome do solicitante, setor, item e quantidade
- Lista todas as solicitações
- Filtra por status (Pendente, Aprovado, Negado) ou por setor
- Aprovar/negar solicitações direto da listagem
- Editar dados de uma solicitação
- Excluir solicitações

## Estrutura do projeto

```
SistemaAlmoxarifado/
├── Components/
│   ├── Layout/          # Layout e menu
│   └── Pages/           # Páginas Blazor
├── Data/                # DbContext
├── Models/              # Modelos (Solicitacao, StatusSolicitacao)
├── Services/            # Lógica de negócio
└── Migrations/          # Migrations do EF Core
```

## Observações

Projeto foi feito pra ser simples e direto, sem frescura no visual. O foco era ter uma estrutura organizada e funcional.

Se tiver algum problema com SQL Server, da pra mudar pra SQLite facilmente, só trocar o provider no `Program.cs` e a connection string.

