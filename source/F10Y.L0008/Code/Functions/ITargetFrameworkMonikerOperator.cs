using System;
using System.Linq;

using F10Y.L0003;
using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface ITargetFrameworkMonikerOperator
    {
        string Get_TargetFrameworkMoniker_ForDirectoryName(string targetFrameworkMoniker_DirectoryName)
            // It's just the TFM.
            => targetFrameworkMoniker_DirectoryName;

        string Get_DirectoryName_ForTargetFrameworkMoniker(string targetFrameworkMoniker)
            // It's just the TFM.
            => targetFrameworkMoniker;

        string Get_DirectoryName(string targetFrameworkMoniker)
            => this.Get_DirectoryName_ForTargetFrameworkMoniker(targetFrameworkMoniker);

        string Get_TargetFrameworkMoniker_ForPack(
            string pack_Name,
            Version version)
        {
            var sharedFramework_Name = Instances.DotnetPackOperator.Get_SharedFrameworkName_FromPackName(pack_Name);

            var output = this.Get_TargetFrameworkMoniker_ForSharedFramework(
                sharedFramework_Name,
                version);

            return output;
        }

        string Get_TargetFrameworkMoniker_ForSharedFramework(
            string pack_Name,
            Version version)
        {
            // The pack name is irrelevant.

            // Switch on 
            var output = version.Major switch
            {
                5 => Instances.TargetFrameworkMonikers.net5_0,
                6 => Instances.TargetFrameworkMonikers.net6_0,
                7 => Instances.TargetFrameworkMonikers.net7_0,
                8 => Instances.TargetFrameworkMonikers.net8_0,
                9 => Instances.TargetFrameworkMonikers.net9_0,
                _ => throw Instances.ExceptionOperator.From($"No target framework moniker available for .NET major version {version.Major}.")
            };

            return output;
        }

        /// <summary>
        /// Case-insensitive match.
        /// </summary>
        bool Equals(
            string targetFrameworkMoniker_A,
            string targetFrameworkMoniker_B)
            => Instances.StringOperator.Are_Equal_CaseInsensitive(
                targetFrameworkMoniker_A,
                targetFrameworkMoniker_B);

        /// <summary>
        /// Sometimes target framework monikers have trailing additional tokens (like "net8.0-windows").
        /// This method returns the tokenless "net8.0" moniker if the moniker has additional tokens.
        /// </summary>
        string Ensure_IsTokenless(string targetFrameworkMoniker)
        {
            var tokens = this.Get_Tokens(targetFrameworkMoniker);

            var output = tokens.First();
            return output;
        }

        /// <summary>
        /// The the target framework moniker a .NET standard target framework moniker? (e.g. "netstandard2.1")
        /// </summary>
        bool Is_Netstandard(string targetFrameworkMoniker)
        {
            // If the target framework moniker starts with "netstandard", it's .NET Standard.
            var output = Instances.StringOperator.Starts_With(
                targetFrameworkMoniker,
                Instances.TargetFrameworkMonikerTokens.netstandard);

            return output;
        }

        TargetFrameworkMonikerDescriptor Parse_ToDescriptor(
            string targetFrameworkMoniker,
            OverloadToken<NotNullOrEmpty> notNullOrEmptyToken)
        {
            var descriptor = new TargetFrameworkMonikerDescriptor();

            var tokens = this.Get_Tokens(targetFrameworkMoniker);

            var tokenCount = tokens.Length;

            // Note: must not be null or empty.
            descriptor.BaseToken = tokens.First();

            descriptor.Has_Version = Instances.StringOperator.Has_IndexOf_FirstDigitCharacter(
                descriptor.BaseToken,
                out var indexOfFirstDigitCharacter_OrNotFound_Base);

            if (descriptor.Has_Version)
            {
                descriptor.Base = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    indexOfFirstDigitCharacter_OrNotFound_Base,
                    descriptor.BaseToken);

                var versionToken = Instances.StringOperator.Get_Substring_From_Inclusive(
                    indexOfFirstDigitCharacter_OrNotFound_Base,
                    descriptor.BaseToken);

                // Does the version token need to be expanded? (e.g. net451 => 4.5.1)
                var needsExpansion = !Instances.StringOperator.Contains(
                    versionToken,
                    Instances.TokenSeparators.For_Version);

                var versionName = needsExpansion
                    ? Instances.StringOperator.Join(
                        Instances.TokenSeparators.For_Version,
                        versionToken.AsEnumerable())
                    : versionToken
                    ;

                descriptor.Version = Instances.VersionOperator.Parse(versionName);
            }
            else
            {
                descriptor.Base = descriptor.BaseToken;
                descriptor.Version = Instances.Versions.None;
            }

            descriptor.Has_OperatingSystemToken = tokenCount > 1;

            if (descriptor.Has_OperatingSystemToken)
            {
                // Note: must not be null or empty, not too short.
                descriptor.OperatingSystemToken = tokens.Second();

                descriptor.Has_OperatingSystemVersion = Instances.StringOperator.Has_IndexOf_FirstDigitCharacter(
                    descriptor.OperatingSystemToken,
                    out var indexOfFirstDigitCharacter_OrNotFound);

                if (descriptor.Has_OperatingSystemVersion)
                {
                    descriptor.OperatingSystem = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                        indexOfFirstDigitCharacter_OrNotFound,
                        descriptor.OperatingSystemToken);

                    var versionToken = Instances.StringOperator.Get_Substring_From_Inclusive(
                        indexOfFirstDigitCharacter_OrNotFound,
                        descriptor.OperatingSystemToken);

                    // Does the version token need to be expanded? (e.g. net451 => 4.5.1)
                    var needsExpansion = !Instances.StringOperator.Contains(
                        versionToken,
                        Instances.TokenSeparators.For_Version);

                    var versionName = needsExpansion
                        ? Instances.StringOperator.Join(
                            Instances.TokenSeparators.For_Version,
                            versionToken.AsEnumerable())
                        : versionToken
                        ;

                    descriptor.OperatingSystemVersion = Instances.VersionOperator.Parse(versionName);
                }
                else
                {
                    descriptor.OperatingSystem = descriptor.OperatingSystemToken;
                    descriptor.OperatingSystemVersion = Instances.Versions.None;
                }
            }

            return descriptor;
        }

        TargetFrameworkMonikerDescriptor Parse_ToDescriptor(
            string targetFrameworkMoniker,
            out OverloadToken<NotNullOrEmpty> notNullOrEmptyToken)
            => this.Parse_ToDescriptor(
                targetFrameworkMoniker,
                notNullOrEmptyToken);

        string[] Get_Tokens(string targetFrameworkMoniker)
        {
            var output = Instances.StringOperator.Split(
                Instances.TokenSeparators.For_TargetFrameworkMoniker,
                targetFrameworkMoniker);

            return output;
        }
    }
}
