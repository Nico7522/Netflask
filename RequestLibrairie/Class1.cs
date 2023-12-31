﻿using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace RequestLibrairie
{
	public class RequestDatabase
	{
		/// <summary>
		/// Retrieve the data from a table
		/// </summary>
		/// <param name="cs">connection string</param>
		/// <param name="table">table from database</param>
		/// <returns>Return a list of object that contain the data</returns>
		public List<object> GetData(string cs, string table)
		{
			List<object> result = new List<object>();

			using (SqlConnection c = new SqlConnection(cs))
			{
				using (SqlCommand cmd = c.CreateCommand())
				{

					cmd.CommandText = $"SELECT * FROM {table}";
					cmd.CommandType = CommandType.Text;

					c.Open();

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{

							for (int i = 0; i < reader.FieldCount; i++)
							{
							result.Add(reader[i]);
							}
						}
					}

					c.Close();
				}
			}
			return result;
		}

		//public void SetData(string cs, string table, params object[] values )
		//{

		//	string ph = $"INSERT INTO {table} VALUES (";
  //          for (int i = 0; i < values.Length; i++)
  //          {
		//		if (i == values.Length - 1)
		//		{
		//			ph = ph + $"'{values[i]}');";
		//		}
		//		else
		//		{
		//			ph = ph + $"'{values[i]}',";
		//		}
		//	}
		//	Console.WriteLine(ph);
		//	using (SqlConnection c = new SqlConnection(cs))
		//	{
		//		using (SqlCommand cmd = c.CreateCommand())
		//		{
		//			c.Open();
		//			SqlTransaction trans = c.BeginTransaction();
		//			cmd.Transaction = trans;

		//			try {
		//				cmd.CommandText = ph;
		//				cmd.CommandType = CommandType.Text;
		//				cmd.ExecuteNonQuery();
		//				trans.Commit();
  //                      Console.WriteLine("Ok");
  //                  }
		//			catch(Exception e) {
  //                      Console.WriteLine("Error");
  //                  }
					
		//				c.Close();
		//		}
		//	}


		//}

		public void SetData<T>(string cs, string table, T item)
		{
			Type type = item.GetType();
			PropertyInfo[] properties = type.GetProperties();

			string ph = $"INSERT INTO {table} VALUES (";
			for (int i = 0; i < properties.Length; i++)
			{
				if (i == properties.Length - 1)
				{
					ph = ph + $"'{properties[i].GetValue(item)}');";
				}
				else
				{
					ph = ph + $"'{properties[i].GetValue(item)}',";
				}
			}
			Console.WriteLine(ph);
			using (SqlConnection c = new SqlConnection(cs))
			{
				using (SqlCommand cmd = c.CreateCommand())
				{
					c.Open();
					SqlTransaction trans = c.BeginTransaction();
					cmd.Transaction = trans;

					try
					{
						cmd.CommandText = ph;
						cmd.CommandType = CommandType.Text;
						cmd.ExecuteNonQuery();
						trans.Commit();
						Console.WriteLine("Ok");
					}
					catch (Exception e)
					{
						Console.WriteLine("Error");
					}

					c.Close();
				}
			}


		}

		public static void AddItem<T>(string connectionString, string commandText, CommandType cType, T item, params string[] parameters)
		{
			Type type = item.GetType();
			PropertyInfo[] properties = type.GetProperties();


			using (SqlConnection c = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = c.CreateCommand())
				{
					c.Open();
					cmd.CommandType = cType;
					cmd.CommandText = commandText;

					int incrParameters = 0;

					for (int i = 0; i < properties.Length; i++)
					{
						if (!properties[i].Name.Contains("id"))
						{
							if (properties[i].GetValue(item)?.GetType() == typeof(DateTime))
							{
								cmd.Parameters.AddWithValue($"@{parameters[incrParameters]}", $"{properties[i].GetValue(item):yyyy-MM-dd}");
							}
							else
							{
								cmd.Parameters.AddWithValue($"@{parameters[incrParameters]}", $"{properties[i].GetValue(item)}");
							}
							incrParameters++;
						}
					}
					SqlParameter outputParameter = new SqlParameter("@Identity", SqlDbType.Int);
					outputParameter.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(outputParameter);
					cmd.ExecuteNonQuery();
					int newCardID = (int)outputParameter.Value;

					//Console.WriteLine($"L'id de la carte avec Parameter.Direction {newCardID}");
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						Console.WriteLine();
						Console.WriteLine("Inserted with success, details of the new item :");
						while (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
							{

								Console.WriteLine(reader[i]);
							}
						}
					}

				}
			}
		}
	}
}

