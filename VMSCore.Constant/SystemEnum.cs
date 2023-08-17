using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace VMSCore.Common.Enums
{
    public static class SystemEnum
    {
        public enum ModuleType
        {
            [Description("DESKTOP")]
            DESKTOP,

            [Description("WEB")]
            WEB,

            [Description("MOBILE")]
            MOBILE
        }

        public enum GroupType
        {
            [Description("GROUP")]
            GROUP,

            [Description("TERMINAL")]
            TERMINAL
        }

        public enum PermissionType
        {
            [Description("Corporation")]
            Corporation,

            [Description("Company")]
            Company,

            [Description("Plant")]
            Plant,

            [Description("Workshop")]
            Workshop,

            [Description("Line")]
            Line
        }

        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static List<string> EnumToList<TEnum>()
        {
            List<string> enumList = new List<string>();
            Type enumType = typeof(TEnum);

            foreach (var value in Enum.GetValues(enumType))
            {
                string description = GetEnumDescription(enumType, value);
                enumList.Add(description);
            }

            return enumList;
        }

        public static string GetEnumDescription(Type enumType, object value)
        {
            string name = Enum.GetName(enumType, value);

            FieldInfo field = enumType.GetField(name);
            if (field == null)
            {
                return null;
            }

            var descriptionAttribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute), false);
            return descriptionAttribute != null ? descriptionAttribute.Description : name;
        }
    }
}
