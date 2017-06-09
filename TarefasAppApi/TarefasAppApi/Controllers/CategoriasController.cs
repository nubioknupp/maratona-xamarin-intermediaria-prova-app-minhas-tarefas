using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TarefasApp.REST.ClienteAPI.Models;
using TarefasApp.REST.ClienteAPI.Repository;

namespace TarefasApp.REST.ClienteAPI.Controllers
{

	[RoutePrefix("api/v1/categorias")]
    public class CategoriasController : ApiController
    {

        private readonly CategoriaRepository _categoriaRepository;

        public CategoriasController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        [HttpGet]
        [Route("buscar")]
        public HttpResponseMessage GetCategorias()
        {
            var result = _categoriaRepository.ObterTodos();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("buscar/usuarios/{usuarioId}")]
        public HttpResponseMessage GetObterPorCategoria(Guid usuarioId)
        {
            var result = _categoriaRepository.ObterPorUsuario(usuarioId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("adicionar")]
        public HttpResponseMessage PostCategoria([FromBody]Categoria categoria)
        {
            if (categoria == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _categoriaRepository.Adicionar(categoria);
                return Request.CreateResponse(HttpStatusCode.OK, categoria);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir categoria");
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage PutCategoria([FromBody]Categoria categoria)
        {
            if (categoria == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _categoriaRepository.Atualizar(categoria);
                return Request.CreateResponse(HttpStatusCode.OK, categoria);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar categoria");
            }
        }

        [HttpDelete]
        [Route("remover")]
        public HttpResponseMessage DeleteCategoria([FromBody]Guid categoriaId)
        {
            if (categoriaId == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _categoriaRepository.Remover(categoriaId);
                return Request.CreateResponse(HttpStatusCode.OK, "Categoria excluida");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir categoria");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoriaRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
