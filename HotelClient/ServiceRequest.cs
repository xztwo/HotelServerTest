﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
