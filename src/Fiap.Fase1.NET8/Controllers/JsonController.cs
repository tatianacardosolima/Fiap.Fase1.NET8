using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Fase1.NET8.Controllers
{
    [ApiController]
    [Route("jsonteste")]
    public class JsonController: ControllerBase
    {
        public JsonController()
        {
                
        }
        [HttpPost("serializable-json")]
        public IActionResult SerializableJson()
        {
            var dados = new Dados() { Id = 100, Name = "Joao", IsEnable = false};
            var json = JsonSerializer.Serialize(dados);
            return Ok(json);
        }

        [HttpPost("deserializable-json")]
        public IActionResult DeserializableJson()
        {
            var json = "{\"id\":1,\"nAme\":\"tatiana\", \"IsEnable\":false}";
            var dados = JsonSerializer.Deserialize<Dados>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return Ok(new {  isenable = dados?.IsEnable, nome = dados?.Name, id = dados?.Id});
        }
    }

    public class Dados
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; } = true;
    }
}
