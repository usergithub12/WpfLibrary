using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Models
{

    [DataContract]
    public class User: LoginUser
    {
       
        [DataMember]
        public string PasswordConfirmation { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Telephone { get; set; }

    }
}