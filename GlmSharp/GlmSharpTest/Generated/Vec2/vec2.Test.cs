using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;
using NUnit.Framework;
using GlmSharp;

// ReSharper disable InconsistentNaming

namespace GlmSharpTest.Generated.Vec2
{
    [TestFixture]
    public class FloatVec2Test
    {

        [Test]
        public void Constructors()
        {
            {
                var v = new vec2(-5);
                Assert.AreEqual(-5, v.x);
                Assert.AreEqual(-5, v.y);
            }
            {
                var v = new vec2(-0.5f, -2);
                Assert.AreEqual(-0.5f, v.x);
                Assert.AreEqual(-2, v.y);
            }
            {
                var v = new vec2(new vec2(-7, 3));
                Assert.AreEqual(-7, v.x);
                Assert.AreEqual(3, v.y);
            }
            {
                var v = new vec2(new vec3(-4.5f, -5.5f, -0.5f));
                Assert.AreEqual(-4.5f, v.x);
                Assert.AreEqual(-5.5f, v.y);
            }
            {
                var v = new vec2(new vec4(5.5f, -0.5f, 5, 2.5f));
                Assert.AreEqual(5.5f, v.x);
                Assert.AreEqual(-0.5f, v.y);
            }
        }

        [Test]
        public void Indexer()
        {
            var v = new vec2(-5, 6);
            Assert.AreEqual(-5, v[0]);
            Assert.AreEqual(6, v[1]);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[-2147483648]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[-2147483648] = 0f; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[-1]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[-1] = 0f; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[2]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[2] = 0f; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[2147483647]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[2147483647] = 0f; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[5]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[5] = 0f; } );
            
