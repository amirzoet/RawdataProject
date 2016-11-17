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
