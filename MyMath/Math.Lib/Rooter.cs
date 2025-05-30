using System;

namespace Math.Lib
{
    /// <summary>
    /// Clase para calcular raíces cuadradas con un método iterativo.
    /// </summary>
    public class Rooter
    {
        /// <summary>
        /// Calcula la raíz cuadrada de un número positivo utilizando el método de Newton-Raphson.
        /// </summary>
        /// <param name="input">Número positivo del cual se desea la raíz cuadrada.</param>
        /// <returns>Raíz cuadrada aproximada del número de entrada.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el valor ingresado es menor o igual a cero.
        /// </exception>
        public double SquareRoot(double input)
        {
            if (input <= 0.0)
                throw new ArgumentOutOfRangeException(nameof(input), "El valor ingresado es invalido, solo se puede ingresar números positivos");

            // Método de Newton-Raphson
            double result = input;
            double previousResult = -input;
            while (System.Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = result - (result * result - input) / (2 * result);
            }
            return result;
        }
    }
}