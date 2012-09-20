#region

using System;
using FluentAssertions;
using Xunit;

#endregion


namespace Kata6
{
    public class TestWrapper
    {
        [Fact]
        public void test_wrap_with_0_column_widht()
        {
            var text = "some text lk'l'k";
            var wrapper = new Wrapper();
            var result = wrapper.Wrap(text, 0, false);
            result.Should().Be(text);
        }

        [Fact]
        public void test_wrap_with_column_width_19()
        {
            const string text = "abc cde sdfddddf some more text text klj;kjkl dddddd";
            var wrapper = new Wrapper();
            var result = wrapper.Wrap(text, 19, false);
            result.Should().Be("abc cde sdfddddf so\nme more text text k\nlj;kjkl dddddd");
        }

        [Fact]
        public void test_wrap_with_column_width_19_text_boudaries()
        {
            const string text = "aaabc cde sdfddddf someaa more text aatext klj;kjkl dddddd";
            var wrapper = new Wrapper();
            var result = wrapper.Wrap(text, 21, true);
            result.Should().Be("aaabc cde sdfddddf \nsomeaa more text \naatext klj;kjkl \ndddddd");
        }

        [Fact]
        public void test_wrap_with_text_lenght_less_then_colwidth()
        {
            const string text = "abcd";
            var wrapper = new Wrapper();
            var result = wrapper.Wrap(text, 10, false);
            result.Should().Be("abcd");
        }

        [Fact]
        public void test_wrap_with_boundaries_less_20_column_width()
        {
            const string text = "abc cde sdfddddf some more text text klj;kjkl dddddd";
            var wrapper = new Wrapper();
            Action act =() => wrapper.Wrap(text, 19, true);
            act.ShouldThrow<Exception>("The column width is rejected as too short for a line wrap");
        }

        [Fact]
        public void test_words_longer_then_column_width()
        {
            const string text = "abc cde sdfddddf sffdsfomrremoretexttextklj;kjkldddddd";
            var wrapper = new Wrapper();
            Action act = () => wrapper.Wrap(text, 22, true);
            act.ShouldThrow<Exception>("One or more words is longer then column width");
        }

        [Fact]
        public void test_words_longer_then_column_width_()
        {
            const string text = "abc cde sdfddddf sffdsfomrremoretexttextklj;kjkldddddd";
            var wrapper = new Wrapper();
            var result = wrapper.Wrap(text, 22, false);
            result.Should().Be("abc cde sdfddddf sffds\nfomrremoretexttextklj;\nkjkldddddd");
        }
    }
}
