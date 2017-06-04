using System.Web.Http;
using System.Web.Http.Cors;

namespace TarefasApp.REST.ClienteAPI.Controllers
{
	[EnableCors("http://localhost:8080, http://tarefasapps.azurewebsites.net", "*", "*")]
	[RoutePrefix("api/v1/categorias")]
    public class CategoriasController : ApiController
    {
        [HttpGet]
		[Route("teste/count")]
		public int Get()
		{
			return 10;
		}
    }
}
