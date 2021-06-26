using System;
namespace testlab
{
    public class Journal
    {
   List<JournalEntry> changes = new List<JournalEntry>();

        public void handler(object sender, StudentListHandlerEventArgs<string> e)
        {
            changes.Add(new JournalEntry(e.NameOfCollection, e.Reason, e.PropertyName, e.RegisterNumber));
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < changes.Count; i++)
                text += changes[i] + "\n";
            return text;
        }
    }
}
