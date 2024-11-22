# **Documentação do Sistema - EvotechEnergy**

## **Índice**
1. [Introdução](#introdução)
2. [Funcionalidades](#funcionalidades)
   - [Gerenciamento de Usuários](#gerenciamento-de-usuários)
   - [Gerenciamento de Dispositivos](#gerenciamento-de-dispositivos)
3. [Estrutura do Projeto](#estrutura-do-projeto)
4. [Processos Principais](#processos-principais)
   - [Cadastrar Usuários](#cadastrar-usuários)
   - [Editar Usuários](#editar-usuários)
   - [Cadastrar Dispositivos](#cadastrar-dispositivos)
   - [Editar Dispositivos](#editar-dispositivos)
   - [Excluir Dados](#excluir-dados)
5. [Como Rodar o Projeto](#como-rodar-o-projeto)
6. [Fluxo do Sistema](#fluxo-do-sistema)
7. [Considerações Finais](#considerações-finais)

---

## **Introdução**

O **EvotechEnergy** é um sistema desenvolvido em **ASP.NET Core MVC**, focado no gerenciamento de dispositivos elétricos e usuários cadastrados no sistema. Seu objetivo é oferecer uma interface intuitiva e estilizada, promovendo o uso consciente da energia.

Repositório do projeto: [Evotech-MVC-GS](https://github.com/WillDant/Evotech-MVC-GS)

---

## **Funcionalidades**

### **Gerenciamento de Usuários**
- **Cadastro**: Permite adicionar novos usuários com informações básicas (nome, email e senha).
- **Edição**: Atualiza os dados de um usuário existente.
- **Exclusão**: Remove um usuário do banco de dados.
- **Listagem**: Exibe uma lista de todos os usuários cadastrados.

### **Gerenciamento de Dispositivos**
- **Cadastro**: Permite adicionar dispositivos com informações como nome e potência.
- **Edição**: Atualiza os dados de dispositivos cadastrados.
- **Exclusão**: Remove dispositivos do banco de dados.
- **Listagem**: Exibe uma lista de todos os dispositivos cadastrados.

---

## **Estrutura do Projeto**

### **1. Models**
Define as entidades principais do sistema:
- `Usuario`: Representa um usuário do sistema.
- `Dispositivo`: Representa um dispositivo elétrico.

### **2. Controllers**
Gerencia as requisições HTTP e controla o fluxo de dados:
- `UsuarioController`: Controla as operações relacionadas a usuários.
- `DispositivoController`: Controla as operações relacionadas a dispositivos.

### **3. Services**
Implementa a lógica de negócios:
- `UsuarioService`: Contém as regras de negócio para usuários.
- `DispositivoService`: Contém as regras de negócio para dispositivos.

### **4. Repositories**
Comunica-se diretamente com o banco de dados:
- `UsuarioRepository`: Opera os dados da entidade `Usuario`.
- `DispositivoRepository`: Opera os dados da entidade `Dispositivo`.

---

## **Processos Principais**

### **Cadastrar Usuários**
1. Acesse a página `/Usuario/Criar`.
2. Preencha o formulário com os seguintes campos:
   - Nome
   - Email
   - Senha
3. Clique em **Cadastrar**. O sistema validará os dados e redirecionará para a lista de usuários.

### **Editar Usuários**
1. Na página `/Usuario/Index`, clique em **Editar** ao lado do usuário desejado.
2. Atualize os campos no formulário exibido.
3. Clique em **Salvar Alterações** para aplicar as mudanças.

### **Cadastrar Dispositivos**
1. Acesse a página `/Dispositivo/Criar`.
2. Preencha o formulário com os seguintes campos:
   - Nome do Dispositivo
   - Potência (em watts)
3. Clique em **Cadastrar** para salvar o dispositivo no banco de dados.

### **Editar Dispositivos**
1. Na página `/Dispositivo/Index`, clique em **Editar** ao lado do dispositivo desejado.
2. Atualize as informações no formulário exibido.
3. Clique em **Salvar Alterações** para aplicar as mudanças.

### **Excluir Dados**
- Tanto na lista de usuários quanto na de dispositivos, clique em **Excluir** para remover o item selecionado.
- A exclusão é confirmada imediatamente.

---

## **Como Rodar o Projeto**

Siga os passos abaixo para configurar e rodar o projeto localmente:

### **1. Pré-requisitos**
- **SDK do .NET 6.0 ou superior**: [Baixar aqui](https://dotnet.microsoft.com/download).
- **Banco de Dados SQL Server**: Configure o banco de dados localmente ou use uma instância em nuvem.
- **Visual Studio** (ou outro editor como Visual Studio Code).
### **2. Clone o Repositório**
```bash
git clone https://github.com/WillDant/Evotech-MVC-GS.git
cd Evotech-MVC-GS
```

### **3. Entity Framework Core**
Usado para acessar e manipular o banco de dados.

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
````

### **4. Configure o Banco de Dados**
- Abra o arquivo appsettings.json e configure a conexão com o banco de dados:
```json
  "ConnectionStrings": {
    "Oracle": "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM552671;Password=051204;"
  }
  ```
  - Execute as migrações para criar o banco de dados no console gerenciador de pacotes:
  ```bash
  Update-Database
  ```

  ### **5. Execute o Projeto**
- No terminal, dentro da pasta do projeto:
```bash
dotnet run
```
- Ou use o Visual Studio:
- Abra o projeto.
- Configure o projeto principal como Startup.
- Pressione F5 para rodar o sistema.


