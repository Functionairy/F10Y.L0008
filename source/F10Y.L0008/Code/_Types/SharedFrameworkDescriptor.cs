using System;

using F10Y.T0004;


namespace F10Y.L0008
{
    /// <summary>
    /// Describes a shared framework (like "Microsoft.NETCore.App", version 8.0.0, that lives in a directory like "C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App\5.0.17\").
    /// </summary>
    /// <remarks>
    /// There is another type called a runtime target descriptor, but while similar, the form of a runtime target descriptor is different: ".NETCoreApp,Version=v8.0".
    /// It contains a runtime target name instead of a shared framework name.
    /// </remarks>
    [DataTypeMarker]
    public class SharedFrameworkDescriptor : IEquatable<SharedFrameworkDescriptor>
    {
        /// <summary>
        /// Values like "Microsoft.NETCore.App", see <see cref="Z000.ISharedFrameworkNames"/>.
        /// </summary>
        public string Name { get; set; }

        public Version Version { get; set; }


        public SharedFrameworkDescriptor()
        {
            // Do nothin.
        }

        public SharedFrameworkDescriptor(
            string name,
            Version version)
        {
            this.Name = name;
            this.Version = version;
        }

        public bool Equals(SharedFrameworkDescriptor other)
            => Instances.SharedFrameworkOperator.Are_Equal_HandleNull(
                this,
                other);

        public override string ToString()
            => Instances.SharedFrameworkOperator.To_String(this);

        public override bool Equals(object obj)
            => this.Equals(obj as SharedFrameworkDescriptor);

        public override int GetHashCode()
            => Instances.SharedFrameworkOperator.Get_HashCode(this);
    }
}


namespace F10Y.L0008.N001
{
    [DataTypeMarker]
    public class SharedFrameworkDescriptor
    {
        /// <summary>
        /// Values like "Microsoft.NETCore.App", see <see cref="Z000.ISharedFrameworkNames"/>.
        /// </summary>
        public string Name { get; set; }

        public string Version { get; set; }


        public SharedFrameworkDescriptor()
        {
            // Do nothin.
        }

        public SharedFrameworkDescriptor(
            string name,
            string version)
        {
            this.Name = name;
            this.Version = version;
        }
    }
}