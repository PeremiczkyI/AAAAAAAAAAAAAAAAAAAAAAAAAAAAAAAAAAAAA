using HalakAPI.Models;
using System.Text.Json.Serialization;

namespace HalakAPI.Controllers
{
    public class HalakDto
    {
        public string Faj { get; set; } = null!;
        public decimal MeretCm { get; set; }
        public string? ToNeve { get; set; } 
    }
}
