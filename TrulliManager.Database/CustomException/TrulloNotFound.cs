using System;
using System.Collections.Generic;
using System.Text;

namespace TrulliManager.Database.CustomException
{
    public class TrulloNotFound : Exception
    {
        public Guid TrulloId { get; set; }
    }
}
