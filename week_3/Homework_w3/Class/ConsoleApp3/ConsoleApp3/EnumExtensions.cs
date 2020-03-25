using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    static class EnumExtentions
    {
        public static T Sum<T>(this IEnumerable<T> Container)
        {
       
            dynamic sum = Container.Aggregate((total, next) => (dynamic)total + (dynamic)next);
   
             return sum;
        } 
        
        public static T Product<T>(this IEnumerable<T> Container)
        {
            dynamic product = Container.Aggregate((total, next) => (dynamic)total * (dynamic)next);

            return product;

        } 
        
        public static T Min<T>(this IEnumerable<T> Container)
        {
            dynamic min = Container.First();
            foreach (T Element in Container)
            {
                if(Element < min)
                {
                    min = Element;
                }
            }

            return min;

        }
        public static T Max<T>(this IEnumerable<T> Container)
        {
            dynamic max = Container.First();
            foreach (T Element in Container)
            {
                if(Element > max)
                {
                    max = Element;
                }
            }

            return max;
        }
        public static T Average<T>(this IEnumerable<T> Container)
        {
            dynamic sum = Container.Aggregate((total, next) => (dynamic)total + (dynamic)next);
            dynamic average = sum / Container.Count();

            return average;
        }
    }
}
