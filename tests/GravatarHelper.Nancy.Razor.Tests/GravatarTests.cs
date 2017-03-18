using System.Collections.Generic;
using GravatarHelper.Nancy.Razor.Extensions;
using GravatarHelper.Nancy.Razor.Tests.Fakes;
using Nancy.ViewEngines.Razor;
using Xunit;

namespace GravatarHelper.Nancy.Razor.Tests
{
    public class GravatarTests
    {
        private const string TestEmailAddress = "MyEmailAddress@example.com";
        private const string TestEmailAddressHash = "0bc83cb571cd1c50ba6f3e8a78ef1346";

        private readonly HtmlHelpers<object> _helpers;

        public GravatarTests()
        {
            var renderContext = new TestRenderContext(null);
            var razorViewEngine = new RazorViewEngine(new DefaultRazorConfiguration());

            _helpers = new HtmlHelpers<object>(razorViewEngine, renderContext, new object());

        }

        [Fact]
        public void Given_EmailAddressAndSize_When_GeneratingHtmlTag_Then_GeneratesWellFormedHtml()
        {
            var gravatar = _helpers.Gravatar(TestEmailAddress, 80);
            Assert.Equal($"<img src=\"http://www.gravatar.com/avatar/{TestEmailAddressHash}?s=80\" />", gravatar.ToHtmlString());
        }

        [Fact]
        public void Given_AdditionalAttributesWithSpecialCharacters_When_GeneratingHtmlTag_Then_GeneratesWellFormedHtml()
        {
            var htmlAttributes = new Dictionary<string, object>
            {
                { "QuoteTest", "\"test\"" },
                { "AngleBracketTest", "<>" },
                { "AmpersandTest", "&" },

            };

            var gravatar = _helpers.Gravatar(TestEmailAddress, 80, htmlAttributes);

            Assert.Equal($"<img src=\"http://www.gravatar.com/avatar/{TestEmailAddressHash}?s=80\" QuoteTest=\"&quot;test&quot;\" AngleBracketTest=\"&lt;>\" AmpersandTest=\"&amp;\" />", gravatar.ToHtmlString());
        }
    }
}