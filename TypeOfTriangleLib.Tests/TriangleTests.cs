namespace TypeOfTriangle.Tests
{
    using Xunit;
    using System;
    using Xunit.Abstractions;
    using TypeOfTriangleLib;

    public class TriangleTests
    {
        private ITestOutputHelper output;

        public TriangleTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void GetType_EquilateralTriangle_ReturnsEquilateral()
        {
            // Arrange
            double side1 = 5.5;
            double side2 = 5.5;
            double side3 = 5.5;

            // Act
            string result = Triangle.GetType(side1, side2, side3);

            // Calculate angles using Law of Cosines
            double angle1 = Math.Acos((side2 * side2 + side3 * side3 - side1 * side1) / (2 * side2 * side3)) * 180 / Math.PI;
            double angle2 = Math.Acos((side1 * side1 + side3 * side3 - side2 * side2) / (2 * side1 * side3)) * 180 / Math.PI;
            double angle3 = 180 - angle1 - angle2;

            output.WriteLine($"Angle 1: {angle1}");
            output.WriteLine($"Angle 2: {angle2}");
            output.WriteLine($"Angle 3: {angle3}");

            // Assert
            Assert.Equal("Equilateral", result);
            Assert.True(Math.Abs(angle1 - angle2) < 0.0001); // Adjust the tolerance value as needed
            Assert.True(Math.Abs(angle2 - angle3) < 0.0001); // Adjust the tolerance value as needed
        }

        [Fact]
        public void GetType_ObtuseTriangle_ReturnsObtuse()
        {
            // Arrange
            double side1 = 3.2;
            double side2 = 4.1;
            double side3 = 5.7;

            // Act
            string result = Triangle.GetType(side1, side2, side3);

            // Calculate angles using Law of Cosines
            double angle1 = Math.Acos((side2 * side2 + side3 * side3 - side1 * side1) / (2 * side2 * side3)) * 180 / Math.PI;
            double angle2 = Math.Acos((side1 * side1 + side3 * side3 - side2 * side2) / (2 * side1 * side3)) * 180 / Math.PI;
            double angle3 = 180 - angle1 - angle2;

            output.WriteLine($"Angle 1: {angle1}");
            output.WriteLine($"Angle 2: {angle2}");
            output.WriteLine($"Angle 3: {angle3}");


            // Assert
            Assert.Equal("Obtuse", result);
            Assert.True(angle1 > 90 || angle2 > 90 || angle3 > 90);
        }

        [Fact]
        public void GetType_AcuteTriangle_ReturnsAcute()
        {
            // Arrange
            double side1 = 4.9;
            double side2 = 4.9;
            double side3 = 6.2;

            // Act
            string result = Triangle.GetType(side1, side2, side3);

            // Calculate angles using Law of Cosines
            double angle1 = Math.Acos((side2 * side2 + side3 * side3 - side1 * side1) / (2 * side2 * side3)) * 180 / Math.PI;
            double angle2 = Math.Acos((side1 * side1 + side3 * side3 - side2 * side2) / (2 * side1 * side3)) * 180 / Math.PI;
            double angle3 = 180 - angle1 - angle2;

            output.WriteLine($"Angle 1: {angle1}");
            output.WriteLine($"Angle 2: {angle2}");
            output.WriteLine($"Angle 3: {angle3}");


            // Assert
            Assert.Equal("Acute", result);
            Assert.True(angle1 < 90 && angle2 < 90 && angle3 < 90);
        }

        [Fact]
        public void GetType_RightTriangle_ReturnsRight()
        {
            // Arrange
            double side1 = 3.0;
            double side2 = 4.0;
            double side3 = 5.0;

            // Act
            string result = Triangle.GetType(side1, side2, side3);

            // Calculate angles using Law of Cosines
            double angle1 = Math.Acos((side2 * side2 + side3 * side3 - side1 * side1) / (2 * side2 * side3)) * 180 / Math.PI;
            double angle2 = Math.Acos((side1 * side1 + side3 * side3 - side2 * side2) / (2 * side1 * side3)) * 180 / Math.PI;
            double angle3 = 180 - angle1 - angle2;

            output.WriteLine($"Angle 1: {angle1}");
            output.WriteLine($"Angle 2: {angle2}");
            output.WriteLine($"Angle 3: {angle3}");


            // Assert
            Assert.Equal("Right", result);
            Assert.True(angle1 == 90 || angle2 == 90 || angle3 == 90);
        }

        [Fact]
        public void GetType_InvalidArguments_ThrowsArgumentException()
        {
            // Arrange
            double side1 = 0.0;
            double side2 = 2.3;
            double side3 = -1.5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Triangle.GetType(side1, side2, side3));
        }
    }
}