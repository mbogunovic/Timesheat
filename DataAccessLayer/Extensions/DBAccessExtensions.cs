using System;
using System.Data;
using System.Reflection;

namespace TimeshEAT.DataAccessLayer.Extensions
{
    /// <summary>
    /// DBAccess extension methods.
    /// </summary>
    public static class DBAccessExtensions
    {
        /// <summary>
		/// Return mapped model from sql data reader.
		/// </summary>
		/// <typeparam name="record">The record from database</typeparam>
		/// <returns>Returns appropriate mapped model T</returns>
		public static T MapTableEntityTo<T>(IDataRecord record) where T : class
        {
            T result = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo property in typeof(T).GetProperties())
                property.SetValue(result, record[property.Name]
					.DBNullTo(property.PropertyType.GetDefault()));

            return result;
        }

        /// <summary>
        /// If value is null return value equal to database nullable object
        /// </summary>
        /// <typeparam name="value">Value that's being converted</typeparam>
        /// <typeparam name="optionalValue">Optional value to convert to</typeparam>
        /// <returns>DBNull.Value or actual value</returns>
        public static object ToDBNullable<T>(this T value, T optionalValue = default(T)) =>
			Equals(value, optionalValue) ? DBNull.Value : (object)value;

		/// <summary>
		/// Checks for db null entry for object value and returns appropriate substitution value or actual value
		/// </summary>
		/// <typeparam name="value">Value thats being checked for db null entry</typeparam>
		/// <typeparam name="substitutionValue">Substitution value if the value is db null</typeparam>
		/// <returns>Appropriate default value or actual value</returns>
		public static T DBNullTo<T>(this object value, T substitutionValue = default(T)) =>
			Convert.IsDBNull(value) ? substitutionValue : (T)value;

		/// <summary>
		/// Method for returning an instance for desired type
		/// </summary>
		/// <typeparam name="type">Type value for creating the istance of that type</typeparam>
		/// <returns>Object instance of parameter type</returns>
		public static object GetDefault(this Type type) =>
			type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
