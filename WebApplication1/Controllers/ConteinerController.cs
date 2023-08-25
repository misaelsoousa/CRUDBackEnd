using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Text.Json;
using WebApplication1.Contexts;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteinerController : ControllerBase
    {
        private readonly ConteinerContext _context;

        public ConteinerController(ConteinerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ConteinerDto> BuscarConteiner([FromQuery] Conteiner conteiner)
        {   
            var lista = _context.conteiner.Join(_context.cliente,
                            conteiner => conteiner.Cliente,
                            cliente => cliente.ClienteId,
                            (conteiner, cliente) => new ConteinerDto { 
                                Id = conteiner.Id,
                                Cliente = cliente.ClienteId,
                                NomeCliente = cliente.Nome,
                                Numero = conteiner.Numero,
                                Tipo = conteiner.Tipo,
                                Status = conteiner.Status,
                                Categoria = conteiner.Categoria,
                            }).ToList();

           if (conteiner.Cliente != null)
                lista = lista.Where(c => c.Cliente == conteiner.Cliente).ToList();

            if (!conteiner.Numero.IsNullOrEmpty())
                lista = lista.Where(c => c.Numero.ToUpper() == conteiner.Numero.ToUpper()).ToList();

            if (!conteiner.Tipo.IsNullOrEmpty())
                lista = lista.Where(c => c.Tipo == conteiner.Tipo).ToList();

            if (!conteiner.Status.IsNullOrEmpty())
                lista = lista.Where(c => c.Status.ToUpper() == conteiner.Status.ToUpper()).ToList();

            if (!conteiner.Categoria.IsNullOrEmpty())
                lista = lista.Where(c => c.Categoria.ToUpper() == conteiner.Categoria.ToUpper()).ToList();

            return lista;
        }

        [HttpPost]
        public string InserirConteiner(Conteiner conteiner)
        {
            if (conteiner.Tipo != "20" && conteiner.Tipo != "40")
                throw new Exception("Tipo inválido!");

            // conteiner.ClienteObj = new Cliente() { ClienteId = conteiner.Cliente };

            _context.conteiner.Add(conteiner);
            _context.SaveChanges();

            return "Conteiner inserido com sucesso";
        }
        [HttpDelete]

        public void DeletarConteiner(int Id)
        {
            Conteiner conteiner = _context.conteiner.Find(Id);

                if (conteiner != null)
            {
                _context.Remove(conteiner);
                _context.SaveChanges();
            }
            else
            {

            }

        }

        [HttpPut]
        public void EditarConteiner(Conteiner conteiner)
        {

            if (conteiner.Cliente == null)
            {

            }
            else
            {
                _context.Update(conteiner);
                _context.SaveChanges();
            }
        }

    }
}
