﻿// <copyright file="ManagedLinearAlgebraProvider.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://mathnet.opensourcedotnet.info
// Copyright (c) 2009 Math.NET
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
namespace MathNet.Numerics.Algorithms.LinearAlgebra
{
    using System;
    using Properties;
    using Threading;

    /// <summary>
    /// The managed linear algebra provider.
    /// </summary>
    public class ManagedLinearAlgebraProvider : ILinearAlgebraProvider
    {
        #region ILinearAlgebraProvider<double> Members

        /// <summary>
        /// Adds a scaled vector to another: <c>y += alpha*x</c>.
        /// </summary>
        /// <param name="y">The vector to update.</param>
        /// <param name="alpha">The value to scale <paramref name="x"/> by.</param>
        /// <param name="x">The vector to add to <paramref name="y"/>.</param>
        /// <remarks>This equivalent to the AXPY BLAS routine.</remarks>
        public void AddVectorToScaledVector(double[] y, double alpha, double[] x)
        {
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }

            if (x == null)
            {
                throw new ArgumentNullException("x");
            }

            if (y.Length != x.Length)
            {
                throw new ArgumentException(Resources.ArgumentVectorsSameLength);
            }

            if (alpha == 0.0)
            {
                return;
            }

            if (alpha == 1.0)
            {
                Parallel.For(0, y.Length, i => y[i] += x[i]);
            }
            else
            {
                Parallel.For(0, y.Length, i => y[i] += alpha * x[i]);
            }
        }

        /// <summary>
        /// Scales an array. Can be used to scale a vector and a matrix.
        /// </summary>
        /// <param name="alpha">The scalar.</param>
        /// <param name="x">The values to scale.</param>
        /// <remarks>This is equivalent to the SCAL BLAS routine.</remarks>
        public void ScaleArray(double alpha, double[] x)
        {
            if (alpha == 1.0)
            {
                return;
            }

            Parallel.For(0, x.Length, i => x[i] = alpha * x[i]);
        }

        public int QueryWorkspaceBlockSize(string methodName)
        {
            throw new NotImplementedException();
        }

        public double DotProduct(double[] x, double[] y)
        {
            throw new NotImplementedException();
        }

        public void AddArrays(double[] x, double[] y, double[] result)
        {
            throw new NotImplementedException();
        }

        public void SubtractArrays(double[] x, double[] y, double[] result)
        {
            throw new NotImplementedException();
        }

        public void PointWiseMultiplyArrays(double[] x, double[] y, double[] result)
        {
            throw new NotImplementedException();
        }

        public double MatrixNorm(Norm norm, double[] matrix)
        {
            throw new NotImplementedException();
        }

        public double MatrixNorm(Norm norm, double[] matrix, double[] work)
        {
            throw new NotImplementedException();
        }

        public void MatrixMultiply(double[] x, double[] y, double[] result)
        {
            throw new NotImplementedException();
        }

