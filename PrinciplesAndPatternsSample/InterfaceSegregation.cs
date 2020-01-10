/*Before*/
using System;

interface IPost
{
    void CreatePost();
}

interface IPostNew
{
    void CreatePost();
    void ReadPost();
}


/*After*/
public interface IPostCreate
{
    void CreatePost();
}

interface IPostRead
{
    void ReadPost();
}



/*Implementation*/
public class Post : IPostCreate, IPostRead
{
    public Post()
    {
    }
    public void CreatePost()
    {
        Console.WriteLine("Create Post");
    }

    public void ReadPost()
    {
        Console.WriteLine("Create Post");
    }


    class PostCreate : IPostCreate
    {
        public void CreatePost()
        {
            throw new NotImplementedException();
        }
    }

    interface IPostDelete : IPostCreate
    {
        void DeletePost();

    }

    class DeletePost : IPostDelete
    {
        public void CreatePost()
        {
            throw new NotImplementedException();
        }

        void IPostDelete.DeletePost()
        {
            throw new NotImplementedException();
        }
    }

    class Main
    {
        public Main()
        {
            IPostCreate a = new Post();
        }
    }
}