using PrinciplesAndPatternsSample;
using System;
using System.IO;

namespace DependencyInjectionBefore
{
    class ErrorLogger
    {
        private Database _db;

        public ErrorLogger() { }
        public ErrorLogger(Database db) { _db = db; }

        public void log(string error)
        {
            _db.LogError($"An error occured: {error}");
            File.WriteAllText("LocalErrors.txt", error);
        }
    }

    class Post
    {
        private ErrorLogger errorLogger = new ErrorLogger();

        void CreatePost(Database db, string postMessage)
        {
            try
            {
                db.Add(postMessage);
            }
            catch (Exception ex)
            {
                errorLogger.log(ex.ToString());
            }
        }
    }


}

namespace DependencyInjectionAfter
{
    class Logger
    {
        private Database _db;

        public Logger() { }
        public Logger(Database db) { _db = db; }

        public void log(string error)
        {
            _db.LogError($"An error occured: {error}");
            File.WriteAllText("LocalErrors.txt", error);
        }
    }

    class Post
    {
        private Logger _logger;

        public Post(Logger injectedLogger)
        {
            _logger = injectedLogger;
        }

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
}