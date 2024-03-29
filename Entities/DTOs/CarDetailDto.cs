﻿using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public static implicit operator CarDetailDto(List<CarDetailDto> v)
        {
            throw new NotImplementedException();
        }
    }
}