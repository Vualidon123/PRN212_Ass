
using System.Windows;
using BO;
using Service;

namespace WpfApp
{
    public partial class Login : Window
    {
        private readonly UserService _userService;

        public Login()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;
           
            var user = _userService.Login(email, password);
            if (user != null)
            {
                if (user.RoleId == 1)
                {
                    GLOBAL.UserId = user.Id;
                    Menu menu = new Menu();
                    menu.Show();
                }
                else if (user.RoleId == 2)
                {
                    Shop_management shop_Management = new Shop_management();
                    shop_Management.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}