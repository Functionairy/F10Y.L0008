using System;

using F10Y.T0009;


namespace F10Y.L0008.T001
{
    [WithXMarker]
    public interface IWith_TargetFrameworkMoniker :
        IHas_TargetFrameworkMoniker
    {
        new string TargetFrameworkMoniker { get; set; }
    }
}
