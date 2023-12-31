using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Models
{
	public class ResearchPaper
	{
		public int PaperID { get; set; }
		public string Title { get; set; }
		public int AuthorID { get; set; }
		public string Abstract { get; set; }
		public string Content { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }
	}
}
