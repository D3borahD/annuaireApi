using System;
using annuaireApi.Models;
using Microsoft.EntityFrameworkCore;

namespace annuaireApi.models
{
	public class AnnuaireApiContext:DbContext
	{
		public AnnuaireApiContext(DbContextOptions<AnnuaireApiContext> options)
			:base(options)
		{

		}

		public DbSet<Site> Sites{ get; set; }

	}
}

