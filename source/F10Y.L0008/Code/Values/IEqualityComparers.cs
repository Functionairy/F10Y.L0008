using System;

using F10Y.T0003;


namespace F10Y.L0008
{
    [ValuesMarker]
    public partial interface IEqualityComparers
    {
        /// <summary>
        /// Compares assembly files based on their file name.
        /// </summary>
        For_MethodBasedEqualityComparer.MethodBasedEqualityComparer<string> For_AssemblyFilePaths => new(
            (a, b) =>
            {
                var fileNameA = Instances.PathOperator.Get_FileName(a);
                var fileNameB = Instances.PathOperator.Get_FileName(b);

                var output = fileNameA == fileNameB;
                return output;
            },
            filePath =>
            {
                var fileName = Instances.PathOperator.Get_FileName(filePath);

                var output = fileName.GetHashCode();
                return output;
            });
    }
}
