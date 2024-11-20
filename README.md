# Projeto Modelo

## Criar o projeto
```bash
    dotnet new console -n ProjetoMvc
```

## Navegue até o diretório do projeto
```bash
    cd ProjetoModelo
```

## Execute o projeto para garantir que tudo está funcionando
```bash
    dotnet run
```


## Instalar pacotes

**Instalar o Pacote Oracle**
```bash
    dotnet add package Oracle.ManagedDataAccess.Core
    dotnet add package Oracle.EntityFrameworkCore
```

```bash
    dotnet add package Microsoft.EntityFrameworkCore
```

```bash
    dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```bash
    dotnet add package Microsoft.EntityFrameworkCore.Design
```

**Suporte do Swagger**
```bash
    dotnet add package Swashbuckle.AspNetCore
```

```bash
    dotnet add package Swashbuckle.AspNetCore.Annotations
```

```bash
    dotnet add package Microsoft.AspNetCore.Mvc
```

**Para realizar autenticação e salvar dados no cookies**

```bash
    dotnet add package Microsoft.AspNetCore.Authentication.Cookies
```

**Restaurar os pacotes**
```bash
    dotnet restore
``` 

Já fizemos este processo anteriormente, mas se der erro, podemos instalar esta versão expecífica.

```bash
    dotnet add package Oracle.ManagedDataAccess.Core --version 23.6.0
```

## Modelo das dependências
```bash
    <Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.Data.SqlClient" Version="5.2.2" />
        <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.10" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.10">
        <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        <PrivateAssets>all</PrivateAssets>
        </PackageReference>
        <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.10">
        <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        <PrivateAssets>all</PrivateAssets>
        </PackageReference>
        <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
        <PackageReference Include="Oracle.EntityFrameworkCore" Version="8.23.60" />
        <PackageReference Include="Oracle.ManagedDataAccess" Version="23.6.1" />
        <PackageReference Include="Oracle.ManagedDataAccess.Core" Version="23.6.1" />
    </ItemGroup>

    </Project>
```


## Criar os json com acessos

**Criar no documento appsettings.Development**

```bash
    {
    
    "ConnectionStrings": {
        "OracleDbConnection": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM123456;Password=123456;"
    },
    
    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
            }
        }
    }
``` 


## Pasta Infrastructure/Data/Context

**Criar arquivo com contexto**
```bash
    ApplicationContext.cs
```

**Inserir os dados para cada base**
******
```bash
    using Microsoft.EntityFrameworkCore;
    using ProjetoMvc.Models; // Ajuste o namespace conforme necessário

    namespace ProjetoModelo.Infrastructure.Data.Context
    {
        public class ApplicationContext : DbContext
        {
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
            {
            }

            // Definir o schema padrão para todas as tabelas
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configurar os nomes das tabelas sem prefixo ou alteração
                //modelBuilder.Entity<Usuario>().ToTable("t_usuario");

            }
            
        }
    }

```

## Estrutura do projeto

/ProjetoModelo
│
├── /Controllers          # Contém as Controllers
│
├── /Application          # Contém as camadas de serviço (lógica de negócio)
│   └── /DTOs             # Objetos de Transferência de Dados (DTOs)
│
├── /Infrastructure       # A camada de infraestrutura (DB, Repositories)
│   ├── /Data             # Contexto de Banco de Dados e migrações
│   └── /Repositories     # Repositories (Interação com o Banco)
│
├── /Models                 # Entidades do Banco de Dados
├── /Views                  # Views (Razor Pages)
├── /wwwroot                # Arquivos estáticos (CSS, JS, etc.)         
├── /tests                  # Testes unitários, de integração, etc.
│
├── appsettings.json        # Configurações gerais, como string de banco
└── Program.cs              # Arquivo principal de configuração do projeto



## Ajustar a porta que o projeto será executado

**Ajuste para a melhor opção do projeto, onde não ocorra conflitos ou concorrência**

```bash
    {
    "$schema": "http://json.schemastore.org/launchsettings.json",
    "iisSettings": {
        "windowsAuthentication": false,
        "anonymousAuthentication": true,
        "iisExpress": {
        "applicationUrl": "http://localhost:6991",
        "sslPort": 44338
        }
    },
    "profiles": {
        "http": {
        "commandName": "Project",
        "dotnetRunMessages": true,
        "launchBrowser": true,
        "launchUrl": "swagger",
        "applicationUrl": "http://localhost:5121",  // Alterado para 5121
        "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
        }
        },
        "https": {
        "commandName": "Project",
        "dotnetRunMessages": true,
        "launchBrowser": true,
        "launchUrl": "swagger",
        "applicationUrl": "https://localhost:7034;http://localhost:5121",  // Alterado para 5121
        "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
        }
        },
        "IIS Express": {
        "commandName": "IISExpress",
        "launchBrowser": true,
        "launchUrl": "swagger",
        "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
        }
        }
    }
    }
