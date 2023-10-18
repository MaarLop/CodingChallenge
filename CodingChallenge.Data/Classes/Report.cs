using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Recursos;

namespace CodingChallenge.Data.Classes
{
    public class Report
    {
        public string GenerateReport(List<GeometricShape> shapes)
        {
            var sb = new StringBuilder();

            GenerateReportHeader(shapes, sb);

            int amountOfSquares = 0, amountOfCircles = 0, amountOfTriangles = 0;

            decimal squareAreas = 0m, circleAreas = 0m, triangleAreas = 0m;

            decimal squarePerimeters = 0m, circlePerimeters = 0m, trianglePerimeters = 0m;

            shapes.ForEach(shape =>
            {
                //no me gusta repetir lineas
                if (shape is Square)
                {
                    IncreaseValues(ref amountOfSquares, shape, ref squareAreas, ref squarePerimeters);
                }
                if (shape is Circle)
                {
                    IncreaseValues(ref amountOfCircles, shape, ref circleAreas, ref circlePerimeters);
                }
                if (shape is EquilateralTriangle)
                {
                    IncreaseValues(ref amountOfTriangles, shape, ref triangleAreas, ref trianglePerimeters);
                }
            });

            GenerateReportBody(sb, amountOfSquares, squareAreas, squarePerimeters, amountOfCircles, circleAreas, circlePerimeters, amountOfTriangles, triangleAreas, trianglePerimeters);

            GenerateReportFooter(sb, amountOfSquares + amountOfCircles + amountOfTriangles,
                squarePerimeters + trianglePerimeters + circlePerimeters, squareAreas + circleAreas + triangleAreas);

            return sb.ToString();
        }

        private static void GenerateReportHeader(List<GeometricShape> shapes, StringBuilder sb)
        {
            sb.Append(shapes.Any() ? $"<h1>{ResX.ShapesReport}</h1>" : $"<h1>{ResX.EmptyListOfShapes}</h1>");
        }

        private static void GenerateReportFooter(StringBuilder sb, int amountOfShapes, decimal perimeters, decimal areas)
        {
            if (amountOfShapes > 0)
            {
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

        private void GenerateReportBody(StringBuilder sb, int amountOfSquares, decimal squareAreas, decimal squarePerimeters,
            int amountOfCircles, decimal circleAreas, decimal circlePerimeters, int amountOfTriangles, decimal triangleAreas,
            decimal trianglePerimeters)
        {
            //no me gusta repetir lineas

            sb.Append(WriteLine(amountOfSquares, squareAreas, squarePerimeters,
                GetPluralOrSingular(amountOfSquares, ResX.Squares, ResX.Square)));

            sb.Append(WriteLine(amountOfCircles, circleAreas, circlePerimeters,
                GetPluralOrSingular(amountOfCircles, ResX.Circles, ResX.Circle)));

            sb.Append(WriteLine(amountOfTriangles, triangleAreas, trianglePerimeters,
                GetPluralOrSingular(amountOfTriangles, ResX.Triangles, ResX.Triangle)));
        }

        private void IncreaseValues(ref int amountOfSquares, GeometricShape shape, ref decimal squareAreas,
            ref decimal squarePerimeters)
        {
            amountOfSquares++;
            squareAreas += shape.CalculateArea();
            squarePerimeters += shape.CalculatePerimeter();
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