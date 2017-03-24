using FirstApplication.Domain;
using FirstApplication.Models;
using FirstApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplication.Controllers
{
    public class LivrosController : Controller
    {
        // GET: Livro
        public ActionResult Index()
        {

            var repository = new LivroRepository();

            var livros = repository.GetAllLivros();

            return View(
                livros.Select(l => new LivroViewModel()
                {
                    Id = l.Id,
                    Ano = l.Ano,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    Editora = l.Editora
                }
                ));

        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            var repository = new LivroRepository();

            var l = repository.GetLivro(id);

            LivroViewModel livro = new LivroViewModel();
            livro.Id = l.Id;
            livro.Ano = l.Ano;
            livro.Titulo = l.Titulo;
            livro.Autor = l.Autor;
            livro.Editora = l.Editora;

            return View(livro);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var repository = new LivroRepository();
                repository.CreateLivro(new Domain.Livro()
                {
                   Ano = livro.Ano,
                   Titulo = livro.Titulo,
                   Autor = livro.Autor,
                   Editora = livro.Editora
                });

                return RedirectToAction("Index");
            }
            return View();
            
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            var repository = new LivroRepository();

            var l = repository.GetLivro(id);

            LivroViewModel livro = new LivroViewModel();
            livro.Id = l.Id;
            livro.Ano = l.Ano;
            livro.Titulo = l.Titulo;
            livro.Autor = l.Autor;
            livro.Editora = l.Editora;

            return View(livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var repository = new LivroRepository();

                repository.UpdadeLivro(new Livro()
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano

                });

                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            var repository = new LivroRepository();

            var l = repository.GetLivro(id);

            LivroViewModel livro = new LivroViewModel();
            livro.Id = l.Id;
            livro.Ano = l.Ano;
            livro.Titulo = l.Titulo;
            livro.Autor = l.Autor;
            livro.Editora = l.Editora;

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var repository = new LivroRepository();

                var delete = repository.DeleteLivro(id);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
