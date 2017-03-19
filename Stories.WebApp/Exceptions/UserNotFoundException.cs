using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Exceptions
{

    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found") { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected UserNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}