using System.Collections.Generic;

namespace SAX.CoreLibrary.Models
{
    public class OpenClass : IOpenClass
    {
        private IDictionary<string, dynamic> DataObjects { get; set; }
        public dynamic GetValue(string key)
        {
            dynamic value;
            DataObjects.TryGetValue(key, out value);
            return value;
        }

        public void SetValue(string key, dynamic value)
        {
            DataObjects.Add(key, value);
        }
    }
}
