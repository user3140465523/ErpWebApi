using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Dal
{
    public static class UtilityHelper
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
                        if (value is bool)
                        {
                            p.SetValue(model,Convert.ToInt32(value), null);
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

        public static List<T> ToDataList<T>(DataTable dt) {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                var s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    var info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info !=null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {

                            throw new Exception($"字段['{info.Name}']转换出错，ex:{ex.Message}");
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }
        //懒得写s
    }
}
