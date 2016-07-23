using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TrainingRoomApp
{
    public class DALTransaction : IDisposable
    {
        #region Variables
        string m_connectionString;
        #endregion


        #region Constructor

        public DALTransaction()
        {
            //modify the key to match with what you have provided in your web.config file
            m_connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AppConnString"].ConnectionString;
        }

        #endregion


        #region Dispose
        private bool disposed = false;
        ~DALTransaction()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposeManagedResources)
        {

            if (!this.disposed)
            {



                disposed = true;
            }

        }




        #endregion


        # region Methods
        public DataSet GetData(string Param1)
        {
            m_connectionString = this.ConnectionString;
            SqlConnection conSqlConnection;
            SqlDataAdapter daEmpData = new SqlDataAdapter();
            DataSet dsEmpData = new DataSet();
            String Query = "<< stored procedure name >>"; //store procedure name comes here
            try
            {

                if ((!string.IsNullOrEmpty(m_connectionString)))
                {
                    using (conSqlConnection = new SqlConnection(m_connectionString))
                    {
                        conSqlConnection.Open();
                        using (SqlCommand cmdEmpData = new SqlCommand(Query, conSqlConnection))
                        {
                            daEmpData.SelectCommand = cmdEmpData;
                            cmdEmpData.Connection = conSqlConnection;
                            cmdEmpData.CommandType = CommandType.StoredProcedure;
                            cmdEmpData.Parameters.AddWithValue("@param1", Param1);

                            //cmdEmpData.ExecuteNonQuery();
                            daEmpData.Fill(dsEmpData);
                            dsEmpData.Tables[0].TableName = "<< proper table name >>"; //set a proper table name, if necessary

                        }


                    }

                }
                return dsEmpData;

            }

            catch
            {
                throw;
            }
            finally
            {
                daEmpData.Dispose(); //make sure you dispose the Data Adapter instance
            }

        }
        # endregion


        #region Properties
        private string ConnectionString
        {
            get
            {
                return m_connectionString;
            }

        }
        #endregion

    }
}