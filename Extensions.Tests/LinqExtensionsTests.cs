using Extensions.Tests.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Extensions.Tests
{
    public class LinqExtensionsTests
    {
        [Fact]
        public void Join_Test()
        {
            var list = new List<string> { "1", "2", "3" };
            Assert.Equal("1,2,3", list.Join(","));
        }

        [Fact]
        public void Transpose_Test()
        {
            var list = new List<List<string>>
            {
                new List<string> {"1", "2", "3"},
                new List<string> {"4", "5", "6"},
                new List<string> {"7", "8", "9"}
            };

            var enumerable = list.Transpose().ToList();
            var row1 = enumerable[0].ToList();
            Assert.Equal("1", row1[0]);
            Assert.Equal("4", row1[1]);
            Assert.Equal("7", row1[2]);

            var row2 = enumerable[1].ToList();
            Assert.Equal("2", row2[0]);
            Assert.Equal("5", row2[1]);
            Assert.Equal("8", row2[2]);

            var row3 = enumerable[2].ToList();
            Assert.Equal("3", row3[0]);
            Assert.Equal("6", row3[1]);
            Assert.Equal("9", row3[2]);
        }

        [Fact]
        public void Distinct_Test()
        {
            var list = new List<string> { "1", "22", "3" };
            var actual = list.Distinct((s1, s2) => s1.Length == s2.Length);
            Assert.Equal(new List<string> { "1", "22" }, actual);
        }

        [Fact]
        public void AddUnique_Basic_Type_Test()
        {
            var list = new List<int>();

            Assert.Empty(list);

            Assert.True(list.AddUnique(1));
            Assert.Single(list);
            Assert.Equal(1, list[0]);

            Assert.True(list.AddUnique(2));
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);

            Assert.False(list.AddUnique(1));
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void AddUnique_Object_Test()
        {
            var list = new List<Model>();
            var model1 = new Model { Number = 1 };
            var model2 = new Model { Number = 2 };


            Assert.Empty(list);

            Assert.True(list.AddUnique(model1));
            Assert.Single(list);
            Assert.Equal(model1, list[0]);

            Assert.True(list.AddUnique(model2));
            Assert.Equal(2, list.Count);
            Assert.Equal(model1, list[0]);
            Assert.Equal(model2, list[1]);

            Assert.False(list.AddUnique(model1));
            Assert.Equal(2, list.Count);
            Assert.Equal(model1, list[0]);
            Assert.Equal(model2, list[1]);
        }

        [Fact]
        public void AddUnique_Object2_Test()
        {
            var list = new List<Model>();
            var model1 = new Model { Number = 1 };

            Assert.Empty(list);

            Assert.True(list.AddUnique(model1));
            Assert.Single(list);
            Assert.Equal(model1, list[0]);

            Assert.True(list.AddUnique(new Model { Number = 1 }));
            Assert.Equal(2, list.Count);
            Assert.Equal(model1, list[0]);
        }

        [Fact]
        public void AddUnique_Object_VaryByProperty_Test()
        {
            var list = new List<Model>();
            var model1 = new Model { Number = 1 };

            Assert.Empty(list);

            Assert.True(list.AddUnique(model1));
            Assert.Single(list);
            Assert.Equal(model1, list[0]);

            Assert.False(list.AddUnique(new Model { Number = 1 }, model => model.Number));
            Assert.Single(list);
            Assert.Equal(model1, list[0]);
        }

        [Fact]
        public void Shuffle_Test()
        {
            var list = new List<string> { "1", "2", "3" };
            var output = list.Shuffle().ToList();
            Assert.Contains(output, o => output.IndexOf(o) != list.IndexOf(o));
        }
    }
}
