using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaiVoa.Models;
using System.Linq;
using System;

namespace VaiVoa.Controllers
{
  // Rota de criação de um novo cartão
  [Route("v1/vaivoa/cartoes")]
  [ApiController]
  public class GeraCartaoVirtualController : ControllerBase
  {
    // Função responsável por gerar números randômicos de cartão
    private static Random random = new Random();

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<string>> PostCartao(
      [FromServices] GeraCartaoVirtualContext context,
      [FromBody] GeraCartaoVirtual cartao)
      {
        const string characters = "0123456789";
        // Gera uma string de caracteres randômicos com 16 caracteres para formatar o número dos cartões de maneira correta
        string novoNumero = new string(Enumerable.Repeat(characters, 16)
        .Select(s => s[random.Next(s.Length)]).ToArray());

        cartao.Email = cartao.Email;
        // Formata o cartao no formato correto
        cartao.NumeroCartao = string.Format("{0: #### #### #### ####}", long.Parse(novoNumero));
        
        // Adiciona um cartao
        context.GeraCartaoVirtual.Add(cartao);
        // Salva de forma assíncrona todas as alterações feitas no database context
        await context.SaveChangesAsync();

        return cartao.NumeroCartao;
      }
  }
}