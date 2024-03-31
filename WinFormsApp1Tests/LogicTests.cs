using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void FirstDigitIsNotValid() //Первое число неположительное
        {
            double a = -2.12;
            double b = 8.2;
            double c = 4.345;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Первое значение не подходит", outMessage);
        }
        [TestMethod()]
        public void SecondDigitIsNotValid() //Второе число неположительное
        {
            double a = 5.54;
            double b = 0;
            double c = 4.55;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Второе значение не подходит", outMessage);
        }
        [TestMethod()]
        public void ThirdDigitIsNotValid() //Третье число неположительное
        {
            double a = 2.5;
            double b = 7.67;
            double c = -7.777;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Третье значение не подходит", outMessage);
        }
        [TestMethod()]
        public void AllDigitsAreNotValid() //Все числа неположительные
        {
            double a = -2.76;
            double b = 0;
            double c = -8.789;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Все значения не подходят", outMessage);
        }
        [TestMethod()]
        public void FirstAndSecondDigitsAreNotValid() //Первое и второе числа неположительные
        {
            double a = -21.1;
            double b = -9.2;
            double c = 12.3;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Первое и второе значения не подходят", outMessage);
        }
        [TestMethod()]
        public void FirstAndThierdDigitsAreNotValid() //Первое и третье числа неположительные
        {
            double a = -11.3;
            double b = 19.4;
            double c = -2.2;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Первое и третье значения не подходят", outMessage);
        }
        [TestMethod()]
        public void SecondAndThirdDigitsAreNotValid() //Второе и третье числа неположительные
        {
            double a = 16.56;
            double b = -9.65;
            double c = 0;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Второе и третье значения не подходят", outMessage);
        }


        [TestMethod()]
        public void TriangleIsNotExist() //Треугольник не существует
        {
            double a = 25.55;
            double b = 78.66;
            double c = 47.77;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Не существует треугольника с такими параметрами", outMessage);
        }
        [TestMethod()]
        public void TriangleIsRectangular() //Треугольник прямоугольный
        {
            double a = 30;
            double b = 40;
            double c = 50;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Треугольник является прямоугольным", outMessage);
        }
        [TestMethod()]
        public void TriangleIsNotRectangular() //Треугольник не является прямоугольным
        {
            double a = 33;
            double b = 17;
            double c = 41;

            var outMessage = Logic.ExistTriangle(a, b, c);

            Assert.AreEqual("Треугольник не является прямоугольным", outMessage);
        }
    }
}