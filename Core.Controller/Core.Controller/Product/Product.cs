using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Interface.Dal;
using Core.Interface.Model.Product;
using Core.Model.Product;

using MySql.Data.MySqlClient;

namespace Core.Controller
{
    public class Product : BaseController, IProductDal
    {
        private static Product _instance;
        public static Product GetInstance()
        {
            if (_instance == null)
                _instance = new Product();
            return _instance;
        }

        #region Queries
        private string MySql_GetAll = "select * from shp_produc";
        private string MySql_GetBetweenDate = "select * from shp_produc where pro_crdate between @startDate and @endDate";
        private string MySql_Get = "select * from shp_produc where pro_identi = @id";

        private string MySql_Insert = "insert into shp_produc ( pro_name, pro_price, pro_descri, pro_crdate, pro_eddate ) values ( @name, @price, @descri, @crdate, @eddate )";
        private string MySql_Delete = "delete from shp_produc where pro_identi = @id";
        private string MySql_Update = "update shp_produc set pro_name = @name, pro_price = @price, pro_descri = @descri, pro_eddate = @eddate where pro_identi = @id";
        #endregion

        /// <summary>
        /// Gets a list of all products
        /// </summary>
        public List<IProductInfo> GetAll()
        {
            List<IProductInfo> result = new List<IProductInfo>();

            var comm = GetCommand(MySql_GetAll);
            using (MySqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new ProductInfo(dr.GetInt64("pro_identi"), dr.GetString("pro_name"), dr.GetDouble("pro_price"), dr.GetString("pro_descri"), dr.GetDateTime("pro_crdate"), dr.GetDateTime("pro_eddate")));
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a product created between two dates
        /// </summary>
        public List<IProductInfo> GetBetweenDate(DateTime startDate, DateTime endDate)
        {
            List<IProductInfo> result = new List<IProductInfo>();

            var comm = GetCommand(MySql_GetBetweenDate);
            comm.Parameters.Add(new MySqlParameter("startDate", startDate));
            comm.Parameters.Add(new MySqlParameter("endDate", endDate));

            using (MySqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new ProductInfo(dr.GetInt64("pro_identi"), dr.GetString("pro_name"), dr.GetDouble("pro_price"), dr.GetString("pro_descri"), dr.GetDateTime("pro_crdate"), dr.GetDateTime("pro_eddate")));
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a product by Id
        /// </summary>
        public IProductInfo Get(int id)
        {
            IProductInfo result = null;

            var comm = GetCommand(MySql_Get);
            comm.Parameters.Add(new MySqlParameter("id", id));

            using (MySqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result = new ProductInfo(dr.GetInt64("pro_identi"), dr.GetString("pro_name"), dr.GetDouble("pro_price"), dr.GetString("pro_descri"), dr.GetDateTime("pro_crdate"), dr.GetDateTime("pro_eddate"));
                }
            }

            return result;
        }

        /// <summary>
        /// Inserts a new product
        /// </summary>
        public bool Insert(IProductInfo product)
        {
            product.CreatedDate = DateTime.Now;

            var comm = GetCommand(MySql_Insert);
            comm.Parameters.Add(new MySqlParameter("name", product.Name));
            comm.Parameters.Add(new MySqlParameter("price", product.Price));
            comm.Parameters.Add(new MySqlParameter("descri", product.Description));
            comm.Parameters.Add(new MySqlParameter("crdate", product.CreatedDate));
            comm.Parameters.Add(new MySqlParameter("eddate", product.EditedDate));

            product.Id = comm.ExecuteNonQuery();

            return product.Id > 0;
        }

        /// <summary>
        /// Updates an existing product by Id
        /// </summary>
        public bool Delete(long id)
        {
            var comm = GetCommand(MySql_Delete);
            comm.Parameters.Add(new MySqlParameter("id", id));

            return comm.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Deletes an existing product
        /// </summary>
        public bool Delete(IProductInfo product)
        {
            var comm = GetCommand(MySql_Delete);
            comm.Parameters.Add(new MySqlParameter("id", product.Id));

            return comm.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        public bool Update(IProductInfo product)
        {
            product.EditedDate = DateTime.Now;
            
            var comm = GetCommand(MySql_Update);
            comm.Parameters.Add(new MySqlParameter("name", product.Name));
            comm.Parameters.Add(new MySqlParameter("price", product.Price));
            comm.Parameters.Add(new MySqlParameter("descri", product.Description));
            comm.Parameters.Add(new MySqlParameter("eddate", product.EditedDate));
            comm.Parameters.Add(new MySqlParameter("id", product.Id));

            return comm.ExecuteNonQuery() > 0;
        }
    }
}
