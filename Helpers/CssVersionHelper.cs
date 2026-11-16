
using System;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;

namespace Hindustancopperlimited.Helpers
{
    public static class CssVersionHelper
    {
        public static string GetVersionedUrl(string virtualPath)
        {
            // Get the physical CSS file location.
            string physicalPath = HostingEnvironment.MapPath(virtualPath);

            // Return the normal URL if the file does not exist.
            if (string.IsNullOrEmpty(physicalPath) ||
                !File.Exists(physicalPath))
            {
                return VirtualPathUtility.ToAbsolute(virtualPath);
            }

            // Read the CSS file content.
            byte[] fileBytes = File.ReadAllBytes(physicalPath);

            // Generate a SHA-256 hash.
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fileBytes);

                string version = BitConverter.ToString(hashBytes)
                    .Replace("-", "")
                    .ToLowerInvariant();

                // Return CSS URL with automatic version.
                return VirtualPathUtility.ToAbsolute(virtualPath)
                    + "?v=" + version;
            }
        }
    }
}

