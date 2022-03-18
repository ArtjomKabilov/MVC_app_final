using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace KutseApp.Models
{
	public class PiduDBInitializer : CreateDatabaseIfNotExists<PiduContext>
	{
		protected override void Seed(PiduContext pd)
		{
			base.Seed(pd);
		}
	}
}