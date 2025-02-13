using CsvImportApi.Context;
using CsvImportApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CsvImportApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoasController(AppDbContext context)
        {
            _context = context;
        }

        //Endpoint: imporar CSV
        [HttpPost("importar")]
        public async Task<IActionResult> ImportarCsv(IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                return BadRequest("Arquivo CSV inválido");
            }

            using var leitor = new StreamReader(arquivo.OpenReadStream());
            await leitor.ReadLineAsync(); // Ignora a primeira linha

            while (!leitor.EndOfStream)
            {
                var linha = await leitor.ReadLineAsync();
                if (linha == null)
                {
                    continue;
                }

                var valores = linha.Split(';');

                var pessoa = new Pessoa
                {
                    Nome = valores[1],
                    Idade = int.Parse(valores[2]),
                    Cidade = valores[3],
                    Profissao = valores[4]
                };

                _context.Pessoas.Add(pessoa);
            }

            await _context.SaveChangesAsync();
            return Ok("O arquivo foi importado com sucesso");
        }

        //Endpoint: buscar registro por ID e retornar JSON
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarRegistro(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound("Registro não encontrado.");
            }

            return Ok(pessoa);
        }
    }
}
