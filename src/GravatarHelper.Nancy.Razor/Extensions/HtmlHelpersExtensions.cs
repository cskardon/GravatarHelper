using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using GravatarHelper.Common;
using Nancy.Helpers;
using Nancy.ViewEngines.Razor;

namespace GravatarHelper.Nancy.Razor.Extensions
{
    public static class HtmlHelpersExtensions
    {
        /// <summary>
        /// Returns a Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelper to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A Gravatar img tag for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static IHtmlString Gravatar(this HtmlHelpers helpers, string email, int imageSize, bool forceSecureUrl = false)
        {
            return CreateGravatarImage(helpers, email, imageSize, null, null, null, null, null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelper to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A Gravatar img tag for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static IHtmlString Gravatar(this HtmlHelpers helpers, string email, int imageSize, string defaultImage, bool forceSecureUrl = false)
        {
            return CreateGravatarImage(helpers, email, imageSize, defaultImage, null, null, null, null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelper to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="htmlAttributes">Object containing the HTML attributes to set for the img element.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A Gravatar img tag for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static IHtmlString Gravatar(this HtmlHelpers helpers, string email, int imageSize, IDictionary<string, object> htmlAttributes, bool forceSecureUrl = false)
        {
            return CreateGravatarImage(helpers, email, imageSize, null, null, null, null, htmlAttributes, forceSecureUrl);
        }

        /// <summary>
        /// Returns a Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelper to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="htmlAttributes">Object containing the HTML attributes to set for the img element.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A Gravatar img tag for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static IHtmlString Gravatar(this HtmlHelpers helpers, string email, int imageSize, string defaultImage, IDictionary<string, object> htmlAttributes, bool forceSecureUrl = false)
        {
            return CreateGravatarImage(helpers, email, imageSize, defaultImage, null, null, null, htmlAttributes, forceSecureUrl);
        }
        
        /// <summary>
        /// Returns a Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelper to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="rating">The content rating of the images to display.</param>
        /// <param name="htmlAttributes">Object containing the HTML attributes to set for the img element.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A Gravatar img tag for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static IHtmlString Gravatar(this HtmlHelpers helpers, string email, int imageSize, string defaultImage, GravatarRating? rating, IDictionary<string, object> htmlAttributes, bool forceSecureUrl = false)
        {
            return CreateGravatarImage(helpers, email, imageSize, defaultImage, rating, null, null, htmlAttributes, forceSecureUrl);
        }

        /// <summary>
        /// Returns a Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelpers to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="rating">The content rating of the images to display.</param>
        /// <param name="addExtension">Whether to add the .jpg extension to the provided Gravatar.</param>
        /// <param name="forceDefault">Forces Gravatar to always serve the default image.</param>
        /// <param name="htmlAttributes">Object containing the HTML attributes to set for the img element.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A Gravatar img tag for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static IHtmlString Gravatar(this HtmlHelpers helpers, string email, int imageSize, string defaultImage, GravatarRating? rating, bool addExtension, bool forceDefault, IDictionary<string, object> htmlAttributes, bool forceSecureUrl = false)
        {
            return CreateGravatarImage(helpers, email, imageSize, defaultImage, rating, addExtension, forceDefault, htmlAttributes, forceSecureUrl);
        }

        /// <summary>
        /// Returns the Gravatar img tag for the provided parameters.
        /// </summary>
        /// <param name="helpers">The HtmlHelpers which were extended.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="rating">The content rating of the images to display.</param>
        /// <param name="addExtension">Whether to add the .jpg extension to the provided Gravatar.</param>
        /// <param name="forceDefault">Forces Gravatar to always serve the default image.</param>
        /// <param name="htmlAttributes">Object containing the HTML attributes to set for the img element.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>The Gravatar img tag for the provided parameters.</returns>
        internal static IHtmlString CreateGravatarImage(HtmlHelpers helpers, string email, int imageSize, string defaultImage, GravatarRating? rating, bool? addExtension, bool? forceDefault, IDictionary<string, object> htmlAttributes, bool forceSecureUrl = false)
        {
            var isSecureConnection = helpers?.RenderContext?.Context?.Request?.Url?.IsSecure ?? false;

            var gravatarUrl = Common.GravatarHelper.CreateGravatarUrl(email, imageSize, defaultImage, rating, addExtension, forceDefault, forceSecureUrl || isSecureConnection);

            var tagBuilder = new StringBuilder($"<img src=\"{gravatarUrl}\"");

            if (htmlAttributes != null)
            {
                foreach (var htmlAttribute in htmlAttributes)
                {
                    var value = HttpUtility.HtmlAttributeEncode(htmlAttribute.Value.ToString());
                    tagBuilder.Append($" {htmlAttribute.Key}=\"{value}\"");
                }
            }

            tagBuilder.Append(" />");

            return new NonEncodedHtmlString(tagBuilder.ToString());
        }
    }
}
