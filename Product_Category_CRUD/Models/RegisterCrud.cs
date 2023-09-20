using System.Data;
using System.Data.SqlClient;

namespace Product_Category_CRUD.Models
{
    public class RegisterCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        IConfiguration configuration;
        public RegisterCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public int AddRegister(Register reg)
        {
            int result = 0;
            string qry = "insert into register(first_name,last_name,gender,email,mobile_no,user_name,password,confirm_password)values(@first_name,@last_name,@gender,@email,@mobile_no,@user_name,@password,@confirm_password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@first_name", reg.FirstName);
            cmd.Parameters.AddWithValue("@last_name", reg.LastName);
            cmd.Parameters.AddWithValue("@gender", reg.Gender);
            cmd.Parameters.AddWithValue("@email", reg.Email);
            cmd.Parameters.AddWithValue("@mobile_no", reg.MobileNo);
            cmd.Parameters.AddWithValue("@user_name", reg.UserName);
            cmd.Parameters.AddWithValue("@password", reg.Password);
            cmd.Parameters.AddWithValue("@confirm_password", reg.ConfirmPassword);
            cmd.Parameters.AddWithValue(@"roll_id", reg.RollId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //public Register Login (string username, string password)
        //{
        //    Register u = new Register();
        //    string qry = "select * from register where username=@user_Name and password=@password";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@user_Name", username);
        //    cmd.Parameters.AddWithValue("@password", password);
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            u.Id = Convert.ToInt32(dr["id"]);
        //            //u.FirstName = dr["firstName"].ToString();
        //            //u.LastName = dr["lastName"].ToString();
        //            u.UserName = dr["user_Name"].ToString();
        //            //u.Password = dr["password"].ToString();
        //            //u.Confirmpwd = dr["confirmpwd"].ToString();
        //            //u.Gender = dr["gender"].ToString();
        //            //u.Email = dr["email"].ToString();
        //            //u.PhoneNumber = dr["phoneNumber"].ToString();
        //            //u.Address = dr["address"].ToString();
        //            //u.City = dr["city"].ToString();
        //            //u.State = dr["state"].ToString();
        //            //u.Pincode = Convert.ToInt32(dr["pincode"]);
        //            u.RollId = Convert.ToInt32(dr["roll_id"]);

        //        }

        //        //public DataTable GetAllUser()
        //        //{
        //        //    con.Open();
        //        //    cmd = new SqlCommand("select * from register", con);
        //        //    dr = cmd.ExecuteReader();

        //        //    if (dr.HasRows)
        //        //    {
        //        //        dt.Load(dr);
        //        //    }
        //        //    con.Close();
        //        //    return dt;
        //        //}






        //    }
        //}
    }
}
