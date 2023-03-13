using crudMvc.Controllers;
using crudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace crudMvc.Repository
{
    public class CantorRepository : ControllerBase
    {
        public List<Cantor> BuscarTudo()
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Cantor.ToList();
            return buscar;
        }
        public void Adicionar(Cantor cantor)
        {
            Contexto contexto = new Contexto();
            contexto.Cantor.Add(cantor);
            contexto.SaveChanges();
        }

        public Cantor Buscar (int id)
        {
            Contexto contexto = new Contexto();
            var buscarPorId = contexto.Cantor.FirstOrDefault(c => c.Id == id);
            return (buscarPorId);
        }

        public Cantor BuscarPorNome(string nome)
        {
            Contexto contexto = new Contexto();
            var buscarPorNome = contexto.Cantor.FirstOrDefault(c => c.NomeCantor == nome);
            return (buscarPorNome);
        }
        
        public Cantor Atualizar (Cantor cantor)
        {
            Contexto contexto = new Contexto();
            var atualizar = contexto.Cantor.FirstOrDefault(c => c.Id == cantor.Id);
            atualizar.NomeCantor = cantor.NomeCantor;
            atualizar.NomeMusica = cantor.NomeMusica;
            contexto.Cantor.Update(atualizar);
            contexto.SaveChanges();
            return atualizar;
        }

        public void Deletar(int id)
        {
            Contexto contexto = new Contexto();
            var deletar = contexto.Cantor.FirstOrDefault(c => c.Id == id);
            contexto.Cantor.Remove(deletar);
            contexto.SaveChanges();            
        }
    }
}
