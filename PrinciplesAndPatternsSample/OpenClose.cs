/*open close*/

/*Before*/

using PrinciplesAndPatternsSample;

namespace OpenCloseBefore
{

     
    class Post
    {
        void CreatePost(Database db, string postMessage)
        {
            if (postMessage.StartsWith("#"))
            {
                db.AddAsTag(postMessage);
            }
            else
            {
                db.Add(postMessage);
            }
        }
    }
}


namespace OpenCloseAfter
{ 

    /*After*/
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

}