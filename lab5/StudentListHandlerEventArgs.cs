using System;
namespace testlab
{
    public enum Update { Add, Replace, Delete };

    public class StudentListHandlerEventArgs<TKey> : EventArgs
    {

        public string name { get; set; }
        public Update Type { get; set; }
        public TKey ChangedKey { get; set; }

        public StudentListHandlerEventArgs(string n, Update T, TKey C)
        {
            name = n;
            Type = T;
            ChangedKey = C;
        }
        public override string ToString()
        {
            return name + "\n" + Type.ToString() + "\n" + ChangedKey.ToString();
        }
    }
}
