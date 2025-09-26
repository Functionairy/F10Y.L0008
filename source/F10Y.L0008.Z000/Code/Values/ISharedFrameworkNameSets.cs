using System;

using F10Y.T0003;


namespace F10Y.L0008.Z000
{
    [ValuesMarker]
    public partial interface ISharedFrameworkNameSets
    {
#pragma warning disable IDE1006 // Naming Styles

        private static ISharedFrameworkNames _SharedFrameworkNames => SharedFrameworkNames.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// All shared frameworks.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note: there is a legacy non-App shared framework <see cref="ISharedFrameworkNames.Microsoft_AspNetCore_All"/>, that is <em>not</em> included.
        /// For that, see <see cref="All_IncludingAspNetCore_All"/>.
        /// </para>
        /// <para>
        /// This set is actual the <see cref="All_Apps"/> set.
        /// </para>
        /// <para>
        /// Yes, it is preposterous that not <em>all</em> shared frameworks are included in this set. I am sorry.
        /// But the set of all App shared frameworks is more useful than the actual set of all shared frameworks.
        /// </para>
        /// </remarks>
        string[] All => this.All_Apps;

        /// <summary>
        /// All App shared frameworks:
        /// <list type="number">
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_AspNetCore_App" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_NETCore_App" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_WindowsDesktop_App" path="descendant::value"/></item>
        /// </list>
        /// </summary>
        string[] All_Apps => new[]
        {
            _SharedFrameworkNames.Microsoft_AspNetCore_App,
            _SharedFrameworkNames.Microsoft_NETCore_App,
            _SharedFrameworkNames.Microsoft_WindowsDesktop_App
        };

        /// <summary>
        /// The <em>actual</em> set of all shared frameworks:
        /// <list type="number">
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_AspNetCore_All" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_AspNetCore_App" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_NETCore_App" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ISharedFrameworkNames.Microsoft_WindowsDesktop_App" path="descendant::value"/></item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// This set is less useful than the <see cref="All_Apps"/> set, since it includes the legacy non-App shared framework <see cref="ISharedFrameworkNames.Microsoft_AspNetCore_All"/>.
        /// </remarks>
        string[] All_IncludingAspNetCore_All => new[]
        {
            _SharedFrameworkNames.Microsoft_AspNetCore_All,
            _SharedFrameworkNames.Microsoft_AspNetCore_App,
            _SharedFrameworkNames.Microsoft_NETCore_App,
            _SharedFrameworkNames.Microsoft_WindowsDesktop_App
        };
    }
}
