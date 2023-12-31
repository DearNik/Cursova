
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
using Research.Models;
using Research.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Research
{
	/// <summary>
	/// Логика взаимодействия для NewPapersPage.xaml
	/// </summary>
	public partial class SearchPage : Page
	{
		public SearchPage()
		{
			InitializeComponent();
		}
		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			MainScroll.Visibility = Visibility.Visible;
			ShowResearch.Visibility = Visibility.Collapsed; 

			string searchTerm = searchTextBox.Text.Trim();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				// Выполняем поиск в базе данных
				List<ResearchPaperViewModel> results = SearchInDatabase(searchTerm);

				// Отображаем результат в ListBox
				resultListBox.ItemsSource = results;

				if (results != null && results.Count > 0)
				{
					resultTextBlock.Text = string.Empty; // Очищаем TextBlock, если он еще используется
				}
				else
				{
					resultTextBlock.Text = "Ничего не найдено";
				}
			}
			else
			{
				resultTextBlock.Text = "Введите поисковый запрос";
			}
		}

		private List<ResearchPaperViewModel> SearchInDatabase(string searchTerm)
		{
			List<ResearchPaperViewModel> results = new List<ResearchPaperViewModel>();

			try
			{
				using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
				{
					connection.Open();
					string query = $"SELECT * FROM ResearchPapers WHERE Content LIKE '%{searchTerm}%'";
					SqlCommand command = new SqlCommand(query, connection);
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						ResearchPaperViewModel result = new ResearchPaperViewModel
						{
							Title = reader["Title"].ToString(),
                            AuthorName = GetAutorName((int)reader["AuthorID"]),
                        Abstract = reader["Abstract"].ToString(),
							Content = reader["Content"].ToString().Replace("\r\n", Environment.NewLine),
							DateCreated = (DateTime)reader["DateCreated"],
							DateUpdated = (DateTime)reader["DateUpdated"]
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
			if (resultListBox.SelectedItem is ResearchPaperViewModel selectedResult)
			{
				DisplayAdditionalInfo(selectedResult);
			}
		}

		private void DisplayAdditionalInfo(ResearchPaperViewModel researchPaper)
		{
			MainScroll.Visibility = Visibility.Collapsed;
			ShowResearch.Visibility = Visibility.Visible;

			ShowResearch.DataContext = researchPaper;
		}
        private static string GetAutorName(int Id)
        {
            string autor = null;

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT FirstName,SecondName FROM Scientists WHERE UserID = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", Id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader["FirstName"].ToString();
                                string secondName = reader["SecondName"].ToString();
                                autor = firstName + " " + secondName;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении количества строк: {ex.Message}");
                }
            }

            return autor;
        }
    }
}
