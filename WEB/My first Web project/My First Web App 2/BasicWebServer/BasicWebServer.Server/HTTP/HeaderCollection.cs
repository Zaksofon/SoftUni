
using System.Collections;

namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection : IEnumerable<Header>

    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            headers = new Dictionary<string, Header>();
        }

        // this next one thing is an INDEXER (check how does it works)
        public string this[string name] => this.headers[name].Value;
        
        public int Count => headers.Count;

        public bool Contains(string name) => this.headers.ContainsKey(name);

        public void Add(string name, string value)
        {
            headers[name] = new Header(name, value);
        }

        public IEnumerator<Header> GetEnumerator()
        {
            return headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
