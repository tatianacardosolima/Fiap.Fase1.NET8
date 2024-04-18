using MessagePack;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Fase1.NET8.Controllers
{
    [ApiController]
    [Route("messagepackteste")]
    public class MessagePackController : ControllerBase
    {
        public MessagePackController()
        {
                
        }
        [HttpPost("Serialize-mp")]
        public IActionResult SerializableJson()
        {
            var dados = new DadosMP() { Id = 100, Name = "Joao", IsEnable = false};
            var json = MessagePackSerializer.Serialize(dados);
            var ret = MessagePackSerializer.ConvertToJson(json);
            return Ok(ret);
        }

        [HttpPost("deserializable-mp")]
        public IActionResult DeserializableJson()
        {
            var dados = new DadosMP() { Id = 100, Name = "Joao", IsEnable = false };
            var json = MessagePackSerializer.Serialize(dados);
            var ret = MessagePackSerializer.Deserialize<DadosMP>(json);


            return Ok(ret);
        }
    }
    [MessagePackObject]
    public class DadosMP
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public bool IsEnable { get; set; } = true;
    }


}
