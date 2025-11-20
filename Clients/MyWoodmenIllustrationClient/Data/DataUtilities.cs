using log4net;
using System;
using System.Data;
using System.Data.OleDb;
using WOW.MyWoodmenIllustrationClient.Properties;
using System.Threading;

namespace WOW.MyWoodmenIllustrationClient.Data
{
    /// <summary>
    /// Contains shared utility methods.
    /// </summary>
    internal static class DataUtilities
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DataUtilities));

        /// <summary>
        /// Executes the non-query method of the specified command object.
        /// This utility method is used to wrap the retry, command timeout, and logging logic.
        /// </summary>
        /// <param name="cmd">The command object to execute.</param>
        /// <returns>The number of records affected.</returns>
        internal static int ExecuteNonQuery(OleDbCommand cmd)
        {
            if (cmd == null)
            {
                if (log.IsErrorEnabled) log.Error("ExecuteNonQuery - The passed command object is null.");
                throw new ArgumentNullException("cmd", "Command cannot be null.");
            }
            if (cmd.Connection == null)
            {
                if (log.IsErrorEnabled) log.Error("ExecuteNonQuery - Connection of the passed command object is null.");
                throw new InvalidOperationException("Connection cannot be null.");
            }

            var tries = 0;
            do
            {
                try
                {
                    cmd.CommandTimeout = Settings.Default.DB2CommandTimeoutSeconds;
                    if (cmd.Connection.State == ConnectionState.Closed) cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    tries++;
                    Thread.Sleep(Settings.Default.ShortSleep_ms);
                    if (log.IsWarnEnabled)
                    {
                        var message = string.Format("ExecuteNonQuery - Exception on attempt: {0}", tries);
                        log.Warn(message, ex);
                    }

                    if (tries > Settings.Default.DB2Retries)
                    {
                        if (log.IsErrorEnabled)
                        {
                            var message = string.Format("ExecuteNonQuery - Failed after {0} attempts.", tries);
                            log.Error(message, ex);
                        }
                        throw;
                    }
                }
                finally
                {
                    if (cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();
                }
            } while (true);
        }

        /// <summary>
        /// Uses the specified data adapter to fill the given data table.
        /// This utility method is used to wrap the retry, command timeout, and logging logic.
        /// </summary>
        /// <param name="da">The data adapter to execute.</param>
        /// <param name="dt">The data table to populate.</param>
        internal static void Fill(OleDbDataAdapter da, DataTable dt)
        {
            if (da == null)
            {
                if (log.IsErrorEnabled) log.Error("Fill - The passed data adapter is null.");
                throw new ArgumentNullException("da", "DataAdapter cannot be null.");
            }
            if (dt == null)
            {
                if (log.IsErrorEnabled) log.Error("Fill - The passed data table is null.");
                throw new ArgumentNullException("dt", "DataTable cannot be null.");
            }

            var tries = 0;
            do
            {
                try
                {
                    da.SelectCommand.CommandTimeout = Settings.Default.DB2CommandTimeoutSeconds;
                    da.Fill(dt);
                    return;
                }
                catch (OleDbException ex)
                {
                    tries++;
                    Thread.Sleep(Settings.Default.ShortSleep_ms);
                    if (log.IsWarnEnabled)
                    {
                        var message = string.Format("Fill - Exception on attempt: {0}", tries);
                        log.Warn(message, ex);
                    }

                    if (tries > Settings.Default.DB2Retries)
                    {
                        if (log.IsErrorEnabled)
                        {
                            var message = string.Format("Fill - Failed after {0} attempts.", tries);
                            log.Error(message, ex);
                        }
                        throw;
                    }
                }

            } while (true);
        }
    }
}
