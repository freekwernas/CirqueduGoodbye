﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Train
    {
        public Train()
        {
            TrainWagons = new HashSet<TrainWagon>();
        }

        public int Id { get; set; }

        public virtual ICollection<TrainWagon> TrainWagons { get; set; }
    }
}