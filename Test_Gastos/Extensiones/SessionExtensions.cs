using System;
using Newtonsoft.Json;
using System.Text;
namespace Test_Gastos
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T? value)
        {
            session.Remove(key);
            if (value != null)
                session.SetString(key, SerializeObject(value));
        }
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : DeserializeObject<T>(value);
        }
        public static void Remove(this ISession session, string key)
        {
            session.Remove(key);
        }
        public static string SerializeObject(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                throw;
            }
        }
        public static T? DeserializeObject<T>(string json)
        {
            try
            {
                T? result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch
            {
                throw;
            }
        }        
    }
}

