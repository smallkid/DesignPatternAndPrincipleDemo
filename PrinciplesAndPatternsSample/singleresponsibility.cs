/*SRP*/

/*Before*/
using System;
using System.IO;


namespace PrinciplesAndPatternsSample.SingleResponsibility
{ 
    class User
    {
        void CreatePost(Database db, string postMessage)
        {
            try
            {
                db.Add(postMessage);
            }
            catch (Exception ex)
            {
                db.LogError($"An error occured: {ex.ToString()}");
                File.WriteAllText("LocalErrors.txt", ex.ToString());
            }
        }
    }


    /*After*/
    class Post
    {
        private ErrorLogger _logger = new ErrorLogger();

        void CreatePost(Database db, string postMessage)
        {
            try
            {
                db.Add(postMessage);
            }
            catch (Exception ex)
            {
                _logger.log(ex.ToString());
            }
        }
    }

    class ErrorLogger
    {
        private Database _db;

        public ErrorLogger(){ }
        public ErrorLogger(Database db) { _db = db; }

        public void log(string error)
        {
            _db.LogError($"An error occured: {error}");
            File.WriteAllText("LocalErrors.txt", error);
        }
    }
}



