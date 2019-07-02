using NUnit.Framework;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Tests.UnitTest
{
    [TestFixture]
    public class TicketTests
    {
        public  Ticket _boletim;
        public readonly Student _student = new Student("Jarson", "057.027.037-25");
        public readonly Student _student1 = new Student("Joao", "057.027.037-25");
        public readonly Teacher _teacher = new Teacher("Maria", "157.127.037-25");
        public readonly Teacher _teacher2 = new Teacher("mario", "157.127.037-25");


        [SetUp]
        public void Setup()
        {
            _boletim = new Ticket("1 - Periodo", _student);
        }

        [Test]
        public void Deve_Adicionar_Duas_Avaliacoes()
        {
            Subject matematica = new Subject("Matematica", _teacher);
            Subject portugues = new Subject("Portugues", _teacher);

            _boletim.AddEvaluation(new Evaluation(matematica,4));
            _boletim.AddEvaluation(new Evaluation(portugues,10));

            Assert.AreEqual(2, _boletim.EvaluationQuatity);
        }
       
        [Test]
        public void Dado_Uma_Disciplina_Invalida_Nao_Adiciona_Nota_No_Boletim()
        {
            Subject portugues = new Subject("", _teacher);
         
            _boletim.AddEvaluation(new Evaluation(portugues, 8.30));

            Assert.AreEqual(0, _boletim.EvaluationQuatity);
        }

        [Test]
        public void Dado_Uma_Professor_Invalido_Nao_Adiciona_Nota_No_Boletim()
        {
            Teacher professor = new Teacher("", "1525");
            Subject portugues = new Subject("Portugues", professor);

            _boletim.AddEvaluation(new Evaluation(portugues, 8.30));

            Assert.AreEqual(0, _boletim.EvaluationQuatity);
        }

        [Test]
        public void Retorna_Validacao_Para_Nota_Maior_Menor_Que_Zero()
        {
           
            Subject portugues = new Subject("Portugues", _teacher2);

            _boletim.AddEvaluation(new Evaluation(portugues, 10.1));

            Assert.AreEqual(false, _boletim.Valid);
        }

        [Test]
        public void Retorna_Validacao_Para_Nota_Menor_Que_Zero()
        {
         
            Subject portugues = new Subject("Portugues", _teacher2);

            _boletim.AddEvaluation(new Evaluation(portugues, -1));

            Assert.AreEqual(false, _boletim.Valid);
        }

        [Test]
        public void Dado_Duas_Disciplinas_Retorna_Media_Nota_7()
        {
    
            Subject portugues = new Subject("Portugues", _teacher2);
            Subject matematica = new Subject("Matematica", _teacher);

            _boletim.AddEvaluation(new Evaluation(portugues, 6));
            _boletim.AddEvaluation(new Evaluation(matematica, 8));

            Assert.AreEqual(7, _boletim.AverageEvaluation());
        }

        [Test]
        public void Dado_Tres_Disciplinas_Retorna_Nota_Cinco()
        {

            Subject portugues = new Subject("Portugues", _teacher2);
            Subject matematica = new Subject("Matematica", _teacher);
            Subject historia = new Subject("Matematica", _teacher2);

            _boletim.AddEvaluation(new Evaluation(portugues, 6));
            _boletim.AddEvaluation(new Evaluation(matematica, 5));
            _boletim.AddEvaluation(new Evaluation(historia, 4));

            Assert.AreEqual(5, _boletim.AverageEvaluation());
        }

        [Test]
        public void Dado_Boletim_Sem_Informacoes_Deve_Retornar_Media_Zero()
        {

            Assert.AreEqual(0, _boletim.AverageEvaluation());
        }

    }
}