        public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, double alpha, double[] a, double[] b, double beta, double[] c)
        {
            throw new NotImplementedException();
        }

        public void LUFactor(double[] a, int[] ipiv)
        {
            throw new NotImplementedException();
        }

        public void LUInverse(double[] a)
        {
            throw new NotImplementedException();
        }

        public void LUInverseFactored(double[] a, int[] ipiv)
        {
            throw new NotImplementedException();
        }

        public void LUInverse(double[] a, double[] work)
        {
            throw new NotImplementedException();
        }

        public void LUInverseFactored(double[] a, int[] ipiv, double[] work)
        {
            throw new NotImplementedException();
        }

        public void LUSolve(int columnsOfB, double[] a, double[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolveFactored(int columnsOfB, double[] a, int ipiv, double[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolve(Transpose transposeA, int columnsOfB, double[] a, double[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolveFactored(Transpose transposeA, int columnsOfB, double[] a, int ipiv, double[] b)
        {
            throw new NotImplementedException();
        }

        public void CholeskyFactor(double[] a)
        {
            throw new NotImplementedException();
        }

        public void CholeskySolve(int columnsOfB, double[] a, double[] b)
        {
            throw new NotImplementedException();
        }

        public void CholeskySolveFactored(int columnsOfB, double[] a, double[] b)
        {
            throw new NotImplementedException();
        }

        public void QRFactor(double[] r, double[] q)
        {
            throw new NotImplementedException();
        }

        public void QRFactor(double[] r, double[] q, double[] work)
        {
            throw new NotImplementedException();
        }

        public void QRSolve(int columnsOfB, double[] r, double[] q, double[] b, double[] x)
        {
            throw new NotImplementedException();
        }

        public void QRSolve(int columnsOfB, double[] r, double[] q, double[] b, double[] x, double[] work)
        {
            throw new NotImplementedException();
        }

        public void QRSolveFactored(int columnsOfB, double[] q, double[] r, double[] b, double[] x)
        {
            throw new NotImplementedException();
        }

        public void SinguarValueDecomposition(bool computeVectors, double[] a, double[] s, double[] u, double[] vt)
        {
            throw new NotImplementedException();
        }

        public void SingularValueDecomposition(bool computeVectors, double[] a, double[] s, double[] u, double[] vt, double[] work)
        {
            throw new NotImplementedException();
        }

        public void SvdSolve(double[] a, double[] s, double[] u, double[] vt, double[] b, double[] x)
        {
            throw new NotImplementedException();
        }

        public void SvdSolve(double[] a, double[] s, double[] u, double[] vt, double[] b, double[] x, double[] work)
        {
            throw new NotImplementedException();
        }

        public void SvdSolveFactored(int columnsOfB, double[] s, double[] u, double[] vt, double[] b, double[] x)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILinearAlgebraProvider<float> Members


        public void AddVectorToScaledVector(float[] y, float alpha, float[] x)
        {
            throw new NotImplementedException();
        }

        public void ScaleArray(float alpha, float[] x)
        {
            throw new NotImplementedException();
        }

        public float DotProduct(float[] x, float[] y)
        {
            throw new NotImplementedException();
        }

        public void AddArrays(float[] x, float[] y, float[] result)
        {
            throw new NotImplementedException();
        }

        public void SubtractArrays(float[] x, float[] y, float[] result)
        {
            throw new NotImplementedException();
        }

        public void PointWiseMultiplyArrays(float[] x, float[] y, float[] result)
        {
            throw new NotImplementedException();
        }

        public float MatrixNorm(Norm norm, float[] matrix)
        {
            throw new NotImplementedException();
        }

        public float MatrixNorm(Norm norm, float[] matrix, float[] work)
        {
            throw new NotImplementedException();
        }

        public void MatrixMultiply(float[] x, float[] y, float[] result)
        {
            throw new NotImplementedException();
        }

        public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, float alpha, float[] a, float[] b, float beta, float[] c)
        {
            throw new NotImplementedException();
        }

        public void LUFactor(float[] a, int[] ipiv)
        {
            throw new NotImplementedException();
        }

        public void LUInverse(float[] a)
        {
            throw new NotImplementedException();
        }

        public void LUInverseFactored(float[] a, int[] ipiv)
        {
            throw new NotImplementedException();
        }

        public void LUInverse(float[] a, float[] work)
        {
            throw new NotImplementedException();
        }

        public void LUInverseFactored(float[] a, int[] ipiv, float[] work)
        {
            throw new NotImplementedException();
        }

        public void LUSolve(int columnsOfB, float[] a, float[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolveFactored(int columnsOfB, float[] a, int ipiv, float[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolve(Transpose transposeA, int columnsOfB, float[] a, float[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolveFactored(Transpose transposeA, int columnsOfB, float[] a, int ipiv, float[] b)
        {
            throw new NotImplementedException();
        }

        public void CholeskyFactor(float[] a)
        {
            throw new NotImplementedException();
        }

        public void CholeskySolve(int columnsOfB, float[] a, float[] b)
        {
            throw new NotImplementedException();
        }

        public void CholeskySolveFactored(int columnsOfB, float[] a, float[] b)
        {
            throw new NotImplementedException();
        }

        public void QRFactor(float[] r, float[] q)
        {
            throw new NotImplementedException();
        }

        public void QRFactor(float[] r, float[] q, float[] work)
        {
            throw new NotImplementedException();
        }

        public void QRSolve(int columnsOfB, float[] r, float[] q, float[] b, float[] x)
        {
            throw new NotImplementedException();
        }

        public void QRSolve(int columnsOfB, float[] r, float[] q, float[] b, float[] x, float[] work)
        {
            throw new NotImplementedException();
        }

        public void QRSolveFactored(int columnsOfB, float[] q, float[] r, float[] b, float[] x)
        {
            throw new NotImplementedException();
        }

        public void SinguarValueDecomposition(bool computeVectors, float[] a, float[] s, float[] u, float[] vt)
        {
            throw new NotImplementedException();
        }

        public void SingularValueDecomposition(bool computeVectors, float[] a, float[] s, float[] u, float[] vt, float[] work)
        {
            throw new NotImplementedException();
        }

        public void SvdSolve(float[] a, float[] s, float[] u, float[] vt, float[] b, float[] x)
        {
            throw new NotImplementedException();
        }

        public void SvdSolve(float[] a, float[] s, float[] u, float[] vt, float[] b, float[] x, float[] work)
        {
            throw new NotImplementedException();
        }

        public void SvdSolveFactored(int columnsOfB, float[] s, float[] u, float[] vt, float[] b, float[] x)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILinearAlgebraProvider<Complex> Members


        public void AddVectorToScaledVector(Complex[] y, Complex alpha, Complex[] x)
        {
            throw new NotImplementedException();
        }

        public void ScaleArray(Complex alpha, Complex[] x)
        {
            throw new NotImplementedException();
        }

        public Complex DotProduct(Complex[] x, Complex[] y)
        {
            throw new NotImplementedException();
        }

        public void AddArrays(Complex[] x, Complex[] y, Complex[] result)
        {
            throw new NotImplementedException();
        }

        public void SubtractArrays(Complex[] x, Complex[] y, Complex[] result)
        {
            throw new NotImplementedException();
        }

        public void PointWiseMultiplyArrays(Complex[] x, Complex[] y, Complex[] result)
        {
            throw new NotImplementedException();
        }

        public Complex MatrixNorm(Norm norm, Complex[] matrix)
        {
            throw new NotImplementedException();
        }

        public Complex MatrixNorm(Norm norm, Complex[] matrix, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void MatrixMultiply(Complex[] x, Complex[] y, Complex[] result)
        {
            throw new NotImplementedException();
        }

        public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, Complex alpha, Complex[] a, Complex[] b, Complex beta, Complex[] c)
        {
            throw new NotImplementedException();
        }

        public void LUFactor(Complex[] a, int[] ipiv)
        {
            throw new NotImplementedException();
        }

        public void LUInverse(Complex[] a)
        {
            throw new NotImplementedException();
        }

        public void LUInverseFactored(Complex[] a, int[] ipiv)
        {
            throw new NotImplementedException();
        }

        public void LUInverse(Complex[] a, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void LUInverseFactored(Complex[] a, int[] ipiv, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void LUSolve(int columnsOfB, Complex[] a, Complex[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolveFactored(int columnsOfB, Complex[] a, int ipiv, Complex[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolve(Transpose transposeA, int columnsOfB, Complex[] a, Complex[] b)
        {
            throw new NotImplementedException();
        }

        public void LUSolveFactored(Transpose transposeA, int columnsOfB, Complex[] a, int ipiv, Complex[] b)
        {
            throw new NotImplementedException();
        }

        public void CholeskyFactor(Complex[] a)
        {
            throw new NotImplementedException();
        }

        public void CholeskySolve(int columnsOfB, Complex[] a, Complex[] b)
        {
            throw new NotImplementedException();
        }

        public void CholeskySolveFactored(int columnsOfB, Complex[] a, Complex[] b)
        {
            throw new NotImplementedException();
        }

        public void QRFactor(Complex[] r, Complex[] q)
        {
            throw new NotImplementedException();
        }

        public void QRFactor(Complex[] r, Complex[] q, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void QRSolve(int columnsOfB, Complex[] r, Complex[] q, Complex[] b, Complex[] x)
        {
            throw new NotImplementedException();
        }

        public void QRSolve(int columnsOfB, Complex[] r, Complex[] q, Complex[] b, Complex[] x, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void QRSolveFactored(int columnsOfB, Complex[] q, Complex[] r, Complex[] b, Complex[] x)
        {
            throw new NotImplementedException();
        }

        public void SinguarValueDecomposition(bool computeVectors, Complex[] a, Complex[] s, Complex[] u, Complex[] vt)
        {
            throw new NotImplementedException();
        }

        public void SingularValueDecomposition(bool computeVectors, Complex[] a, Complex[] s, Complex[] u, Complex[] vt, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void SvdSolve(Complex[] a, Complex[] s, Complex[] u, Complex[] vt, Complex[] b, Complex[] x)
        {
            throw new NotImplementedException();
        }

        public void SvdSolve(Complex[] a, Complex[] s, Complex[] u, Complex[] vt, Complex[] b, Complex[] x, Complex[] work)
        {
            throw new NotImplementedException();
        }

        public void SvdSolveFactored(int columnsOfB, Complex[] s, Complex[] u, Complex[] vt, Complex[] b, Complex[] x)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}