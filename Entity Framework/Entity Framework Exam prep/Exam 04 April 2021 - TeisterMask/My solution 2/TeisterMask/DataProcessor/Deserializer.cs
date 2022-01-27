using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var projectsTaskXmlAsString =
                XmlConverter.Deserializer<ProjectTaskImportDto>(xmlString, "Projects");

            var sb = new StringBuilder();

            foreach (var projectTaskXml in projectsTaskXmlAsString)
            {
                var isValidProjectOpenDate = DateTime.TryParseExact(projectTaskXml.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validProjectOpenDate);

                var isValidProjectDueDate = DateTime.TryParseExact(projectTaskXml.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validProjectDueDate);

                if (!IsValid(projectTaskXml) || !isValidProjectOpenDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var project = new Project()
                {
                    Name = projectTaskXml.Name,
                    OpenDate = validProjectOpenDate,
                    DueDate = isValidProjectDueDate ? validProjectDueDate : (DateTime?)null
                };

                foreach (var taskXml in projectTaskXml.Tasks)
                {
                    var isValidTaskOpenDate = DateTime.TryParseExact(taskXml.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validTaskOpenDate);

                    var isValidTaskDueDate = DateTime.TryParseExact(taskXml.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validTaskDueDate);

                    if (!IsValid(taskXml) || !isValidTaskOpenDate || !isValidTaskDueDate
                        || validTaskOpenDate < validProjectOpenDate
                        || validProjectDueDate.Date != DateTime.MinValue && validProjectDueDate < validTaskDueDate)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var task = new Task()
                    {
                        Name = taskXml.Name,
                        OpenDate = validTaskOpenDate,
                        DueDate = validTaskDueDate,
                        ExecutionType = (ExecutionType)taskXml.ExecutionType,
                        LabelType = (LabelType)taskXml.LabelType
                    };
                    project.Tasks.Add(task);
                }

                context.Projects.AddRange(project);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported project - {projectTaskXml.Name} with {project.Tasks.Count()} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeeTaskJsonAsString =
                JsonConvert.DeserializeObject<IEnumerable<EmployeeTaskImportDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var employeeTaskJson in employeeTaskJsonAsString)
            {
                if (!IsValid(employeeTaskJson))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var employee = new Employee()
                {
                    Username = employeeTaskJson.Username,
                    Email = employeeTaskJson.Email,
                    Phone = employeeTaskJson.Phone,
                };

                foreach (var jsonTask in employeeTaskJson.Tasks.Distinct())
                {
                    var task = context.Tasks.Find(jsonTask);

                    if (task == null)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var newEmployeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    };
                    context.EmployeesTasks.Add(newEmployeeTask);
                }
                context.SaveChanges();
                sb.AppendLine($"Successfully imported employee - {employeeTaskJson.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}