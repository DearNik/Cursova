using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using Research.ViewModel;

namespace Research
{
	/// <summary>
	/// Логика взаимодействия для NewPapersPage.xaml
	/// </summary>
	public partial class NewPapersPage : Page
	{
		private ResearchPaperViewModel researchPaperViewModel;
        private static string connectionString = "Data Source=DESKTOP-L7EKRDR;Initial Catalog=ResearchPapers;User ID=nikita;Password=nikita;";
        public NewPapersPage()
		{
			InitializeComponent();
			researchPaperViewModel = DatabaseHelper.GetLastResearchPaper();
			DataContext = researchPaperViewModel;
		}

		public class DatabaseHelper
		{
			public static ResearchPaperViewModel GetLastResearchPaper()
			{
				ResearchPaperViewModel researchPaper = new ResearchPaperViewModel();

				try
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						connection.Open();
						string query = "SELECT TOP 1 * FROM ResearchPapers ORDER BY DateUpdated DESC";
						SqlCommand command = new SqlCommand(query, connection);
						SqlDataReader reader = command.ExecuteReader();

						if (reader.Read())
						{
							researchPaper.Title = reader["Title"].ToString();
							researchPaper.AuthorName = GetAutorName((int)reader["AuthorID"]);
							researchPaper.Abstract = reader["Abstract"].ToString();
							researchPaper.Content = reader["Content"].ToString();
							researchPaper.DateCreated = (DateTime)reader["DateCreated"];
							researchPaper.DateUpdated = (DateTime)reader["DateUpdated"];
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка: {ex.Message}");
				}

				return researchPaper;
			}
		}
        private static string GetAutorName(int Id)
        {
            string autor = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
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

