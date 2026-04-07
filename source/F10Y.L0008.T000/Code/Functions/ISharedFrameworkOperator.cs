using System;

using F10Y.T0002;


namespace F10Y.L0008.T000
{
    [FunctionsMarker]
    public partial interface ISharedFrameworkOperator
    {
        bool Are_Equal_HandleNull(
            SharedFrameworkDescriptor a,
            SharedFrameworkDescriptor b)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(
                a,
                b,
                this.Are_Equal);

            return output;
        }

        bool Are_Equal(
            SharedFrameworkDescriptor a,
            SharedFrameworkDescriptor b)
        {
            var output = true
                && a.Name == b.Name
                && a.Version == b.Version
                ;

            return output;
        }

        int Compare_Name_ThenVersion(
            SharedFrameworkDescriptor x,
            SharedFrameworkDescriptor y)
        {
            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Name,
                Instances.StringOperator.Compare,
                out var comparison))
            {
                return comparison;
            }

            if (Instances.ComparisonOperator.Is_ComparisonDefinitive(
                x, y,
                x => x.Version,
                Instances.VersionOperator.Compare,
                out comparison))
            {
                return comparison;
            }

            // Else.
            return comparison;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Compare_Name_ThenVersion(SharedFrameworkDescriptor, SharedFrameworkDescriptor)"/> as the default.
        /// </remarks>
        int Compare(
            SharedFrameworkDescriptor x,
            SharedFrameworkDescriptor y)
            => this.Compare_Name_ThenVersion(x, y);

        string Get_SharedFramework_VersionString(Version version)
            => Instances.VersionOperator.To_String_Major_Minor_Build(version);

        int Get_HashCode(SharedFrameworkDescriptor sharedFrameworkDescriptor)
        {
            var output = Instances.HashCodeOperator.Combine(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version);

            return output;
        }

        string To_String(
            string sharedFrameworkName,
            string version)
            => $"{sharedFrameworkName}{Instances.TokenSeparators.For_SharedFramework}{version}";

        string To_String(
            string sharedFrameworkName,
            Version version)
        {
            var version_String = this.Get_SharedFramework_VersionString(version);

            var output = this.To_String(
                sharedFrameworkName,
                version_String);

            return output;
        }

        string To_String_DisallowNull(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => this.To_String(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version);

        string To_String_AllowNull(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => Instances.NullOperator.Is_Null(sharedFrameworkDescriptor)
            ? Instances.Texts.null_Bracketed
            : this.To_String(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version)
            ;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="To_String_DisallowNull(SharedFrameworkDescriptor)"/> as the default.
        /// </remarks>
        string To_String(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => this.To_String_DisallowNull(sharedFrameworkDescriptor);
    }
}
