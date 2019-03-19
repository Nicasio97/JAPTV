using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public enum MovieType { Watched, Saved, Recommended };

    public class SqlDataAccess2
    {
        /*
         -https://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C
         -https://www.codeproject.com/Articles/823854/How-to-connect-SQL-Database-to-your-Csharp-program >>USING USAGE<<
        */
        //"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
        //@"Server=DESKTOP-RQE2NVK\SQLEXPRESS;Database=JaPTVDB;Trusted_Connection=True;"
        //@"Data Source=.\SQLEXPRESS;Database=JAPTV;Trusted_Connection=True;"
        private readonly string connectionString = @"Server = localhost\SQLEXPRESS;Database=JAPTVDB;Trusted_Connection=True";

        private SqlConnection OpenConnection()
        {
            //with using? 
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = connectionString
            };
            try
            {
                conn.Open();
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al iniciar Coneccion");
                Console.WriteLine(Sqle.Message);
                //throw;
            }
            catch (Exception)
            {
                Console.WriteLine("Problema no relacionado a Sql");
                //throw;
            }

            return conn;
        }
        private SqlConnection CloseConnection()
        {
            //with using? 
            SqlConnection conn = new SqlConnection()
            {
                ConnectionString = connectionString
            };
            conn.Close();
            return conn;
        }

        public User LoadUser(string userName, string password)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.[User] WHERE UserName = @userName AND Password = @password ", conn);
                command.Parameters.Add(new SqlParameter("@userName", userName));
                command.Parameters.Add(new SqlParameter("@password", password));
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();

                while (reader.Read())
                {
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.UserID = int.Parse(reader["UserID"].ToString());
                    user.Name = reader["Name"].ToString();
                    user.Surname = reader["Surname"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                }
                return user;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public User LoadUser(int userID)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.[User] WHERE UserID = @userID", conn);
                command.Parameters.Add(new SqlParameter("@userID", userID));
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();

                while (reader.Read())
                {
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.UserID = int.Parse(reader["UserID"].ToString());
                    user.Name = reader["Name"].ToString();
                    user.Surname = reader["Surname"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                }
                return user;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void RegisterUser(string userName, string password, string Name, string Surname, string email, DateTime birthdate)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO table(UserName, Password, Name, Surname, Email, BirthDate) "
                    + " Values (@0, @1, @2, @3, @4, @5)", conn);
                command.Parameters.Add(new SqlParameter("@0", userName));
                command.Parameters.Add(new SqlParameter("@1", password));
                command.Parameters.Add(new SqlParameter("@2", Name));
                command.Parameters.Add(new SqlParameter("@3", Surname));
                command.Parameters.Add(new SqlParameter("@4", email));
                command.Parameters.Add(new SqlParameter("@5", birthdate));
                command.ExecuteNonQuery();
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);

                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);

                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        //Para traer peliculas con cierto ORDEN, incluir ORDER BY en el sql command 
        public Movie LoadMovie(int movieID)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM Movie WHERE MovieID = @movieID", conn);
                command.Parameters.Add(new SqlParameter("movieID", movieID));
                SqlDataReader reader = command.ExecuteReader();
                Movie movie = new Movie();

                while (reader.Read())
                {
                    movie.MovieID = int.Parse(reader["MovieID"].ToString());
                    movie.Name = reader["Name"].ToString();
                    movie.Description = reader["Description"].ToString();
                    movie.Cast = LoadActors(int.Parse(reader["MovieID"].ToString()));
                    movie.Categories = LoadCategories(int.Parse(reader["MovieID"].ToString()));
                    movie.Director = reader["Director"].ToString();
                    movie.ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString());
                    movie.Rating = float.Parse(reader["Rating"].ToString());
                    movie.RunningTime = int.Parse(reader["RunningTime"].ToString());
                    movie.AgeRestriction = reader["AgeRestriction"].ToString();
                }
                return movie;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<Movie> LoadMovies()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Movie", conn))
                    {
                        var dt = new DataTable();
                        var da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        List<Movie> lm = new List<Movie>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            Movie movie = new Movie();
                            //{
                            movie.MovieID = int.Parse(dr["MovieID"].ToString());
                            movie.Name = dr["Name"].ToString();
                            if (dr["Rating"] != DBNull.Value)
                            {
                                movie.Rating = float.Parse(dr["Rating"].ToString());
                            }
                            //};
                            lm.Add(movie);
                        }
                        return lm;
                    }
                }

            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Category> LoadCategories(int movieID)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT Category.Name, Category.CategoryID FROM MovieCategory, " +
                    "Category WHERE MovieCategory.MovieID = @movieID AND MovieCategory.CategoryID = Category.CategoryID;", conn);
                cmd.Parameters.Add(new SqlParameter("movieID", movieID));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<Category> lm = new List<Category>();

                foreach (DataRow dr in dt.Rows)
                {
                    Category category = new Category
                    {
                        Name = dr["Name"].ToString(),
                        CategoryID = int.Parse(dr["CategoryID"].ToString())
                    };
                    lm.Add(category);
                }
                return lm;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<Actor> LoadActors(int movieID)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT Actor.Name, Actor.ActorID FROM MovieActor, Actor WHERE " +
                    "MovieActor.MovieID = 2 AND MovieActor.ActorID = Actor.ActorID;", conn);
                cmd.Parameters.Add(new SqlParameter("movieID", movieID));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<Actor> lm = new List<Actor>();

                foreach (DataRow dr in dt.Rows)
                {
                    Actor category = new Actor
                    {
                        Name = dr["Name"].ToString(),
                        ActorID = int.Parse(dr["ActorID"].ToString())
                    };
                    lm.Add(category);
                }
                return lm;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<WatchedMovie> LoadWatchedMovies(int userID)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT Movie.MovieID, Movie.Name, WatchedMovie.UserRating, WatchedMovie.WatchedDate " +
                    "FROM Movie, WatchedMovie WHERE WatchedMovie.UserID = @userID AND Movie.MovieID = WatchedMovie.MovieID;SELECT Movie.Name, " +
                    "Movie.Director, WatchedMovie.UserRating, WatchedMovie.WatchedDate FROM Movie, WatchedMovie WHERE WatchedMovie.UserID = 3 " +
                    "AND Movie.MovieID = WatchedMovie.MovieID; ", conn);
                cmd.Parameters.Add(new SqlParameter("userID", userID));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<WatchedMovie> lm = new List<WatchedMovie>();

                foreach (DataRow dr in dt.Rows)
                {
                    WatchedMovie movie = new WatchedMovie
                    {
                        MovieID = int.Parse(dr["MovieID"].ToString()),
                        Name = dr["Name"].ToString(),
                        //Director = dr["Director"].ToString(),
                        WatchedDate = DateTime.Parse(dr["WatchedDate"].ToString()),
                        UserRating = int.Parse(dr["UserRating"].ToString())
                    };

                    //if (dr["UserRating"] == DBNull.Value)
                    //{
                    //    ((PeliculaVista)pelicula).UsuarioCalificacion = 1;
                    //}
                    //else
                    //{
                    //    ((PeliculaVista)pelicula).UsuarioCalificacion = int.Parse(dr["UsuarioCalificacion"].ToString());
                    //}

                    lm.Add(movie);
                }
                return lm;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<SavedMovie> LoadSavedMovies()
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT Movie.MovieID, Movie.Name FROM Movie, SavedMovie WHERE " +
                    "SavedMovie.UserID = 3 AND Movie.MovieID = SavedMovie.MovieID;", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<SavedMovie> lm = new List<SavedMovie>();

                foreach (DataRow dr in dt.Rows)
                {
                    SavedMovie movie = new SavedMovie
                    {
                        MovieID = int.Parse(dr["MovieID"].ToString()),
                        Name = dr["Name"].ToString(),
                    };
                    lm.Add(movie);
                }
                return lm;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<RecommendedMovie> LoadRecommendedMovies()
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT Movie.MovieID, Movie.Name FROM " +
                    "Movie, RecommendedMovie WHERE RecommendedMovie.UserID = 3 AND Movie.MovieID = RecommendedMovie.MovieID;", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<RecommendedMovie> lm = new List<RecommendedMovie>();

                foreach (DataRow dr in dt.Rows)
                {
                    RecommendedMovie movie = new RecommendedMovie
                    {
                        MovieID = int.Parse(dr["MovieID"].ToString()),
                        Name = dr["Name"].ToString(),
                    };
                    lm.Add(movie);
                }
                return lm;
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                return null;
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                return null;
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteMovie(int movieID, int userID, MovieType movieType)
        {
            try
            {
                string tableName;
                switch (movieType)
                {
                    case (MovieType.Recommended):
                        tableName = "RecommendedMovie";
                        break;
                    case (MovieType.Saved):
                        tableName = "SavedMovie";
                        break;
                    case (MovieType.Watched):
                        tableName = "WatchedMovie";
                        break;
                    default:
                        tableName = null;
                        break;
                }
                SqlConnection conn = OpenConnection();
                SqlCommand command = new SqlCommand("DELETE FROM @tableNAme WHERE MovieID = @movieID AND UserID = @userID;", conn);
                command.Parameters.Add(new SqlParameter("@movieID", movieID));
                command.Parameters.Add(new SqlParameter("@userID", userID));
                command.Parameters.Add(new SqlParameter("@tableNAme", tableName));
                command.ExecuteNonQuery();
            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void InsertMovie(int movieID, int userID, MovieType movieType)
        {
            try
            {
                SqlConnection conn = OpenConnection();
                SqlCommand command;
                switch (movieType)
                {
                    case (MovieType.Recommended):
                        command = new SqlCommand("INSERT INTO RecommendedMovie VALUES (@movieID,@userID)", conn);
                        command.Parameters.Add(new SqlParameter("@movieID", movieID));
                        command.Parameters.Add(new SqlParameter("@userID", userID));
                        command.ExecuteNonQuery();
                        break;
                    case (MovieType.Saved):
                        command = new SqlCommand("INSERT INTO SavedMovie VALUES (@movieID,@userID)", conn);
                        command.Parameters.Add(new SqlParameter("@movieID", movieID));
                        command.Parameters.Add(new SqlParameter("@userID", userID));
                        command.ExecuteNonQuery();
                        break;
                    case (MovieType.Watched):
                        command = new SqlCommand("INSERT INTO WatchedMovie (MovieID, UserID, WatchedDate, UserRating) VALUES (@movieID,@userID,@watchedDate,@userRating)", conn);
                        command.Parameters.Add(new SqlParameter("@movieID", movieID));
                        command.Parameters.Add(new SqlParameter("@userID", userID));
                        command.Parameters.Add(new SqlParameter("@watchedDate", DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@userRating", null));
                        command.ExecuteNonQuery();
                        break;
                    default:
                        //throw new Exception();
                        break;
                }

            }
            catch (SqlException Sqle)
            {
                Console.WriteLine("Problema al cargar usuario");
                Console.WriteLine(Sqle.Message);
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problema no relacionado a Sql 2");
                Console.WriteLine(e.Message);
                //throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void MoveFromSavedToWatched(int movieID, int userID)
        {
            try
            {
                InsertMovie(movieID, userID, MovieType.Watched);
                DeleteMovie(movieID, userID, MovieType.Saved);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void MoveFromRecoToWatched(int movieID, int userID)
        {
            try
            {
                InsertMovie(movieID, userID, MovieType.Watched);
                DeleteMovie(movieID, userID, MovieType.Recommended);
            }
            catch (SqlException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void MoveFromRecoToSaved(int movieID, int userID)
        {
            try
            {
                InsertMovie(movieID, userID, MovieType.Saved);
                DeleteMovie(movieID, userID, MovieType.Recommended);
            }
            catch (SqlException)
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RateMovie(int movieID, int userID, int points)
        {
            SqlTransaction trans = null;
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    trans = conn.BeginTransaction();
                    //if(movieID > 5 || movieID < 3)
                    //{
                    //    //Excecute
                    //}
                    //else
                    //{
                    //    //throw new RateOutOfRangeException
                    //}

                    var command = new SqlCommand("UPDATE WatchedMovie SET UserRating = @points WHERE MovieID = @movieID AND UserID = @userID;", conn, trans);
                    //var reader = command.ExecuteReader();
                    command.Parameters.Add(new SqlParameter("@movieID", movieID));
                    command.Parameters.Add(new SqlParameter("@userID", userID));
                    command.Parameters.Add(new SqlParameter("@points", points));
                    command.ExecuteNonQuery();

                    int ratingCount = 0;
                    int ratingSum = 0;
                    command.CommandText = "SELECT RatingCount, RatingSum FROM Movie WHERE MovieID = @movieID";
                    //command.Parameters.Add(new SqlParameter("@movieID", movieID));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ratingCount = int.Parse(reader["RatingCount"].ToString());
                        ratingSum = int.Parse(reader["RatingSum"].ToString());
                    }
                    ratingSum = ratingSum + points;
                    ratingCount = ratingCount + 1;
                    float average = ratingSum / ratingCount;

                    command.CommandText = "UPDATE Movie SET RatingCount = @ratingCount , RatingSum = @ratingSum , Rating = @rating WHERE MovieID = @movieID";
                    command.Parameters.Add(new SqlParameter("@ratingCount", movieID));
                    command.Parameters.Add(new SqlParameter("@ratingSum", userID));
                    command.Parameters.Add(new SqlParameter("@rating", movieID));
                    command.ExecuteNonQuery();

                    trans.Commit();
                }
            }
            catch (SqlException)
            {
                trans.Rollback();
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}