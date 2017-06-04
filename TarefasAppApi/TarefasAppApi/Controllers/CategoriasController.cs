using System.Web.Http;
using System.Web.Http.Cors;
using TarefasApp.REST.ClienteAPI.Models;

namespace TarefasApp.REST.ClienteAPI.Controllers
{
	[EnableCors("http://localhost:8080, http://tarefasapps.azurewebsites.net", "*", "*")]
	[RoutePrefix("api/v1/categorias")]
    public class CategoriasController : ApiController
    {
        /// <summary>
        /// Buscar quantidade de categorias
        /// </summary>
        /// <returns>Retorna quantidade de categorias</returns>
        [HttpGet]
		[Route("teste/count")]
		public int Get()
		{
            //var cat = new Categoria();

            //cat.UsuarioId = System.Guid.Parse("b13f687a-27ae-4659-9daf-90a796bf6d97");

            return 10;
		}
    }
}
