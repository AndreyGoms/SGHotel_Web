using Microsoft.EntityFrameworkCore;

namespace SGHotel.Models.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
      
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<QuartoModel> Quartos { get; set; }
        public DbSet<AndarModel> Andares    { get; set; }
        public DbSet<ContaModel> Contas { get; set; }
        public DbSet<ReservasModel> Reservas { get; set; }
    }
}
