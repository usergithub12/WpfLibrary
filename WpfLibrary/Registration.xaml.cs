﻿using System;
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
            User user = new User();

            try
            {
                if (tb_password.Text == tb_conf_password.Text)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                if (tb_login.Text == String.Empty)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }


            try
            {
                if (tb_password.Text.Count()>=6)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }




            user.Telephone = tb_telephone.Text;
            user.Password =  tb_password.Text;
            user.Login =     tb_login.Text;
            user.Email =     tb_email.Text;
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