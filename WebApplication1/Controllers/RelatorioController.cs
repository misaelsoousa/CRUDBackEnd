using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Xml.Linq;
using WebApplication1.Contexts;
using WebApplication1.Models;
using System;
using System.Linq;
using System.Data.Entity;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly ConteinerContext _context;

        public RelatorioController(ConteinerContext context)
        {
            _context = context;
        }


            
        [HttpGet]
        public List<Relatorio> BuscarRelatorio([FromQuery]Relatorio relatorio)
        {

            var lista = _context.movimento
                                .Join(_context.conteiner,
                                                movimento => movimento.Conteiner,
                                                conteiner => conteiner.Id,
                                                (movimento, conteiner) => new { movimento, conteiner }
                                            )
                                .Join(_context.cliente,
                                               x => x.conteiner.Cliente,
                                               cliente => cliente.ClienteId,
                                               (x, cliente) => new { cliente.Nome, x.movimento }
                                            )
                                .GroupBy(r => r.Nome,
                                    (key, itens) => new Relatorio
                                    {
                                        NomeCliente = key,
                                        Embarque = itens.Where(i => i.movimento.Tipo == "embarque").Count(),
                                        Descarga = itens.Where(i => i.movimento.Tipo == "descarga").Count(),
                                        Gatein = itens.Where(i => i.movimento.Tipo == "gatein").Count(),
                                        Gateout = itens.Where(i => i.movimento.Tipo == "gateout").Count(),
                                        Reposicionamento = itens.Where(i => i.movimento.Tipo == "reposicionamento").Count(),
                                        Pesagem = itens.Where(i => i.movimento.Tipo == "pesagem").Count(),
                                        Scanner = itens.Where(i => i.movimento.Tipo == "scanner").Count(),                                        
                                    })
                                .ToList();


            
            

            //if (movimento.Conteiner != null)
            //    lista = lista.Where(c => c.Conteiner == movimento.Conteiner).ToList();

            return lista;
        }
        [HttpGet]
        [Route("sumario")]
        public List<SumarioDto> BuscarSumario([FromQuery] Relatorio relatorio)
        {
            int importCount = _context.conteiner.Count(c => c.Categoria == "importação");
            int exportCount = _context.conteiner.Count(c => c.Categoria == "exportação");

            var lista = new List<SumarioDto>
            {
                new SumarioDto {
                importacao = importCount,
                exportacao = exportCount
                }
            };

            return lista;
        }





    }
}
