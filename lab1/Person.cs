using System;
class Person
    {
    private string firstName;
    private string lastName;
    private DateTime birthDate;

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

    }