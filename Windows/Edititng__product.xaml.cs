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
using System.Windows.Shapes;

namespace ООО__Руль_
{
    /// <summary>
    /// Логика взаимодействия для Edititng__product.xaml
    /// </summary>
    public partial class Edititng__product : Window
    {
        Product p; ListBox l;
        public Edititng__product(Product p1, ListBox l1)
        {
            InitializeComponent();
            p = p1;
            l = l1;
            DataContext = p;
        }

        private void InsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                l.ItemsSource = null;
                l.ItemsSource = Entities.GetContext().Product.ToList();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка !: " + ex.Message, "Ошибка выполнения команды", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
