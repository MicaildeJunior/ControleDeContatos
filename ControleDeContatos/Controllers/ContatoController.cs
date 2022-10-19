using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        // injeção de dependência
        // private readonly (somente leitura)
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        // metodos gets são apenas para busca, ao carregar a tela!

        public IActionResult Index()    
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
           
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            return View(contato);

        }

        public IActionResult ApagarConfirmacao(int id) // busca pelo id 
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            return View(contato);
        }

        public IActionResult Apagar(int id) // apaga pelo id que buscou
        {
            _contatoRepositorio.Apagar(id);

            return RedirectToAction("Index");
        }


        // metodos POST são de inclusão, um metodo de receber uma informação e cadastrar essa informação.

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);

            // O return irá Redirecionar para uma Acão
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);

            // O return irá Redirecionar para uma Acão
            return RedirectToAction("Index");
        }
    }
}
