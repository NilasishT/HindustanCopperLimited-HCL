
using System;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Hindustancopperlimited.Helpers
{
    public static class ImageUrlHelper
    {
        public static string VersionedImage(
            this UrlHelper url,
            string virtualPath)
        {
            if (string.IsNullOrWhiteSpace(virtualPath))
                return string.Empty;

            string physicalPath =
                url.RequestContext.HttpContext.Server.MapPath(
                    virtualPath);

            if (!File.Exists(physicalPath))
                return url.Content(virtualPath);

            string cacheKey =
                "ImageVersion_" + physicalPath.ToLowerInvariant();

            string version =
                HttpRuntime.Cache.Get(cacheKey) as string;

            if (version == null)
            {
                using (SHA256 sha = SHA256.Create())
                using (FileStream stream = File.OpenRead(physicalPath))
                {
                    byte[] hash = sha.ComputeHash(stream);

                    version = BitConverter.ToString(hash)
                        .Replace("-", "");
                }

                CacheDependency dependency =
                    new CacheDependency(physicalPath);

                HttpRuntime.Cache.Insert(
                    cacheKey,
                    version,
                    dependency,
                    Cache.NoAbsoluteExpiration,
                    Cache.NoSlidingExpiration
                );
            }

            return url.Content(virtualPath) + "?v=" + version;
        }
    }
}
