namespace PerformanceRecord2.Controler
{
    public interface IOutput
    {
        //1
        void OutputGroupedDisciplinesByFormOfControle();
        //2
        void OutputBestStudent();
        //3
        void OutputStudentsWherePIBStartWith(string letter);
        //4
        void OutputDisciplinesOnCourses();
        //5
        void OutputConcatDisciplinesStartWith(string letter1, string letter2);
        //6
        void OutputAverageMarkOnDiscipline();
        //7
        void OutputStudentsWithOddId();
        //8
        void OutputSearchMarkOnStudentDiscipline(int studentId, int disciplineId);
        //9
        void OutputStudentsWithMarkBetterThan(int mark);
        //10
        void OutputNumberOfDisciplineOnCours();
        //11
        void OutputGroupeCoursesByYears();
        //12
        void OutputStudentResultOnDiscipline();
        //13
        void OutputHighestMarkOnDiscipline();
        //14
        void OutputStudentsConcat();
        //15
        void OutputCreditModulOnDiscipline(int n);
    }
}
