using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.ViewModel
{
	using System;
	using System.ComponentModel;

	public class ScientistsViewModel : INotifyPropertyChanged
    {
        private int scientistsID;
        private string firstName;
        private string secondName;
        private int userID;
        private string incumbency;
        private string description;
        private string awards;

        public int ScientistsID
        {
            get { return scientistsID; }
            set
            {
                scientistsID = value;
                OnPropertyChanged(nameof(ScientistsID));
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }

        public int UserID
        {
            get { return userID; }
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public string Incumbency
        {
            get { return incumbency; }
            set
            {
                incumbency = value;
                OnPropertyChanged(nameof(Incumbency));
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Awards
        {
            get { return awards; }
            set
            {
                awards = value;
                OnPropertyChanged(nameof(Awards));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