```

## Model

**Passo a Passo para criar um MVC completo e robusto**

Primeiro de tudo, vamos criar uma Model estrutura com MVC, onde teremos Model, Dto, Repository, Controller e View.

## 1. Criar a Model/Entities

**Estrutura simples para espelhar o banco, não faremos validações nesta classe**

No diretório `Domain/Entities`, crie uma classe para representar a entidade `Usuario`:

```dash
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace ProjetoModelo.Domain.Entities
    {
        [Table("t_usuario")]
        public class Usuario
        {
            [Key]
            public int Id { get; set; }
            public string Nome { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Senha { get; set; } = null!;
        }
    }
```

## 2. Criar o DTO

**Responsabilidade**

O DTO (Data Transfer Object) é responsável por transferir dados entre camadas (como Controller e Domain) de forma segura e eficiente. Ele isola a lógica do domínio da interface com o cliente, garantindo que apenas os campos necessários sejam expostos. Além disso, é o lugar ideal para aplicar validações relacionadas à entrada de dados.

```bash
    using System.ComponentModel.DataAnnotations;

    namespace ProjetoModelo.Application.DTOs
    {
        public class UsuarioDTO
        {
            [Required(ErrorMessage = "O nome é obrigatório.")]
            [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
            public string Nome { get; set; } = null!;

            [Required(ErrorMessage = "O email é obrigatório.")]
            [EmailAddress(ErrorMessage = "O email deve estar em um formato válido.")]
            public string Email { get; set; } = null!;

            [Required(ErrorMessage = "A senha é obrigatória.")]
            [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
            public string Senha { get; set; } = null!;
        }
    }
```

## Criar o Interface de repository  e repository

**Somente com os métodos de cadastro ou ações com o banco, não precisamos ter ações que tratem de views aqui**

```bash
    using ProjetoModelo.Domain.Entities;

    namespace ProjetoModelo.Infrastructure.Repositories
    {
        public interface IUsuarioRepository
        {
            void AdicionarUsuario(Usuario usuario);
            IEnumerable<Usuario> ConsultarTodos();
        }
    }

```

**Implementação do Repositório**

Crie uma classe que implemente essa interface. Para este exemplo, os dados serão armazenados em memória:

```bash
    using ProjetoModelo.Domain.Entities;

    namespace ProjetoModelo.Infrastructure.Repositories
    {
        public class UsuarioRepository : IUsuarioRepository
        {
            private static List<Usuario> _usuarios = new();

            public void AdicionarUsuario(Usuario usuario)
            {
                usuario.Id = _usuarios.Count + 1;
                _usuarios.Add(usuario);
            }

            public IEnumerable<Usuario> ConsultarTodos()
            {
                return _usuarios;
            }
        }
    }

```

## Criar Controller
**Iremos trabalhar com o controller para view e ter a etapa do CRUD de adicionar um usuário por exemplo**

```bash
    using Microsoft.AspNetCore.Mvc;
    using ProjetoModelo.Application.DTOs;
    using ProjetoModelo.Domain.Entities;
    using ProjetoModelo.Infrastructure.Repositories;

    namespace ProjetoModelo.Controllers
    {
        public class UsuarioController : Controller
        {
            private readonly IUsuarioRepository _repository;

            public UsuarioController(IUsuarioRepository repository)
            {
                _repository = repository;
            }

            // Método para exibir a View com o formulário
            [HttpGet]
            public IActionResult Criar()
            {
                return View();
            }

            // Método para processar o envio do formulário
            [HttpPost]
            public IActionResult AdicionarUsuario(UsuarioDTO dto)
            {
                if (!ModelState.IsValid)
                {
                    return View("Cadastro", dto); 
                }

                var usuario = new Usuario
                {
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Senha = dto.Senha
                };

                _repository.AdicionarUsuario(usuario);
                return RedirectToAction("CadastroConfirmado");
            }

            // Método para exibir uma página de confirmação
            public IActionResult CadastroConfirmado()
            {
                return View();
            }
        }
    }

```

## Views

**Criar a pasta dentro do repositório src > Presentation > View > Ususario > Arquivo Criar.cshtml, Consultar.cshtml e MensagemConfirmacao.cshtml

**Arquivo Criar.cshtml**

```bash
    @model ProjetoModelo.Application.DTOs.UsuarioDTO

    @{
        ViewData["Title"] = "Cadastro de Usuário";
    }

    <h1>@ViewData["Title"]</h1>

    <form asp-action="AdicionarUsuario" method="post">
        <div>
            <label for="Nome">Nome:</label>
            <input type="text" id="Nome" name="Nome" value="@Model?.Nome" />
            <span asp-validation-for="Nome" class="text-danger"></span>
        </div>
        <div>
            <label for="Email">Email:</label>
            <input type="email" id="Email" name="Email" value="@Model?.Email" />
            <span asp-validation-for="Email" class="text-danger"></span>
        </div>
        <div>
            <label for="Senha">Senha:</label>
            <input type="password" id="Senha" name="Senha" />
            <span asp-validation-for="Senha" class="text-danger"></span>
        </div>
        <button type="submit">Cadastrar</button>
    </form>
```

**Mensagem de confirmação**
```bash
    @{
        ViewData["Title"] = "Cadastro Confirmado";
    }

    <h1>@ViewData["Title"]</h1>

    <p>Usuário cadastrado com sucesso!</p>
```

## Pasta Share
**Criar a pasta dentro do repositório src > Presentation > View > Share**

Está estrutura terá o arquivo de layout e validations. Será essêncial para visualizarmos os dados na tela e o layout tem o header.

```bash
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>@ViewData["Title"]</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    </head>
    <body>
        <header class="bg-dark text-white p-3">
            <h1>Meu Projeto</h1>
        </header>
        <div class="container mt-4">
            @RenderBody()
        </div>
        <footer class="bg-light text-center p-3">
            <p>&copy; 2024 Meu Projeto</p>
        </footer>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    </body>
    </html>
```

***Vincular as Views ao Layout***

```bash
    @{
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
``` 

***Configurar as Views Individuais para receber a estrutura do banco de dados***

```bash
    @model ProjetoModelo.Application.DTOs.UsuarioDTO

    @{
        ViewData["Title"] = "Cadastrar Usuário";
    }
```

## Adicionar Scripts de validação

**No arquivo _ValidationScriptsPartial**

```bash
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.3/dist/jquery.validate.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation-unobtrusive@4.0.0/dist/jquery.validate.unobtrusive.min.js"></script>
```

**Inclua esse arquivo no layout ou diretamente nas Views que precisarem de validação**

```bash
    @await Html.PartialAsync("_ValidationScriptsPartial")
```

## Migrations

1. Instalar a ferramenta dotnet-ef

```bash
    dotnet tool install --global dotnet-ef
```

2. Verificar se a instalação foi bem-sucedida
```bash
    dotnet ef
```

3. Verificar se vai dar erro ou instalar novamente:
```bash
    dotnet add package Microsoft.EntityFrameworkCore.Design
```

4. Quando criar uma Model, criar e atualizar a Migration
```bash
    dotnet ef migrations add Inicio
```
**Sempre mudar o nome Inicio para o nome da sua model ou tabela**

5. Aplique as migrações:
```bash
    dotnet ef database update
```

6. Listar as migrations criadas
```bash
    dotnet ef migrations list
```

7. Remover uma migration
```bash
    dotnet ef migrations remove
```

## Realizar o teste com o postman

**Ajuste no arquivo Program.cs**

Este modelo é para web api. Nós casos em que precisamos usar as Views no projeto, precisamos ajustar este documento. 
**Teremos uma etapa mais para frente, mostrando este ajuste.**

```bash
    
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using ProjetoModelo.src.Infrastructure.Data.Context;

    var builder = WebApplication.CreateBuilder(args);

    // Adicionar a rota do documento com as configurações do Oracle. Configuração do appsettings.Development.json
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

    //Configurando a string e conexo oracle no banco de dados
    builder.Services.AddDbContext<ApplicationContext>(options => {

        // O Oracle vem do arquivo appsettings.Development, da string de conexão.
        options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));

    });


    //Adicionando a interface e classe concreta no framework de injeco de dependencia

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    //Configurando e habilitando a documentao no swagger 
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Claudio Silva Bispo",
            Version = "RM 553472",
            Description = "API desenvolvida para CP2 de DOTNET, na faculdade FIAP."
        });
        c.EnableAnnotations(); // Habilitar anotacões no Swagger
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

