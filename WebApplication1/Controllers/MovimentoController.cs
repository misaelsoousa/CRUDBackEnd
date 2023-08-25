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
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly ConteinerContext _context;

        public MovimentoController(ConteinerContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<MovimentoDto> BuscarMovimento([FromQuery]Movimento movimento)
        {

            var lista = _context.movimento.Join(_context.conteiner,
                           movimento => movimento.Conteiner,
                           conteiner => conteiner.Id,
                           (movimento, conteiner) => new MovimentoDto
                           {
                               Id = movimento.Id,
                               Conteiner = movimento.Conteiner,
                               Numero = conteiner.Numero,
                               Tipo = movimento.Tipo,
                               DataIni = movimento.DataIni,
                               DataFim = movimento.DataFim
                           }).ToList();



            //if (movimento.Conteiner != null)
            //    lista = lista.Where(c => c.Conteiner == movimento.Conteiner).ToList();

            

            if (!movimento.Tipo.IsNullOrEmpty())
                lista = lista.Where(c => c.Tipo == movimento.Tipo).ToList();

            if (!movimento.DataIni.IsNullOrEmpty())
                lista = lista.Where(c => c.DataIni == movimento.DataIni).ToList();

            if (!movimento.DataFim.IsNullOrEmpty())
                lista = lista.Where(c => c.DataFim == movimento.DataFim).ToList();

            return lista;
        }

        [HttpPost]
        public string InserirMovimento(Movimento movimento)
        {
            _context.Add(movimento);
            _context.SaveChanges();

            return "Movimentação cadastrada com sucesso";
        }
        [HttpDelete]

        public void DeletarMovimento(int idMovimento)
        {
            Movimento movimento = _context.movimento.Find(idMovimento);

            _context.Remove(movimento);
            _context.SaveChanges();
        }

        [HttpPut]
        public void EditarMovimento(Movimento movimento)
        {


            _context.Update(movimento);
            _context.SaveChanges();
        }



    }
}
