﻿using System.Drawing;
using ColorMine.ColorSpaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorMine.Utility;

namespace ColorMine.Test.ColorSpaces
{
    public class XyzTest : ConverterTest
    {
        [TestClass]
        public class X
        {
            [TestMethod]
            public void SavesAppropriateValue()
            {
                const double expected = 255;
                // TODO Should be mocking!
                var target = new Xyz
                {
                    X = expected
                };

                Assert.AreEqual(expected, target.X);
            }

        }

        [TestClass]
        public class Y
        {
            [TestMethod]
            public void SavesAppropriateValue()
            {
                const double expected = 0;

                var target = new Xyz
                {
                    Y = expected
                };

                Assert.AreEqual(expected, target.Y);
            }
        }

        [TestClass]
        public class Z
        {
            [TestMethod]
            public void SavesAppropriateValue()
            {
                const double expected = 2.0;

                var target = new Xyz
                {
                    Z = expected
                };

                Assert.AreEqual(expected, target.Z);
            }

        }

        [TestClass]
        public class Initialize
        {
            private void ExpectedValuesFromKnownColor(Color knownColor, double expectedX, double expectedY, double expectedZ)
            {
                var target = new Xyz();
                target.Initialize(knownColor);

                // TODO Shouldn't use ColorMine code to validate ColorMine code...
                Assert.IsTrue(expectedX.BasicallyEqualTo(target.X));
                Assert.IsTrue(expectedY.BasicallyEqualTo(target.Y));
                Assert.IsTrue(expectedZ.BasicallyEqualTo(target.Z));
            }

            [TestMethod]
            public void ExpectedValuesFromTomato()
            {
                ExpectedValuesFromKnownColor(Color.Tomato, 46.839,30.639,9.406);
            }

            [TestMethod]
            public void ExpectedValuesFromSpringGreen()
            {
                ExpectedValuesFromKnownColor(Color.SpringGreen, 39.591,73.052,32.093);
            }

            [TestMethod]
            public void ExpectedValuesFromSteelBlue()
            {
                ExpectedValuesFromKnownColor(Color.SteelBlue, 18.747,20.563,46.161);
            }
        }

        [TestClass]
        public class ToColor
        {
            private void ExpectedColorFromKnownValues(Color knownColor, double expectedX, double expectedY, double expectedZ)
            {
                var target = new Xyz
                {
                    X = expectedX,
                    Y = expectedY,
                    Z = expectedZ
                };

                var actual = target.ToColor();

                Assert.IsTrue(CloseEnough(knownColor.R, actual.R));
                Assert.IsTrue(CloseEnough(knownColor.G, actual.G));
                Assert.IsTrue(CloseEnough(knownColor.B, actual.B));
            }

            [TestMethod]
            public void ExpectedColorFromDarkSalmon()
            {
                ExpectedColorFromKnownValues(Color.DarkSalmon, 48.023,40.541,23.707);
            }

            [TestMethod]
            public void ExpectedColorFromDarkSeaGreen()
            {
                ExpectedColorFromKnownValues(Color.DarkSeaGreen, 34.269,43.789,32.633);
            }

            [TestMethod]
            public void ExpectedColorFromDodgerBlue()
            {
                ExpectedColorFromKnownValues(Color.DodgerBlue, 28.559,27.443,98.399);
            }

        }
    }
}
