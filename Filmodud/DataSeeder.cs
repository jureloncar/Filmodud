using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Filmodud
{
    public static class DataSeeder
    {
        public static bool CheckIfDatabaseExists(IConfiguration configuration)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(configuration.GetConnectionString("MoviesDatabase")))
            {
                bool dbExists = false;
                connection.Open();
                string cmdText = "SELECT 1 FROM pg_database WHERE datname='Movies'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdText, connection))
                {
                    dbExists = cmd.ExecuteScalar() != null;
                }

                return dbExists;
            }
        }

        public static void CreateMoviesIfNotExist(IConfiguration configuration)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(configuration.GetConnectionString("MoviesDatabase")))
            {
                bool moviesTableExists = false;
                connection.Open();
                string cmdText = "SELECT EXISTS (SELECT table_name FROM information_schema.tables WHERE table_name = 'movies');";
                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdText, connection))
                {
                    moviesTableExists = (bool)cmd.ExecuteScalar();
                }

                if (moviesTableExists == false)
                {
                    string createMoviesTableCmd = @"CREATE TABLE movies (
                                                  movie_id serial PRIMARY KEY,
                                                  title TEXT NOT NULL,
                                                  description TEXT NOT NULL,
                                                  image TEXT NOT NULL,
                                                  release_date timestamp NULL,
                                                  rating int NULL);";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(createMoviesTableCmd, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }
    }
}
