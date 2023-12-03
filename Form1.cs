using Guna.UI2.WinForms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Media;

namespace HotelManagement
{
    public partial class Form1 : Form
    {
        private DatabaseManager databaseManager;
        private int loginAttempts = 0;
        private SoundPlayer successSoundPlayer;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source = LAPTOP - 6H42QTM4\\SQLEXPRESS; Initial Catalog = dbMyHotel; Integrated Security = True";
            databaseManager = new DatabaseManager(connectionString);
            successSoundPlayer = new SoundPlayer("C:\\Users\\TRUNG DUC\\Downloads\\Từ-Thích-Thích-Thành-Thương-Thương-AMee-Hoàng-Dũng.wav");
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string enteredUsername = txt_username.Text;
            string enteredPassword = txt_passowrd.Text;


            if (databaseManager.AuthenticateUser(enteredUsername, enteredPassword))
            {
                //phát âm thanh 
                successSoundPlayer.Play();
                // Nếu xác thực thành công, đặt lại số lần nhập sai
                loginAttempts = 0;

                // Mở Dashboard
                DashBoard ds = new DashBoard();
                this.Hide();
                ds.Show();
            }
            else
            {
                // Tăng số lần nhập sai
                loginAttempts++;

                if (loginAttempts >= 3)
                {
                    // Nếu nhập sai quá 3 lần, đóng ứng dụng
                    MessageBox.Show("Bạn đã nhập sai mật khẩu quá 3 lần. Ứng dụng sẽ thoát.");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tên người dùng và mật khẩu.");
                }
            }
        }

    private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}