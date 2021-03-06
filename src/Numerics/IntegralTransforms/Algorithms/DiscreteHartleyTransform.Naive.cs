﻿// <copyright file="DiscreteHartleyTransform.Naive.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://mathnet.opensourcedotnet.info
//
// Copyright (c) 2009 Math.NET
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

namespace MathNet.Numerics.IntegralTransforms.Algorithms
{
    using System;
    using Threading;

    /// <summary>
    /// Fast (FHT) Implementation of the Discrete Hartley Transform (DHT).
    /// </summary>
    public partial class DiscreteHartleyTransform
    {
        /// <summary>
        /// Naive generic DHT, useful e.g. to verify faster algorithms.
        /// </summary>
        /// <param name="samples">Time-space sample vector.</param>
        /// <returns>Corresponding frequency-space vector.</returns>
        internal static double[] Naive(double[] samples)
        {
            double w0 = Constants.Pi2 / samples.Length;
            var spectrum = new double[samples.Length];

            Parallel.For(
                0,
                samples.Length,
                k =>
                {
                    double wk = w0 * k;
                    double sum = 0.0;
                    for (int n = 0; n < samples.Length; n++)
                    {
                        double w = n * wk;
                        sum += samples[n] * Constants.Sqrt2 * Math.Cos(w - Constants.PiOver4);
                    }

                    spectrum[k] = sum;
                });

            return spectrum;
        }

        /// <summary>
        /// Naive forward DHT, useful e.g. to verify faster algorithms.
        /// </summary>
        /// <param name="timeSpace">Time-space sample vector.</param>
        /// <param name="options">Hartley Transform Convention Options.</param>
        /// <returns>Corresponding frequency-space vector.</returns>
        public double[] NaiveForward(double[] timeSpace, HartleyOptions options)
        {
            var frequencySpace = Naive(timeSpace);
            ForwardScaleByOptions(options, frequencySpace);
            return frequencySpace;
        }

        /// <summary>
        /// Naive inverse DHT, useful e.g. to verify faster algorithms.
        /// </summary>
        /// <param name="frequencySpace">Frequency-space sample vector.</param>
        /// <param name="options">Hartley Transform Convention Options.</param>
        /// <returns>Corresponding time-space vector.</returns>
        public double[] NaiveInverse(double[] frequencySpace, HartleyOptions options)
        {
            var timeSpace = Naive(frequencySpace);
            InverseScaleByOptions(options, timeSpace);
            return timeSpace;
        }
    }
}
