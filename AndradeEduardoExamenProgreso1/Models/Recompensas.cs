using System.ComponentModel.DataAnnotations;

namespace AndradeEduardoExamenProgreso1.Models
{
    public class Recompensas
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int puntos { get; set; }
        [Required]
        public int tipoRecompensa { get; set; }

        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public int clienteId { get; set; }

        [Required]
        public int reservaId { get; set; }


    }
}
