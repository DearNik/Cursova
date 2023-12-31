using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Models
{
	public class Comment
	{
		public int CommentID { get; set; }
		public int PaperID { get; set; }
		public int UserID { get; set; }
		public string Text { get; set; }
		public DateTime DatePosted { get; set; }
	}
}