```

## Realizar o teste

**Criar um Controller Teste**
```bash
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ProjetoModelo.src.Infrastructure.Data.Context;

    namespace ProjetoModelo.Presentation.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class TestController : ControllerBase
        {
            private readonly ApplicationContext _context;
            private readonly ILogger<TestController> _logger;

            public TestController(ApplicationContext context, ILogger<TestController> logger)
            {
                _context = context;
                _logger = logger;
            }

            [HttpGet("test-connection")]
            public IActionResult TestConnection()
            {
                try
                {
                    var canConnect = _context.Database.CanConnect();
                    if (canConnect)
                    {
                        return Ok("Conexão com o banco de dados Oracle bem-sucedida!");
                    }
                    else
                    {
                        return StatusCode(500, "Não foi possível conectar ao banco de dados Oracle.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao conectar ao banco de dados Oracle");
                    return StatusCode(500, $"Erro ao conectar ao banco de dados Oracle: {ex.Message}");
                }
            }
        }
    }
```

**No terminal**
```bash
    dotnet run
```
**No Postaman**
```bash
    http://localhost:5000/api/test/test-connection
```

## Documentação com Swagger

**Vamos adicionar o Swagger ao projeto**

```bash
    dotnet add package Swashbuckle.AspNetCore
    dotnet add package Swashbuckle.AspNetCore.Annotations
