using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Sample.Common.Constants;

namespace Sample.Common.Exceptions
{
    [Serializable]
    public class BaseException : Exception
    {
        public string ClientId { get; set; }

        public BaseException() { }

        public BaseException(string message) : base(message) { }

        public BaseException(string message, Exception exception) : base(message, exception) { }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ClientId = info.GetString(InputRequest.FieldNameClientId);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(InputRequest.FieldNameClientId, ClientId, typeof(string));

            base.GetObjectData(info, context);
        }
    }
}