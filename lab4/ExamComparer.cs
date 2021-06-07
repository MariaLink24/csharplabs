using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class ExamComparer : IComparer<Exam>

    {
        public int Compare(Exam x, Exam y)
        {
            if (x.examDate == y.examDate)
                return 0;
            else
                if (x.examDate < y.examDate)
                return -1;
            else
                return 1;
        }
    }

