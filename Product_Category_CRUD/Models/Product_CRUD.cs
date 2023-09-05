using System.Data.SqlClient;

namespace Product_Category_CRUD.Models
{
    public class Product_CRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public Product_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public IEnumerable<Product> GetProduct()
        {
            List<Product> list = new List<Product>();
            string qry = "select p.*, category.Cname from product p inner join Category category on category.cid = p.cid";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Imageurl = dr["imageurl"].ToString();
                    p.Cid = Convert.ToInt32(dr["cid"]);
                    p.Cname = dr["Cname"].ToString();
                    list.Add(p);
                }
            }
            con.Close();
            return list;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select p.*, category.Cname from product p inner join Category category on category.cid = p.cid where p.id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Imageurl = dr["imageurl"].ToString();
                    p.Cid = Convert.ToInt32(dr["cid"]);
                    p.Cname = dr["Cname"].ToString();
                }
            }
            con.Close();
            return p;
        }


        public int AddProduct(Product p)
        {
            int result = 0;
            string qry = "insert into product values(@name,@price,@imageurl,@cid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@imageurl", p.Imageurl);
            cmd.Parameters.AddWithValue("@cid", p.Cid);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateProduct(Product p)
        {
            int result = 0;
            string qry = "update product set name=@name,price=@price,imageurl=@imageurl,cid=@cid where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@imageurl", p.Imageurl);
            cmd.Parameters.AddWithValue("@cid", p.Cid);
            cmd.Parameters.AddWithValue("@id", p.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
