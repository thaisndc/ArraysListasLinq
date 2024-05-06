using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysListasLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var studants = new List<Student>
            {
                new Student(1, "Thais", "123456789", 100),
                new Student(2, "João", "987654321", 35),
                new Student(3, "Maria", "456789123", 85),
                new Student(4, "José", "654321987", 70),
                new Student(5, "Thais", "321987654", 75),
            };
            
            var any = studants.Any(); //ver se tem algum item na lista
            var any100 = studants.Any(s => s.Grade == 100); // verifica se tem algum aluno que fechou com nota 100

            var single = studants.Single(s => s.Id == 1);// Verifica se existe algum aluno com identificador 1.
            var singleOrDefault = studants.SingleOrDefault(s => s.Document == "123456789");  //Buscar o elemento com essa condição. Buscar pelo menos um aluno com nota 0.

            var first = studants.First(s => s.FullName == "Thais"); //Buscar pelo primeiro elemento, se nao houver lança uma exceção.
            var firstOrDefault = studants.FirstOrDefault(s => s.Grade == 0); // se nenhum elemento corresponde ao critério, ele retorna o valor padrão do tipo de elemento da sequência (primeiro que tirou 0).

            var orderedByGrade = studants.OrderBy(s => s.Grade);//Ordenar os alunos por nota. (Crescente)
            var orderedByGradeDescending = studants.OrderByDescending(s => s.Grade);//Classifica os elementos em ordem decrescente com base no critério especificado.

            var approvedStudants = studants.Where(s => s.Grade >= 70);//Buscar alunos aprovados. Acima ou igual a 70

            var grades = studants.Select(s => s.Grade);//Pegar apenas as notas dos estudantes.
            var phoneNumbers = studants.SelectMany(s => s.PhoneNumbers);// pegar todos os numeros de telefones dos alunos. Coleção unificada.

            var sum = studants.Sum(s => s.Grade);//Somar todas as notas de alunos.
            var min = studants.Sum(s => s.Grade);//Qual a menor nota da turma?
            var max = studants.Sum(s => s.Grade);//Pegar o valor maximo da nota
            var count = studants.Count;//Tamanho da lista de alunos
        }
    }

    public class Student
    {
        public Student(int id, string fullname, string document, int grade)
        {
            this.Id = id;
            this.FullName = fullname;
            this.Document = document;
            this.Grade = grade;

            PhoneNumbers = new List<string> { "123323233", "3412324245", "2445563645" };
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public int Grade { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
