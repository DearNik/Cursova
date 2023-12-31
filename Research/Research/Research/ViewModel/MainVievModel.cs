using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;

namespace Research
{
	public partial class MainWindow : Window
	{
        public static event EventHandler ShowEditPageRequested;
        public MainWindow()
		{
			InitializeComponent();
			ResizeMode = ResizeMode.NoResize;
			WindowStyle = WindowStyle.SingleBorderWindow;
        }
		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			string username = usernameTextBox.Text;
			string password = passwordBox.Password;

			using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
			{
				try
				{
                    connection.Open();

                    string userQuery = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand userCmd = new SqlCommand(userQuery, connection))
                    {
                        userCmd.Parameters.AddWithValue("@Username", username);
                        userCmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = userCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                                if (isAdmin)
                                {
                                    MessageBox.Show("Вход выполнен успешно! (Администратор)");
                                    Admin.Visibility = Visibility.Visible;
                                    AddNew.Visibility = Visibility.Collapsed;
                                    My.Visibility = Visibility.Collapsed;
                                    Profile.Visibility = Visibility.Collapsed;
                                }
                                else
                                {
                                    MessageBox.Show("Вход выполнен успешно!");
                                    Admin.Visibility = Visibility.Collapsed;
                                    AddNew.Visibility = Visibility.Visible;
                                    My.Visibility = Visibility.Visible;
                                    Profile.Visibility = Visibility.Visible;

                                }
                                UserManager.Instance.Username = username;
                                UserManager.Instance.Password = password;
                                LoginPanel.Visibility = Visibility.Collapsed;
                                MainFrame.Visibility = Visibility.Visible;
                                MainContentPanel.Visibility = Visibility.Visible;
                                MainFrame.Visibility = Visibility.Visible;
                                ShowMainPage(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Неверное имя пользователя или пароль.");
                            }
                        }
                    }
                }
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}");
				}
			}
		}
        private void LoginGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ви увійшли як гість");
            MainFrame.Visibility = Visibility.Visible;
            LoginPanel.Visibility = Visibility.Collapsed;
            Admin.Visibility = Visibility.Collapsed;
            AddNew.Visibility = Visibility.Collapsed;
            My.Visibility = Visibility.Collapsed;
            MainContentPanel.Visibility = Visibility.Visible;
            Profile.Visibility = Visibility.Collapsed;
            ShowMainPage(sender, e);
        }
        private void ShowMainPage(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
		}
		private void ShowNewPapersPage(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("/Pages/NewPapersPage.xaml", UriKind.Relative));
		}

		private void ShowSearchPage(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("/Pages/SearchPage.xaml", UriKind.Relative));
		}

		private void ShowScientistsPage(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("/Pages/ScientistsPage.xaml", UriKind.Relative));
		}
        private void ShowAddNewPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("/Pages/AddNewPaper.xaml", UriKind.Relative));
        }
        private void ShowMyPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("/Pages/MyPapersPage.xaml", UriKind.Relative));
        }
        private void ShowAdminPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("/Pages/AdminPage.xaml", UriKind.Relative));
        }
        private void ProfileClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("/Pages/ProfilePage.xaml", UriKind.Relative));
        }
        public static void RequestShowEditPage()
        {
            ShowEditPageRequested?.Invoke(null, EventArgs.Empty);
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Visible;
            MainContentPanel.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Collapsed;
            usernameTextBox.Text = null;
            passwordBox.Password = null;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
