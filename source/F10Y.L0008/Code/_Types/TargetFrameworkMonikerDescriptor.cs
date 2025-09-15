using System;


namespace F10Y.L0008
{
    public class TargetFrameworkMonikerDescriptor
    {
        /// <summary>
        /// The base target framework moniker.
        /// (Example: the "net6.0" in "net6.0-ios15.0")
        /// </summary>
        public string BaseToken { get; set; }

        /// <summary>
        /// The base target framework moniker token.
        /// (Example: the "net" in "net6.0-ios15.0")
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// The version (if the target framework moniker has a version).
        /// (Example: 7.0 for "net7.0" and 4.5.2 for "net452")
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Make it explicit if a target framework moniker has a version.
        /// </summary>
        public bool Has_Version { get; set; }

        /// <summary>
        /// The operating system target framework moniker token.
        /// (Example: the "ios15.0" in "net6.0-ios15.0".)
        /// </summary>
        public string OperatingSystemToken { get; set; }

        /// <summary>
        /// Make it explicit if a target framework moniker has an operating system token.
        /// </summary>
        public bool Has_OperatingSystemToken { get; set; }

        /// <summary>
        /// The operating system target framework moniker token.
        /// (Example: the "ios" in "net6.0-ios15.0".)
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// The version (if the target framework moniker has a version).
        /// (Example: 15.0 for "net6.0-ios15.0")
        /// </summary>
        public Version OperatingSystemVersion { get; set; }

        /// <summary>
        /// Make it explicit if a target framework moniker has an operating system version.
        /// </summary>
        public bool Has_OperatingSystemVersion { get; set; }
    }
}
