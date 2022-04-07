using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
	public class LiveContext : DbContext
	{
		public LiveContext(DbContextOptions<LiveContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<Live> Lives { get; set; }
	}
}

