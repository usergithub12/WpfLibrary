using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WpfLibrary.ServiceNS;

namespace WpfLibrary
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            try
            {
               
                User user = new User();
                user.Telephone = tb_telephone.Text;
                user.Password = tb_password.Text;
                user.PasswordConfirmation = tb_conf_password.Text;
                user.Login = tb_login.Text;
                user.Email = tb_email.Text;

                client.GetUserforValidation(user);
            }
          
            catch (FaultException<MyExceptionFault> err)
            {
                MessageBox.Show($"M - {err.Message}\nR - {err.Reason}\nS - {err.Source}");
               // Console.WriteLine($"M - {err.Detail.Message}\nR - {err.Detail.Result}\nS - {err.Detail.Description}");
            }
            catch (FaultException fe)
            {
                Console.WriteLine($"Halepa - {fe}");
            }
            catch (NullReferenceException err)
            {
                Console.WriteLine("Htos ne vudiluv pamjati");
            }
            catch (Exception)
            {
                Console.WriteLine("Useless block");

            }
           
            foreach (var item in st_checkboxes.Children.OfType<CheckBox>())
            {
                item.IsChecked = true;
            }


          
                LoginForm loginForm = new LoginForm();

                loginForm.ShowDialog();
           
          
              //  this.Close();
        }

        private void Btn_reset_Click(object sender, RoutedEventArgs e)
        {
            tb_telephone.Text=String.Empty;
             tb_password.Text=String.Empty;
                tb_login.Text=String.Empty;
              tb_email.Text = String.Empty;
        }
    }
}
