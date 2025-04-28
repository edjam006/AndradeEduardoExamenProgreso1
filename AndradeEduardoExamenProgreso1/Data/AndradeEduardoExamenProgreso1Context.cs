using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndradeEduardoExamenProgreso1.Models;

namespace AndradeEduardoExamenProgreso1.Data
{
    public class AndradeEduardoExamenProgreso1Context : DbContext
    {
        public AndradeEduardoExamenProgreso1Context (DbContextOptions<AndradeEduardoExamenProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<AndradeEduardoExamenProgreso1.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<AndradeEduardoExamenProgreso1.Models.Reserva> Reserva { get; set; } = default!;
        public DbSet<AndradeEduardoExamenProgreso1.Models.Recompensas> Recompensas { get; set; } = default!;
    }
}
