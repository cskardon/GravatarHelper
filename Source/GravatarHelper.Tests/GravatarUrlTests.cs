﻿namespace GravatarHelper.Tests
{
    using System;
    using System.Collections.Specialized;
    using System.Web;
    using Xunit;

    /// <summary>
    /// Test which verify the functionality of CreateGravatarUrl.
    /// </summary>
    public class GravatarUrlTests
    {
        /// <summary>
        /// Our testing HttpRequest; allowing us to switch between secure / non-secure connection. 
        /// </summary>
        private TestHttpRequest httpRequest = new TestHttpRequest();

        /// <summary>
        /// Initializes a new instance of the <see cref="GravatarUrlTests"/> class.
        /// </summary>
        public GravatarUrlTests()
        {
            GravatarHelper.GetHttpContext = () => new TestHttpContext(this.httpRequest);
        }

        /// <summary>
        /// Verifies that CreateGravatarUrl uses the .jpg file extension if a file extension has been requested.
        /// </summary>
        [Fact(DisplayName = "File extensions are used if requested.")]
        public void UsesExtensionIfRequested()
        {
            Func<bool?, string> createGravatarUrl = (useExtension) =>
                {
                    var url = GravatarHelper.CreateGravatarUrl("MyEmailAddress@example.com", 80, null, null, useExtension, null);
                    var uri = new Uri(url);

                    return uri.Segments[2];
                };

            Assert.True(createGravatarUrl(true).EndsWith(".jpg"), "Uses a file extension when requested to.");
            Assert.True(!createGravatarUrl(false).EndsWith(".jpg"), "Does not use a file extension when requested not to.");
            Assert.True(!createGravatarUrl(null).EndsWith(".jpg"), "Does not use extensions by default.");
        }

        /// <summary>
        /// Verifies that CreateGravatarUrl automatically switches between http and https depending on IsSecureConnection.
        /// </summary>
        [Fact(DisplayName = "Automatically determine whether to use http or https.")]
        public void AutomaticallyUseHttpAndHttps()
        {
            this.httpRequest.SecureConnectionResult = true;            
            var secureUrl = GravatarHelper.CreateGravatarUrl("MyEmailAddress@example.com", 80, null, null, null, null);

            Assert.True(secureUrl.StartsWith("https://"), "Https protocl should be used on secure connections by default.");

            this.httpRequest.SecureConnectionResult = false;
            var normalUrl = GravatarHelper.CreateGravatarUrl("MyEmailAddress@example.com", 80, null, null, null, null);            

            Assert.True(normalUrl.StartsWith("http://"), "Http protocl should be used on normal connections by default.");
        }

        /// <summary>
        /// Verify that the Gravatar size cannot exceed either minimum or maximum size. 
        /// </summary>
        [Fact(DisplayName = "Image size cannot exceed either minimum or maximum size.")]
        public void ImageSizeCannotExceedBounds()
        {
            Func<int, int> createGravatarUrl = (gravatarSize) =>
                {
                    var url = GravatarHelper.CreateGravatarUrl("MyEmailAddress@example.com", gravatarSize, null, null, null, null);
                    var sizeQueryParameter = GetQueryParameter(url, "s");
                    int size;

                    Assert.True(int.TryParse(sizeQueryParameter, out size), "The query string must contain an integer value for size.");

                    return size;
                };

            var average = (GravatarHelper.MinImageSize + GravatarHelper.MaxImageSize) / 2;

            var minSize = createGravatarUrl(GravatarHelper.MinImageSize - 1);
            var avgSize = createGravatarUrl(average);
            var maxSize = createGravatarUrl(GravatarHelper.MaxImageSize + 1);

            Assert.True(minSize == GravatarHelper.MinImageSize, "Size cannot be smaller than MinImageSize");
            Assert.True(avgSize == average, "Size must remain unaltered if between MinImageSize and MaxImageSize");
            Assert.True(maxSize == GravatarHelper.MaxImageSize, "Size cannot be larger than MaxImageSize.");
        }

        /// <summary>
        /// Verify that the URL generated by CreateGravatarUrl is well-formed.
        /// </summary>
        [Fact(DisplayName = "Generated URL is well-formed.")]
        public void UrlIsWellFormed()
        {
            Func<string, Uri> createGravatarUri = (defaultImage) =>
                {
                    var url = GravatarHelper.CreateGravatarUrl("MyEmailAddress@example.com", 80, defaultImage, GravatarRating.PG, true, true);
                    return new Uri(url);
                };

            var identiconUri = createGravatarUri(GravatarHelper.DefaultImageIdenticon);
            var customUri = createGravatarUri("http://example.com/logo.jpg");

            Assert.True(identiconUri.IsWellFormedOriginalString(), "CreateGravatarUrl did not create well-formed URI using a gravatar default image.");
            Assert.True(customUri.IsWellFormedOriginalString(), "CreateGravatarUrl did not create well-formed URI using custom default image.");
        }

        /// <summary>
        /// Gets the query parameters as a <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>A NameValueCollection of all query parameters.</returns>
        private NameValueCollection GetQueryParameters(string url)
        {
            var uri = new Uri(url);
            return HttpUtility.ParseQueryString(uri.Query);
        }

        /// <summary>
        /// Gets the query parameter.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The value of the query parameter.</returns>
        private string GetQueryParameter(string url, string parameter)
        {
            return this.GetQueryParameters(url)[parameter];
        }
    }
}