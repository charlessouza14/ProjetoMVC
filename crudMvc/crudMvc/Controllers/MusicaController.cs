using crudMvc.Models;
using crudMvc.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crudMvc.Controllers
{
    public class MusicaController : Controller
    {
        public IActionResult Index()
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            var buscar = musicaRepository.BuscarTudo();
            ViewBag.Cantores = buscar;
            return View("Index");
        }
        // irá precisar criar outros indexs
        public IActionResult PostForm()
        {
            return View("Post");
        }

        public IActionResult GetAll()
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            var buscar = musicaRepository.BuscarTudo();
            ViewBag.Cantores = buscar; 
            return View("Index");
        }

        public IActionResult Post(Cantor cantor)
        {
            if (cantor == null)
            {
                return View("Por favor digite um nome válido");
            }
            MusicaRepository musicaRespository = new MusicaRepository();
            musicaRespository.Adicionar(cantor);
            return RedirectToAction("Index","Musica");
        }

        public IActionResult Get(Cantor cantor)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            musicaRepository.BuscarPorNome(cantor.NomeCantor);
            return View("Get");
        }
        
        public IActionResult Put(Cantor cantor)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            musicaRepository.Atualizar(cantor);
            return View("Put");
        }

        public IActionResult Delete(Cantor cantor)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            musicaRepository.Deletar(cantor.Id);
            return View();
        }
    }
}
