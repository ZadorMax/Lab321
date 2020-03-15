using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03CSharp.Models.Exceptions
{
    class BornInFutureException : ArgumentException
    {
        public DateTime Value { get; }
        public BornInFutureException(string message, DateTime val)
        : base(message)
        {
            Value = val;
        }
    }
    class IncorrectEmailException : ArgumentException
    {
        public string Value { get; }
        public IncorrectEmailException(string message, string val): base(message)
        {
            Value = val;
        }
    }
    class IncorrectBirthDateException : ArgumentException
    {
        public DateTime Value { get; }
        public IncorrectBirthDateException(string message, DateTime val) : base(message)
        {
            Value = val;
        }
    }
}