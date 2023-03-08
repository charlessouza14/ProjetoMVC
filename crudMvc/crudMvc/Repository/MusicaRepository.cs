﻿using crudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;

namespace crudMvc.Repository
{
    public class MusicaRepository : ControllerBase
    {
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

        public Cantor Deletar(int id)
        {
            Contexto contexto = new Contexto();
            var deletarMusica = contexto.Cantor.FirstOrDefault(c =>c.Id == id);
            contexto.Cantor.Remove(deletarMusica);
            contexto.SaveChanges();
            return(deletarMusica);
        }
    }
}