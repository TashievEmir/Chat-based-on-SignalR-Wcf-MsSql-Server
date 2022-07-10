using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
    public static class Colors
    {
        static string[] colors =
        {
            "red",
            "blue",
            "black",
            "green",
            "pink",
            "purple",
            "brown",
            "gray",
            "yellow",
            "orange"
        };
        public static string generateColor()
        {
            Random random=new Random();
            int num = random.Next(1, colors.Length);
            return colors[num];
        }
    }
}