using Flunt.Validations;
using School.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Entities
{
    public class Ticket:Entity
    {
        public Ticket(string description,Student student)
        {
            Description = description;
            Evaluations = new List<Evaluation>();
            Student = student;

            AddNotifications(student.Notifications);
            AddNotifications(new Contract().Requires().IsNotNullOrEmpty(Description, "Descrição", "Descrição não pode ser vazia."));
        }

        public string Description { get; private set; }
        public Student Student { get; private set; }
        public IList<Evaluation> Evaluations { get; private set; }
        public int EvaluationQuatity => Evaluations.Count;

        public void AddEvaluation(Evaluation evaluation)
        {
            AddNotifications(evaluation);
            if (evaluation.Invalid)
                return;

            Evaluations.Add(evaluation);
        }

        public double AverageEvaluation()
        {
            double count = 0;
            if(EvaluationQuatity == 0)
                return 0;
            
          
            foreach (var evaluation in Evaluations)
            {
                count += evaluation.Note;
            }

            return Average(count, EvaluationQuatity);
        }

        public  double Average(double value, double average)
        {
            if (average <= 0)
                return 0;
            return value / average;
        }



    }
}
