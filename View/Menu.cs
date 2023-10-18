using PerformanceRecord2.Controler;
using System.Collections.Generic;
using System;

namespace PerformanceRecord2.View
{
    public class Menu
    {
        IOutputXMLDocumentOnConsole _xmlDocOutput;
        IOutput _output;
        private Dictionary<MenuList, Action> _commands = new Dictionary<MenuList, Action>();
        public Menu(IOutputXMLDocumentOnConsole xmlDocOutput, IOutput output)
        {
            _xmlDocOutput = xmlDocOutput;
            _output = output;
            InitializeMenuCommands();
        }

        private void InitializeMenuCommands()
        {
            _commands.Add(MenuList.XMLDocumentCourse, () => _xmlDocOutput.XMLDocumentCourse());
            _commands.Add(MenuList.GroupedDisciplinesByFormOfControle, () => _output.OutputGroupedDisciplinesByFormOfControle());
            _commands.Add(MenuList.BestStudent, () => _output.OutputBestStudent());
            _commands.Add(MenuList.StudentsWherePIBStartWith, () => _output.OutputStudentsWherePIBStartWith("J"));
            _commands.Add(MenuList.DisciplinesOnCourses, () => _output.OutputDisciplinesOnCourses());
            _commands.Add(MenuList.ConcatDisciplinesStartWith, () => _output.OutputConcatDisciplinesStartWith("P", "c"));
            _commands.Add(MenuList.AverageMarkOnDiscipline, () => _output.OutputAverageMarkOnDiscipline());
            _commands.Add(MenuList.StudentsWithOddId, () => _output.OutputStudentsWithOddId());
            _commands.Add(MenuList.SearchMarkOnStudentDiscipline, () => _output.OutputSearchMarkOnStudentDiscipline(1, 1));
            _commands.Add(MenuList.StudentsWithMarkBetterThan, () => _output.OutputStudentsWithMarkBetterThan(95));
            _commands.Add(MenuList.NumberOfDisciplineOnCours, () => _output.OutputNumberOfDisciplineOnCours());
            _commands.Add(MenuList.GroupeCoursesByYears, () => _output.OutputGroupeCoursesByYears());
            _commands.Add(MenuList.StudentResultOnDiscipline, () => _output.OutputStudentResultOnDiscipline());
            _commands.Add(MenuList.HighestMarkOnDiscipline, () => _output.OutputHighestMarkOnDiscipline());
            _commands.Add(MenuList.StudentsConcat, () => _output.OutputStudentsConcat());
            _commands.Add(MenuList.CreditModulOnDiscipline, () => _output.OutputCreditModulOnDiscipline(3));

        }
        public void Display()
        {
            Console.WriteLine("Menu:\n0: List of courses\n1: Grouped disciplines by form of controle\n2: Best student" +
                "\n3: Students whose PIB start with letter\n4: Disciplines on courses\n5:  Concat disciplines start with" +
                "\n6: Average mark on discipline\n7: Students with odd Id\n8: Search mark on student discipline" +
                "\n9: Students with mark better than\n10: Number of discipline on cours\n11: Groupe courses by years\n12: Student result on discipline" +
                "\n13: Highest mark on discipline\n14: Students concat\n15: CreditModulOnDiscipline");
           
            Console.Write("Choose number of reqest: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (Enum.IsDefined(typeof(MenuList), choice))
                {
                    ExecuteCommand((MenuList)choice);
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        public void ExecuteCommand(MenuList command)
        {
            if (_commands.TryGetValue(command, out var action))
            {
                action.Invoke();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}
