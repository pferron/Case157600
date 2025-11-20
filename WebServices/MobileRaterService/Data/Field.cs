using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WOW.MobileRaterService.Data
{
    /// <summary>
    /// Read-only representation of a data source field.
    /// </summary>
    /// <remarks>Instances are exposed from a data source class in a nested class of related Field objects.
    /// This provides the data source consumer access to an intellisense list of available field names and sizes.</remarks>
    public sealed class Field
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(Field));

        /// <summary>
        /// Initializes a new field object.
        /// </summary>
        /// <param name="name">The name associated with this field.</param>
        /// <param name="size">The size associated with this field.</param>
        /// <param name="dataType">The data type of this field.</param>
        /// <remarks>This constructor is intended to be used for database fields.</remarks>
        public Field(string name, int size, OleDbType dataType)
        {
            Name = name;
            Size = size;
            DbType = dataType;
            SqlType = 0;
            NetType = Conversions.TranslateType(dataType);
        }

        /// <summary>
        /// Initializes a new field object.
        /// </summary>
        /// <param name="name">The name associated with this field.</param>
        /// <param name="size">The size associated with this field.</param>
        /// <param name="dataType">The data type of this field.</param>
        /// <remarks>This constructor is intended to be used for database fields.</remarks>
        public Field(string name, int size, SqlDbType dataType)
        {
            Name = name;
            Size = size;
            DbType = 0;
            SqlType = dataType;
            NetType = Conversions.TranslateType(dataType);
        }

        /// <summary>
        /// Initializes a new field object.
        /// </summary>
        /// <param name="name">The name associated with this field.</param>
        /// <param name="size">The size associated with this field.</param>
        /// <param name="dataType">The data type of this field.</param>
        /// <remarks>This constructor is intended to be used for queue fields.</remarks>
        public Field(string name, int size, Type dataType)
        {
            Name = name;
            Size = size;
            DbType = 0;
            SqlType = 0;
            NetType = dataType;
        }

        /// <summary>
        /// Combines two values for the specified field, truncates, and returns the result.
        /// </summary>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value to prepend.</param>
        /// <returns>The newly combined string.</returns>
        public string Combine(object oldValue, object newValue)
        {
            string strReturn = null;

            if (!object.ReferenceEquals(NetType, typeof(string)))
            {
                var message = "Combine can only be used for string values.";
                if (logger.IsErrorEnabled) logger.Error(message);
                throw new InvalidOperationException(message);
            }

            if (oldValue == null)
                oldValue = string.Empty;
            if (newValue == null)
                newValue = string.Empty;

            strReturn = (DataValueUtilities.NZ(newValue, string.Empty).Trim() + ";" + DataValueUtilities.NZ(oldValue, string.Empty).Trim()).Trim(';');

            return DataValueUtilities.Truncate(strReturn, Size, ">");
        }

        /// <summary>
        /// Creates a System.Data.DataColumn using the state of the field.
        /// </summary>
        /// <returns>A properly initialized DataColumn object.</returns>
        public DataColumn CreateDataColumn()
        {
            using (DataColumn objReturn = new DataColumn(Name, NetType))
            {
                if (object.ReferenceEquals(NetType, typeof(string)))
                {
                    objReturn.MaxLength = Size;
                }

                return objReturn;
            }
        }

        /// <summary>
        /// Creates a System.Data.OleDb.OleDbParameter using the state of the field.
        /// </summary>
        /// <param name="name">The name to give the parameter.</param>
        /// <param name="newValue">The value to give the parameter.</param>
        /// <returns>A properly initialized OleDbParameter object.</returns>
        public OleDbParameter CreateOleDbParameter(string name, object newValue)
        {
            OleDbParameter objReturn = new OleDbParameter(name, DbType, Size, Name);

            if (object.ReferenceEquals(NetType, typeof(string)))
            {
                objReturn.Value = DataValueUtilities.Truncate(newValue, Size);
            }
            else if (object.ReferenceEquals(NetType, typeof(int)))
            {
                objReturn.Value = DataValueUtilities.NZ(newValue, 0);
            }
            else if (object.ReferenceEquals(NetType, typeof(decimal)))
            {
                objReturn.Value = DataValueUtilities.NZ(newValue, 0m);
            }
            else if (object.ReferenceEquals(NetType, typeof(DateTime)))
            {
                var dtmDate = DataValueUtilities.NZ(newValue, DataValueUtilities.ZeroDate);
                if (dtmDate < DataValueUtilities.ZeroDate && dtmDate != DataValueUtilities.ZeroDateDB2 && dtmDate != DataValueUtilities.ZeroDateTimeDB2)
                {
                    dtmDate = DataValueUtilities.ZeroDate;
                }
                objReturn.Value = dtmDate;
            }
            else if (object.ReferenceEquals(NetType, typeof(bool)))
            {
                objReturn.Value = DataValueUtilities.NZ(newValue, false);
            }
            else
            {
                objReturn.Value = newValue;
            }

            return objReturn;
        }

        /// <summary>
        /// Creates a System.Data.OleDb.OleDbParameter using the state of the field.
        /// </summary>
        /// <param name="name">The name to give the parameter.</param>
        /// <param name="newValue">The string value to give the parameter.</param>
        /// <param name="addTrailingWildcard">An indication of whether a trailing wildcard should be appended.</param>
        /// <returns>A properly initialized OleDbParameter object.</returns>
        public OleDbParameter CreateOleDbParameter(string name, object newValue, bool addTrailingWildcard)
        {
            OleDbParameter objReturn = null;

            if (addTrailingWildcard)
            {
                try
                {
                    //Temporarily drop the size to reuse the normal logic.
                    Size--;
                    objReturn = CreateOleDbParameter(name, newValue);
                }
                finally
                {
                    //Ensure that the size gets reset.
                    Size++;
                }
                objReturn.Value = Convert.ToString(objReturn.Value, CultureInfo.InvariantCulture) + "%";
            }
            else
            {
                objReturn = CreateOleDbParameter(name, newValue);
            }

            return objReturn;
        }

        /// <summary>
        /// Creates a System.Data.OleDb.OleDbParameter using the state of the field.
        /// </summary>
        /// <param name="name">The name to give the parameter.</param>
        /// <param name="dataRow">A DataRow containing the value that should be used for the parameter.</param>
        /// <returns>A properly initialized OleDbParameter object.</returns>
        public OleDbParameter CreateOleDbParameter(string name, DataRow dataRow)
        {
            return CreateOleDbParameter(name, dataRow[Name]);
        }

        /// <summary>
        /// Creates a System.Data.SqlClient.SqlParameter using the state of the field.
        /// </summary>
        /// <param name="name">The name to give the parameter.</param>
        /// <param name="newValue">The value to give the parameter.</param>
        /// <returns>A properly initialized SqlParameter object.</returns>
        public SqlParameter CreateSqlParameter(string name, object newValue)
        {
            SqlParameter objReturn = new SqlParameter(name, SqlType, Size, Name);

            if (object.ReferenceEquals(NetType, typeof(string)))
            {
                objReturn.Value = DataValueUtilities.Truncate(newValue, Size);
            }
            else if (object.ReferenceEquals(NetType, typeof(int)))
            {
                objReturn.Value = DataValueUtilities.NZ(newValue, 0);
            }
            else if (object.ReferenceEquals(NetType, typeof(decimal)))
            {
                objReturn.Value = DataValueUtilities.NZ(newValue, 0m);
            }
            else if (object.ReferenceEquals(NetType, typeof(DateTime)))
            {
                var dtmDate = DataValueUtilities.NZ(newValue, DataValueUtilities.ZeroDate);
                if (dtmDate < DataValueUtilities.ZeroDate && dtmDate != DataValueUtilities.ZeroDateDB2 && dtmDate != DataValueUtilities.ZeroDateTimeDB2)
                {
                    dtmDate = DataValueUtilities.ZeroDate;
                }
                objReturn.Value = dtmDate;
            }
            else if (object.ReferenceEquals(NetType, typeof(bool)))
            {
                objReturn.Value = DataValueUtilities.NZ(newValue, false);
            }
            else
            {
                objReturn.Value = newValue;
            }

            return objReturn;
        }

        /// <summary>
        /// Creates a System.Data.SqlClient.SqlParameter using the state of the field.
        /// </summary>
        /// <param name="name">The name to give the parameter.</param>
        /// <param name="newValue">The string value to give the parameter.</param>
        /// <param name="addTrailingWildcard">An indication of whether a trailing wildcard should be appended.</param>
        /// <returns>A properly initialized SqlParameter object.</returns>
        public SqlParameter CreateSqlParameter(string name, object newValue, bool addTrailingWildcard)
        {
            SqlParameter objReturn = null;

            if (addTrailingWildcard)
            {
                try
                {
                    //Temporarily drop the size to reuse the normal logic.
                    Size--;
                    objReturn = CreateSqlParameter(name, newValue);
                }
                finally
                {
                    //Ensure that the size gets reset.
                    Size++;
                }
                objReturn.Value = Convert.ToString(objReturn.Value, CultureInfo.InvariantCulture) + "%";
            }
            else
            {
                objReturn = CreateSqlParameter(name, newValue);
            }

            return objReturn;
        }

        /// <summary>
        /// Creates a System.Data.SqlClient.SqlParameter using the state of the field.
        /// </summary>
        /// <param name="name">The name to give the parameter.</param>
        /// <param name="dataRow">A DataRow containing the value that should be used for the parameter.</param>
        /// <returns>A properly initialized SqlParameter object.</returns>
        public SqlParameter CreateSqlParameter(string name, DataRow dataRow)
        {
            return CreateSqlParameter(name, dataRow[Name]);
        }

        /// <summary>
        /// Gets the DB2 data type of the source field.
        /// </summary>
        private OleDbType DbType { get; set; }

        /// <summary>
        /// Gets the name of the data source field.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the .NET data type of the source field.
        /// </summary>
        private Type NetType { get; set; }

        /// <summary>
        /// Gets the size/length of the data source field.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Gets the MS SQL data type of the source field.
        /// </summary>
        private SqlDbType SqlType { get; set; }
    }
}