using System.Data.SqlClient;

public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool AuthenticateUser(string username, string password)
    {
        string connectionString = "Data Source = LAPTOP-6H42QTM4\\SQLEXPRESS; Initial Catalog = dbMyHotel; Integrated Security = True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                // Sử dụng ExecuteScalar để lấy giá trị đầu tiên từ kết quả truy vấn
                int count = Convert.ToInt32(command.ExecuteScalar());

                // Trả về true nếu có ít nhất một bản ghi trùng khớp
                return count > 0;
            }
        }
    }
}
