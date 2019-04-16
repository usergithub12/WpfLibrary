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
               
                service1Client.GetLoginUserforValidation(tb_login.Text,tb_password.Text);
            }
            catch (FaultException<MyExceptionFault> err)
            {
                MessageBox.Show($"M - {err.Message}\nR - {err.Reason}\nS - {err.Source}");
                MessageBox.Show($"M - {err.Detail.Message}\nR - {err.Detail.Result}\nS - {err.Detail.Description}");
            }
            catch (FaultException<PasswordEqualsInDataBaseExceptionFault>err)
            {
                MessageBox.Show($"M - {err.Message}\nR - {err.Reason}\nS - {err.Source}");
                MessageBox.Show($"M - {err.Detail.Message}\nR - {err.Detail.Result}\nS - {err.Detail.Description}");
            }
            catch (FaultException fe)
            {
                MessageBox.Show($"Halepa - {fe}");
            }
            catch (NullReferenceException err)
            {
               MessageBox.Show("Htos ne vudiluv pamjati");
            }
            catch (Exception)
            {
                MessageBox.Show("Useless block");

            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
           
        }

        private void Btn_sign_up_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
