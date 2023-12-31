using Research.Models;
using Research.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            List<UserViewModel> results = SearchInDatabase();
            resultListBox.ItemsSource = results;
        }

        

        private List<UserViewModel> SearchInDatabase()
        {
            List<UserViewModel> results = new List<UserViewModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Users ORDER BY UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UserViewModel result = new UserViewModel
                        {
                            UserID = (int)reader["UserID"],
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString(),
                            IsAdmin = (bool)reader["IsAdmin"],
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
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            string email = emailTextBox.Text;
            int id;

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    connection.Open();

                    id = GetFreeId()+1;

                    string query = "INSERT INTO Users (UserID,Username, Password, Email, IsAdmin) VALUES (@UserID , @Username, @Password, @Email, @IsAdmin)";
                    
                    if(username != "" & password != "" & email != "")
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserID", id);
                            cmd.Parameters.AddWithValue("@IsAdmin", false);
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            cmd.Parameters.AddWithValue("@Email", email);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Користувач доданий успішно!");
                            }
                            else
                            {
                                MessageBox.Show("Користувач не доданий");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заповніть усі поля");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}");
                }
            }
        }

        private int GetFreeId()
        {
            int rowCount = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT MAX(UserID) FROM Users ";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении количества строк: {ex.Message}");
                }
            }

            return rowCount;
        }

        private void ResultListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (resultListBox.SelectedItem is UserViewModel selectedResult)
            {
                DisplayAdditionalInfo(selectedResult);
            }
        }
        UserViewModel researchPaper1 = new UserViewModel();

        private void DisplayAdditionalInfo(UserViewModel researchPaper)
        {
            MainScroll.Visibility = Visibility.Collapsed;
            ShowResearch.Visibility = Visibility.Visible;
            ShowResearch.DataContext = researchPaper;
            researchPaper1 = researchPaper;
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

                        string query = "UPDATE Users SET Username = @Username, Password = @Password, Email = @Email , IsAdmin = @IsAmdin WHERE UserID = @UserID";
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@Username", NewUsernameTextBox.Text);
                        command.Parameters.AddWithValue("@Password", NewPassWordTextBox.Text);
                        command.Parameters.AddWithValue("@Email", NewEmailTextBox.Text);
                        command.Parameters.AddWithValue("@UserID", researchPaper1.UserID);
                        command.Parameters.AddWithValue("@IsAmdin", isAdminCheckBox.IsChecked ?? false);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Данные успешно обновлены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}\n{ex.StackTrace}");
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

                        string deleteQuery = "DELETE FROM Scientists WHERE UserID = " + researchPaper1.UserID + "";

                        SqlCommand command = new SqlCommand(deleteQuery, connection);

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                }
                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM ResearchPapers WHERE AuthorID = " + researchPaper1.UserID + "";

                        SqlCommand command = new SqlCommand(deleteQuery, connection);

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                }
                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Users WHERE UserID = " + researchPaper1.UserID + "";

                        SqlCommand command = new SqlCommand(deleteQuery, connection);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Запись с указанным UserID не найдена.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                }
            }
        }
        public void Refresh()
        {
            List<UserViewModel> results = SearchInDatabase();
            resultListBox.ItemsSource = results;
        }
    }
}
