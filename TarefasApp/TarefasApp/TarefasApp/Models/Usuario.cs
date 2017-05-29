using Newtonsoft.Json;

namespace TarefasApp.Models
{
    public class Usuario
    {
        [JsonProperty("userId")]
        public int Id { get; set; }
    }
}