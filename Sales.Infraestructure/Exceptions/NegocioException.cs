﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Exceptions
{
    public class NegocioException : Exception
    {
        public NegocioException(string? message) : base(message)
        {
        }
    }
}
