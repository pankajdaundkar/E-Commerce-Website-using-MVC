using System.Data.SqlClient;

namespace Product_Category_CRUD.Models
{
    public class CartCURD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CartCURD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int AddTOCart(Cart cart)
        {
            int result = 0;

            string qry = "insert into Cart values (@id,@uid,@Quantity)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", cart.Id);
            cmd.Parameters.AddWithValue("@uid", cart.Uid);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }
        public List<Product> ViewCart(int uid)
        {
            List<Product> products = new List<Product>();
            string qry = "select p.*, c.Quantity,c.CartId from Product p join Cart c on c.id=p.id where c.uid=@uid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@uid", uid);
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
                    p.Imageurl = dr["imageUrl"].ToString();
                    p.Quantity = Convert.ToInt32(dr["Quantity"]);
                    p.CartId = Convert.ToInt32(dr["CartId"]);
                    products.Add(p);
                }
            }
            return products;
        }
        public int DeleteCart(int CartId)
        {
            int result = 0;

            string qry = " delete from cart where CartId=@CartId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@CartId", CartId);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;

        }
        
    }
}

