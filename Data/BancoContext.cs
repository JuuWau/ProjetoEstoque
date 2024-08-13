using System;
using System.Collections.Generic;  
using System.Linq;
using System.Threading.Tasks;
using Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data{

    public class BancoContext : DbContext{
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){
            
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}