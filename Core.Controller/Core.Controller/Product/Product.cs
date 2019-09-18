using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Core.Interface.Dal;
using Core.Interface.Model.Product;
using Core.Model.Product;

//using MySql.Data.MySqlClient;
using System.Data.SqlClient;

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
        private string Sql_GetAll = "select * from shp_produc";
        private string Sql_GetBetweenDate = "select * from shp_produc where pro_crdate between @startDate and @endDate";
        private string Sql_Get = "select * from shp_produc where pro_identi = @id";

        private string Sql_Insert = "insert into shp_produc ( pro_name, pro_price, pro_descri, pro_crdate, pro_eddate ) values ( @name, @price, @descri, @crdate, @eddate )";
        private string Sql_Delete = "delete from shp_produc where pro_identi = @id";
        private string Sql_Update = "update shp_produc set pro_name = @name, pro_price = @price, pro_descri = @descri, pro_eddate = @eddate where pro_identi = @id";
        #endregion

        /// <summary>
        /// Gets a list of all products
        /// </summary>
        public List<IProductInfo> GetAll()
        {
            List<IProductInfo> result = new List<IProductInfo>();

            var comm = GetCommand(Sql_GetAll);

            comm.Connection.Open();
            using (SqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new ProductInfo(dr.GetInt64(0), dr.GetString(1), dr.GetDouble(2), dr.GetString(3), dr.GetDateTime(4), dr.GetDateTime(5)));
                }
            }

            CloseCommand();
            return result;
        }

        /// <summary>
        /// Gets a product created between two dates
        /// </summary>
        public List<IProductInfo> GetBetweenDate(string startDate, string endDate)
        {
            DateTime start = DateTime.ParseExact(startDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(endDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            return GetBetweenDate(start, end);
        }

        /// <summary>
        /// Gets a product created between two dates
        /// </summary>
        public List<IProductInfo> GetBetweenDate(DateTime startDate, DateTime endDate)
        {
            List<IProductInfo> result = new List<IProductInfo>();

            var comm = GetCommand(Sql_GetBetweenDate);
            comm.Parameters.Add(new SqlParameter("startDate", startDate));
            comm.Parameters.Add(new SqlParameter("endDate", endDate));

            comm.Connection.Open();
            using (SqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new ProductInfo(dr.GetInt64(0), dr.GetString(1), dr.GetDouble(2), dr.GetString(3), dr.GetDateTime(4), dr.GetDateTime(5)));
                }
            }

            CloseCommand();
            return result;
        }

        /// <summary>
        /// Gets a product by Id
        /// </summary>
        public IProductInfo Get(int id)
        {
            IProductInfo result = null;

            var comm = GetCommand(Sql_Get);
            comm.Parameters.Add(new SqlParameter("id", id));

            comm.Connection.Open();
            using (SqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result = new ProductInfo(dr.GetInt64(0), dr.GetString(1), dr.GetDouble(2), dr.GetString(3), dr.GetDateTime(4), dr.GetDateTime(5));
                }
            }

            CloseCommand();
            return result;
        }

        /// <summary>
        /// Inserts a new product
        /// </summary>
        public bool Insert(IProductInfo product)
        {
            product.CreatedDate = DateTime.Now;

            var comm = GetCommand(Sql_Insert);
            comm.Parameters.Add(new SqlParameter("name", product.Name));
            comm.Parameters.Add(new SqlParameter("price", product.Price));
            comm.Parameters.Add(new SqlParameter("descri", product.Description));
            comm.Parameters.Add(new SqlParameter("crdate", product.CreatedDate));
            comm.Parameters.Add(new SqlParameter("eddate", product.EditedDate));

            comm.Connection.Open();
            product.Id = comm.ExecuteNonQuery();

            CloseCommand();
            return product.Id > 0;
        }

        /// <summary>
        /// Updates an existing product by Id
        /// </summary>
        public bool Delete(long id)
        {
            var comm = GetCommand(Sql_Delete);
            comm.Parameters.Add(new SqlParameter("id", id));

            comm.Connection.Open();
            var result = comm.ExecuteNonQuery() > 0;
            CloseCommand();

            return result;
        }

        /// <summary>
        /// Deletes an existing product
        /// </summary>
        public bool Delete(IProductInfo product)
        {
            var comm = GetCommand(Sql_Delete);
            comm.Parameters.Add(new SqlParameter("id", product.Id));

            comm.Connection.Open();
            var result = comm.ExecuteNonQuery() > 0;
            CloseCommand();

            return result;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        public bool Update(IProductInfo product)
        {
            product.EditedDate = DateTime.Now;
            
            var comm = GetCommand(Sql_Update);
            comm.Parameters.Add(new SqlParameter("name", product.Name));
            comm.Parameters.Add(new SqlParameter("price", product.Price));
            comm.Parameters.Add(new SqlParameter("descri", product.Description));
            comm.Parameters.Add(new SqlParameter("eddate", product.EditedDate));
            comm.Parameters.Add(new SqlParameter("id", product.Id));

            comm.Connection.Open();
            var result = comm.ExecuteNonQuery() > 0;
            CloseCommand();

            return result;
        }
    }
}
