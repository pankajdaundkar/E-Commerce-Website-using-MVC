using System.Data.SqlClient;

namespace Product_Category_CRUD.Models
{
    public class LoginCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        //DataTable dt;
        IConfiguration configuration;

        public LoginCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public Register GetLogin(string username, string password)
        {

            Register reg = new Register();
            string qry = "select * from Register where user_name=@user_name and password=@password";
            cmd = new SqlCommand(qry, con);
           // cmd.Parameters.AddWithValue("@id",reg.Id);
            cmd.Parameters.AddWithValue("@user_name", username);
            cmd.Parameters.AddWithValue("@password", password);
            //cmd.Parameters.AddWithValue("@status_id", reg.status_id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    reg.Uid = Convert.ToInt32(dr["uid"]);
                    reg.UserName = dr["user_name"].ToString();
                    //reg.Password = dr["password"].ToString();
                    reg.RollId= Convert.ToInt32(dr["roll_id"]);
                }
            }
            con.Close();
            return reg;
        }
    }
}
