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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var n = Name.Text;
            var j = discription.Text;
            var c = maker.Text;
            var z = Convert.ToInt32(cost.Text);
            var v = image.Text;
            var xc = Convert.ToInt32(discount.Text);

            var d = new Product();
            d.Name = n;
            d.Discription = j;
            d.Maker = c;
            d.Cost = z;
            d.Max_Discount = xc;
            d.Image = v;
           
           Entities.GetContext().Product.Add(d);
            Entities. GetContext().SaveChanges();
            MessageBox.Show("Данные сохранены");
            this.NavigationService.GoBack();
        }
    }
}
