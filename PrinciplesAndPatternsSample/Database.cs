using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinciplesAndPatternsSample
{
    public class Database
    {
        public Database() { }

        public void Add(string s) => Console.WriteLine(s);

        public void AddAsTag(string s) => Console.WriteLine(s);

        public void NotifyUser(string s) => Console.WriteLine(s);

        public void OverrideExistingMention(string s, string msg) => Console.WriteLine(s);

        public void LogError(string s) => Console.WriteLine(s);

        public List<string> getUnhandledPostsMessages() => new List<string>();
    }

}
