using System;

namespace Pharmacy_Management1.Models
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {

        }
    }
}