using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KutseApp.Models
{
	public class PiduContext : DbContext
	{
		public DbSet<Pidu> Pidus { get; set; }
	}
}