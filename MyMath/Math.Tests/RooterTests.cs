using System;
using Math.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.Tests
{
    [TestClass]
    public class RooterTests
    {
        [TestMethod]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
                RooterOneValue(rooter, expected);
        }
        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }
        
        [TestMethod]
        public void RooterTestNegativeInputx()
        {
            Rooter rooter = new Rooter();
            try
            {
                rooter.SquareRoot(-10);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [TestMethod]
        public void RooterThrowsExceptionWithCorrectMessage()
        {
            var rooter = new Rooter();

            try
            {
                rooter.SquareRoot(-10);
                Assert.Fail("No se lanzó la excepción esperada.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Verifico que el mensaje comience con la cadena deseada:
                string mensajeEsperado = "El valor ingresado es invalido, solo se puede ingresar números positivos";
                Assert.IsTrue(
                    ex.Message.StartsWith(mensajeEsperado, StringComparison.Ordinal),
                    $"Se esperaba que Message empezara con:\n  {mensajeEsperado}\npero fue:\n  {ex.Message}"
                );
                
                // Opcionalmente, también podrías verificar ex.ParamName:
                Assert.AreEqual("input", ex.ParamName);
            }
        }
        [TestMethod]
        public void SqrtOfNineIsThree()
        {
            Rooter rooter = new Rooter();
            double result = rooter.SquareRoot(9.0);
            Assert.AreEqual(3.0, result, 0.001);
        }

        [TestMethod]
        public void SqrtOfZeroIsZero()
        {
            Rooter rooter = new Rooter();
            double result = rooter.SquareRoot(0.0);
            Assert.AreEqual(0.0, result, 0.001);
        }



    }
}