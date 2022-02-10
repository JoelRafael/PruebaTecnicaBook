using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using PruebaTecnicaBooks.Models.Books;
using PruebaTecnicaBooks.Rutas;
using System.Net.Http.Json;

namespace PruebaTecnicaBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController: ControllerBase
    {


        static readonly HttpClient client = new HttpClient();


        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            HttpResponseMessage response = await client.GetAsync(RutasEndpointBooks.GetBooks);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<GetBooks>Response = JsonSerializer.Deserialize<List<GetBooks>>(responseBody);
            return Ok(new { Status = 200,  Error = false,  Message =Response });
        }
        [HttpGet]
        [Route("GetBooks/{id}")]
        public async Task<IActionResult> GetBooksId(int id) {
            var Ruta = RutasEndpointBooks.GetBooks+id;
            HttpResponseMessage response = await client.GetAsync(Ruta);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var Response = JsonSerializer.Deserialize<GetBooks>(responseBody);
                return Ok(new { Status = 200, Error = false, Message = Response });
            }

            return NotFound(new { Status = 404 , Error = true, Message = "Este libro no existe" });

        }

        [HttpPost]
        [Route("PostBooks")]
        public async Task<IActionResult> PostBooks(GetBooks  json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await client.PostAsJsonAsync(RutasEndpointBooks.GetBooks, json);
            if (response.IsSuccessStatusCode)
            {
                return StatusCode(201, new { Status = 201, Error = false, Message = "Libro creado con exito" });
            }
            return BadRequest(new { Status = 400, Error = true, Message = "Hubo un problema para agregar el libro" });
        }

        [HttpPut]
        [Route("PutsBooks/{id}")]
        public async Task<IActionResult>PutBooks(int id, GetBooks json)
        {
            if(id != json.id)
            {
                return BadRequest(new { Status = 400, Error = true, Message = "los id no coinciden"});
            }
            var Ruta = RutasEndpointBooks.GetBooks + id;
            var response = await client.PutAsJsonAsync(Ruta, json);
            if (response.IsSuccessStatusCode)
            {
                return StatusCode(201, new { Status = 201, Error = false, Message = "Libro Actualizado con exito" });
            }
            return BadRequest(new { Status = 400, Error = true, Message = "Hubo un problema para actualizar el libro" });
        }
        [HttpDelete]
        [Route("DeleteBooks/{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            var Ruta = RutasEndpointBooks.GetBooks+id;
            var response = await client.DeleteAsync(Ruta);
            if (response.IsSuccessStatusCode)
            {
                return StatusCode(201, new { Status = 201, Error = false, Message = "Libro borrado con exito" });
            }
            return BadRequest(new { Status = 400, Error = true, Message = "Hubo un problema para eliminar el libro" });
        }

    }

}
