using System.ComponentModel;
using System.Linq;
using EnsureThat;

namespace Sample.Common.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// get enum by description
        /// </summary>
        /// <typeparam name="TEnum">enum type</typeparam>
        /// <param name="description">enum description</param>
        /// <returns>enum</returns>
        public static TEnum? GetEnumByDescription<TEnum>(string description) where TEnum : struct
        {
            var type = typeof(TEnum);
            EnsureArg.IsNotNullOrEmpty(description, nameof(description), o => o.WithMessage("invalid description field"));
            EnsureArg.IsTrue(type.IsEnum, nameof(TEnum), o => o.WithMessage("input parser should be an enum type"));

            var field = type.GetFields()
                .SelectMany(f => f.GetCustomAttributes(
                    typeof(DescriptionAttribute), false), (
                    f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
                    .Description.ToLowerInvariant() == description.ToLowerInvariant());

            return field == null ? (TEnum?)null : (TEnum)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// get enum description
        /// </summary>
        /// <typeparam name="TEnum">enum type</typeparam>
        /// <param name="item">enum object</param>
        /// <returns>enum description</returns>
        public static string GetEnumDescription<TEnum>(this TEnum item)
            => item.GetType()
                .GetField(item.ToString() ?? string.Empty)
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()?.Description ?? string.Empty;
    }
}