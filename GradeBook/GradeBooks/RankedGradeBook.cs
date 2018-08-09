using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
  public  class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
            IsWeighted = weighted;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(this.Students.Count < 5)
            {
                return 'F';
                throw new InvalidOperationException();
               
            }
            else
            {
                int treshold = (int) Math.Ceiling(Students.Count*0.2);
                List<double> grades = Students.OrderByDescending(k => k.AverageGrade).Select(k => k.AverageGrade).ToList();

                if (grades[treshold-1] <= averageGrade)
                {
                    return 'A'; 
                }else if(grades[2* treshold - 1] <= averageGrade)
                {
                    return 'B';
                }else if (grades[3 * treshold - 1] <= averageGrade)
                {
                    return 'C';
                }else if (grades[4 * treshold - 1] <= averageGrade)
                {
                    return 'D';
                }
                
                else
                {
                    return 'F';
                }
      
            }
          
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;

            }
            else
            {
                base.CalculateStatistics();
                return;
            }
           
        }

        public override void CalculateStudentStatistics(string name)
        {

            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;

            }
            else
            {
                base.CalculateStudentStatistics(name);
                return;
            }
      
        }

    }


}
