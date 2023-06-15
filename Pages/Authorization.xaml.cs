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

namespace ООО__Руль_.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginTextBox.Text;
            var password = PasswordBox.Password;

            var user = Entities.GetContext().User.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            if(user!=null)
            {
                if(user.Role=="Администратор")
                {
                    this.NavigationService.Navigate(new AdminProduct());
                }
                else if (user.Role == "Менеджер")
                {
                    this.NavigationService.Navigate(new AdminProduct());
                }
                else if (user.Role == "Клиент")
                {
                    this.NavigationService.Navigate(new AdminProduct());
                }
            }
            else
            {
                MessageBox.Show("Такой пользователь не найден");
            }
        }

        private void OK_ButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
