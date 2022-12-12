using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcquant.Models
{
    public class InicializaBD
    {


        public List<TbUnidadeConstrutiva> Initialize(bcquant_localContext context)
        {
            context.Database.EnsureCreated();

            var consulta = from c in context.TbUnidadeConstrutiva

                           select c;
            return consulta.ToList();

            // Procura por livros
            //if (context.UnidadeConstrutiva.ToArray())
            //{
            //    return;   //O BD foi alimentado
            //}
            //var livros = new Livro[]
            //{
            //  new Livro{Nome="ASP, ADO Banco de dados na web", Autor="Macoratti", Preco=3.99M, Lancamento= DateTime.Now},
            //  new Livro{Nome="A Cabana", Autor="Willian P. Young", Preco=29.55M, Lancamento=DateTime.Now},
            //};
            //foreach (Livro p in livros)
            //{
            //    context.Livros.Add(p);
            //}
            //context.SaveChanges();
        }
    }

}

