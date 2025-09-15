using System;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface ISharedFrameworkOperator
    {
        public bool Are_Equal_HandleNull(
            SharedFrameworkDescriptor a,
            SharedFrameworkDescriptor b)
        {
            var output = Instances.NullOperator.NullCheckDeterminesEquality_Else(
                a,
                b,
                this.Are_Equal);

            return output;
        }

        public bool Are_Equal(
            SharedFrameworkDescriptor a,
            SharedFrameworkDescriptor b)
        {
            var output = true
                && a.Name == b.Name
                && a.Version == b.Version
                ;

            return output;
        }

        public int Get_HashCode(SharedFrameworkDescriptor sharedFrameworkDescriptor)
        {
            var output = Instances.HashCodeOperator.Combine(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version);

            return output;
        }

        public string Get_SharedFramework_VersionString(Version version)
            => Instances.VersionOperator.To_String_Major_Minor_Build(version);

        public string To_String(
            string sharedFrameworkName,
            string version)
            => $"{sharedFrameworkName}{Instances.TokenSeparators.For_SharedFramework}{version}";

        public string To_String(
            string sharedFrameworkName,
            Version version)
        {
            var version_String = this.Get_SharedFramework_VersionString(version);

            var output = this.To_String(
                sharedFrameworkName,
                version_String);

            return output;
        }

        public string To_String(SharedFrameworkDescriptor sharedFrameworkDescriptor)
            => this.To_String(
                sharedFrameworkDescriptor.Name,
                sharedFrameworkDescriptor.Version);
    }
}
