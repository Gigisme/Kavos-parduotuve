using Dapper;
using MvcMovie.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.db
{
    public class Db
    {
        private readonly ILogger<Db> _logger;
        private readonly IConfiguration _configuration;

        public Db(ILogger<Db> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
    

        public Preke? GetProductById(int productId)
        {
            var query = @"
SELECT
    id AS Id,
    pavadinimas AS Name, 
    kaina AS Price, 
    nuotrauka AS Image, 
    svoris AS Weight, 
    aprasymas AS Description, 
    reitingas AS Rating
FROM prekes 
WHERE id = @productId";
            using IDbConnection db = GetConnection();
            var product = db.QueryFirst<Preke>(query, new { productId } );
            return product;
        }

        public int DeleteProduct(int productId)
        {
            var query = "DELETE FROM prekes WHERE id = @productId";
            using IDbConnection db = GetConnection();
            var product = db.Execute(query, new { productId });
            return product;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_configuration["DbConnStr"]);
        }

        public int AddProduct(Preke product)
        {
            string productInsert = 
@"INSERT INTO prekes 
(pavadinimas, kaina, nuotrauka, svoris, aprasymas, reitingas) 
Values (@Name, @Price, @Image, @Weight, @Description, @Rating);";
            using IDbConnection db = GetConnection();
            var affectedRows = db.Execute(productInsert, product);
            return affectedRows;
        }

        public int UpdateProduct(Preke product)
        {
            string productUpdate =
@"UPDATE prekes SET 
pavadinimas = @Name, kaina = @Price, svoris = @Weight, aprasymas = @Description
WHERE id = @Id;";
            using IDbConnection db = GetConnection();
            var affectedRows = db.Execute(productUpdate, product);
            return affectedRows;
        }

        public List<Preke> FilterProducts(int input1, int input2)
        {
            var query = @"
SELECT 
                        prekes.id AS Id, 
                        prekes.pavadinimas AS Name, 
                        prekes.kaina AS Price, 
                        prekes.nuotrauka AS Image, 
                        prekes.svoris AS Weight, 
                        prekes.aprasymas AS Description, 
                        prekes.reitingas AS Rating,
                        reklamos.lygis AS Ad
                    FROM prekes
                    LEFT JOIN reklamos ON reklamos.fk_preke = prekes.id
                    WHERE prekes.kaina >= @input1 AND prekes.kaina <= @input2
                    ORDER BY (CASE reklamos.lygis
                        WHEN 'ekonimiška' THEN 3
                        WHEN 'premium' THEN 2
                        WHEN 'super' THEN 1
                        ELSE 4 END)  ASC, reklamos.nuo DESC
;";
            using IDbConnection db = GetConnection();
            var products = db.Query<Preke>(query, new { input1, input2 }).ToList();
            return products;
        }

        public int CreateAd(Reklama ad)
        {
            string adInsert =
 @"INSERT INTO reklamos 
(nuo, iki, kaina, lygis, fk_preke) 
Values (@From, @To, @Price, @Level, @Fk_product);";
            using IDbConnection db = GetConnection();
            var affectedRows = db.Execute(adInsert, ad);
            return affectedRows;
        }

        public List<Preke> GetProducts()
        {
            using IDbConnection db = GetConnection();
            var products = db.Query<Preke>(
                @"
                    SELECT 
                        prekes.id AS Id, 
                        prekes.pavadinimas AS Name, 
                        prekes.kaina AS Price, 
                        prekes.nuotrauka AS Image, 
                        prekes.svoris AS Weight, 
                        prekes.aprasymas AS Description, 
                        prekes.reitingas AS Rating,
                        reklamos.lygis AS Ad
                    FROM prekes
                    LEFT JOIN reklamos ON reklamos.fk_preke = prekes.id
                    ORDER BY (CASE reklamos.lygis
                        WHEN 'ekonimiška' THEN 3
                        WHEN 'premium' THEN 2
                        WHEN 'super' THEN 1
                        ELSE 4 END)  ASC, reklamos.nuo DESC;
                    
                    
                    
                    ")
                .ToList();

            if (products == null)
            {
                return default;
            }

            return products;
        }
    }
}
