using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AndradeEduardoExamenProgreso1.Models
{
    public class Cliente
    {
        [Key]
        public int clienteId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100.")]
        public int Edad { get; set; }
        [Required]
        [Precision(18, 2)] 
        public decimal Presupuesto { get; set; }
        [AllowNull]
        public Boolean tienePuntos { get; set; }


        [Required]
        public DateTime fechaAproximadaReserva { get; set; }










    }
}
