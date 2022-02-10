using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaBooks.Rutas
{
    public class RutasEndpointBooks
    {
        public static string GetBooks { get { return "https://fakerestapi.azurewebsites.net/api/v1/Books/"; } }
        //public static string GetBooksbyId { get { return "https://fakerestapi.azurewebsites.net/api/v1/Books"; } }
    }
}
