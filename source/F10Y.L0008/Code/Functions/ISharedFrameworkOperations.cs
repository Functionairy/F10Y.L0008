using System;

using F10Y.T0002;


namespace F10Y.L0008
{
    [FunctionsMarker]
    public partial interface ISharedFrameworkOperations
    {
        Func<SharedFrameworkDescriptor, bool> Is_Named(string name)
            => sharedFramwork => sharedFramwork.Name == name;
    }
}
