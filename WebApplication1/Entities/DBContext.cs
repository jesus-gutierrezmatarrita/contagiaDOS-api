using Microsoft.EntityFrameworkCore;
using Proyecto_Redes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contagiaDOS.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<GameEntity> Games { get; set; }
    }
    
}
