using System;
using CustomLinkedList;
using Xunit;

namespace ListTest
{
    public class UnitTest1
    {
        private DynamicList<int> sut;


        public UnitTest1()
        {
            sut = new DynamicList<int>();
        }
        
        [Fact]
        public void AddElementToEmptyList()
        {
            //act
            sut.Add(5);
            //assert
            Assert.Equal(1, sut.Count);
            Assert.True(sut.Contains(5));
        }

        [Fact]
        public void AddElementToNotEmptyList()
        {
            //arrange
            sut.Add(5);

            //act
            sut.Add(6);
            //assert
            Assert.Equal(2, sut.Count);
            Assert.Equal(1, sut.IndexOf(6));
            Assert.True(sut.Contains(6));
        }


        [Fact]
        public void RemoveOutOfRangeIndex()
        {
            //arrange
            AddElementsToList(1);
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.RemoveAt(2));
        }

        [Fact]
        public void RemoveElementAtGivenIndex()
        {
            //arrange
            AddElementsToList(3);
            //act
            sut.RemoveAt(2);
            //assert
            Assert.Equal(2, sut.Count);
        }

        [Fact]
        public void RemoveNonExistingElement()
        {
            //arrange
            AddElementsToList(1);
            //act
            var result = sut.Remove(50);
            //assert
            Assert.Equal(1, sut.Count);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(5, 1)]
        [InlineData(8, 4)]
        public void RemoveExistingElement(int elementsCount, int removedElem)
        {
            //arrange
            AddElementsToList(elementsCount);
            //act
            sut.Remove(removedElem);
            //assert
            Assert.Equal(elementsCount-1, sut.Count);
            Assert.False(sut.Contains(removedElem));
        }

        [Fact]
        public void RemoveFromEmptyList()
        {
            //act
            var result = sut.Remove(6);
            //assert
            Assert.Equal(0, sut.Count);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(3, -1)]
        [InlineData(5, 9)]
        [InlineData(8, 10)]
        public void IndexOfNonExistingElement(int elementsCount, int indexedElem)
        {
            //arrange
            AddElementsToList(elementsCount);
            //act
            var result = sut.IndexOf(indexedElem);
            //assert
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(3, 1, 1)]
        [InlineData(5, 4, 4)]
        [InlineData(8, 8, -1)]
        public void IndexOfExistingElement(int elementsCount, int indexedElem, int expectedIndex)
        {
            //arrange
            AddElementsToList(elementsCount);
            //act
            var result = sut.IndexOf(indexedElem);
            //assert
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void IndexOfEmptyList()
        {
            //act
            var result = sut.IndexOf(3);
            //assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ContainsNonExistingElement()
        {
            //arrange
            AddElementsToList(3);
            //act
            var result = sut.Contains(6);
            //assert
            Assert.False(result);
        }
        [Theory]
        [InlineData(3, 1)]
        [InlineData(5, 4)]
        [InlineData(8, 3)]
        public void ContainsExistingElement(int nrOfElements, int elementContained)
        {
            //arrange
            AddElementsToList(nrOfElements);
            //act
            var result = sut.Contains(elementContained);
            //assert
            Assert.True(result);
        }

        private void AddElementsToList(int nrOfElements)
        {
            for (int i = 0; i < nrOfElements; i++)
            {
                sut.Add(i);
            }
        }
    }
}