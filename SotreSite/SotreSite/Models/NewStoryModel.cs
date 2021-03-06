﻿using StorySite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SotreSite.Models
{
    public class NewStoryModel : IStoryModel
    {
        private IStorySiteUnitOfWork unitOfWork;
        public NewStoryModel(IStorySiteUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateStory(string title, string body)
        {
            var comment = new Comment();
            comment.ID = Guid.NewGuid();
            comment.CommentText = "test comment";

            var story = new Story();
            story.ID = Guid.NewGuid();
            story.CreatedOn = DateTime.Now;
            story.Active = true;
            story.Rating = 3;
            story.Title = "hello";
            story.Comments = new List<Comment>();
            story.Comments.Add(comment);

            unitOfWork.StoryRepository.Insert(story);
            unitOfWork.Save();
        }
    }
}