```

**Configure o Swagger no Program.cs**
```bash
    services.AddSwaggerGen();
``` 

**Estruturar as documentações**

Nos arquivos, podemos inserir as annotations que vai mostrar os endpoints, detalhes de cada ação para que qualquer usuário entenda o que estamos utilizando e o que tem disponível.

```bash
        //Consultar todo os fornecedores
        [HttpGet]

        [SwaggerOperation(Summary = "Lista todos os fornecedores", Description = "Este endpoint retorna uma lista completa de todos os fornecedores cadastrados.")]

        [Produces<IEnumerable<FornecedorEntity>>]

        public IActionResult Get()
        {
            var objModel = _applicationService.ConsultarTodos();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados do fornecedor");
        }
```

Veja que usamos a annotation [SwaggerOperation] em cada método para explicar e deixar mais simples o uso. Podemos escrever o que quisermos aqui.

Inserir no inicio de cada arquivo controller que tiver as annotations do swagger
```bash
    using Swashbuckle.AspNetCore.Annotations;
```

## Views

# Documentação: Uso de Views e Métodos no ASP.NET Core

## Como usar uma View

1. **Crie uma View**  
   - No diretório `Views/Pasta conforme a Model/`, adicione um arquivo `Index.cshtml` com o conteúdo HTML desejado.
   Exemplo:
   Criei uma Model para cadastrar usuário (nome Usuario ou UsuarioModel dentro da pasta src > Domain > Entities).

   Estrutura da view: src > View > Usuario > Criar.cshmtl ou src > View > Usuario > Consultar.cshmtl

   **Cada nome pode representar uma ação do controller, para criar um usuário, visualizar os dados no banco, atualizar, excluir e assim por diante**

2. **Configure o método na Controller**  
   - No arquivo `UsuarioController.cs`, adicione o método que renderiza a View, ou seja, que você possar criar ou consultar o usuário:
     
     ```bash
     using Microsoft.AspNetCore.Mvc;

     namespace ProjetoModelo.Controllers
     {
         public class UsuarioController : Controller
         {
            [HttpGet]
            public IActionResult Criar()
            {
                return View(); // Renderiza a View Criar.cshtml, aqui eu quero visualizar a página para criar um usuário. Pode perceber que o método precisa corresponder ao que precisamos, teremos o get para visualizar uma página, um post para cadastrar um usuário. Geralmente vamos usar o GET para visualizar as páginas e o POST para executar uma ação de formulário por exemplo.
            }
         }
     }
     ```

3. **Acesse a View**  
   - Execute a aplicação e acesse `/Ususario/Criar` no navegador.

---

## Como criar um método para adicionar um usuário

1. **Crie uma classe para representar o usuário**  
   - No diretório `Models`, adicione um arquivo `Usuario.cs`:
     ```bash
     namespace ProjetoModelo.Models
     {
         public class Usuario
         {
             public string Nome { get; set; }
             public string Email { get; set; }
         }
     }
     ```

2. **Adicione o método na Controller**  
   - No arquivo `UsuarioController.cs`, adicione o método para salvar/criar o usuário:
     ```bash
     using Microsoft.AspNetCore.Mvc;
     using ProjetoModelo.Models;

     namespace ProjetoModelo.Controllers
     {
         public class UsuarioController : Controller
         {
             private static List<Usuario> usuarios = new List<Usuario>();

             [HttpPost]
             public IActionResult Criar(Usuario usuario)
             {
                 usuarios.Add(usuario);
                 return RedirectToAction("Criar"); // Redireciona para a página principal para criar um usuário. Pode escolher para onde direcionar quando cadastrar algum usuário. Pode ser para uma página de mensagem de sucesso, home, enfim, qualquer uma.
             }
         }
     }
     ```

3. **Crie um formulário na View para adicionar usuários**  
   - No arquivo `Views/Usuario/Criar.cshtml`, insira o seguinte código:
     ```bash
     <form asp-action="Criar" method="post">
         <input type="text" name="Nome" placeholder="Nome" required />
         <input type="email" name="Email" placeholder="Email" required />
         <button type="submit">Adicionar</button>
     </form>
     ```

4. **Teste o método**  
   - Preencha o formulário e submeta. O usuário será adicionado à lista em memória.

---

> **Nota:** Certifique-se de que o serviço esteja rodando e de que a rota esteja configurada corretamente no arquivo `Program.cs`.
