using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.ExceptionsFault
{
    [Serializable]
    [DataContract]
    public class EmailFormatExceptionFault
    {
      
            [DataMember]
            public bool Result { get; set; }

            [DataMember]
            public string Message { get; set; }

            [DataMember]
            public string Description { get; set; }
       
    }
}