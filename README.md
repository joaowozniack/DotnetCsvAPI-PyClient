# Projeto: API ASP.NET Core + Cliente Python

## :dart: Objetivo do projeto
O objetivo deste projeto foi desenvolver uma API Web em ASP.NET Core para importar e consultar informações através de registros armazenados em banco de dados SQL Server. Além disso, o projeto possui um cliente em Python que consome essa API para obter um registro específico e exibe seus dados.

## :hammer: Tecnologias utilizadas
- **Backend:** C# com ASP.NET Core Web API.
- **Banco de dados:** SQL Server (Entity Framework Core).
- **Cliente:** Python (requests).
<div style="display: inline-block"><br>
  <img align="center" alt="Joao-Csharp" height="30" width="40" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" />
  <img align="center" alt="Joao-SQLserver" height="30" width="40" src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/microsoftsqlserver/microsoftsqlserver-original.svg" />
  <img align="center" alt="Joao-Python" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/python/python-original.svg" />
</div>


## :1234: Passos para executar a API em C# 
1. Clonar o repositório:
   ```
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```
2. Configurar o banco de dados no SQL Server.
   - Crie um banco de dados.
   - Altere a string de conexão em `appsettings.json`:
   ```
   "ConnectionStrings": {
      "DefaultConnection": "Server={NomeServidor};Database={NomeBancoDeDados};Trusted_Connection=True;"
    }
   ```
3. Executar as migrações para criar o banco de dados:
   ```
   dotnet ef database update
   ```
4. Iniciar a API:
   ```
   dotnet run
   ```
 5. Url disponível em: `http://localhost:5250/Pessoas`.

## :1234: Passos para executar o cliente em Python
1. Instalar o Python (caso não tenha instalado).
2. Instalar a biblioteca `resquests`:
   ```
   pip install requests
   ```
3. Executar o script Python:
   ```
   python app.py
   ```
4. Inserir um ID para buscar registro na API.

## :phone: Exemplos de chamadas e respostas da API
:one: Importar um CSV para o Banco de Dados
- Requisição: `POST /Pessoas/importar`.
- Corpo (arquivo CSV):
  ```
  Id,Nome,Idade,Cidade,Profissao
  1,Ana Silva,29,São Paulo,Engenheira
  2,Bruno Souza,35,Rio de Janeiro,Professor
  3,Carla Mendes,42,Belo Horizonte,Médica
  4,Daniel Santos,27,Curitiba,Desenvolvedor
  5,Elisa Ramos,31,Fortaleza,Advogada
  6,Felipe Costa,40,Porto Alegre,Administrador
  7,Gustavo Lima,33,Recife,Designer
  8,Helena Martins,28,Salvador,Psicóloga
  9,Ivan Rocha,37,Florianópolis,Engenheiro
  10,Juliana Alves,26,Brasília,Jornalista
  ```
- Resposta:
  ```
  "O arquivo foi importado com sucesso"
  ```
:two: Buscar uma Pessoa pelo ID
- Requisição: `GET /Pessoas/2`.
- Resposta:
  ```
  {
    "id": 2,
    "nome": "Bruno Souza",
    "idade": 35,
    "cidade": "Rio de Janeiro",
    "profissao": "Professor"
  }
  ```
:three: Saída do Cliente em Python
```
Informe o ID da pessoa: 3
=====================================
Pessoa encontrada! Segue informações:
Nome: Carla Mendes
Idade: 42 anos - Categoria: Sênior
Cidade: Belo Horizonte
Profissão: Médica
=====================================
```
