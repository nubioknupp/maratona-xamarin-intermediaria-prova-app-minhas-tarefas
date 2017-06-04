using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TarefasApp.REST.ClienteAPI.Models;
using TarefasApp.REST.ClienteAPI.Repository;

namespace TarefasApp.REST.ClienteAPI.Controllers
{

    [RoutePrefix("api/v1/tarefas")]
    public class TarefasController : ApiController
    {
        private readonly TarefaRepository _tarefaRepository;

        public TarefasController()
        {
            _tarefaRepository = new TarefaRepository();
        }

        [HttpGet]
        [Route("buscar")]
        public HttpResponseMessage GetTarefas()
        {
            var result = _tarefaRepository.ObterTodos();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("buscar/categorias/{categoriaId}")]
        public HttpResponseMessage GetObterPorCategoria(Guid categoriaId)
        {
            if (categoriaId == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var result = _tarefaRepository.ObterPorCategoria(categoriaId);
            return Request.CreateResponse(HttpStatusCode.OK, result); 
        }

        [HttpPost]
        [Route("adicionar")]
        public HttpResponseMessage PostTarefa([FromBody]Tarefa tarefa)
        {
            if(tarefa == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _tarefaRepository.Adicionar(tarefa);
                return Request.CreateResponse(HttpStatusCode.OK, tarefa);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir tarefa");
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage PutTarefa([FromBody]Tarefa tarefa)
        {
            if (tarefa == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _tarefaRepository.Atualizar(tarefa);
                return Request.CreateResponse(HttpStatusCode.OK, tarefa);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir tarefa");
            }
        }

        [HttpDelete]
        [Route("remover")]
        public HttpResponseMessage DeleteTarefa([FromBody]Guid tarefaId)
        {
            if (tarefaId == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _tarefaRepository.Remover(tarefaId);
                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa excluida");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir tarefa");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tarefaRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
