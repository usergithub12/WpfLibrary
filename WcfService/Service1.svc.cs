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
using WcfService.ExceptionsFault;
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

        public void GetLoginUserforValidation(string login, string password)
        {
            using (LibraryBooks books = new LibraryBooks())
            {
                try
                {
                    var t = books.Users.FirstOrDefault(u => u.Login == login);
                    if(t==null)
                    {
                        throw new UserExistsInDatabaseException();
                    }
                }
                catch (UserExistsInDatabaseException err)
                {
                    MyExceptionFault ex = new MyExceptionFault();
                    ex.Result = false;
                    ex.Message = err.Message;
                    ex.Description = "Htos' naplyguv, ajajaj ((((";
                    throw new FaultException<MyExceptionFault>(ex, new FaultReason(" user not exists in database"));
                }

                try
                {
                    foreach (var item in books.Users)
                    {
                        if (item.Password == password)
                        {

                            throw new PasswordEqualsInDataBaseException();


                        }
                    }
                }
                catch (PasswordEqualsInDataBaseException err)
                {

                    PasswordEqualsInDataBaseExceptionFault ex = new PasswordEqualsInDataBaseExceptionFault();
                    ex.Result = false;
                    ex.Message = err.Message;
                    ex.Description = "Htos' naplyguv, ajajaj ((((";
                    throw new FaultException<PasswordEqualsInDataBaseExceptionFault>(ex, new FaultReason(" passwords not equals"));
                }
               
            }


        }

        public void GetUserforValidation(User user)
        {
            try
            {
                if (user.Login == String.Empty || user.Login == null || Regex.IsMatch(user.Login, @"\p{IsCyrillic}"))
                {
                    throw new EmptyCyrilicLoginException();
                }
            }
            catch (EmptyCyrilicLoginException err)
            {
                EmptyCyrilicLoginExceptionFault ex = new EmptyCyrilicLoginExceptionFault();
                ex.Result = false;
                ex.Message = err.Message;
                ex.Description = "Htos' naplyguv, ajajaj ((((";

                throw new FaultException<EmptyCyrilicLoginExceptionFault>(ex, new FaultReason(" field empty or has cyrilyc characters"));
            }

            try
            {

                if (user.Password != user.PasswordConfirmation)
                {
                    throw new PasswordConfirmationException();
                }
            }
            catch (PasswordConfirmationException err)
            {
                PasswordConfirmationExceptionFault ex = new PasswordConfirmationExceptionFault();
                ex.Result = false;
                ex.Message = err.Message;
                ex.Description = "Htos' naplyguv, ajajaj ((((";

                throw new FaultException<PasswordConfirmationExceptionFault>(ex, new FaultReason(" pass!=pass conf"));
            }

            try
            {
                if (user.Password.Length >= 6)
                {
                    throw new PasswordIndexOutOfRangeException();
                }
            }
            catch (PasswordIndexOutOfRangeException err)
            {
                PasswordIndexOutOfRangeExceptionFault ex = new PasswordIndexOutOfRangeExceptionFault();
                ex.Result = false;
                ex.Message = err.Message;
                ex.Description = "Htos' naplyguv, ajajaj ((((";

                throw new FaultException<PasswordIndexOutOfRangeExceptionFault>(ex, new FaultReason(" over 6 characters in pass"));
            }

            try
            {
                if (Regex.IsMatch(user.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                {
                    throw new PasswordSpecificCharactersException();
                }
            }
            catch (PasswordSpecificCharactersException err)
            {
                PasswordSpecificCharactersExceptionFault ex = new PasswordSpecificCharactersExceptionFault();
                ex.Result = false;
                ex.Message = err.Message;
                ex.Description = "Htos' naplyguv, ajajaj ((((";

                throw new FaultException<PasswordSpecificCharactersExceptionFault>(ex, new FaultReason(" specific characters in pass"));
            }

            try
            {
                if (user.Email == null||String.IsNullOrEmpty(user.Email))
                {
                    MailAddress m = new MailAddress(user.Email);
                    throw new EmailFormatException();
                }
            }
            catch (EmailFormatException err)
            {
                EmailFormatExceptionFault ex = new EmailFormatExceptionFault();
                ex.Result = false;
                ex.Message = err.Message;
                ex.Description = "Htos' naplyguv, ajajaj ((((";

                throw new FaultException<EmailFormatExceptionFault>(ex, new FaultReason(" wrond email format"));
            }

            try
            {
                if (String.IsNullOrEmpty(user.Telephone))
                {
                    var r = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
                    r.IsMatch(user.Telephone);
                    throw new PhoneFormatException();
                }

            }
            catch (PhoneFormatException err)
            {
                PhoneFormatExceptionFault ex = new PhoneFormatExceptionFault();
                ex.Result = false;
                ex.Message = err.Message;
                ex.Description = "Htos' naplyguv, ajajaj ((((";

                throw new FaultException<PhoneFormatExceptionFault>(ex, new FaultReason(" wrong phone format"));
            }
            using (LibraryBooks books = new LibraryBooks())
            {
                books.Users.Add(user);
                books.SaveChanges();
            }
        }
    }
}
