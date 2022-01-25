using System.Collections.Generic;
using System.Data.SqlClient;
using Bloggy.Demo.Domain;

namespace Bloggy.Demo
{
    public class DataAccess
    {
        private const string conString = "Server=(localdb)\\mssqllocaldb; Database=BlogPostDemo";

        public List<BlogPost> GetAllBlogPostsBrief()
        {
            var sql = @"SELECT [Id], [Author], [Title]
                        FROM BlogPost";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<BlogPost>();

                while (reader.Read())
                {
                    var bp = new BlogPost
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Author = reader.GetSqlString(1).Value,
                        Title = reader.GetSqlString(2).Value
                    };
                    list.Add(bp);
                }

                return list;

            }
        }

        public BlogPost GetPostById(int postId)
        {
            var sql = @"SELECT [Id], [Author], [Title]
                        FROM BlogPost 
                        WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", postId));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var bp = new BlogPost
                    {
                        Id = reader.GetSqlInt32(0).Value,
                        Author = reader.GetSqlString(1).Value,
                        Title = reader.GetSqlString(2).Value
                    };
                    return bp;

                }

                return null;

            }
        }

        public void UpdateBlogpost(BlogPost blogPost)
        {
            var sql = "UPDATE BlogPost SET Title=@Title WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", blogPost.Id));
                command.Parameters.Add(new SqlParameter("Title", blogPost.Title));
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBlogpost(BlogPost blogPost)
        {
            var sql = "DELETE FROM BlogPost WHERE id=@Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("Id", blogPost.Id));
                command.ExecuteNonQuery();
            }
        }

        public void CreateBlogpost(BlogPost blogPost)
        {
            var sql = "INSERT INTO BlogPost(Title, Author) VALUES(@title,@author)";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("@author", blogPost.Author));
                command.Parameters.Add(new SqlParameter("@title", blogPost.Title));
                command.ExecuteNonQuery();
            }
        }
    }
}
