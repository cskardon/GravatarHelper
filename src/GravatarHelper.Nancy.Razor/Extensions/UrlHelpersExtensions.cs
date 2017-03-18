using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GravatarHelper.Common;
using Nancy.ViewEngines.Razor;

namespace GravatarHelper.Nancy.Razor.Extensions
{
    /// <summary>
    /// Gravatar UrlHelper extension methods.
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Returns the Gravatar URL for the provided parameters.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>#
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>The Gravatar URL for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static string Gravatar<T>(this UrlHelpers<T> helpers, string email, int imageSize, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarUrl(email, imageSize, null, null, null, null, forceSecureUrl || IsSecureConnection(helpers));
        }

        /// <summary>
        /// Returns the Gravatar URL for the provided parameters.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>The Gravatar URL for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static string Gravatar<T>(this UrlHelpers<T> helpers, string email, int imageSize, string defaultImage, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarUrl(email, imageSize, defaultImage, null, null, null, forceSecureUrl || IsSecureConnection(helpers));
        }

        /// <summary>
        /// Returns the Gravatar URL for the provided parameters.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="imageSize">Gravatar size in pixels.</param>
        /// <param name="defaultImage">The default image to use if the user does not have a Gravatar setup,
        /// can either be a url to an image or one of the DefaultImage* constants</param>
        /// <param name="rating">The content rating of the images to display.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>The Gravatar URL for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static string Gravatar<T>(this UrlHelpers<T> helpers, string email, int imageSize, string defaultImage, GravatarRating? rating, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarUrl(email, imageSize, defaultImage, rating, null, null, forceSecureUrl || IsSecureConnection(helpers));
        }

        /// <summary>
        /// Returns a URL to the Gravatar profile.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the Gravatar for.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>The Gravatar URL for the provided parameters.</returns>
        [ExcludeFromCodeCoverage]
        public static string GravatarProfile<T>(this UrlHelpers<T> helpers, string email, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarProfileUrl(email, null, null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a URL to the Gravatar profile data formatted as JSON.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the link for.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A URL to the Gravatar profile data formatted as JSON.</returns>
        [ExcludeFromCodeCoverage]
        public static string GravatarProfileAsJSON<T>(this UrlHelpers<T> helpers, string email, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarProfileUrl(email, "json", null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a URL to the Gravatar profile data formatted as JSON.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the link for.</param>
        /// <param name="callback">Name of the Javascript callback function.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A URL to the Gravatar profile data formatted as JSON.</returns>
        public static string GravatarProfileAsJSON<T>(this UrlHelpers<T> helpers, string email, string callback, bool forceSecureUrl = false)
        {
            var optionalParameters = new Dictionary<string, string>
            {
                { "Callback", callback }
            };

            return Common.GravatarHelper.CreateGravatarProfileUrl(email, "json", optionalParameters, forceSecureUrl);
        }

        /// <summary>
        /// Returns a URL to the Gravatar profile data formatted as vCard.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the link for.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A URL to the Gravatar profile data formatted as vCard.</returns>
        public static string GravatarProfileAsVCard<T>(this UrlHelpers<T> helpers, string email, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarProfileUrl(email, "vcf", null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a URL to the Gravatar profile data formatted as XML.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the link for.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A URL to the Gravatar profile data formatted as XML.</returns>
        public static string GravatarProfileAsXml<T>(this UrlHelpers<T> helpers, string email, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarProfileUrl(email, "xml", null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a URL to an image containing a QR Code link back to the Gravatar profile.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the link for.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A URL to an image containing a QR Code link back to the Gravatar profile.</returns>
        public static string GravatarProfileAsQRCode<T>(this UrlHelpers<T> helpers, string email, bool forceSecureUrl = false)
        {
            return Common.GravatarHelper.CreateGravatarProfileUrl(email, "qr", null, forceSecureUrl);
        }

        /// <summary>
        /// Returns a URL to an image containing a QR Code link back to the Gravatar profile.
        /// </summary>
        /// <param name="helpers">The UrlHelpers to extend.</param>
        /// <param name="email">Email address to generate the link for.</param>
        /// <param name="imageSize">QR Code size in pixels.</param>
        /// <param name="forceSecureUrl">Forces the use of https</param>
        /// <returns>A URL to an image containing a QR Code link back to the Gravatar profile.</returns>
        public static string GravatarProfileAsQRCode<T>(this UrlHelpers<T> helpers, string email, int imageSize, bool forceSecureUrl = false)
        {
            var optionalParameters = new Dictionary<string, string>
            {
                { "s", imageSize.ToString() }
            };

            return Common.GravatarHelper.CreateGravatarProfileUrl(email, "qr", optionalParameters, forceSecureUrl);
        }

        /// <summary>
        /// Determines whether the request associated with the provided UrlHelpers was secure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers">The helpers.</param>
        /// <returns>
        ///   <c>true</c> if the connection is secure; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsSecureConnection<T>(UrlHelpers<T> helpers)
        {
            return helpers?.RenderContext?.Context?.Request?.Url?.IsSecure ?? false;
        }
    }
}
