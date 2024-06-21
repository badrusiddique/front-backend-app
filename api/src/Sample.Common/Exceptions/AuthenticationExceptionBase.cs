using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Sample.Common.Exceptions
{
    [Serializable]
    public class AuthenticationExceptionBase : BaseException
    {
        private const string FieldNameDocId = "HttpRequest";

        public string HttpRequest { get; set; }

        public AuthenticationExceptionBase() { }

        public AuthenticationExceptionBase(string message) : base(message) { }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected AuthenticationExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            HttpRequest = (string)info.GetValue(FieldNameDocId, typeof(string));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(FieldNameDocId, HttpRequest, typeof(string));

            base.GetObjectData(info, context);
        }
    }
}