using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Text.Json;
using System.Xml.Linq;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ConteinerContext _context;

        public ClienteController(ConteinerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Cliente> BuscarCliente([FromQuery] Cliente cliente)
        {

            var lista = _context.cliente.ToList();

            if (!cliente.Nome.IsNullOrEmpty())
                lista = lista.Where(c => c.Nome == cliente.Nome).ToList();

            if (!cliente.CNPJ.IsNullOrEmpty())
                lista = lista.Where(c => c.CNPJ == cliente.CNPJ).ToList();

            if (!cliente.CEP.IsNullOrEmpty())
                lista = lista.Where(c => c.CEP == cliente.CEP).ToList();

            if (!cliente.Contato.IsNullOrEmpty())
                lista = lista.Where(c => c.Contato == cliente.Contato).ToList();

            return lista;
        }

        [HttpPost]
        public string InserirCliente(Cliente cliente)
        { 

            _context.Add(cliente);
            _context.SaveChanges();

            return "Cliente inserido com sucesso";
        }
        [HttpDelete]

        public void DeletarCliente(int idCliente)
        {
            Cliente cliente = _context.cliente.Find(idCliente);

            if (cliente != null)
            {
                _context.Remove(cliente);
                _context.SaveChanges();
            }
            else
            {
                
            }
        }

        [HttpPut]
        public void EditarCliente(Cliente cliente)
        {


            _context.Update(cliente);
            _context.SaveChanges();
        }
    }
}
