using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public class CreationException : Exception
    {

        public CreationException(string msg) : base(msg)
        {

        }
    }
}
