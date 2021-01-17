using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBTemplate.Core.Models.Common
{
    public class AppSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
