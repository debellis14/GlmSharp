using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GlmSharp
{
    [Serializable]
    public struct imat2x3 : IReadOnlyList<int>, IEquatable<imat2x3>
    {
        // Matrix fields mXY
        public int m00, m01, m02; // Column 0
        public int m10, m11, m12; // Column 1
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public int[,] Values => new[,] { { m00, m01, m02 }, { m10, m11, m12 } };
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public int[] Values1D => new[] { m00, m01, m02, m10, m11, m12 };
        
        /// <summary>
        /// Returns the column nr 0
        /// </summary>
        public ivec3 Column0 => new ivec3(m00, m01, m02);
        
        /// <summary>
        /// Returns the column nr 1
        /// </summary>
        public ivec3 Column1 => new ivec3(m10, m11, m12);
        
        /// <summary>
        /// Returns the row nr 0
        /// </summary>
        public ivec2 Row0 => new ivec2(m00, m10);
        
        /// <summary>
        /// Returns the row nr 1
        /// </summary>
        public ivec2 Row1 => new ivec2(m01, m11);
        
        /// <summary>
        /// Returns the row nr 2
        /// </summary>
        public ivec2 Row2 => new ivec2(m02, m12);
        
        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        public static imat2x3 Zero { get; } = new imat2x3(default(int), default(int), default(int), default(int), default(int), default(int));
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        public static imat2x3 Ones { get; } = new imat2x3(1, 1, 1, 1, 1, 1);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        public static imat2x3 Identity { get; } = new imat2x3(1, default(int), default(int), default(int), 1, default(int));
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public imat2x3(int m00, int m01, int m02, int m10, int m11, int m12)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
        }
        
        /// <summary>
        /// Copy constructor
        /// </summary>
        public imat2x3(imat2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }
        
        /// <summary>
        /// Column constructor
        /// </summary>
        public imat2x3(ivec3 c0, ivec3 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all FieldCount.
        /// </summary>
        public IEnumerator<int> GetEnumerator()
        {
            yield return m00;
            yield return m01;
            yield return m02;
            yield return m10;
            yield return m11;
            yield return m12;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all FieldCount.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Returns the number of FieldCount (6).
        /// </summary>
        public int Count => 6;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int fieldIndex]
        {
            get
            {
                switch (fieldIndex)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m02;
                    case 3: return m10;
                    case 4: return m11;
                    case 5: return m12;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
            set
            {
                switch (fieldIndex)
                {
                    case 0: this.m00 = value; break;
                    case 1: this.m01 = value; break;
                    case 2: this.m02 = value; break;
                    case 3: this.m10 = value; break;
                    case 4: this.m11 = value; break;
                    case 5: this.m12 = value; break;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int col, int row]
        {
            get
            {
                return this[col * 3 + row];
            }
            set
            {
                this[col * 3 + row] = value;
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(imat2x3 rhs) => m00.Equals(rhs.m00) && m01.Equals(rhs.m01) && m02.Equals(rhs.m02) && m10.Equals(rhs.m10) && m11.Equals(rhs.m11) && m12.Equals(rhs.m12);
        
        /// <summary>
        /// Returns true iff this equals rhs type- and component-wise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is imat2x3 && Equals((imat2x3) obj);
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(imat2x3 lhs, imat2x3 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(imat2x3 lhs, imat2x3 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public imat3x2 Transposed => new imat3x2(m00, m10, m01, m11, m02, m12);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public int MinElement => Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(m00, m01), m02), m10), m11), m12);
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public int MaxElement => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(m00, m01), m02), m10), m11), m12);
        
        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public float Length => (float)Math.Sqrt(m00*m00 + m01*m01 + m02*m02 + m10*m10 + m11*m11 + m12*m12);
        
        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public float LengthSqr => m00*m00 + m01*m01 + m02*m02 + m10*m10 + m11*m11 + m12*m12;
        
        /// <summary>
        /// Returns the sum of all FieldCount.
        /// </summary>
        public int Sum => m00 + m01 + m02 + m10 + m11 + m12;
        
        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public float Norm => (float)Math.Sqrt(m00*m00 + m01*m01 + m02*m02 + m10*m10 + m11*m11 + m12*m12);
        
        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public float Norm1 => Math.Abs(m00) + Math.Abs(m01) + Math.Abs(m02) + Math.Abs(m10) + Math.Abs(m11) + Math.Abs(m12);
        
        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt(m00*m00 + m01*m01 + m02*m02 + m10*m10 + m11*m11 + m12*m12);
        
        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public int NormMax => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Abs(m00), Math.Abs(m01)), Math.Abs(m02)), Math.Abs(m10)), Math.Abs(m11)), Math.Abs(m12));
        
        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => Math.Pow(Math.Pow((double)Math.Abs(m00), p) + Math.Pow((double)Math.Abs(m01), p) + Math.Pow((double)Math.Abs(m02), p) + Math.Pow((double)Math.Abs(m10), p) + Math.Pow((double)Math.Abs(m11), p) + Math.Pow((double)Math.Abs(m12), p), 1 / p);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication imat2x3 * imat2 -> imat2x3.
        /// </summary>
        public static imat2x3 operator*(imat2x3 lhs, imat2 rhs) => new imat2x3(lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01, lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11, lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01, lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11, lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01, lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication imat2x3 * imat3x2 -> imat3.
        /// </summary>
        public static imat3 operator*(imat2x3 lhs, imat3x2 rhs) => new imat3(lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01, lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11, lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21, lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01, lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11, lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21, lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01, lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11, lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication imat2x3 * imat4x2 -> imat4x3.
        /// </summary>
        public static imat4x3 operator*(imat2x3 lhs, imat4x2 rhs) => new imat4x3(lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01, lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11, lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21, lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31, lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01, lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11, lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21, lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31, lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01, lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11, lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21, lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31);
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static ivec3 operator*(imat2x3 m, ivec2 v) => new ivec3(m.m00 * v.x + m.m10 * v.y, m.m01 * v.x + m.m11 * v.y, m.m02 * v.x + m.m12 * v.y);
        
        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static imat2x3 CompMul(imat2x3 A, imat2x3 B) => new imat2x3(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12);
        
        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static imat2x3 CompDiv(imat2x3 A, imat2x3 B) => new imat2x3(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static imat2x3 CompAdd(imat2x3 A, imat2x3 B) => new imat2x3(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static imat2x3 CompSub(imat2x3 A, imat2x3 B) => new imat2x3(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static imat2x3 operator+(imat2x3 lhs, imat2x3 rhs) => new imat2x3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static imat2x3 operator+(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static imat2x3 operator+(int lhs, imat2x3 rhs) => new imat2x3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static imat2x3 operator-(imat2x3 lhs, imat2x3 rhs) => new imat2x3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static imat2x3 operator-(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static imat2x3 operator-(int lhs, imat2x3 rhs) => new imat2x3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static imat2x3 operator/(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static imat2x3 operator/(int lhs, imat2x3 rhs) => new imat2x3(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static imat2x3 operator*(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static imat2x3 operator*(int lhs, imat2x3 rhs) => new imat2x3(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12);
        
        /// <summary>
        /// Executes a component-wise % (modulo).
        /// </summary>
        public static imat2x3 operator%(imat2x3 lhs, imat2x3 rhs) => new imat2x3(lhs.m00 % rhs.m00, lhs.m01 % rhs.m01, lhs.m02 % rhs.m02, lhs.m10 % rhs.m10, lhs.m11 % rhs.m11, lhs.m12 % rhs.m12);
        
        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static imat2x3 operator%(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 % rhs, lhs.m01 % rhs, lhs.m02 % rhs, lhs.m10 % rhs, lhs.m11 % rhs, lhs.m12 % rhs);
        
        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static imat2x3 operator%(int lhs, imat2x3 rhs) => new imat2x3(lhs % rhs.m00, lhs % rhs.m01, lhs % rhs.m02, lhs % rhs.m10, lhs % rhs.m11, lhs % rhs.m12);
        
        /// <summary>
        /// Executes a component-wise ^ (xor).
        /// </summary>
        public static imat2x3 operator^(imat2x3 lhs, imat2x3 rhs) => new imat2x3(lhs.m00 ^ rhs.m00, lhs.m01 ^ rhs.m01, lhs.m02 ^ rhs.m02, lhs.m10 ^ rhs.m10, lhs.m11 ^ rhs.m11, lhs.m12 ^ rhs.m12);
        
        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static imat2x3 operator^(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 ^ rhs, lhs.m01 ^ rhs, lhs.m02 ^ rhs, lhs.m10 ^ rhs, lhs.m11 ^ rhs, lhs.m12 ^ rhs);
        
        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static imat2x3 operator^(int lhs, imat2x3 rhs) => new imat2x3(lhs ^ rhs.m00, lhs ^ rhs.m01, lhs ^ rhs.m02, lhs ^ rhs.m10, lhs ^ rhs.m11, lhs ^ rhs.m12);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or).
        /// </summary>
        public static imat2x3 operator|(imat2x3 lhs, imat2x3 rhs) => new imat2x3(lhs.m00 | rhs.m00, lhs.m01 | rhs.m01, lhs.m02 | rhs.m02, lhs.m10 | rhs.m10, lhs.m11 | rhs.m11, lhs.m12 | rhs.m12);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static imat2x3 operator|(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 | rhs, lhs.m01 | rhs, lhs.m02 | rhs, lhs.m10 | rhs, lhs.m11 | rhs, lhs.m12 | rhs);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static imat2x3 operator|(int lhs, imat2x3 rhs) => new imat2x3(lhs | rhs.m00, lhs | rhs.m01, lhs | rhs.m02, lhs | rhs.m10, lhs | rhs.m11, lhs | rhs.m12);
        
        /// <summary>
        /// Executes a component-wise & (bitwise-and).
        /// </summary>
        public static imat2x3 operator&(imat2x3 lhs, imat2x3 rhs) => new imat2x3(lhs.m00 & rhs.m00, lhs.m01 & rhs.m01, lhs.m02 & rhs.m02, lhs.m10 & rhs.m10, lhs.m11 & rhs.m11, lhs.m12 & rhs.m12);
        
        /// <summary>
        /// Executes a component-wise & (bitwise-and) with a scalar.
        /// </summary>
        public static imat2x3 operator&(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 & rhs, lhs.m01 & rhs, lhs.m02 & rhs, lhs.m10 & rhs, lhs.m11 & rhs, lhs.m12 & rhs);
        
        /// <summary>
        /// Executes a component-wise & (bitwise-and) with a scalar.
        /// </summary>
        public static imat2x3 operator&(int lhs, imat2x3 rhs) => new imat2x3(lhs & rhs.m00, lhs & rhs.m01, lhs & rhs.m02, lhs & rhs.m10, lhs & rhs.m11, lhs & rhs.m12);
        
        /// <summary>
        /// Executes a component-wise left-shift with a scalar.
        /// </summary>
        public static imat2x3 operator<<(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 << rhs, lhs.m01 << rhs, lhs.m02 << rhs, lhs.m10 << rhs, lhs.m11 << rhs, lhs.m12 << rhs);
        
        /// <summary>
        /// Executes a component-wise right-shift with a scalar.
        /// </summary>
        public static imat2x3 operator>>(imat2x3 lhs, int rhs) => new imat2x3(lhs.m00 >> rhs, lhs.m01 >> rhs, lhs.m02 >> rhs, lhs.m10 >> rhs, lhs.m11 >> rhs, lhs.m12 >> rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bmat2x3 operator<(imat2x3 lhs, imat2x3 rhs) => new bmat2x3(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator<(imat2x3 lhs, int rhs) => new bmat2x3(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator<(int lhs, imat2x3 rhs) => new bmat2x3(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bmat2x3 operator<=(imat2x3 lhs, imat2x3 rhs) => new bmat2x3(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator<=(imat2x3 lhs, int rhs) => new bmat2x3(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator<=(int lhs, imat2x3 rhs) => new bmat2x3(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bmat2x3 operator>(imat2x3 lhs, imat2x3 rhs) => new bmat2x3(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator>(imat2x3 lhs, int rhs) => new bmat2x3(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator>(int lhs, imat2x3 rhs) => new bmat2x3(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bmat2x3 operator>=(imat2x3 lhs, imat2x3 rhs) => new bmat2x3(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator>=(imat2x3 lhs, int rhs) => new bmat2x3(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bmat2x3 operator>=(int lhs, imat2x3 rhs) => new bmat2x3(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12);
    }
}
