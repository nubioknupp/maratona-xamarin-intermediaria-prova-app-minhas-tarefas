using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TarefasApp.Helpers;
using TarefasApp.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TarefasApp.Services.TarefasAppService))]
namespace TarefasApp.Services
{
    public class TarefasAppService : ITarefasAppService
    {
        private const string BaseUrl = "https://tarefasapps.azurewebsites.net/api/v1/";
        private readonly HttpClient _httpClient;


        public TarefasAppService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("X-ZUMO-AUTH", Settings.AuthToken);
        }

        public async Task<List<Categoria>> BuscarCategoriasPorUsuarioAsync(string usuarioId)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync($"{BaseUrl}categorias/buscar/usuarios/{usuarioId}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Categoria>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<List<Tarefa>> BuscarTarefasPorCategoriaAsync(string categoriaId)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync($"{BaseUrl}tarefas/buscar/categorias/{categoriaId}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tarefa>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<bool> GravarCategoriaAsync(Categoria categoria)
        {
            var uri = new Uri($"{BaseUrl}categorias/adicionar");

            var json = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> GravarTarefaAsync(Tarefa tarefa)
        {
            var uri = new Uri($"{BaseUrl}tarefas/adicionar");

            var json = JsonConvert.SerializeObject(tarefa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
        }
    }
}
