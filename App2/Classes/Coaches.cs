﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Classes
{
    public class Coaches
    {
            public int Id { get; }
            public string Name { get; set; } = "";

             public Gender Gender { get; set; } = DataStorage.Gender[0];
             public DateTime BirthDate { get; set; } = DateTime.Now;

            public Coaches() 
            {
                Id = sportsmanCount++;
            }

            private static int sportsmanCount = 1;
    }
}
