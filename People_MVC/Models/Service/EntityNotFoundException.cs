using System;

namespace People_MVC.Models.Service

{
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

       
    }
}