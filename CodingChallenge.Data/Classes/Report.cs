using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Resource;
using CodingChallenge.Guards;

namespace CodingChallenge.Data.Classes
{
    public class Report
    {
        private readonly ResourceManager _resourceManager;

        public Report()
        {
            _resourceManager = new ResourceManager("CodingChallenge.Data.Resource.ResX", typeof(ResX).Assembly);
        }

        public string GenerateReport(List<GeometricShape> shapes)
        {
            var sb = new StringBuilder();

            Guard.Against.IsNull(shapes, ResX.ShapesCanTBeNull);

            GenerateReportHeader(shapes, sb);

            var reportList = shapes.GroupBy(x => x.GetType())
                .Select(group => new ReportShape
                {
                    Type = group.Key,
                    Amount = group.Count(),
                    Area = group.ToList().Sum(s => s.CalculateArea()),
                    Perimeter = group.ToList().Sum(t => t.CalculatePerimeter())
                })
                .ToList();

            GenerateReportBody(sb, reportList);

            GenerateReportFooter(sb, reportList);

            return sb.ToString();
        }

        private static void GenerateReportHeader(List<GeometricShape> shapes, StringBuilder sb)
        {
            sb.Append(shapes.Any() ? $"<h1>{ResX.ShapesReport}</h1>" : $"<h1>{ResX.EmptyListOfShapes}</h1>");
        }

        private static void GenerateReportFooter(StringBuilder sb, List<ReportShape> reports)
        {
            if (reports != null && reports.Any())
            {
                var amountOfShapes = reports.Sum(x => x.Amount);
                var perimeters = reports.Sum(x => x.Perimeter);
                var areas = reports.Sum(x => x.Area);

                sb.Append($"{ResX.TOTAL}:<br/>");
                sb.Append($"{amountOfShapes} {GetPluralOrSingular(amountOfShapes, ResX.Shapes_lowercase, ResX.Shape_lowercase)} ");
                sb.Append($"{ResX.Perimeter} {perimeters.ToString("#.##", ResX.Culture)} ");
                sb.Append($"{ResX.Area} {areas.ToString("#.##", ResX.Culture)}");
            }
        }

        private static string GetPluralOrSingular(int amountOfShapes, string pluralNoun, string singularNoun)
        {
            return amountOfShapes == 1 ? singularNoun : pluralNoun;
        }

        private void GenerateReportBody(StringBuilder sb, List<ReportShape> reports)
        {
            reports.ForEach(x =>
            {
                var type = GetPluralOrSingular(x.Amount,
                    _resourceManager.GetString($"{x.Type.Name}_plural", CultureInfo.CurrentUICulture),
                    _resourceManager.GetString(x.Type.Name, CultureInfo.CurrentUICulture));
                sb.Append(WriteLine(x.Amount, x.Area, x.Perimeter, type));
            });
        }

        private string WriteLine(int amount, decimal area, decimal perimeter, string type)
        {
            if (amount > 0)
            {
                return $"{amount} {type} | " +
                       $"{ResX.Area} {area.ToString("0.##", ResX.Culture)} | " +
                       $"{ResX.Perimeter} {perimeter.ToString("0.##", ResX.Culture)} <br/>";
            }

            return string.Empty;
        }
    }
}