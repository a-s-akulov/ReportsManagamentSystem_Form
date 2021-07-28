using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace ReportsManagementSystemForm
{
    public class ModuleSQL
    {
        //readonly string connectionString = Properties.Settings.Default.MailDiscountConnectionString;
        readonly string connectionString = "Data Source=devsql;Initial Catalog=ReportsManagementSystem;Integrated Security=True"; // KATTEST;

        public ModuleSQL()
        {

        }


        public bool ProcedureExecNoData(string procedure, SqlParameter[] paramsSql) // Выполняет заданную процедуру без возвращения данных
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 600;
            command.CommandText = procedure;
            command.Parameters.AddRange(paramsSql);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception exc = ex;
                string mes = exc.Message + "\n\n";
                while (exc.InnerException != null)
                {
                    exc = exc.InnerException;
                    mes += exc.Message + "\n";
                }
                MessageBox.Show(mes, "Ошибка (SQL)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return true;
        }


        public Tuple<bool, DataSet> ProcedureExecWithData(string procedure, SqlParameter[] paramsSql) // Выполняет заданную процедуру, возвращая DataSet
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 600;
            command.CommandText = procedure;
            command.Parameters.AddRange(paramsSql);

            DataSet data = new DataSet();
            try
            {
                connection.Open();
                dataAdapter.Fill(data);
            }
            catch (Exception ex)
            {
                Exception exc = ex;
                string mes = exc.Message + "\n\n";
                while (exc.InnerException != null)
                {
                    exc = exc.InnerException;
                    mes += exc.Message + "\n";
                }
                MessageBox.Show(mes, "Ошибка (SQL)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Tuple<bool, DataSet>(false, data);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return new Tuple<bool, DataSet>(true, data);
        }
    }
}
