using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarks.Models;
using System.Text.RegularExpressions;

namespace Bookmarks.Data
{
    public class BookmarksDAL
    {

        public static void AddBookmarks(string username, string title, string url, string[] tags, string notes)
        {
            var dbCon = new BookmarksEntities();

            using (dbCon)
            {
                var bookmark = new Bookmark();
                bookmark.Notes = notes;
                bookmark.URL = url;
                bookmark.Title = title;

                bookmark.User = CreateOrLoadUser(dbCon, username);

                foreach (var tagName in tags)
                {
                    var tag = CreateOrLoadTag(dbCon, tagName);

                    bookmark.Tags.Add(tag);
                }

                var titleTags = Regex.Split(title, @"[ ,-\.;!?]+");

                foreach (var titleTag in titleTags)
                {
                    var tag = CreateOrLoadTag(dbCon, titleTag);

                    bookmark.Tags.Add(tag);
                }

                dbCon.Bookmarks.Add(bookmark);
                dbCon.SaveChanges();
            }
        }

        private static Tag CreateOrLoadTag(BookmarksEntities context, string tagName)
        {
            var existingTag = (from t in context.Tags
                               where t.Name.ToLower() == tagName.ToLower()
                               select t).FirstOrDefault();

            if (existingTag != null)
            {
                return existingTag;
            }

            var newTag = new Tag();
            newTag.Name = tagName.ToLower();
            context.Tags.Add(newTag);
            context.SaveChanges();
            return newTag;
        }

        private static User CreateOrLoadUser(BookmarksEntities context, string username)
        {
            var existingUser = (from u in context.Users
                                where u.Username.ToLower() == username.ToLower()
                                select u).FirstOrDefault();

            if (existingUser != null)
            {
                return existingUser;
            }

            var newUser = new User();
            newUser.Username = username;
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }
    }
}
