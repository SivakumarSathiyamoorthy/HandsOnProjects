using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    internal class EngineeringGrade : OverallGrade
    {
        public override string GetGrade(Student stu)
        {
            if (stu.Name == null) { throw new ArgumentNullException(); }
           

            int avg = ( stu.Science + stu.Maths) / 2;

            switch (avg)
            {
                case var _ when avg > 90:
                    return "Gold Medal";

                case var _ when (avg >= 80 && avg <= 90):
                    return "Silver Medal";

                case var _ when (avg < 80 && avg > 50):
                    return "Bronze Medal";

                default:
                    return "NA";

            }

        }
    }
}
