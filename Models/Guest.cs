using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KutseApp.Models
{
	public class Guest
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="On vaja sisesta oma nime!")]
		public string Name { get; set; }
		[Required(ErrorMessage = "On vaja sisesta oma email!")]
		[RegularExpression(@".+\@.+\..+", ErrorMessage = "See on vale email!")]
		public string Email { get; set; }
		[Required(ErrorMessage = "On vaja sisesta oma telefoninumber!")]
		//[RegularExpression(@"\+372.+", ErrorMessage = "See on vale telefon!")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Tee oma valik!")]
		public bool? Attend { get; set; }
	}
}