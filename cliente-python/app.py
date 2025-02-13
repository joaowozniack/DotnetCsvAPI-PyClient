import requests

# Função: buscar registro na API
def buscar_pessoa(id):
    url = f"http://localhost:5250/Pessoas/{id}"
    try:
        response = requests.get(url)
        response.raise_for_status()
        return response.json()
    except requests.exceptions.RequestException as err:
        print(f"Erro ao buscar pessoa: {err}")
        print(f"URL: {url}")
        return None
    
# Função: categorizar idade
def categorizar_idade(idade):
    if idade < 30:
        return "Jovem"
    elif 30 <= idade <= 40:
        return "Adulto"
    else:
        return "Sênior"
    
# Função: exibir dados
def exibir_pessoa(id):
    registro = buscar_pessoa(id)
    if registro:
        print("=====================================")
        print("Pessoa encontrada! Segue informações:")
        print(f"Nome: {registro['nome']}")
        print(f"Idade: {registro['idade']} anos - Categoria: {categorizar_idade(registro['idade'])}")
        print(f"Cidade: {registro['cidade']}")
        print(f"Profissão: {registro['profissao']}")
        print("=====================================")
    else:
        print("Pessoa não encontrada.")

# Execução
if __name__ == "__main__":
    try:
        id = int(input("Informe o ID da pessoa: "))
        exibir_pessoa(id)
    except ValueError:
        print("ID inválido, insira um valor válido.")