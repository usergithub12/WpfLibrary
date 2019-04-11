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

using WpfLibrary.ServiceNS;

namespace WpfLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {

            // Service1 service1 = new Service1();
            Service1Client service1Client = new Service1Client();
            Book book = new Book();
            book.Title = tb_title.Text;
            book.Author = tb_author.Text;
            book.Pages = int.Parse(tb_pages.Text);
            book.Id = int.Parse(tb_id.Text);
            service1Client.GetBookfromDB(book);
        }

        private void Btn_data_Click(object sender, RoutedEventArgs e)
        {
            lb_data.Items.Clear();
            Service1Client service1Client = new Service1Client();
            foreach (var item in service1Client.GetBooks())
            {
                string temp = item.Id +" " + item.Title + " " + item.Author + " " + item.Pages;
                lb_data.Items.Add(temp); 
            }
            
        }
    }
}
