﻿using Microsoft.AspNetCore.Mvc;
using RDProject.Domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ModelFactory
    {
        public static User Map(UserModel model)
        {
            return new User
            {
                name = model.name,
                creationdate = model.creationdate,
                age = model.age,
                location = model.location
            };
        }

        public static UserModel Map(User user, IUrlHelper URL)
        {
            return new UserModel
            {
                url = URL.Link(Config.UserRoute, new { id = user.id  }),
                name = user.name,
                creationdate = user.creationdate,
                age = user.age,
                location = user.location,
            };
        }

        //public static Mark Map(MarkModel model)
        //{
        //    return new Mark
        //    {
        //        mark = model.mark,
        //        postid = model.url,
        //        userid = model.url,
        //        title = model.title
        //    };
        //}

        public static MarkModel Map(Mark mark, IUrlHelper URL)
        {
            return new MarkModel
            {
                posturl = URL.Link(Config.PostRoute, new { id = mark.postid}),
                mark = mark.mark,
                title = mark.title,
                };
        }

        public static List<SearchResultModel> Map(List<SearchResult> searchresults)
        {
            List<SearchResultModel> srms = new List<SearchResultModel>();
            foreach (var sr in searchresults)
            {
                srms.Add(new SearchResultModel
                {
                    score = sr.score,
                    tags = sr.tags,
                    title = sr.title,
                    username = sr.username
                });
            }
            return srms; 
        }

        public static SearchHistoryModel Map(Search search)
        {
            return new SearchHistoryModel
            {
                text = search.text,
                timestamp = search.timestamp
            };
        }


        public static List<CommentModel> Map(List<Comment> comments, IUrlHelper URL)
        {
            List<CommentModel> result = new List<CommentModel>();
            foreach (var comment in comments)
            {
                result.Add(new CommentModel
                {
                    body = comment.body,
                    creationdate = comment.creationdate,
                    score = comment.score,
                    username = comment.username,
                    userurl = URL.Link(Config.UserRoute, new { id = comment.userid })
                });
            }
            return result;
        }

        public static FullPostModel Map(FullPost post, IUrlHelper URL)
        {
            FullPostModel fpm = new FullPostModel();

            QuestionModel qm = new QuestionModel
            {
                comments = Map(post.comments.Where(c => c.parentid == post.question.postid).ToList(),URL),
                body = post.question.body,
                creationdate = post.question.creationdate,
                score = post.question.score,
                title = post.question.title,
                username = post.question.username,
                userurl = URL.Link(Config.UserRoute, new { id = post.question.userid })           
            };
            List<AnswerModel> ams = new List<AnswerModel>();
            foreach (var answer in post.answers)
            {
                Console.WriteLine(answer.id);
                ams.Add(new AnswerModel
                {
                    comments = Map(post.comments.Where(c => c.parentid == answer.postid).ToList(),URL),
                    body = answer.body,
                    creationdate = answer.creationdate,
                    score = answer.score,
                    username = answer.username,
                    userurl = URL.Link(Config.UserRoute, new { id = answer.userid })
                });
            }

            fpm = new FullPostModel
            {
                questionmodel = qm,
                answermodels = ams,
                tags = post.tags,
                url = URL.Link(Config.PostRoute, new { id = post.question.postid})
            };
            return fpm;
        }

    }
}
