using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class StudentComparator : IComparer<Student>
{
    public int Compare([AllowNull] Student x, [AllowNull] Student y)
    {

        if (x.meanValue > y.meanValue)
        {
            return 1;
        }
        else if (x.meanValue < y.meanValue)
        {
            return -1;
        }
 
        return 0;

    }

    
 
}