using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public static class ListExtension
    {
        /// <summary>
        /// Проверяет находятся ли в колекции элементы из другой колекции
        /// </summary>
        /// <param name="ilist">Начальная коллекция</param>
        /// <param name="list">Коллекция для сравнения</param>
        /// <returns></returns>
        public static bool ContainsList(this IList ilist, List<int> list)
        {
            foreach (var item in list)
            {
                if (ilist.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Проверяет находятся ли в колекции элементы из другой колекции
        /// </summary>
        /// <param name="ilist">Начальная коллекция</param>
        /// <param name="list">Коллекция для сравнения</param>
        /// <returns></returns>
        public static bool ContainsList(this IList ilist, List<string> list)
        {
            foreach (var item in list)
            {
                if (ilist.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Information(this IList ilist)
        {
            foreach (var item in ilist)
            {
                Console.WriteLine(item);
            }
        }

        public static string RemoveLastChar(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            else
            {
                return text.Remove(text.Length - 1);
            }
        }

        
    }
}
