﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAnimal
    {
        int Id { get; } 
        int Size { get; }
        string Name { get; }
    }
}
