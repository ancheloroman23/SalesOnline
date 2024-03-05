
using Newtonsoft.Json;
using System;

namespace SalesOnline.Application.Dtos.Base
{
    public abstract class DtoBase
    {
        [JsonProperty("IdUsuarioMod")]
        public int IdUsuarioMod { get; set; }

        [JsonProperty("FechaMod")]
        public DateTime? FechaMod { get; set; }
    }
}
