using System.ComponentModel.DataAnnotations;

namespace AndradeEduardoExamenProgreso1.Models
{
    public class Reserva
    {
        [Key]
        public int reservaId { get; set; }

        [Required]
        public DateTime fechaIngreso { get; set; }
            
        [Required]
        public DateTime fechaSalida { get; set; }

        [Required]
        public int clienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