            v[1] = 0f;
            Assert.AreEqual(0f, v[1]);
            v[1] = 1f;
            Assert.AreEqual(1f, v[1]);
            v[0] = 2;
            Assert.AreEqual(2, v[0]);
            v[0] = 3;
            Assert.AreEqual(3, v[0]);
            v[1] = 4;
            Assert.AreEqual(4, v[1]);
            v[1] = 5;
            Assert.AreEqual(5, v[1]);
            v[0] = 6;
            Assert.AreEqual(6, v[0]);
            v[1] = 7;
            Assert.AreEqual(7, v[1]);
            v[0] = 8;
            Assert.AreEqual(8, v[0]);
            v[0] = 9;
            Assert.AreEqual(9, v[0]);
            v[1] = -1;
            Assert.AreEqual(-1, v[1]);
            v[0] = -2;
            Assert.AreEqual(-2, v[0]);
            v[1] = -3;
            Assert.AreEqual(-3, v[1]);
            v[1] = -4;
            Assert.AreEqual(-4, v[1]);
            v[1] = -5;
            Assert.AreEqual(-5, v[1]);
            v[1] = -6;
            Assert.AreEqual(-6, v[1]);
            v[0] = -7;
            Assert.AreEqual(-7, v[0]);
            v[1] = -8;
            Assert.AreEqual(-8, v[1]);
            v[1] = -9;
            Assert.AreEqual(-9, v[1]);
            v[1] = -9.5f;
            Assert.AreEqual(-9.5f, v[1]);
            v[0] = -8.5f;
            Assert.AreEqual(-8.5f, v[0]);
            v[1] = -7.5f;
            Assert.AreEqual(-7.5f, v[1]);
            v[0] = -6.5f;
            Assert.AreEqual(-6.5f, v[0]);
            v[1] = -5.5f;
            Assert.AreEqual(-5.5f, v[1]);
            v[1] = -4.5f;
            Assert.AreEqual(-4.5f, v[1]);
            v[0] = -3.5f;
            Assert.AreEqual(-3.5f, v[0]);
            v[1] = -2.5f;
            Assert.AreEqual(-2.5f, v[1]);
            v[0] = -1.5f;
            Assert.AreEqual(-1.5f, v[0]);
            v[0] = -0.5f;
            Assert.AreEqual(-0.5f, v[0]);
            v[1] = 0.5f;
            Assert.AreEqual(0.5f, v[1]);
            v[0] = 1.5f;
            Assert.AreEqual(1.5f, v[0]);
            v[1] = 2.5f;
            Assert.AreEqual(2.5f, v[1]);
            v[1] = 3.5f;
            Assert.AreEqual(3.5f, v[1]);
            v[1] = 4.5f;
            Assert.AreEqual(4.5f, v[1]);
            v[0] = 5.5f;
            Assert.AreEqual(5.5f, v[0]);
            v[1] = 6.5f;
            Assert.AreEqual(6.5f, v[1]);
            v[0] = 7.5f;
            Assert.AreEqual(7.5f, v[0]);
            v[1] = 8.5f;
            Assert.AreEqual(8.5f, v[1]);
            v[1] = 9.5f;
            Assert.AreEqual(9.5f, v[1]);
        }

        [Test]
        public void PropertyValues()
        {
            var v = new vec2(0f, -2);
            var vals = v.Values;
            Assert.AreEqual(0f, vals[0]);
            Assert.AreEqual(-2, vals[1]);
            Assert.That(vals.SequenceEqual(v.ToArray()));
        }

        [Test]
        public void StaticProperties()
        {
            Assert.AreEqual(0f, vec2.Zero.x);
            Assert.AreEqual(0f, vec2.Zero.y);
            
            Assert.AreEqual(1f, vec2.Ones.x);
            Assert.AreEqual(1f, vec2.Ones.y);
            
            Assert.AreEqual(1f, vec2.UnitX.x);
            Assert.AreEqual(0f, vec2.UnitX.y);
            
            Assert.AreEqual(0f, vec2.UnitY.x);
            Assert.AreEqual(1f, vec2.UnitY.y);
            
            Assert.AreEqual(float.MaxValue, vec2.MaxValue.x);
            Assert.AreEqual(float.MaxValue, vec2.MaxValue.y);
            
            Assert.AreEqual(float.MinValue, vec2.MinValue.x);
            Assert.AreEqual(float.MinValue, vec2.MinValue.y);
            
            Assert.AreEqual(float.Epsilon, vec2.Epsilon.x);
            Assert.AreEqual(float.Epsilon, vec2.Epsilon.y);
            
            Assert.AreEqual(float.NaN, vec2.NaN.x);
            Assert.AreEqual(float.NaN, vec2.NaN.y);
            
            Assert.AreEqual(float.NegativeInfinity, vec2.NegativeInfinity.x);
            Assert.AreEqual(float.NegativeInfinity, vec2.NegativeInfinity.y);
            
            Assert.AreEqual(float.PositiveInfinity, vec2.PositiveInfinity.x);
            Assert.AreEqual(float.PositiveInfinity, vec2.PositiveInfinity.y);
        }

        [Test]
        public void Operators()
        {
            var v1 = new vec2(6.5f, -8.5f);
            var v2 = new vec2(6.5f, -8.5f);
            var v3 = new vec2(-8.5f, 6.5f);
            Assert.That(v1 == new vec2(v1));
            Assert.That(v2 == new vec2(v2));
            Assert.That(v3 == new vec2(v3));
            Assert.That(v1 == v2);
            Assert.That(v1 != v3);
            Assert.That(v2 != v3);
        }

        [Test]
        public void StringInterop()
        {
            var v = new vec2(-5.5f, 1.5f);
            
            var s0 = v.ToString();
            var s1 = v.ToString("#");
            
            var v0 = vec2.Parse(s0);
            var v1 = vec2.Parse(s1, "#");
            Assert.AreEqual(v, v0);
            Assert.AreEqual(v, v1);
            
            var b0 = vec2.TryParse(s0, out v0);
            var b1 = vec2.TryParse(s1, "#", out v1);
            Assert.That(b0);
            Assert.That(b1);
            Assert.AreEqual(v, v0);
            Assert.AreEqual(v, v1);
            
            b0 = vec2.TryParse(null, out v0);
            Assert.False(b0);
            b0 = vec2.TryParse("", out v0);
            Assert.False(b0);
            b0 = vec2.TryParse(s0 + ", 0", out v0);
            Assert.False(b0);
            
            Assert.Throws<NullReferenceException>(() => { vec2.Parse(null); });
            Assert.Throws<FormatException>(() => { vec2.Parse(""); });
            Assert.Throws<FormatException>(() => { vec2.Parse(s0 + ", 0"); });
            
            var s2 = v.ToString(";", CultureInfo.InvariantCulture);
            Assert.That(s2.Length > 0);
            
            var s3 = v.ToString("; ", "G");
            var s4 = v.ToString("; ", "G", CultureInfo.InvariantCulture);
            var v3 = vec2.Parse(s3, "; ", NumberStyles.Number);
            var v4 = vec2.Parse(s4, "; ", NumberStyles.Number, CultureInfo.InvariantCulture);
            Assert.AreEqual(v, v3);
            Assert.AreEqual(v, v4);
            
            var b4 = vec2.TryParse(s4, "; ", NumberStyles.Number, CultureInfo.InvariantCulture, out v4);
            Assert.That(b4);
            Assert.AreEqual(v, v4);
        }

    }
}