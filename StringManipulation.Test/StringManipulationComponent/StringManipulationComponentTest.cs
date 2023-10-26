namespace StringManipulation.Test.StringManipulationComponent
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StringManipulation.Components;
    using Shouldly;

    [TestClass]
    public class StringManipulationComponentTest
    {
        private StringManipulationComponent stringManipulationComponent;

        [TestMethod]
        public void DeleteEmptyLinesNoInput()
        {
            // Arrange
            string input = "\r\n\r\n\r\n\r\n";
            string expected = "";

            // Act
            string actual = this.stringManipulationComponent.DeleteEmptyLines(input);

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void DeleteEmptyLines()
        {
            // Arrange
            var input = new List<String>{ "aa", "", "", "bb", "", "cc"};
            var expected = new List<String>{ "aa", "bb", "cc"};

            // Act
            string actual = this.stringManipulationComponent.DeleteEmptyLines(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void DeleteLinesContainingBlank()
        {
            // Arrange
            var input = new List<String>{ "a12", "b34", "c56", "B34"};

            // Act
            string actual = this.stringManipulationComponent.DeleteLinesContaining(input.ListToString(), "", true);
            
            // Assert
            actual.StringToList().DeepPublicCompare(input);
        }

        [TestMethod]
        public void DeleteLinesContainingCaseSensitive()
        {
            // Arrange
            var input = new List<String>{ "a12", "b34", "c56", "B34"};
            var expected = new List<String>{ "a12", "c56", "B34"};

            // Act
            string actual = this.stringManipulationComponent.DeleteLinesContaining(input.ListToString(), "b", true);
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void DeleteLinesContainingCaseInSensitive()
        {
            // Arrange
            var input = new List<String>{ "a12", "b34", "c56", "B34"};
            var expected = new List<String>{ "a12", "c56"};

            // Act
            string actual = this.stringManipulationComponent.DeleteLinesContaining(input.ListToString(), "b", false);
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void DeleteLinesNotContainingCaseSensitive()
        {
            // Arrange
            var input = new List<String>{ "a12", "b34", "c56", "B34"};
            var expected = new List<String>{ "b34"};

            // Act
            string actual = this.stringManipulationComponent.DeleteLinesNotContaining(input.ListToString(), "b", true);
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void DeleteLinesNotContainingCaseInSensitive()
        {
            // Arrange
            var input = new List<String>{ "a12", "b34", "c56", "B34"};
            var expected = new List<String>{ "b34", "B34"};

            // Act
            string actual = this.stringManipulationComponent.DeleteLinesNotContaining(input.ListToString(), "b", false);
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void Trim()
        {
            // Arrange
            var input = new List<String>{ "", "   a", "b   ", "    c   "};
            var expected = new List<String>{ "", "a", "b", "c"};

            // Act
            string actual = this.stringManipulationComponent.Trim(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void TrimBeforeFirst()
        {
            // Arrange
            var input = new List<String>{ "abcde", "abc", "d", "ddd", "daaa"};
            var expected = new List<String>{ "e", "abc", "", "dd", "aaa"};

            // Act
            string actual = this.stringManipulationComponent.TrimBeforeFirst(input.ListToString(), "d");
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void TrimAfterFirst()
        {
            // Arrange
            var input = new List<String>{ "abcde", "abc", "d", "adef", "dabc", "abcd"};
            var expected = new List<String>{ "abc", "abc", "", "a", "", "abc"};

            // Act
            string actual = this.stringManipulationComponent.TrimAfterFirst(input.ListToString(), "d");
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void SortAscendingString()
        {
            // Arrange
            var input = new List<String>{ "a", "", " ", "  ", "fffff", "f f", "e", "gg"};
            var expected = new List<String>{ "", " ", "  ", "a", "e", "f f", "fffff", "gg"};

            // Act
            string actual = this.stringManipulationComponent.SortAscendingString(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void SortDescendingString()
        {
            // Arrange
            var input = new List<String>{ "a", "", " ", "  ", "fffff", "f f", "e", "gg"};
            var expected = new List<String>{ "gg", "fffff", "f f", "e", "a", "  ", " ", ""};

            // Act
            string actual = this.stringManipulationComponent.SortDescendingString(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void SortAscendingNumeric()
        {
            // Arrange
            var input = new List<String>{ "", "aa", "1", "2", "10", "11", "100", "1 a", "1 b", "ab"};
            var expected = new List<String>{ "1", "2", "10", "11", "100", "", "1 a", "1 b", "aa", "ab"};

            // Act
            string actual = this.stringManipulationComponent.SortAscendingNumeric(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void SortDescendingNumeric()
        {
            // Arrange
            var input = new List<String>{ "", "aa", "1", "2", "10", "11", "100", "1 a", "1 b", "ab"};
            var expected = new List<String>{ "1", "2", "10", "11", "100", "", "1 a", "1 b", "aa", "ab"};
            expected.Reverse();

            // Act
            string actual = this.stringManipulationComponent.SortDescendingNumeric(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void SortLineLength()
        {
            // Arrange
            var input = new List<String>{ "12", "", "123", "1234", "12345678", "333", "34", "a", "1", "z", "  "};
            var expected = new List<String>{  "", "1", "a", "z", "  ", "12", "34", "123", "333", "1234", "12345678"};

            // Act
            string actual = this.stringManipulationComponent.SortLineLength(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void ReverseCurrentOrder()
        {
            // Arrange
            var input = new List<String>{ "a", "", " ", "  ", "c", "d", "e"};
            var expected = new List<String>{ "e", "d", "c", "  ", " ", "", "a"};

            // Act
            string actual = this.stringManipulationComponent.ReverseCurrentOrder(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void RemoveDuplicates()
        {
            // Arrange
            var input = new List<String>{ "a", "b", "a", "c", "b", "", " ", " ", "", "e", "c"};
            var expected = new List<String>{ "a", "b", "c", "", " ", "e"};

            // Act
            string actual = this.stringManipulationComponent.RemoveDuplicates(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void FindUniqueItems()
        {
            // Arrange
            var input = new List<String>{ "a", "", "b", "a", "c", "a", "d", "a", "f", "g", "a", "", "h"};
            var expected = new List<String>{ "b", "c", "d", "f", "g", "h"};

            // Act
            string actual = this.stringManipulationComponent.FindUniqueItems(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void FindAllItemsThatAreDuplicates()
        {
            // Arrange
            var input = new List<String>{ "a", "", "b", "a", "c", "a", "d", "a", "f", "g", "a", "", "h"};
            var expected = new List<String>{ "a", "", "a", "a", "a", "a", ""};

            // Act
            string actual = this.stringManipulationComponent.FindAllItemsThatAreDuplicates(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void CountOccurrences()
        {
            // Arrange
            var input = new List<String>{ "a", "", "a", "b", "a", "k", "k"};
            var expected = new List<String>{ "3 - a", "1 - ", "3 - a", "1 - b", "3 - a", "2 - k", "2 - k"};

            // Act
            string actual = this.stringManipulationComponent.CountOccurrences(input.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void Sum()
        {
            // Arrange
            var input = new List<String>{ "1.1", "2 a", "3"};

            // Act
            string actual = this.stringManipulationComponent.Sum(input.ListToString());
            
            // Assert
            var actualList = actual.StringToList();
            actualList[0].ShouldBe("line 2 does not contain a number so is ignored : 2 a");
            actualList[1].ShouldBe("4.1");
            actualList[2].ShouldBe("04.100000");
            actualList[3].ShouldBe("4.10");
            actualList[4].ShouldBe("");
            actualList[5].ShouldBe("1.1");
            actualList[6].ShouldBe("2 a");
            actualList[7].ShouldBe("3");
        }

        [TestMethod]
        public void InsertAtStartOfEachLine()
        {
            // Arrange
            var input = new List<String>{ "", "abc", "def", "  "};
            var expected = new List<String>{ "zzz", "zzzabc", "zzzdef", "zzz  "};

            // Act
            string actual = this.stringManipulationComponent.InsertAtStartOfEachLine(input.ListToString(), "zzz");
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void InsertAtEndOfEachLine()
        {
            // Arrange
            var input = new List<String>{ "", "abc", "def", "  "};
            var expected = new List<String>{ "nnn", "abcnnn", "defnnn", "  nnn"};

            // Act
            string actual = this.stringManipulationComponent.InsertAtEndOfEachLine(input.ListToString(), "nnn");
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void InsertAtPosition()
        {
            // Arrange
            var input = new List<String>{ "", " ", "abcd", "efgh", "ij", "k"};
            var expected = new List<String>{ " <line too short>", "  <line too short>", "abzzzcd", "efzzzgh", "ijzzz", "k <line too short>"};

            // Act
            var actual = this.stringManipulationComponent.InsertAtPosition(input.ListToString(), 2, "zzz");
            
            // Assert
            actual.Item1.StringToList().DeepPublicCompare(expected);
            actual.Item2.ShouldBe(3);
        }

        [TestMethod]
        public void List1NotList2()
        {
            // Arrange
            var input1 = new List<String>{ "a", "b", "c", "e", "f", "h", ""};
            var input2 = new List<String>{ "z", "e", "y", "b", "y", "", " "};
            var expected = new List<String>{ "a", "c", "f", "h"};

            // Act
            string actual = this.stringManipulationComponent.List1NotList2(input1.ListToString(), input2.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void List1AndList2()
        {
            // Arrange
            var input1 = new List<String>{ "a", "b", "c", "e", "f", "h", ""};
            var input2 = new List<String>{ "z", "e", "y", "b", "y", "", " "};
            var expected = new List<String>{ "b", "e", ""};

            // Act
            string actual = this.stringManipulationComponent.List1AndList2(input1.ListToString(), input2.ListToString());
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.stringManipulationComponent = new StringManipulationComponent();
        }
    }
}
