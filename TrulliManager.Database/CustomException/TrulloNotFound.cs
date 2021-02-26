using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Text;

namespace TrulliManager.Database.CustomException
{
    public class TrulloNotFound : Exception
    {
        public string TrulloId { get; set; }
    }
}
