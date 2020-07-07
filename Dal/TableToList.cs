using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ErpWebApi.Utility
{
    public static class Utility
    {
        /// <summary>
        /// 将DataTable转为list集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> TableTolist<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] properties = type.GetProperties();
                T model = new T();
                foreach (PropertyInfo p in properties)
                {
                    object value = row[p.Name];
                    if (value == DBNull.Value)
                    {
                        p.SetValue(model, "", null);
                    }
                    else
                    {
                        if (value is decimal)
                        {
                            p.SetValue(model, Convert.ToInt32(value), null);
                        }
                        else
                        {
                            p.SetValue(model, value, null);
                        }
                    }
                }
                list.Add(model);
            }
            return list;
        }

        //懒得写
    }
}
