using BO;
using Service;
using System.Windows;

namespace WpfApp
{
    public partial class Register : Window
    {
        private readonly IUserService _userService;

        public Register()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var name = NameTextBox.Text;
            var password = PasswordBox.Password;


            var user = new User
            {
                Email = email,
                Name = name,
                Password = password,
                RoleId = 1 
            };

            try
            {
                _userService.Register(user);
                MessageBox.Show("Registration successful!");
                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}