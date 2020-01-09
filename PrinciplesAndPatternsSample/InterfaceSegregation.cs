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
}