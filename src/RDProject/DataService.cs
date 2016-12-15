using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDProject.Domain_model;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace RDProject
{
    public class DataService : IDataService
    {
        public IList<Answer> GetAnswersToQuestion(int questionid)
        {
            using (var db = new DatabaseContext())
            {
                return db.Set<Answer>().FromSql(
                        "call getanswersforquestion({0})",
                        new object[] { questionid }).ToList();
            }
        }

        public IList<Comment> GetCommentsToPost(int postid)
        {
            using (var db = new DatabaseContext())
            {
                return db.Set<Comment>().FromSql(
                        "call getcommentsforpost({0})",
                        new object[] { postid }).ToList();
            }
        }

        public Boolean Mark(int userid, int postid, string text)
        {
            using(var db = new DatabaseContext())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("call markpost({0},{1},{2})", text, postid, userid);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }   
            }
        }

        public Boolean DeleteMark(int userid, int postid)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("call deletemark({0},{1})", userid,postid);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public IList<Mark> GetMarks(int userid, int page, int pagesize)
        {
            using (var db = new DatabaseContext())
            {
                return db.Set<Mark>().FromSql(
                        "call getmarkedposts({0},{1},{2})",
                        new object[] { userid, page, pagesize }).ToList();
            }
        }

        public IList<Search> GetSearchHistory(int userid, int page, int pagesize)
        {
            using (var db = new DatabaseContext())
            {
                return db.Set<Search>().FromSql(
                        "call getsearchhistory({0},{1},{2})",
                        new object[] { userid, page, pagesize }).ToList();
            }
        }

        //public IList<Post> GetPosts(Func<Post, bool> predicate, int page, int pagesize)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        return db.posts.Where(predicate).ToList();
        //    }
        //}

        public User GetUser(int id)
        {
            using (var db = new DatabaseContext()) {
                return db.Set<User>().FromSql(
                        "call getuser({0})",
                        new object[] { id }).FirstOrDefault();
            }
        }

        //public IList<User> GetUsers(Func<User, bool> predicate, int page, int pagesize)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        return db.users.Where(predicate).ToList();
        //    }
        //}

        public FullPost GetPost(int id)
        {
            FullPost result = new FullPost();
            using(var db = new DatabaseContext())
            {
                var conn = (MySqlConnection)db.Database.GetDbConnection();
                conn.Open();

                var cmd = new MySqlCommand("call getfullpost(@1)", conn);
                cmd.Parameters.Add("@1", DbType.Int32).Value = id;
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    //question
                    Question question = new Question
                    {
                        id = rdr.GetInt32(rdr.GetOrdinal("id")),
                        acceptedanswerid = rdr.IsDBNull(rdr.GetOrdinal("acceptedanswerid"))? 
                        -1 : rdr.GetInt32(rdr.GetOrdinal("acceptedanswerid")),
                        body = rdr.GetString(rdr.GetOrdinal("body")),
                        title = rdr.GetString(rdr.GetOrdinal("title")),
                        score = rdr.GetInt32(rdr.GetOrdinal("score")),
                        creationdate = rdr.GetDateTime(rdr.GetOrdinal("creationdate")),
                        postid = rdr.GetInt32(rdr.GetOrdinal("postid")),
                        userid = rdr.GetInt32(rdr.GetOrdinal("ownerid")),
                        username = rdr.GetString(rdr.GetOrdinal("displayname"))

                    };
               


                    //tags
                    rdr.NextResult();
                    var tags = new List<string>();
                    while (rdr.Read())
                    {
                        tags.Add(rdr.GetString(rdr.GetOrdinal("tag")));
                    }

                    //answers
                    rdr.NextResult();
                    var answers = new List<Answer>();
                    while (rdr.Read())
                    {
                        answers.Add(new Answer
                        {
                            id = rdr.GetInt32(rdr.GetOrdinal("id")),
                            body = rdr.GetString(rdr.GetOrdinal("body")),
                            score = rdr.GetInt32(rdr.GetOrdinal("score")),
                            creationdate = rdr.GetDateTime(rdr.GetOrdinal("creationdate")),
                            postid = rdr.GetInt32(rdr.GetOrdinal("postid")),
                            userid = rdr.GetInt32(rdr.GetOrdinal("ownerid")),
                            parentid = rdr.GetInt32(rdr.GetOrdinal("parentid")),
                            username = rdr.GetString(rdr.GetOrdinal("displayname"))

                        });
                    }

                    //comments
                    rdr.NextResult();
                    var comments = new List<Comment>();
                    while (rdr.Read())
                    {
                        comments.Add(new Comment
                        {
                            id = rdr.GetInt32(rdr.GetOrdinal("id")),
                            body = rdr.GetString(rdr.GetOrdinal("body")),
                            score = rdr.GetInt32(rdr.GetOrdinal("score")),
                            creationdate = rdr.GetDateTime(rdr.GetOrdinal("creationdate")),
                            postid = rdr.GetInt32(rdr.GetOrdinal("postid")),
                            userid = rdr.GetInt32(rdr.GetOrdinal("ownerid")),
                            parentid = rdr.GetInt32(rdr.GetOrdinal("parentid")),
                            username = rdr.GetString(rdr.GetOrdinal("displayname")),

                        });
                    }

                    result = new FullPost
                    {
                        question = question,
                        tags = tags,
                        answers = answers,
                        comments = comments
                    };
                }

                return result;
            }
            
        }

        public IList<SearchResult> Search(string search, int userid, int page, int pagesize)
        {
            List<SearchResult> result = new List<SearchResult>();
            using (var db = new DatabaseContext())
            {
                List<int> questionids = db.Set<SearchId>().FromSql(
                    "call mysearch({0},{1},{2},{3})",
                    new object[] { search, userid, page, pagesize })
                    .Select(q => q.questionid).ToList();

                var conn = (MySqlConnection)db.Database.GetDbConnection();
                conn.Open();

                foreach (int id in questionids)
                {
                    Console.WriteLine(id);
                    //var info = db.Set<SearchResult>().FromSql(
                    //"call getquestioninfo({0})",
                    //new object[] { id }).ToList();
                    var cmd = new MySqlCommand("call getquestioninfo(@1)", conn);
                    cmd.Parameters.Add("@1", DbType.Int32).Value = id;
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if(!rdr.Read()) break;
                        var title = rdr.GetString(rdr.GetOrdinal("title"));
                        var score = rdr.GetInt32(rdr.GetOrdinal("score"));
                        var username = rdr.GetString(rdr.GetOrdinal("displayname"));
                        var tags = new List<string>();
                        rdr.NextResult();
                        while (rdr.Read())
                        {
                            tags.Add(rdr.GetString(rdr.GetOrdinal("tag")));
                        }


                        result.Add(new SearchResult
                        {
                            id = id,
                            username = username,
                            title = title,
                            score = score,
                            tags = tags
                        });
                    }
                }


                return result;
            }
        }

    }
}
