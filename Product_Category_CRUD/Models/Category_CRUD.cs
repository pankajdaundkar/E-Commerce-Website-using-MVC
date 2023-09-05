using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Product_Category_CRUD.Models
{
    public class Category_CRUD
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public Category_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public int AddCategory(Category category)
        {
            int result = 0;
            string str = "insert into category values(@cname)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cname", category.Cname);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCategory(Category category)
        {
            int result = 0;
            string str = "update category set cname=@cname where cid=@cid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cname", category.Cname);
            cmd.Parameters.AddWithValue("@cid", category.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            string str = "delete from  category where cid=@cid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public IEnumerable<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            string qry = "select * from category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category category = new Category();
                    category.Cid = Convert.ToInt32(dr["cid"]);
                    category.Cname = dr["cname"].ToString();
                    list.Add(category);
                }
            }
            con.Close();
            return list;
        }
        public Category GetCategoryById(int id)
        {
            Category category = new Category();
            string qry = "select * from category where cid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    category.Cid = Convert.ToInt32(dr["cid"]);
                    category.Cname = dr["cname"].ToString();
                }
            }
            con.Close();
            return category;
        }



    }
}
