namespace Product_Category_CRUD.Models
{
    using System.Data.SqlClient;

    
    
        public class OrderCURD
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            IConfiguration configuration;
            public OrderCURD(IConfiguration configuration)
            {
                this.configuration = configuration;
                con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
            }
            public int AddOrder(Order order)
            {
                int result = 0;

                string qry = "insert into Orders(id,uid)values (@id,@uid)";
                cmd = new SqlCommand(qry, con);
                //cmd.Parameters.AddWithValue("@quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@id", order.Id);
                cmd.Parameters.AddWithValue("@uid", order.Uid);

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                return result;

            }
            public List<Product> GetMyOrder(int uid)
            {
                List<Product> products = new List<Product>();
                string qry = "select p.*,o.* from product p join Orders o on o.id=p.id  where o.uid=@uid";
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
                        p.Imageurl = dr["imageurl"].ToString();
                        //p.Cid = Convert.ToInt32(dr["cid"]);
                    p.OrderId = Convert.ToInt32(dr["orderid"]);
                    //p.Quantity = Convert.ToInt32(dr["quantity"]);
                    p.DateTime = Convert.ToDateTime(dr["Date_Time"]);
                    products.Add(p);
                    }
                }
                con.Close() ;
                return products;
            }
        }
    }

