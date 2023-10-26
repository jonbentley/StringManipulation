namespace StringManipulation.Test.StringManipulationComponent
{
    using Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class SplitStringInto3OnPositionsTest
    {
        private StringManipulationComponent stringManipulationComponent;

        [TestMethod]
        public void SplitStringInto3OnPositionsShort_Empty()
        {
            // Arrange
            string input = "";

            // Act
            var actual = this.stringManipulationComponent.SplitStringInto3OnPositions(input, 1, 3);
            
            // Assert
            actual.Item1.ShouldBe("");
            actual.Item2.ShouldBe("");
            actual.Item3.ShouldBe("");
        }

        [TestMethod]
        public void SplitStringInto3OnPositionsShort_Short()
        {
            // Arrange
            string input1 = "12";
            string input2 = "1";

            // Act
            var actual1 = this.stringManipulationComponent.SplitStringInto3OnPositions(input1, 3, 5);
            
            var actual2 = this.stringManipulationComponent.SplitStringInto3OnPositions(input2, 3, 5);

            // Assert
            actual1.Item1.ShouldBe("12");
            actual1.Item2.ShouldBe("");
            actual1.Item3.ShouldBe("");

            actual2.Item1.ShouldBe("1");
            actual2.Item2.ShouldBe("");
            actual2.Item3.ShouldBe("");
        }
        
        [TestMethod]
        public void SplitStringInto3OnPositionsShort_Medium()
        {
            // Arrange
            string input1 = "123";
            string input2 = "12345";

            // Act
            var actual1 = this.stringManipulationComponent.SplitStringInto3OnPositions(input1, 3, 5);
            
            var actual2 = this.stringManipulationComponent.SplitStringInto3OnPositions(input2, 3, 5);

            // Assert
            actual1.Item1.ShouldBe("12");
            actual1.Item2.ShouldBe("3");
            actual1.Item3.ShouldBe("");

            actual2.Item1.ShouldBe("12");
            actual2.Item2.ShouldBe("345");
            actual2.Item3.ShouldBe("");
        }
        
        [TestMethod]
        public void SplitStringInto3OnPositionsShort_Long()
        {
            // Arrange
            string input1 = "123456";
            string input2 = "12345678";

            // Act
            var actual1 = this.stringManipulationComponent.SplitStringInto3OnPositions(input1, 3, 5);
            
            var actual2 = this.stringManipulationComponent.SplitStringInto3OnPositions(input2, 3, 5);

            // Assert
            actual1.Item1.ShouldBe("12");
            actual1.Item2.ShouldBe("345");
            actual1.Item3.ShouldBe("6");

            actual2.Item1.ShouldBe("12");
            actual2.Item2.ShouldBe("345");
            actual2.Item3.ShouldBe("678");
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            this.stringManipulationComponent = new StringManipulationComponent();
        }
    }
}
