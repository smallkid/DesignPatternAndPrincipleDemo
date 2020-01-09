/*liskov*/
/*Before */
using PrinciplesAndPatternsSample;
using System.Collections.Generic;

namespace LiskovBefore
{
    public class Post
    {
        public virtual void CreatePost(Database db, string postMessage)
        {
            db.Add(postMessage);
        }
    }

    class TagPost : Post
    {
        public override void CreatePost(Database db, string postMessage)
        {
            db.AddAsTag(postMessage);
        }
    }

    class MentionPost : Post
    {
        void CreateMentionPost(Database db, string postMessage)
        {
            string user = postMessage;

            db.NotifyUser(user);
            db.OverrideExistingMention(user, postMessage);
            base.CreatePost(db, postMessage);
        }
    }

    class PostHandler
    {
        private Database database = new Database();

        void HandleNewPosts()
        {
            List<string> newPosts = database.getUnhandledPostsMessages();

            foreach (string postMessage in newPosts)
            {
                Post post;

                if (postMessage.StartsWith("#"))
                {
                    post = new TagPost();
                }
                else if (postMessage.StartsWith("@"))
                {
                    post = new MentionPost();
                }
                else
                {
                    post = new Post();
                }

                post.CreatePost(database, postMessage);
            }
        }
    }
}


/*After*/
namespace LiskovAfter
{
    public class Post
    {
        public virtual void CreatePost(Database db, string postMessage)
        {
            db.Add(postMessage);
        }
    }

    class MentionPost : Post
    {
        Database _db;

        public override void CreatePost(Database db, string postMessage)
        {
            _db = db;
            string user = postMessage;

            NotifyUser(user);
            OverrideExistingMention(user, postMessage);
            base.CreatePost(db, postMessage);
        }

        private void NotifyUser(string user)
        {
            _db.NotifyUser(user);
        }

        private void OverrideExistingMention(string user, string postMessage)
        {
            _db.OverrideExistingMention(user, postMessage);
        }
    }
}