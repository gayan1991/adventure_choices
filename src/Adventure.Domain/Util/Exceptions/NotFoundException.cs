using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.Util.Exceptions
{
    public class NotFoundException : Exception
    {
        public Guid Id { get; set; }

        public NotFoundException() { }

        /// <summary>
        ///  Use this to handle for not found scenario
        /// </summary>
        /// <param name="message">Information that wants to be passed</param>
        public NotFoundException(string message) : base(message)
        { }

        /// <summary>
        /// Use this to handle if an object for the Id is not found
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="message">Extra information</param>
        public NotFoundException(Guid id, string message) : base($"{id} is not found. {message}")
        {
            Id = id;
        }
    }
}
