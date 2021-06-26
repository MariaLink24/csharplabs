using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testlab
{
    public class TimeList
    {
        public List<TimeItem> items = new List<TimeItem>();

        public void Add(TimeItem timeItem)
        {
            items.Add(timeItem);
        }

        public static TimeList Load(string fileName)
        {
            var serializer = new XmlSerializer(typeof(TimeList));

            using (TextReader reader = new StreamReader(fileName))
            {
                return (serializer.Deserialize(reader) as TimeList);
            }
        }

        public void Save(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TimeList));

            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, this);
            }

        }
        public override string ToString()
        {
            for (int i = 0; i < items.Count; i++)
                text += (i + 1) + ". " + items[i].ToString() + "\n";
            return text;
        }
    }
}
