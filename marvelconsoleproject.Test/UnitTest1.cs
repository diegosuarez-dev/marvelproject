using Xunit;
using System.Collections.Generic;
using marvelconsoleproject.Helpers;

namespace marvelconsoleproject.Test
{
    public class UnitTest1
    {
        [Fact]
        public void FetchSeriesReturnsSeriesList()
        {
            //arrange
            var req = new Request();

            //act
            var series = req.FetchSeries();

            //assert
            Assert.IsType<List<Serie>>(series);
        }

        [Fact]
        public void FetchCharactersReturnsCharacterListWhenSelectedSerieExists()
        {
            //arrange
            var req = new Request();
            req.FetchSeries();

            //act
            var characters = req.FetchCharacters(4);

            //assert
            Assert.IsType<List<Character>>(characters);
        }

        [Fact]
        public void FetchCharactersReturnsCharacterListWhenSelectedSerieDoesNotExist()
        {
            //arrange
            var req = new Request();
            req.FetchSeries();

            //act
            var characters = req.FetchCharacters(21);

            //assert
            Assert.IsType<List<Character>>(characters);
        }

        [Fact]
        public void FetchCharactersReturnsCharacterListWhenSelectedSerieIsNegative()
        {
            //arrange
            var req = new Request();
            req.FetchSeries();

            //act
            var characters = req.FetchCharacters(-5);

            //assert
            Assert.IsType<List<Character>>(characters);
        }

        [Fact]
        public void GetSelectedSeriesNameReturnsStringWhenSelectedSerieExists()
        {
            //arrange
            var req = new Request();
            req.FetchSeries();

            //act
            var title = req.GetSelectedSeriesName(1);

            //assert
            Assert.IsType<string>(title);
        }

        [Fact]
        public void GetSelectedSeriesNameReturnsStringWhenSelectedSerieDoesNotExist()
        {
            //arrange
            var req = new Request();
            req.FetchSeries();

            //act
            var title = req.GetSelectedSeriesName(25);

            //assert
            Assert.IsType<string>(title);
        }

        [Fact]
        public void GetSelectedSeriesNameReturnsStringWhenSelectedSerieIsNegative()
        {
            //arrange
            var req = new Request();
            req.FetchSeries();

            //act
            var title = req.GetSelectedSeriesName(-10);

            //assert
            Assert.IsType<string>(title);
        }
    }
}
