using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Classes
{
    internal static class DataStorage
    {
        public static List<Sportsman> Sportsmen { get; } = new List<Sportsman>();
        public static List<Coaches> Coaches { get; } = new List<Coaches>();

        public static List<Gender> Gender { get; } = new List<Gender>()
        {
            new Gender() { Name="Мужской" },
            new Gender() { Name="Женский" }
        };
    }


}
