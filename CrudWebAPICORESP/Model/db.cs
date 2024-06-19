using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudWebAPICORESP.Model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=SNEHA\\SQLEXPRESS02;Database=kisanmitra_kisan;Trusted_Connection=True; TrustServerCertificate=true");

        public string ConsultantInsert(Consultant consultant)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("sp_SingleInsertConsultantCertification", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@consultant_id", consultant.consultant_id);
                com.Parameters.AddWithValue("@certification_number", consultant.certification_number);
                com.Parameters.AddWithValue("@inserted_by", consultant.inserted_by);
                com.Parameters.AddWithValue("@updated_by", consultant.updated_by);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public string ConsultantUpdate(Consultant consultant)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("sp_SingleUpdateConsultantCertification", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@consultant_id", consultant.consultant_id);
                com.Parameters.AddWithValue("@old_certification_number", consultant.old_certification_number);
                com.Parameters.AddWithValue("@new_certification_number", consultant.new_certification_number);
                com.Parameters.AddWithValue("@updated_by", consultant.updated_by);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public string ConsultantDelete(string certification_number)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("sp_SingleDeleteConsultantCertification", con);
                com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@consultant_id", consultant_id);
                com.Parameters.AddWithValue("@certification_number", certification_number);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

        public DataSet ConsultantGetAll(out string msg, int pageNumber, int pageSize)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("sp_ConsultantCertificationGet", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@pageNumber", pageNumber);
                com.Parameters.AddWithValue("@pageSize", pageSize);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }

        public DataSet ConsultantGetById(string consultant_id, string certification_number, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("sp_ConsultantCertificationGet", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@consultant_id", consultant_id);
                com.Parameters.AddWithValue("@certification_number", certification_number);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}
