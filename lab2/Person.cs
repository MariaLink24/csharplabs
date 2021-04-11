using System;
interface IDateAndCopy {
    object DeepCopy();
    DateTime Date {get; set;}
}
class Person: IDateAndCopy
    {
    protected string firstName;
    protected string lastName;
    protected DateTime birthDate;

    public Person (){
     firstName = "Sharik";
     lastName = "Matroskin";
     birthDate = new DateTime(1980, 2, 3);
    }

    public Person (string fn, string ln, DateTime bd){
        firstName = fn;
        lastName = ln;
        birthDate = bd;
    }

    DateTime IDateAndCopy.Date { get; set; }

    public String first
            {
                get { return firstName; }
                set { firstName = value; }
            }
    public String last
        {
            get { return lastName; }
            set { lastName = value; }
        }
    
    public DateTime date
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

    public int birthYear
        {
            get { return birthDate.Year; }
            set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
        }


    public override string ToString()
        {
            return firstName + " " + lastName + " " + birthDate.ToString() + "\n";
        }
    public virtual string ToShortString()
        {
            return  firstName + " " +  lastName + "\n";
        }
    
    public override  bool Equals(object obj){
          Person personObject = obj as Person;

          return obj != null &&
          this.firstName == personObject.firstName &&
             this.lastName == personObject.lastName &&
             this.birthDate == personObject.birthDate;         
        }
        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }
        public override int GetHashCode()
        {
            return this.firstName.GetHashCode()+this.lastName.GetHashCode()+this.birthDate.GetHashCode();
        }
        public virtual object DeepCopy()
        {
            Person copiedPerson = new Person();
            copiedPerson.lastName = (string)lastName.Clone();
            copiedPerson.firstName = (string)firstName.Clone();
            copiedPerson.birthDate = birthDate;
            return copiedPerson;
        }

    }