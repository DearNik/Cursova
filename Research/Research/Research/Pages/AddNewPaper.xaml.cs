using Research.Models;
using Research.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
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
    public partial class AddNewPaper : Page
    {
        public AddNewPaper()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string small = SmallTextBox.Text;
            string content = ContentTextBox.Text;
            int id;

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                try
                {
                    connection.Open();

                    id = GetFreeId() + 1;

                    string query = "INSERT INTO ResearchPapers (PaperID,Title, AuthorID, Abstract, Content,DateCreated,DateUpdated) VALUES (@PaperID , @Title, @AuthorID, @Abstract, @Content,GETDATE(), GETDATE())";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@PaperID", id);
                            cmd.Parameters.AddWithValue("@Title", title);
                            cmd.Parameters.AddWithValue("@AuthorID", GetAutorID());
                            cmd.Parameters.AddWithValue("@Abstract", small);
                            cmd.Parameters.AddWithValue("@Content", content);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Звіт доданий успішно!");
                            }
                            else
                            {
                                MessageBox.Show("Звіт не доданий");
                            }
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

                    string query = "SELECT MAX(PaperID) FROM ResearchPapers ";

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
    }
}
