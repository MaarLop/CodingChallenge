using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Factories;
using CodingChallenge.Data.Helpers;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private readonly Report _report = new Report();

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

        [TestCase]
        public void TestReportWithASingleTrapeze()
        {
            var trapezes = new List<GeometricShape> { ShapeFactory.CreateShape(Shape.Trapeze, 5, 1, 2) };

            LanguageHelper.SetSpanish();

            var report = _report.GenerateReport(trapezes);

            var expected = "<h1>Reporte de Formas</h1>1 Trapecio | Área 7,5 | Perímetro 103,5 <br/>TOTAL:<br/>1 forma Perímetro 103,5 Área 7,5";
            Assert.AreEqual(expected, report);
        }

        [TestCase]
        public void TestReportWithTwoTrapezes()
        {
            var trapezes = new List<GeometricShape>
            {
                ShapeFactory.CreateShape(Shape.Trapeze, 5, 1, 2),
                ShapeFactory.CreateShape(Shape.Trapeze, 5, 1, 2)
            };

            LanguageHelper.SetSpanish();

            var report = _report.GenerateReport(trapezes);

            var expected = "<h1>Reporte de Formas</h1>2 Trapecios | Área 15 | Perímetro 207 <br/>TOTAL:<br/>2 formas Perímetro 207 Área 15";
            Assert.AreEqual(expected, report);
        }

        [TestCase]
        public void TestReportWithASingleRectangle()
        {
            var rectangles = new List<GeometricShape> { ShapeFactory.CreateShape(Shape.Rectangle, 5, 1) };

            LanguageHelper.SetSpanish();

            var report = _report.GenerateReport(rectangles);

            var expected = "<h1>Reporte de Formas</h1>1 Rectángulo | Área 5 | Perímetro 12 <br/>TOTAL:<br/>1 forma Perímetro 12 Área 5";
            Assert.AreEqual(expected, report);
        }

        [TestCase]
        public void TestReportWithTwoRectangle()
        {
            var rectangles = new List<GeometricShape>
            {
                ShapeFactory.CreateShape(Shape.Rectangle, 5, 1),
                ShapeFactory.CreateShape(Shape.Rectangle, 5, 1)
            };

            LanguageHelper.SetSpanish();

            var report = _report.GenerateReport(rectangles);

            var expected = "<h1>Reporte de Formas</h1>2 Rectángulos | Área 10 | Perímetro 24 <br/>TOTAL:<br/>2 formas Perímetro 24 Área 10";
            Assert.AreEqual(expected, report);
        }

        [Test]
        [TestCase(-1, Shape.Square)]
        [TestCase(0, Shape.EquilateralTriangle)]
        [TestCase(3, Shape.Rectangle)]
        public void TestInvalidInputs(int size, Shape shape)
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(shape, size));
        }
    }
}