using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.ExceptionsFault;
using WcfService.Models;

namespace WcfService
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(EmailFormatExceptionFault))]
        [FaultContract(typeof(EmptyCyrilicLoginExceptionFault))]
        [FaultContract(typeof(PasswordConfirmationExceptionFault))]
        [FaultContract(typeof(PasswordIndexOutOfRangeExceptionFault))]
        [FaultContract(typeof(PasswordSpecificCharactersExceptionFault))]
        [FaultContract(typeof(PhoneFormatExceptionFault))]
        void GetUserforValidation(User user);

        [OperationContract]
        void GetBookfromDB(Book b);

        [OperationContract]
        Book[] GetBooks();

        [OperationContract]
        [FaultContract(typeof(MyExceptionFault))]
        [FaultContract(typeof(PasswordEqualsInDataBaseExceptionFault))]
        void GetLoginUserforValidation(string login, string password);


       
     
        
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
