using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Generator
{
    public static class ValueGenerators
    {
        public static object GetType(Type type)
        {
            object a = 0;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                int count = 2;

                for (int i = 0; i < count; i++)
                {
                    ((IList)list).Add(ValueGenerators.GetType(type));
                }
                return list;
            }
            else if (type == typeof(DateTime))
            {
                a = DateTime.Now;
            }
            else if (type.IsValueType)
            {
                a = GenerateRandomValueType(type);
            }
            else if (type == typeof(String))
            {
                a = "fghgfds";
            }

            return a;
        }

        private static ValueType GenerateRandomValueType(Type type)
        {
            Random rand = new Random();
            if (type == typeof(int))
            {
                return rand.Next(10, 1000);
            }

            if (type == typeof(double))
            {
                return rand.Next();
            }
            
            if (type == typeof(float))
            {
                return rand.Next();
            }

            return 0;
        }
    }
}