using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	public class DatabaseHelper
	{
		public static string ConnectionString { get; } = "Data Source=DESKTOP-L7EKRDR;Initial Catalog=ResearchPapers;User ID=nikita;Password=nikita;";

		public static SqlConnection GetConnection()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection;
		}
	}
