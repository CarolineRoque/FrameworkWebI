using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebVetMyPet.Models;

namespace WebVetMyPet.Data
{
    public class WebVetMyPetContext : DbContext
    {
        public WebVetMyPetContext (DbContextOptions<WebVetMyPetContext> options)
            : base(options)
        {
        }

        public DbSet<WebVetMyPet.Models.Specialty>? Specialty { get; set; }

        public DbSet<WebVetMyPet.Models.Veterinarian>? Veterinarian { get; set; }

        public DbSet<WebVetMyPet.Models.Service>? Service { get; set; }

        public DbSet<WebVetMyPet.Models.Animal>? Animal { get; set; }

        public DbSet<WebVetMyPet.Models.Owner>? Owner { get; set; }


    }
}
