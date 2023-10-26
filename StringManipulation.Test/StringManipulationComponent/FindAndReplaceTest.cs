namespace StringManipulation.Test.StringManipulationComponent
{
    using System;
    using System.Collections.Generic;
    using Components;
    using Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Shouldly;

    [TestClass]
    public class FindAndReplaceTest
    {
        private StringManipulationComponent stringManipulationComponent;

        [TestMethod]
        public void FindAndReplaceExceptionDuffParameters()
        {
            // Arrange
            var input = new List<String>{ "" };

            // Act
            var result = Should.Throw<System.Exception>(() => this.stringManipulationComponent.FindAndReplace(input.ListToString(), "a", "b", 0, 9, 1 ));

            // Assert
            result.Message.ShouldBe("The from column number '9' is greater that the to column '1'");
        }

        [TestMethod]
        public void FindAndReplaceSimpleCase()
        {
            // Arrange
            var input = new List<String>{ "abc", "", "bcde", "bc", "bcbc", "bcb", "bbc", "bcc", " bc efg"};
            var expected = new List<String>{ "azzz", "", "zzzde", "zzz", "zzzzzz", "zzzb", "bzzz", "zzzc", " zzz efg"};

            // Act
            string actual = this.stringManipulationComponent.FindAndReplace(input.ListToString(), "bc", "zzz", 0, 0, 0 );
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void FindAndReplaceOccurrence2()
        {
            // Arrange
            var input = new List<String>{ "abc", "", "bcde", "bc", "bcbc", "aaabcaaabcggg","bc efgbc"};
            var expected = new List<String>{  "abc", "", "bcde", "bc", "bczzz", "aaabcaaazzzggg", "bc efgzzz"};

            // Act
            string actual = this.stringManipulationComponent.FindAndReplace(input.ListToString(), "bc", "zzz", 2, 0, 0 );
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        [TestMethod]
        public void FindAndReplaceBetweenCols()
        {
            // Arrange
            var input = new List<String>{ "abc", "", "bcde", "123456bc", "1bcbc", "aabcabca", "bc efgbc"};
            var expected = new List<String>{ "azzz","", "bcde", "123456bc", "1zzzzzz","aazzzazzza", "bc efgbc"};

            // Act
            string actual = this.stringManipulationComponent.FindAndReplace(input.ListToString(), "bc", "zzz", 0, 2, 7 );
            
            // Assert
            actual.StringToList().DeepPublicCompare(expected);
        }

        
        [TestMethod]
        public void FindAndReplaceBetweenColsOccurrence2()
        {
            // Arrange
            var input = new List<String>{ "", " ", "abc", "xabcdefxxx", "xabcdex", "xabcxdxefgx"};
            var expected = new List<String>{ "", " ", "abc", "xabcdefxxx", "xabcdex", "xabcxdzefgx"};

            // Act
            string actual = this.stringManipulationComponent.FindAndReplace(input.ListToString(), "x", "z", 2, 2, 7 );
            
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
