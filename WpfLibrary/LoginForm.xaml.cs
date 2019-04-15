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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();

           
        }

        private void Btn_sign_in_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Service1Client service1Client = new Service1Client();
                LoginUser loginUser = new LoginUser();
                loginUser.Login = tb_login.Text;
                loginUser.Password = tb_password.Text;
                service1Client.GetLoginUserforValidation(loginUser);
            }
            catch (FaultException<MyExceptionFault> err)
            {
                Console.WriteLine($"M - {err.Message}\nR - {err.Reason}\nS - {err.Source}");
                Console.WriteLine($"M - {err.Detail.Message}\nR - {err.Detail.Result}\nS - {err.Detail.Description}");
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

        }
    }
}
