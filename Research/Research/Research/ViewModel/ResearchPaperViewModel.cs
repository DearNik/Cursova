using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.ViewModel
{
    using System;
    using System.ComponentModel;

	public class ResearchPaperViewModel : INotifyPropertyChanged
	{
		private string title;
		private string authorName;
        private int authorId;
        private string abstractText;
		private string content;
		private DateTime dateCreated;
		private DateTime dateUpdated;

		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

        public int AuthorId
        {
            get { return authorId; }
            set
            {
                authorId = value;
                OnPropertyChanged(nameof(AuthorId));
            }
        }

        public string AuthorName
		{
			get { return authorName; }
			set
			{
				authorName = value;
				OnPropertyChanged(nameof(AuthorName));
			}
		}

		public string Abstract
		{
			get { return abstractText; }
			set
			{
				abstractText = value;
				OnPropertyChanged(nameof(Abstract));
			}
		}

		public string Content
		{
			get { return content; }
			set
			{
				content = value;
				OnPropertyChanged(nameof(Content));
			}
		}

		public DateTime DateCreated
		{
			get { return dateCreated; }
			set
			{
				dateCreated = value;
				OnPropertyChanged(nameof(DateCreated));
			}
		}

		public DateTime DateUpdated
		{
			get { return dateUpdated; }
			set
			{
				dateUpdated = value;
				OnPropertyChanged(nameof(DateUpdated));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}
