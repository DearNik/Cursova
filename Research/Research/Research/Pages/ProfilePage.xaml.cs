using Research.Models;
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

namespace Research.Pages
{
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            List<ScientistsViewModel> results = SearchInDatabase();
        }

        private List<ScientistsViewModel> SearchInDatabase()
        {
            List<ScientistsViewModel> results = new List<ScientistsViewModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Scientists WHERE UserID = "+ GetAutorID() + "";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ScientistsViewModel result = new ScientistsViewModel
                        {
                            UserID = GetAutorID(),
                            ScientistsID = (int)reader["ScientistsID"],
                            FirstName = reader["FirstName"].ToString(),
                            SecondName = reader["SecondName"].ToString(),
                            Incumbency = reader["Incumbency"].ToString(),
                            Description = reader["Discripion"].ToString(),
                            Awards = reader["Awards"].ToString(),

                        };

                        results.Add(result);
                        ShowResearch.DataContext = result;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            return results;
        }

        private void ApplyChangesButton_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();

                        string query = "UPDATE Scientists SET FirstName = @FirstName, SecondName = @SecondName, Incumbency = @Incumbency , Discripion = @Discripion , Awards = @Awards WHERE UserID = @UserID";
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@FirstName", NameBox.Text);
                        command.Parameters.AddWithValue("@SecondName", SecondBox.Text);
                        command.Parameters.AddWithValue("@Incumbency", IncumbencyBox.Text);
                        command.Parameters.AddWithValue("@UserID", GetAutorID());
                        command.Parameters.AddWithValue("@Discripion", ContentTextBox.Text);
                        command.Parameters.AddWithValue("@Awards", AwardsBox.Text);


                        command.ExecuteNonQuery();

                        MessageBox.Show("Данные успешно обновлены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}\n{ex.StackTrace}");
                }
        }

        /*private void ApplyChangesButton_Click(object sender, RoutedEventArgs e)
        {
                /*try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();

                        string query = "UPDATE Users SET FirstName = @FirstName, SecondName = @SecondName, Incumbency = @Incumbency , Discripion = @Discripion , Awards = @Awards WHERE UserID = @UserID";
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@FirstName", NewUsernameTextBox.Text);
                        command.Parameters.AddWithValue("@SecondName", NewPassWordTextBox.Text);
                        command.Parameters.AddWithValue("@Incumbency", NewEmailTextBox.Text);
                        command.Parameters.AddWithValue("@UserID", GetAutorID());
                        command.Parameters.AddWithValue("@Discripion", NewEmailTextBox.Text);
                        command.Parameters.AddWithValue("@Awards", NewEmailTextBox.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Данные успешно обновлены.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}\n{ex.StackTrace}");
                }*/

        /*try
        {
            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Scientists (ScientistsID, FirstName, SecondName, UserID, Incumbency, Discripion, Awards) VALUES (@ScientistsID, @FirstName, @SecondName, @UserID, @Incumbency, @Discripion, @Awards) ON DUPLICATE KEY UPDATE  FirstName = @FirstName,  SecondName = @SecondName, Incumbency = @Incumbency, Discripion = @Description,  Awards = @Awards;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ScientistsID", GetFreeId());
                command.Parameters.AddWithValue("@FirstName", NameBox.Text);
                command.Parameters.AddWithValue("@SecondName", SecondBox.Text);
                command.Parameters.AddWithValue("@Incumbency", IncumbencyBox.Text);
                command.Parameters.AddWithValue("@UserID", GetAutorID());
                command.Parameters.AddWithValue("@Discripion", ContentTextBox.Text);
                command.Parameters.AddWithValue("@Awards", AwardsBox.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Данные успешно обновлены.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}\n{ex.StackTrace}");
        }*/
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox textBox = (TextBox)sender;
                textBox.AppendText(Environment.NewLine);
                e.Handled = true;
            }
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
        private int GetFreeId()
        {
            int rowCount = 0;

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT MAX(ScientistsID) FROM Scientists ";

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
    }
}
