using System;
using annuaireApi.Models;
using Microsoft.EntityFrameworkCore;

namespace annuaireApi.models
{
	public class AnnuaireApiContext:DbContext
	{
		// constructor
		public AnnuaireApiContext(DbContextOptions<AnnuaireApiContext> options)
			:base(options)
		{

		}

		// permet de créer la table dans la db
		public DbSet<Site> Site { get; set; }

	}
}

