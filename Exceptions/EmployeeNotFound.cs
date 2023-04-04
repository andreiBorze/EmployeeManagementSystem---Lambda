using System;
using System.Runtime.Serialization;

namespace EmployeeManagementSystem____Lambda
{
    [Serializable]
    internal class EmployeeNotFound : Exception
    {
        private Guid id;

        public EmployeeNotFound()
        {
        }

        public EmployeeNotFound(Guid id)
        {
            this.id = id;
        }

        public EmployeeNotFound(string message) : base(message)
        {
        }

        public EmployeeNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}