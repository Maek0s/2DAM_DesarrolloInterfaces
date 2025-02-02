using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ud07xUnit.Models;

namespace UnitTestProject
{
    public class OperacionsTests
    {
        // Test para la suma
        [Theory]
        [InlineData(3, 4, 7)]  // 3 + 4 = 7
        [InlineData(-1, 5, 4)]  // -1 + 5 = 4
        public void Sumar_ShouldReturnCorrectResult(int num1, int num2, int expected)
        {
            var result = Operacions.Sumar(num1, num2);
            Assert.Equal(expected, result);
        }

        // Test para la resta
        [Theory]
        [InlineData(5, 3, 2)]   // 5 - 3 = 2
        [InlineData(0, 2, -2)]  // 0 - 2 = -2
        public void Restar_ShouldReturnCorrectResult(int num1, int num2, int expected)
        {
            var result = Operacions.Restar(num1, num2);
            Assert.Equal(expected, result);
        }

        // Test para la multiplicación
        [Theory]
        [InlineData(2, 3, 6)]   // 2 * 3 = 6
        [InlineData(-2, 4, -8)] // -2 * 4 = -8
        public void Multiplicar_ShouldReturnCorrectResult(int num1, int num2, int expected)
        {
            var result = Operacions.Multiplicar(num1, num2);
            Assert.Equal(expected, result);
        }

        // Test para la división
        [Theory]
        [InlineData(6, 2, "3")]  // 6 / 2 = 3
        [InlineData(5, 2, "2")]  // 5 / 2 = 2 (división entera)
        public void Dividir_ShouldReturnCorrectResult(int num1, int num2, string expected)
        {
            var result = Operacions.Dividir(num1, num2);
            Assert.Equal(expected, result);
        }

        // Test para la división por cero
        [Theory]
        [InlineData(5, 0, "Error: División por cero")]  // División por cero
        public void Dividir_ByZero_ShouldReturnError(int num1, int num2, string expected)
        {
            var result = Operacions.Dividir(num1, num2);
            Assert.Equal(expected, result);
        }
    }
}
