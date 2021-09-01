using System.Collections.Generic;

namespace GeometricLayout.Data
{
    /// <summary>
    /// Data class to hold data of GeometricLayout.
    /// </summary>
    public static class GeometriesDataHandler
    {
        public static int MaxSupportedColumn = 12;

        public static int MinSupportedColumn = 1;

        /// <summary>
        /// Dictionary to hold Row and Column map.
        /// </summary>
        public static Dictionary<string, int> RowVsXAxisMap = new Dictionary<string, int>()
        {
            {"a", 5},
            {"b", 4},
            {"c", 3},
            {"d", 2},
            {"e", 1},
            {"f", 0},
        };

    }
}
