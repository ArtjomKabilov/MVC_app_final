using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace KutseApp.Models
{
	public class GuestDBInitializer : CreateDatabaseIfNotExists<GuestContext>
	{
		protected override void Seed(GuestContext db)
		{
			base.Seed(db);
		}
	}
}