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
