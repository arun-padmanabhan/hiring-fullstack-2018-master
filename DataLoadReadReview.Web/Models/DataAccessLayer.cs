using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;


    public class DataAccessLayer
    {
        
        public IEnumerable<string> GetAllTables()
        {
            List<string> myCollection = new List<string>();

            using (var connection = new NpgsqlConnection("Host=127.0.0.1;port=5701;Username=arun;Password=V0zxKQd6M0Qp;Database=hiring"))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pg_catalog.pg_tables", connection);
                NpgsqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                    myCollection.Add(dr[1].ToString());

            }

            return myCollection;
        }
       
    }
