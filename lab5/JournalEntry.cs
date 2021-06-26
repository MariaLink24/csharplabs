using System;
namespace testlab
{
    public class JournalEntry
    {
        string NameOfCollection { get; set; }
        Update U { get; set; }
        string PropertyName { get; set; }
        int RegisterNumber { get; set; }
        public JournalEntry(string nameOfCollection, Update update, string propertyName, int registredNumber)
        {
            NameOfCollection = nameOfCollection; U = update; PropertyName = propertyName; RegisterNumber = registredNumber;
        }
        public override string ToString()
        {
            return "NameOfCollection: " + NameOfCollection + ", Update: " + Update + ", PropertyName: " + PropertyName + ", RegistredNumber: " + RegisterNumber;
        }
    }
}
