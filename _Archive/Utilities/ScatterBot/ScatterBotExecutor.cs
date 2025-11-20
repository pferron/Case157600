using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScatterBot
{
    class ScatterBotExecutor
    {
        private List<Task> _actionTasks = new List<Task>();
        private CancellationToken _token = new CancellationToken();
        private object _lock = new Object();

        private static readonly ILog logger = LogManager.GetLogger(typeof(ScatterBotExecutor));

        public enum ExecutionStatus
        {
            None,
            Executing,
            Success,
            Error
        };

        public event EventHandler ExecutionStatusChanged;
        public event EventHandler ExecutionComplete;

        public void ExecuteActions(ICollection<ScatterBotAction> actions)
        {
            // null and zero count check
            if (actions == null || actions.Count == 0)
            {
                ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Success, Message = "No actions were requested. Systems are unchanged." });
                return;
            }

            // start tasks for each action
            foreach (var action in actions)
            {
                Task task = new Task(() => ExecuteAction(action), _token);
                task.ContinueWith((t) => AfterActions());

                _actionTasks.Add(task);
            }

            _actionTasks.ForEach(a => a.Start());
        }

        private void ExecuteAction(ScatterBotAction action)
        {
            // copy version file
            // UNC paths all around
            if (action.UpdateAppServerVersion)
            {
                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Copying version file to App server '{0}'.", action.TargetHostname) });
                    FileDistributionHelper.DistributeFile(action.SourceVersionFilePath, action.TargetAppVersionFilePath);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error copying version file to App Server: {0}", action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while copying version file to App server '{0}'. Check the log for details.", action.TargetHostname) });
                }
            }

            if (action.UpdateLifeServerVersion)
            {
                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Copying version file to Life server '{0}'.", action.TargetHostname) });
                    FileDistributionHelper.DistributeFile(action.SourceVersionFilePath, action.TargetLifeVersionFilePath);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error copying version file to Life Server: {0}", action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while copying version file to Life server '{0}'. Check the log for details.", action.TargetHostname) });
                }
            }

            if (action.UpdateWebServerVersion)
            {
                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Copying version file to Web server '{0}'.", action.TargetHostname) });
                    FileDistributionHelper.DistributeFile(action.SourceVersionFilePath, action.TargetWebVersionFilePath);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error copying version file to Web Server: {0}", action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while copying version file to Web server '{0}'. Check the log for details.", action.TargetHostname) });
                }

            }

            // copy RSU files
            if (action.DeployRsuPackage)
            {
                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Copying RSU deployment files to '{0}'.", action.TargetHostname) });
                    FileDistributionHelper.DistributeFolder(action.SourceRsuFolderPath, action.TargetRsuFolderPath);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error copying RSU deployment files to {0}", action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while copying RSU deployment files to '{0}'. Check the log for details.", action.TargetHostname) });
                }
            }

            // restart services
            if (action.RestartServices)
            {
                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Restarting '{0}' on server '{1}'.", action.AppServiceName, action.TargetHostname) });
                    RemoteServicesHelper.RestartService(action.TargetHostname, action.AppServiceName);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error restarting {0} on server {1}", action.AppServiceName, action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while restarting '{0}' on '{1}'. Check the log for details.", action.AppServiceName, action.TargetHostname) });
                }

                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Restarting '{0}' on server '{1}'.", action.LifeServiceName, action.TargetHostname) });
                    RemoteServicesHelper.RestartService(action.TargetHostname, action.LifeServiceName);
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error restarting {0} on server {1}", action.LifeServiceName, action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while restarting '{0}' on '{1}'. Check the log for details.", action.LifeServiceName, action.TargetHostname) });
                }

                try
                {
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Executing, Message = String.Format("Restarting '{0}' on server '{1}'.", "W3SVC", action.TargetHostname) });
                    RemoteServicesHelper.RestartService(action.TargetHostname, "W3SVC");
                }
                catch (Exception ex)
                {
                    if (logger.IsErrorEnabled)
                    {
                        var message = string.Format(CultureInfo.InvariantCulture, "Error restarting W3SVC on server {0}", action.TargetHostname);
                        logger.Error(message, ex);
                    }
                    ExecutionStatusChanged.Invoke(null, new ExecutionStatusChangedArgs { Status = ExecutionStatus.Error, Message = String.Format("An error occurred while restarting '{0}' on '{1}'. Check the log for details.", action.LifeServiceName, action.TargetHostname) });
                }
            }
        }

        private void AfterActions()
        {
            // If all task have ended, raise the completed event
            lock (_lock)
            {
                if (_actionTasks.Count(t => t.IsCompleted) == _actionTasks.Count)
                {
                    ExecutionComplete.Invoke(null, new ExecutionCompleteArgs { Message = "All tasks complete." });
                }
            }

        }
    }

    class ExecutionStatusChangedArgs : EventArgs
    {
        public ScatterBot.ScatterBotExecutor.ExecutionStatus Status { get; set; }
        public string Message { get; set; }
    }

    class ExecutionCompleteArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
