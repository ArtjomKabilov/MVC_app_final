using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KutseApp.Models
{
	public class Pidu
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "On vaja sisesta pidu nime!")]
		public string Name { get; set; }
		[Required(ErrorMessage = "On vaja sisesta kuupäev!")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }
	}
}