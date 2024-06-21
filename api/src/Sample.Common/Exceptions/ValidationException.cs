using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Sample.Common.Exceptions
{
    [Serializable]
    public class ValidationException : BaseException
    {
        public ValidationException() { }

        public ValidationException(string message) : base(message) { }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            base.GetObjectData(info, context);
        }
    }
}