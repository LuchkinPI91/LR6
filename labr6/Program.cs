using System;

namespace labr6
{
  
    class Program
    {
        static void Main(string[] args)
        {
            String ln;
            int groupn;
            double avgb1;
            double avgb2;
            int id1;
            int n;
            Students student = new Students();
            Console.WriteLine("Введите кол-во студентов:");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите Фамилию студента:");
                ln = Console.ReadLine();
                Console.WriteLine("Введите номер группы:");
                groupn = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите средный балл за 1 экзамен:");
                avgb1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите средный балл за 2 экзамен:");
                avgb2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите номер зачетки:");
                id1 = Convert.ToInt32(Console.ReadLine());

                student.set_student(i, ln, groupn, avgb1, avgb2);
                student.student_book.set_id(i, id1); 

            }

            Console.WriteLine("До сортировки:");
            student.outPut(n);
            Console.WriteLine("После сортировки:");
            student.sort(n);
            student.outPut(n);
            student.zadanie(n);
            student.sum(n);

        }
    }

    class Students
    {
        public const int M = 30;
        private String[] last_name = new String[M];
        private int[] group = new int[M];
        private double[] avg_ball1 = new double[M];
        private double[] avg_ball2 = new double[M];
        public Student_book student_book = new Student_book();
        public void set_student(int i, String last_n, int groupn, double ab1, double ab2) 
        {
            last_name[i] = last_n;
            group[i] = groupn;
            avg_ball1[i] = ab1;
            avg_ball2[i] = ab2;
        }

        public void outPut(int n) 
        {
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine("{0} | {1} | {2} | {3} | {4}", last_name[i], group[i], avg_ball1[i], avg_ball2[i],student_book.get_id(i));

            }
        }

        public void sort(int n) 
        {
            String ln;
            int gp;
            double ab1;
            double ab2;
            int Id, Id1;

            for (int i = 0; i < n - 1; i++) 
            {
                for (int j = n - 1; j > i; j--) 
                {

                    ln = last_name[j - 1];
                    last_name[j - 1] = last_name[j];
                    last_name[j] = ln;

                    gp = group[j - 1];
                    group[j - 1] = group[j];
                    group[j] = gp;

                    ab1 = avg_ball1[j - 1];
                    avg_ball1[j - 1] = avg_ball1[j];
                    avg_ball1[j] = ab1;

                    ab2 = avg_ball2[j - 1];
                    avg_ball2[j - 1] = avg_ball2[j];
                    avg_ball2[j] = ab2;

                    Id = student_book.get_id(j - 1);
                    Id1 = student_book.get_id(j);
                    student_book.set_id(j - 1, Id1);
                    student_book.set_id(j, Id);

                }
            }
        
        
        
        
        }

        public void zadanie(int n) 
        {
            for (int i = 0; i < n; i++) 
            {

                if (avg_ball2[i] < avg_ball1[i]) 
                {
                  
                    Console.WriteLine("{0}", last_name[i]);
                
                }
            
            }
        
        
        }

        public void sum(int n)
        {
            double sum1, sum2;
            sum1 = 0;
            sum2 = 0;
            for (int i = 0; i < n; i++)
            { 
                sum1 += avg_ball1[i];
                sum2 += avg_ball2[i];
            }

            Console.WriteLine("Sum1:{0}", sum1);
            Console.WriteLine("Sum2:{0}", sum2);
        }
    }

    class Student_book
    {
        public const int M = 30;

        private int[] id = new int[M];

        public void set_id(int i,int id1) 
        {

            id[i] = id1;

        }

        public int get_id(int i)
        {

            return id[i];
 
        }
    
    }
}
