using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDProject
{
    public interface IDataService
    {
        IList<SearchResult> Search(string search, int userid, int page, int pagesize);
        User GetUser(int id);
        IList<Answer> GetAnswersToQuestion(int questionid);
        IList<Comment> GetCommentsToPost(int postid);
        IList<Search> GetSearchHistory(int userid, int page, int pagesize);
        IList<Mark> GetMarks(int userid, int page, int pagesize);
        Boolean Mark(int userid, int postid, string text);
        Boolean DeleteMark(int userid, int postid);
    }
}
