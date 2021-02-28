using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessGame.Tests.Struct
{
    public class PositionTest
    {
        [Fact]
        public void ShouldPositionBeEqual()
        {
            var position1 = new Position(EColumn.A, ELine.One);
            var position2 = new Position(EColumn.A, ELine.One);
            Assert.True(position1.Equals(position2));
        }

        [Theory]
        [InlineData(EColumn.A, ELine.Five)]
        [InlineData(EColumn.H, ELine.One)]
        public void ShouldPositionNotBeEqual(EColumn column, ELine line)
        {
            var position1 = new Position(EColumn.A, ELine.One);
            var position2 = new Position(column, line);
            Assert.False(position1.Equals(position2));
        }

        [Theory]
        [InlineData(EColumn.A, ELine.Eight)]
        [InlineData(EColumn.A, ELine.One)]
        public void ShouldPositionColumnBeEqual(EColumn column, ELine line)
        {
            var position1 = new Position(EColumn.A, ELine.One);
            var position2 = new Position(column, line);
            Assert.True(position1.EqualsColumn(position2));
        }

        [Theory]
        [InlineData(EColumn.B, ELine.Eight)]
        [InlineData(EColumn.B, ELine.One)]
        public void ShouldPositionColumnNotBeEqual(EColumn column, ELine line)
        {
            var position1 = new Position(EColumn.A, ELine.One);
            var position2 = new Position(column, line);
            Assert.False(position1.EqualsColumn(position2));
        }

        [Theory]
        [InlineData(EColumn.A, ELine.One)]
        [InlineData(EColumn.B, ELine.One)]
        public void ShouldPositionLineBeEqual(EColumn column, ELine line)
        {
            var position1 = new Position(EColumn.A, ELine.One);
            var position2 = new Position(column, line);
            Assert.True(position1.EqualsLine(position2));
        }

        [Theory]
        [InlineData(EColumn.A, ELine.Two)]
        [InlineData(EColumn.B, ELine.Two)]
        public void ShouldPositionLineNotBeEqual(EColumn column, ELine line)
        {
            var position1 = new Position(EColumn.A, ELine.One);
            var position2 = new Position(column, line);
            Assert.False(position1.EqualsLine(position2));
        }

        [Theory]
        [InlineData(EColumn.B, ELine.Five, 2)]
        [InlineData(EColumn.H, ELine.Two, -4)]
        [InlineData(EColumn.D, ELine.Eight, 0)]
        public void ShouldReturnDifferencePositionColumn(EColumn column, ELine line, int correctDifferenceValue)
        {
            var position = new Position(EColumn.D, ELine.One);
            var positionCompare = new Position(column, line);
            Assert.Equal(position.DifferenceColumn(positionCompare), correctDifferenceValue);
        }

        [Theory]
        [InlineData(EColumn.B, ELine.Six, -1)]
        [InlineData(EColumn.H, ELine.One, 4)]
        [InlineData(EColumn.D, ELine.Five, 0)]
        public void ShouldReturnDifferencePositionLine(EColumn column, ELine line, int correctDifferenceValue)
        {
            var position = new Position(EColumn.E, ELine.Five);
            var positionCompare = new Position(column, line);
            Assert.Equal(position.DifferenceLine(positionCompare), correctDifferenceValue);
        }
    }
}
