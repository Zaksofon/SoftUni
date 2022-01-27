using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using AutoMapper;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using ExportDto;

    using Formatting = Newtonsoft.Json.Formatting;
    public class Serializer
    {
        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToList()
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .OrderByDescending(et => et.DueDate)
                        .ThenBy(et => et.TaskName)
                        .ToList()
                })
                .OrderByDescending(e => e.Tasks.Count)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {


            var projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ProjectTaskExportDto()
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new TaskExportDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Tasks.Count())
                .ThenBy(p => p.ProjectName)
                .ToArray();

            return XmlConverter.Serialize(projects, "Projects");
        }
    }
}
