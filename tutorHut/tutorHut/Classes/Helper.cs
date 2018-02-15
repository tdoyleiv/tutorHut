using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutorHut.Classes
{
    public class Helper
    {
        public string LogicConversionOne(string parameter)
        {
            var array = parameter.ToString().Split(null);
            for (int i = 1; i < array.Length; i++)
            {
                var result = "+" + array[i];
            }
            return array.ToString();
        }
        public string LogicConversionTwo(string parameter)
        {
            var array = parameter.ToString().Split(null);
            for (int i = 0; i < array.Length; i++)
            {
                var result = "+" + array[i];
            }
            return array.ToString();
        }
    }
}