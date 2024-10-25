using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainCommon.Model
{
    /// <summary>
    /// 抽象值对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// 值对象一般来说比较字段值是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            var compareObj = obj as T;
            if (ReferenceEquals(compareObj, null)) return false;

            return EqualsCore(compareObj);
            

        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        /// <summary>
        /// 比较每个公共字段
        /// </summary>
        /// <param name="compareObj"></param>
        /// <returns></returns>
        protected virtual bool EqualsCore(ValueObject<T> compareObj) 
        {
            FieldInfo[] fields = GetPublicFields();
            bool isEqual = true;
            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                string selfValue = field.GetValue(this)?.ToString() ?? string.Empty;
                string compareValue = field.GetValue(compareObj)?.ToString() ?? string.Empty;
                isEqual = string.Equals(selfValue, compareValue);
                if (!isEqual) break;
            }
            return isEqual;
        }


        /// <summary>
        /// 获取每个公共字段的hashcode
        /// </summary>
        /// <param name="compareObj"></param>
        /// <returns></returns>
        protected virtual int GetHashCodeCore() 
        {
            int hashCodeResult = 0;
            FieldInfo[] fields = GetPublicFields();
            foreach (var field in fields)
            {
                string value = field.GetValue(this)?.ToString() ?? string.Empty;
                hashCodeResult += hashCodeResult.GetHashCode();
            }
            return hashCodeResult;

        }


        /// <summary>
        /// 获取这个类所有的共有字段
        /// </summary>
        /// <returns></returns>
        protected FieldInfo[] GetPublicFields() 
        {
            Type type = this.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            return fields;
        }



        /// <summary>
        /// 重写方法 实体比较 ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        /// <summary>
        /// 重写方法 实体比较 !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 克隆副本
        /// </summary>
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }


    }
}
