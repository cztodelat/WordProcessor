using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using WordProcessor.Models;

namespace WordProcessor.Data
{
    public class WordProcessorContext : DbContext
    {
        public DbSet<WordModel> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=YOUR_SOURCE;Initial Catalog=WordsDB;Integrated Security=True");
        }
    }
}
