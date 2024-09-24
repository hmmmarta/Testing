using System.Data.SqlClient;
using AnalaizerClassLibrary;

namespace testing_lab1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsOperatorFromDB()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-B6V0R6SV\SQLEXPRESS;Initial Catalog=DBLibraryCalc;Integrated Security=True;Connect Timeout=30") )
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select operator, boolean from IsOperatorTable", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string symbol = reader.GetString(0);
                    bool expBoolean = Convert.ToBoolean(reader.GetInt32(1));
                    bool result = AnalaizerClass.IsOperator(symbol);
                    Assert.AreEqual(result, expBoolean);
                }
                reader.Close();
            }
        }

        [TestMethod]
        public void InsertSymbolFromDB()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-B6V0R6SV\SQLEXPRESS;Initial Catalog=DBLibraryCalc;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select input, symbol, position, output from InsertSymbolTable", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string input = reader.GetString(0);
                    char symbol = Convert.ToChar(reader.GetString(1));
                    int position = reader.GetInt32(2);
                    string expOutput = reader.GetString(3);
                    string result = AnalaizerClass.InsertSymbol(input, symbol, position);
                    Assert.AreEqual(result, expOutput);
                }
                reader.Close();
            }
        }

    }
}