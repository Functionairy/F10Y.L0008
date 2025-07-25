using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface ITargetFrameworkMonikers :
        Z000.ITargetFrameworkMonikers,
        Z0002.ITargetFrameworkMonikers
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Z000.ITargetFrameworkMonikers _Z000 => Z000.TargetFrameworkMonikers.Instance;

        [Ignore]
        public Z0002.ITargetFrameworkMonikers _Z0002 => Z0002.TargetFrameworkMonikers.Instance;

#pragma warning restore IDE1006 // Naming Styles



    }
}
