using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TestApi.Common
{
    public static class DataTableHelper
    {
        /// <summary>
        /// DataTable转换List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T:class,new()
        {
            var fileds = typeof(T).GetProperties();
            List<T> list = new List<T>();
            foreach (DataRow item in dt.Rows)
            {
                T model = new T();
                foreach (var info in fileds)
                {
                    if (dt.Columns.Contains(info.Name))
                    {
                        object value = item[info.Name];
                        if (value != DBNull.Value)
                        {
                            info.SetValue(model, value);
                        }
                    }
                }
                list.Add(model);
            }
            return list;
        }
    }
}