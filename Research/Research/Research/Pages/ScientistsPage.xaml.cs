using Research.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Research
{
	public partial class ScientistsPage : Page
	{
		public ScientistsPage()
		{
            InitializeComponent();
            List<ScientistsViewModel> results = SearchInDatabase();
            resultListBox.ItemsSource = results;
        }

        private List<ScientistsViewModel> SearchInDatabase()
        {
            List<ScientistsViewModel> results = new List<ScientistsViewModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Scientists ORDER BY ScientistsID";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ScientistsViewModel result = new ScientistsViewModel
                        {
                            FirstName = reader["FirstName"].ToString(),
                            SecondName = reader["SecondName"].ToString(),
                            Incumbency = reader["Incumbency"].ToString(),
                            Description = reader["Discripion"].ToString().Replace("\r\n", Environment.NewLine),
                            Awards = reader["Awards"].ToString(),
                        };

                        results.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            return results;
        }
        private void ResultListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (resultListBox.SelectedItem is ScientistsViewModel selectedScientists)
            {
                DisplayAdditionalInfo(selectedScientists);
            }
        }

        private void DisplayAdditionalInfo(ScientistsViewModel Scientists)
        {
            MainScroll.Visibility = Visibility.Collapsed;
            ShowScientists.Visibility = Visibility.Visible;

            ShowScientists.DataContext = Scientists;
        }
    }
}
