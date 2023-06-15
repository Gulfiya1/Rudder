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
using ООО__Руль_.Window;

namespace ООО__Руль_.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminProduct.xaml
    /// </summary>
    public partial class AdminProduct : Page
    {
        public AdminProduct()
        {
            InitializeComponent();
            list.ItemsSource = Entities.GetContext().Product.ToList();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem == null)
            {
                MessageBox.Show("Выберите поле", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var delete = MessageBox.Show("Вы действительно хотите удалить данную запись?", "", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                if (delete == MessageBoxResult.OK)
                {
                    var t = list.SelectedItems.Cast<Product>().ToList();
                    Entities.GetContext().Product.RemoveRange(t);
                    Entities.GetContext().SaveChanges();
                    list.ItemsSource = Entities.GetContext().Product.ToList();
                }
            }
        }

        private void InsertButton(object sender, RoutedEventArgs e)
        {
            var t = list.SelectedItem as Product;
            if (t == null)
            {
                MessageBox.Show("Выбберите поле для редактирования");

            }
            EditingProduct et = new EditingProduct(t, list); et.Show();
        }
    }
}
