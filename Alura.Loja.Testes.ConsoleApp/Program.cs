using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Aufeneiros",
                Complemento = "Sobrado",
                Bairro = "Hogwarts",
                Cidade = "Ministério da Magia",
            };

            using(var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggetFactory = serviceProvider.GetService<ILoggerFactory>();
                loggetFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {

            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "CocaCola", Categoria = "Bebidas", PrecoUnitario = 8.00, Unidade = "Litros" };
            var p3 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 15.49, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Pascoa Feliz!";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluirProduto(p1);
            promocaoDePascoa.IncluirProduto(p2);
            promocaoDePascoa.IncluirProduto(p3);


            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggetFactory = serviceProvider.GetService<ILoggerFactory>();
                loggetFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoDePascoa);
                var promocao = contexto.Promocoes.Find(2);
                contexto.Promocoes.Remove(promocao);
                contexto.SaveChanges();
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}
