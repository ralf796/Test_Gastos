using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Extensiones
{
    public class UnitOfWork : IDisposable
    {

        #region Private
        private enum ServerType
        {
            Sql,
            MySql
        }
        private string DapperCommand { get; set; }
        private CommandType DapperCommandType { get; set; }
        private DynamicParameters DapperParameters { get; set; }
        private SqlConnection? SQLConnection;
        private ServerType ConnectionType;
        private string? ConnectionString;
        private readonly DateTime executeStart;
        private bool executeException;
        private readonly bool isDebug;
        private void GetConnectionString(string connectionName)
        {
            ConnectionString = string.Empty;
            if (System.Configuration.ConfigurationManager.ConnectionStrings[connectionName] != null)
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName];
                ConnectionString = connection.ConnectionString;

                if (connection.ProviderName == "System.Data.SqlClient")
                {
                    if (!ConnectionString.Contains("Application Name="))
                        ConnectionString += $"Application Name={AppDomain.CurrentDomain.FriendlyName};";
                    ConnectionType = ServerType.Sql;
                }
                else
                    ConnectionType = ServerType.MySql;
            }
            else
                throw new ArgumentNullException($"La conexión {connectionName} no es válida, verifique la configuración de la aplicación.");
        }
        #endregion
        #region Public                   
        public UnitOfWork(string query, CommandType commandType = CommandType.StoredProcedure, string connectionName= "BDGastos")
        {            
            SqlMapper.Settings.CommandTimeout = 7200;
            //Command
            DapperCommand = query;
            //Type
            DapperCommandType = commandType;
            //Parameters
            DapperParameters = new DynamicParameters();
            //Conexion
            //GetConnectionString(connectionName);
            //SQLConnection = new SqlConnection(ConnectionString);
            //SQLConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Repuestos"].ConnectionString);
            SQLConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            SQLConnection.Open();
            //if (ConnectionType == ServerType.MySql)
            //{
            //    MySQLConnection = new MySqlConnection(ConnectionString);
            //    MySQLConnection.Open();
            //}
            if (Environment.ProcessPath != null)
                isDebug = Environment.ProcessPath.Contains("Debug");

            //Execution Time
            executeStart = DateTime.Now;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                LogExecution();
                DapperCommand = string.Empty;
                if (SQLConnection != null)
                {
                    SQLConnection.Close();
                    SQLConnection.Dispose();
                    SQLConnection = null;
                }
                //if (MySQLConnection != null)
                //{
                //    MySQLConnection.Close();
                //    MySQLConnection.Dispose();
                //    MySQLConnection = null;
                //}
            }
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// Metódo para agregar un parametro al comando aunque su valor sea nulo
        /// </summary>
        /// <param name="name">Nombre del parametro con @</param>
        /// <param name="value">Valor del parametro</param>
        public void AddParameter(string name, object? value, ParameterDirection direction = ParameterDirection.Input)
        {
            try
            {
                DapperParameters.Add(name, value, direction: direction);
            }
            catch
            {
                executeException = true;
                throw;
            }
        }
        /// <summary>
        /// Metódo para agregar un parametro al comando, si el valor es nulo se omite
        /// </summary>
        /// <param name="name">Nombre del parametro con @</param>
        /// <param name="value">Valor del parametro</param>
        public void AddParameterOptional(string name, object? value, ParameterDirection direction = ParameterDirection.Input)
        {
            try
            {
                if (value != null)
                    DapperParameters.Add(name, value, direction: direction);
            }
            catch
            {
                executeException = true;
                throw;
            }
        }
        /// <summary>
        /// Metódo para obtener el valor de un parametro de tipo output
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <param name="name">Nombre del parametro que contiene el valor a obtener</param>
        /// <returns></returns>
        public T OutValueParameter<T>(string name)
        {
            return DapperParameters.Get<T>(name);
        }

        /// <summary>
        /// Metodo que obtiene una lista de objetos.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a retornar</typeparam>
        /// <returns>Lista de objetos obtenidos de base de datos</returns>
        public List<T> GetData<T>()
        {
            List<T> result;
            try
            {
                if (ConnectionType == ServerType.Sql && SQLConnection != null)
                    result = SQLConnection.Query<T>(DapperCommand, param: DapperParameters, commandType: DapperCommandType).ToList();
                //else if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                //    result = MySQLConnection.Query<T>(DapperCommand, param: DapperParameters, commandType: DapperCommandType).ToList();
                else
                    result = new List<T>();
            }
            catch (Exception ex)
            {
                throw handleException(ex);
            }
            return result;
        }
        /// <summary>
        /// Metodo para obtener la primer fila del resultado de una ejecución.
        /// </summary>
        /// <returns>Campos de la primer fila del resultado</returns>
        public T? GetRow<T>()
        {
            try
            {
                if (ConnectionType == ServerType.Sql && SQLConnection != null)
                    return SQLConnection.Query<T>(DapperCommand, param: DapperParameters, commandType: DapperCommandType).FirstOrDefault();
                //else if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                //    return MySQLConnection.Query<T>(DapperCommand, param: DapperParameters, commandType: DapperCommandType).FirstOrDefault();
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                throw handleException(ex);
            }
        }
        /// <summary>
        /// Metodo para ejecutar un query sin un tipo de dato definido.
        /// </summary>
        /// <returns>Estado y Codigo de la ejecución</returns>
        public int ExecuteNonQuery()
        {
            try
            {
                int result = -1;
                if (ConnectionType == ServerType.Sql && SQLConnection != null)
                    result = SQLConnection.Execute(DapperCommand, param: DapperParameters, commandType: DapperCommandType);
                //else if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                //    result = MySQLConnection.Execute(DapperCommand, param: DapperParameters, commandType: DapperCommandType);
                return result;
            }
            catch (Exception ex)
            {
                throw handleException(ex);
            }
        }
        /// <summary>
        /// Metodo para ejecutar un query y obtener el primer valor de respuesta.
        /// </summary>
        /// <returns>Estado y Codigo de la ejecución</returns>
        public T? ExecuteScalar<T>()
        {
            try
            {
                //Get Result
                if (ConnectionType == ServerType.Sql && SQLConnection != null)
                    return SQLConnection.ExecuteScalar<T>(DapperCommand, param: DapperParameters, commandType: DapperCommandType);
                //else if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                //    return MySQLConnection.ExecuteScalar<T>(DapperCommand, param: DapperParameters, commandType: DapperCommandType);
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                throw handleException(ex);
            }
        }
        #endregion
        #region Handler Exceptions
        private Exception handleException(Exception ex)
        {
            executeException = true;
            ApplicationException result;
            DateTime executeEnd = DateTime.Now;
            TimeSpan executeTimeTotal = executeEnd - executeStart;
            string executionTime = $"{executeTimeTotal.ToString(@"hh\:mm\:ss")}";
            if (ex != null && ex.GetType() == typeof(SqlException))
            {
                SqlException exception = (SqlException)ex;
                result = new ApplicationException(exception.Message);
            }
            //else if (ex != null && ex.GetType() == typeof(MySqlException))
            //{
            //    MySqlException exception = (MySqlException)ex;
            //    result = new ApplicationException(exception.Message);
            //}
            else
            {
                result = new ApplicationException(ex?.Message, ex);
            }

            string CommandExecuted = LogExecution();
            result.Data.Add("DBObject", CommandExecuted);
            if (isDebug)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (ConnectionType == ServerType.Sql && SQLConnection != null)
                    Console.Error.WriteLine($"Error - {ConnectionType.ToString()} - IP: {SQLConnection.DataSource} DB: {SQLConnection.Database} TIME: {executionTime}");
                //if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                //    Console.Error.WriteLine($"Error - {ConnectionType.ToString()} - IP: {MySQLConnection.DataSource} DB: {MySQLConnection.Database} TIME: {executionTime}");
                Console.Error.WriteLine(CommandExecuted);
                Console.ResetColor();
                Console.Error.WriteLine("");
            }
            else
            {
                if (ConnectionType == ServerType.Sql && SQLConnection != null)
                    Trace.TraceError($"Error - {ConnectionType.ToString()} - IP: {SQLConnection.DataSource} DB: {SQLConnection.Database} - {CommandExecuted} TIME: {executionTime}");
                //if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                //    Trace.TraceError($"Error - {ConnectionType.ToString()} - IP: {MySQLConnection.DataSource} DB: {MySQLConnection.Database} - {CommandExecuted} TIME: {executionTime}");
            }

            return result;
        }
        public string LogExecution()
        {
            DateTime executeEnd = DateTime.Now;
            TimeSpan executeTimeTotal = executeEnd - executeStart;
            string executionTime = $"{executeTimeTotal.ToString(@"hh\:mm\:ss")}";
            StringBuilder Command = new StringBuilder();
            if (DapperCommandType == CommandType.Text)
                Command.Append($"{DapperCommand} ");
            else
            {
                if (ConnectionType == ServerType.Sql)
                    Command.Append($"exec {DapperCommand} ");
                else
                    Command.Append($"call {DapperCommand} ");
            }

            foreach (var parameter in DapperParameters.ParameterNames)
            {
                if (DapperCommandType == CommandType.Text)
                    Command = Command.Replace(parameter, $"{getParameterWithValue(parameter)}");
                else
                    Command.Append($"{getParameterWithValue(parameter)}");
            }

            Command = Command.Replace("@@", "@").Replace(",,", ",");

            if (!executeException)
            {
                if (isDebug)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    if (ConnectionType == ServerType.Sql && SQLConnection != null)
                        Console.WriteLine($"Info - {ConnectionType.ToString()} - IP: {SQLConnection.DataSource} DB: {SQLConnection.Database} TIME: {executionTime}");
                    //if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                    //    Console.WriteLine($"Info - {ConnectionType.ToString()} - IP: {MySQLConnection.DataSource} DB: {MySQLConnection.Database} TIME: {executionTime}");
                    Console.ResetColor();
                    Console.Write(Command);
                    Console.WriteLine("");
                }
                else
                {
                    if (ConnectionType == ServerType.Sql && SQLConnection != null)
                        Trace.TraceInformation($"Info - {ConnectionType.ToString()} - IP: {SQLConnection.DataSource} DB: {SQLConnection.Database} - {Command} TIME: {executionTime}");
                    //if (ConnectionType == ServerType.MySql && MySQLConnection != null)
                    //    Trace.TraceInformation($"Info - {ConnectionType.ToString()} - IP: {MySQLConnection.DataSource} DB: {MySQLConnection.Database} - {Command} TIME: {executionTime}");
                }
            }
            return Command.ToString();
        }
        private string getParameterWithValue(string parameter)
        {
            object value = DapperParameters.Get<object>(parameter);
            string valueCommand = string.Empty;
            if (value == null)
                valueCommand = $"@{parameter}=null";
            else if (value.GetType().Equals(typeof(string)))
                valueCommand = $"@{parameter}='{Convert.ToString(value)}'";
            else if (value.GetType().Equals(typeof(DateTime)))
                valueCommand = $"@{parameter}='{Convert.ToDateTime(value).ToString("yyyy-MM-dd hh:mm:ss")}'";
            else
                valueCommand = $"@{parameter}={Convert.ToString(value)}";

            if (DapperParameters.ParameterNames.Last() != parameter)
                valueCommand += ", ";

            return valueCommand;
        }
        #endregion
    }
}
