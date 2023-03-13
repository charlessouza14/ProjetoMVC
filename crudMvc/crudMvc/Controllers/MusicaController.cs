using crudMvc.Models;
using crudMvc.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace crudMvc.Controllers
{
    public class MusicaController : Controller
    {
        public IActionResult Index()
        {
            CantorRepository musicaRepository = new CantorRepository();
            var buscar = musicaRepository.BuscarTudo();
            ViewBag.Cantores = buscar;
            return View("Index");
        }
        // irá precisar criar outros indexs
        public IActionResult PostForm()
        {
            return View("Post");
        }

        public IActionResult GetFormUpdate([FromQuery]int id)
        {
            CantorRepository cantorRepository = new CantorRepository();
            var cantorDB = cantorRepository.Buscar(id);
            ViewBag.Cantor = cantorDB;
            return View("EditarCantor");
        }
        public IActionResult GetForName(string nome)
        {
            CantorRepository cantorRepository = new CantorRepository();
            var buscarNome = cantorRepository.BuscarPorNome(nome);
            ViewBag.Nome = buscarNome;
            return View("ExibirCantor");
        }
        public IActionResult GetAll()
        {
            CantorRepository musicaRepository = new CantorRepository();
            var buscar = musicaRepository.BuscarTudo();
            ViewBag.Cantores = buscar; 
            return View("Index","Musica");
        }

        public IActionResult Post(Cantor cantor)
        {
            if (cantor == null)
            {
                return View("Por favor digite um nome válido");
            }
            CantorRepository musicaRespository = new CantorRepository();
            musicaRespository.Adicionar(cantor);
            return RedirectToAction("Index","Musica");
        }

        public IActionResult Get(Cantor cantor)
        {
            CantorRepository musicaRepository = new CantorRepository();
            musicaRepository.BuscarPorNome(cantor.NomeCantor);
            return View("Get");
        }
        
        public IActionResult Put(Cantor cantor)
        {
            CantorRepository cantorRepository = new CantorRepository();
            cantorRepository.Atualizar(cantor);
            return RedirectToAction("Index","Musica");
        }
      
        public IActionResult Delete(int id)
        {
            CantorRepository musicaRepository = new CantorRepository();
            musicaRepository.Deletar(id);
            return RedirectToAction("Index","Musica");
        }
    }
}
