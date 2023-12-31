using Research.Models;
using Research.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace Research.Pages
{
    public partial class MyPapersPage : Page
    {
        public MyPapersPage()
        {
            InitializeComponent();
            List<ResearchPaperViewModel> results = SearchInDatabase();
            resultListBox.ItemsSource = results;
        }

        private List<ResearchPaperViewModel> SearchInDatabase()
        {
            List<ResearchPaperViewModel> results = new List<ResearchPaperViewModel>();
            string username = UserManager.Instance.Username;
            string password = UserManager.Instance.Password;

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM ResearchPapers WHERE AuthorID = "+ GetAutorID() + " ORDER BY DateUpdated DESC";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    string AutorName = GetAutorName(GetAutorID());

                    while (reader.Read())
                    {
                        ResearchPaperViewModel result = new ResearchPaperViewModel
                        {
                            Title = reader["Title"].ToString(),
                            AuthorName = AutorName,
                            Abstract = reader["Abstract"].ToString(),
                            Content = reader["Content"].ToString().Replace("\r\n", Environment.NewLine),
                            DateCreated = (DateTime)reader["DateCreated"],
                            DateUpdated = (DateTime)reader["DateUpdated"],
                            AuthorId = (int)reader["AuthorID"]
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
        ResearchPaperViewModel researchPaper1 = new ResearchPaperViewModel();
        private void DisplayAdditionalInfo(ResearchPaperViewModel researchPaper)
        {
            MainScroll.Visibility = Visibility.Collapsed;
            ShowResearch.Visibility = Visibility.Visible;

            ShowResearch.DataContext = researchPaper;
            researchPaper1 = researchPaper;
        }
        private int GetAutorID()
        {
            string username = UserManager.Instance.Username;
            string password = UserManager.Instance.Password;
            int userid = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT UserID FROM Users WHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        userid = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении количества строк: {ex.Message}");
                }
            }

            return userid;
        }
        private string GetAutorName(int Id)
        {
            string username = UserManager.Instance.Username;
            string password = UserManager.Instance.Password;
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
        private void ApplyChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (researchPaper1 != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();

                        string query = "UPDATE ResearchPapers SET Title = @Title, Abstract = @Abstract ,Content = @Content, DateUpdated = GETDATE() WHERE AuthorID = " + researchPaper1.AuthorId + "";
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@Title", TitleTextBox.Text);
                        command.Parameters.AddWithValue("@Abstract", AbstractTextBox.Text);
                        command.Parameters.AddWithValue("@Content", ContentTextBox.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Данні успішно оновлено");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}\n{ex.StackTrace}");
                    Console.WriteLine(ex.Message,ex.StackTrace);
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (researchPaper1 != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM ResearchPapers WHERE AuthorID = " + researchPaper1.AuthorId + "";

                        SqlCommand command = new SqlCommand(deleteQuery, connection);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show("Звіт видалений");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                }
            }
        }
    }
}
