﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopLemming.Core.Domain
{
    public class FileToApi
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? RealEstateId { get; set; }
    }
    public class CarFileToApi
    {
        public Guid Id { get; set; }
        public string CarExistingFilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}
