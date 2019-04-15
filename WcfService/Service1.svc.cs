using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using WcfService.Exceptions;
using WcfService.Models;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public partial class Service1 : IService1
    {

       

        public void GetBookfromDB(Book b)
        {
            using (LibraryBooks books = new LibraryBooks())
            {
                books.Books.Add(b);
                books.SaveChanges();
            }
        }

        public Book[] GetBooks()
        {
            using (LibraryBooks books = new LibraryBooks())
            {
                return books.Books.ToArray();
            }

        }

        public void GetLoginUserforValidation(LoginUser loginUser)
        {
            using (LibraryBooks books = new LibraryBooks())
            {
                try
                {
                    foreach (var item in books.LoginUsers)
                    {
                        if (item.Login == loginUser.Login)
                        {
                            throw new UserExistsInDatabaseException();
                        }
                    }
                }
                catch (UserExistsInDatabaseException err)
                {
                    MyExceptionFault ex = new MyExceptionFault();
                    ex.Result = false;
                    ex.Message = err.Message;
                    ex.Description = "Htos' naplyguv, ajajaj ((((";
                    throw new FaultException<MyExceptionFault>(ex, new FaultReason(" bebebe"));
                }

                try
                {
                    foreach (var item in books.LoginUsers)
                    {
                        if (item.Password == loginUser.Password)
                        {

                            throw new PasswordEqualsInDataBaseException();


                        }
                    }
                }
                catch (PasswordEqualsInDataBaseException err)
                {

                    MyExceptionFault ex = new MyExceptionFault();
                    ex.Result = false;
                    ex.Message = err.Message;
                    ex.Description = "Htos' naplyguv, ajajaj ((((";
                    throw new FaultException<MyExceptionFault>(ex, new FaultReason(" bebebe"));
                }


            }
        }

        public void GetUserforValidation(User user)
        {

            
          
                if (user.Login != String.Empty&&user.Login!=null&&!Regex.IsMatch(user.Login, @"\p{IsCyrillic}"))
                {
                   throw new NullReferenceException();
                }
          
        

           
                if (user.Password==user.PasswordConfirmation)
                {
                throw new FaultException();
            }
           
            //catch (Exception err)
            //{
            //    MyWcfSuperPuperException ex = new MyWcfSuperPuperException();
            //    ex.Result = false;
            //    ex.Message = err.Message;
            //    ex.Description = "Htos' naplyguv, ajajaj ((((";

            //    throw new FaultException<MyWcfSuperPuperException>(ex, new FaultReason(" bebebe"));
            //}



            
                if (user.Password.Length>=6)
                {
                throw new IndexOutOfRangeException();
                }
           
           

           
                if (Regex.IsMatch(user.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                {
                throw new FaultException();
                }




            if (user.Email != null)
            {
                MailAddress m = new MailAddress(user.Email);
                throw new FormatException();
            }



            if (string.IsNullOrEmpty(user.Telephone))
            {
                var r = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
                r.IsMatch(user.Telephone);
                throw new FaultException();
            }
        }
    }
}
