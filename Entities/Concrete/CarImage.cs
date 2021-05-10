using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        int CarImageId { get; set; }
        int CarId { get; set; }
        string ImagePath { get; set; }
        DateTime Date { get; set; }

    }
}
