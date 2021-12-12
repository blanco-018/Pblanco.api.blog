using Pblanco.Api.blog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pblanco.Api.blog.Models
{
    public static class Contextdb
    {
        public static void InitialLoad()
        {
            Post = new List<Post>();

            Post.Add(new Post { Id = 1, Title = "Venta de camisetas", Body = "camiseta con flores" });

            Post.Add(new Post { Id = 2, Title = "nuevas sudaderas", Body = "nuevas sudaderas negras" });

            Post.Add(new Post { Id = 3, Title = "Colaboracion con Snipes", Body = "Nueva colaboracion con nuevos outfits" });

            Post.Add(new Post { Id = 4, Title = "Nuevas zapatillas en el mercado", Body = "Zapatatillas nike con camara de aire" });

            Post.Add(new Post { Id = 5, Title = "Nuevas raquetas", Body = "raquetas firmadas por Rafa Nadal" });

            Post.Add(new Post { Id = 6, Title = "Nuevos pantalones", Body = "Pantalones vaqueros y deportivos a la venta" });

            Post.Add(new Post { Id = 7, Title = "Nuevas camisetas 2022", Body = "Lo mas trending en camisetas" });

            Post.Add(new Post { Id = 8, Title = "Nuevas Airforce One 2022", Body = "Lo mas trending en zapatillas nike" });

            Post.Add(new Post { Id = 9, Title = "Nuevas chaquetas 2022", Body = "Lo mas trending en chaquetas" });

            Post.Add(new Post { Id = 10, Title = "Nuevas cazadoras 2022", Body = "Lo mas trending en cazadoras" });

        }

        public static List<Post> Post { get; set; }
    }
}
