using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Factories;
using CodingChallenge.Data.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private readonly Report _report = new Report();

        [TestInitialize]
        public void Before()
        {
        }

        [TestCase]
        public void TestEmptyListInSpanish()
        {
            LanguageHelper.SetSpanish();
            var expected = "<h1>Lista vacía de formas!</h1>";
            Assert.AreEqual(expected,
                _report.GenerateReport(new List<GeometricShape>()));
        }

        [TestCase]
        public void TestEmptyListInEnglish()
        {
            LanguageHelper.SetEnglish();

            var expected = "<h1>Empty list of shapes!</h1>";
            Assert.AreEqual(expected,
                _report.GenerateReport(new List<GeometricShape>()));
        }

        [TestCase]
        public void TestReportWithASingleSquare()
        {
            var squares = new List<GeometricShape> { ShapeFactory.CreateShape(Shape.Square, 5) };

            LanguageHelper.SetSpanish();

            var report = _report.GenerateReport(squares);

            var expected = "<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 forma Perímetro 20 Área 25";
            Assert.AreEqual(expected, report);
        }

        [TestCase]
        public void TestReportWithASeveralSquares()
        {
            LanguageHelper.SetEnglish();

            var squares = new List<GeometricShape>
            {
                ShapeFactory.CreateShape(Shape.Square, 5),
                ShapeFactory.CreateShape(Shape.Square, 1),
                ShapeFactory.CreateShape(Shape.Square, 3)
            };

            var report = _report.GenerateReport(squares);

            var expected = "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35";
            Assert.AreEqual(expected, report);
        }

        [TestCase]
        public void TestReportWithSeveralShapesInEnglish()
        {
            LanguageHelper.SetEnglish();
            var shapes = new List<GeometricShape>
            {
                ShapeFactory.CreateShape(Shape.Square, 5),
                ShapeFactory.CreateShape(Shape.Circle, 3),
                ShapeFactory.CreateShape(Shape.EquilateralTriangle, 4),
                ShapeFactory.CreateShape(Shape.Square, 2),
                ShapeFactory.CreateShape(Shape.EquilateralTriangle, 9),
                ShapeFactory.CreateShape(Shape.Circle, 2.75m),
                ShapeFactory.CreateShape(Shape.EquilateralTriangle, 4.2m)
            };

            var report = _report.GenerateReport(shapes);

            var expected =
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65";
            Assert.AreEqual(expected, report);
        }

        [TestCase]
        public void TestReportWithSeveralShapesInSpanish()
        {
            LanguageHelper.SetSpanish();

            var shapes = new List<GeometricShape>
            {
                ShapeFactory.CreateShape(Shape.Square, 5),
                ShapeFactory.CreateShape(Shape.Circle, 3),
                ShapeFactory.CreateShape(Shape.EquilateralTriangle, 4),
                ShapeFactory.CreateShape(Shape.Square, 2),
                ShapeFactory.CreateShape(Shape.EquilateralTriangle, 9),
                ShapeFactory.CreateShape(Shape.Circle, 2.75m),
                ShapeFactory.CreateShape(Shape.EquilateralTriangle, 4.2m)
            };

            var report = _report.GenerateReport(shapes);

            var expected =
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13,01 | Perímetro 18,06 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65";
            Assert.AreEqual(expected, report);
        }
    }

    //TODO:
    //Ver que pasan con el trapecio y el rectangulo
    //Refactorizar la clase de report (quizas un poco mas)
    //Volver a dejar los csporj como estaban
    //Probar los validadores
    //cambiar nombre a las carpetas
}