﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Interface.Dal;
using Core.Interface.Product;
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

        private string MySql_Save = "";
        #endregion

        /// <summary>
        /// Returns all entries
        /// </summary>
        public List<IProductInfo> GetAll()
        {
            List<IProductInfo> result = new List<IProductInfo>();

            var comm = GetCommand(MySql_GetAll);
            using (MySqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new ProductInfo(dr.GetInt64("pro_identi"), dr.GetString("pro_name"), dr.GetDouble("pro_price"), dr.GetString("pro_descri")));
                }
            }

            return result;
        }

        /// <summary>
        /// Returns all entries created between the between
        /// </summary>
        public List<IProductInfo> GetBetweenDate(DateTime startDate, DateTime endDate)
        {
            List<IProductInfo> result = new List<IProductInfo>();

            var comm = GetCommand(MySql_GetBetweenDate);
            comm.Parameters.Add( new MySqlParameter( "startDate", startDate ) );
            comm.Parameters.Add( new MySqlParameter( "endDate", endDate ) );

            using (MySqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add( new ProductInfo( dr.GetInt64( "pro_identi" ), dr.GetString( "pro_name" ), dr.GetDouble( "pro_price" ), dr.GetString( "pro_descri" ) ) );
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the entry with the id
        /// </summary>
        public IProductInfo Get(int id)
        {
            IProductInfo result = null;

            var comm = GetCommand( MySql_Get );
            comm.Parameters.Add( new MySqlParameter( "id", id ) );

            using (MySqlDataReader dr = comm.ExecuteReader())
            {
                while (dr.Read())
                {
                    result = new ProductInfo( dr.GetInt64( "pro_identi" ), dr.GetString( "pro_name" ), dr.GetDouble( "pro_price" ), dr.GetString( "pro_descri" ) );
                }
            }

            return result;
        }

        public bool Save(IProductInfo product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IProductInfo product)
        {
            throw new NotImplementedException();
        }

        public bool Update(IProductInfo product)
        {
            throw new NotImplementedException();
        }
    }
}
