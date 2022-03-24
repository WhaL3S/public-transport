using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Class to store data for single route
    /// </summary>
    public class Route : IComparable<Route>, IEquatable<Route>
    {
        // Auto-Properties
        public int number { get; set; }
        public string name { get; set; }
        public int length { get; set; }
        public int stopsNumber { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="number">Route number (int)</param>
        /// <param name="name">Route name (string)</param>
        /// <param name="length">Route length (int)</param>
        /// <param name="stopsNumber">Number of stops (int)</param>
        /// <param name="startTime">Route starting time (TimeSpan)</param>
        /// <param name="endTime">Route ending time (TimeSpan)</param>
        public Route(int number, string name, int length, int stopsNumber, TimeSpan startTime, TimeSpan endTime)
        {
            this.number = number;
            this.name = name;
            this.length = length;
            this.stopsNumber = stopsNumber;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        // Overridden method GetHashCode()
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        // Overridden method Equals(), check object equality
        public override bool Equals(object obj)
        {
            return Equals(obj as Route);
        }

        public bool Equals(Route other)
        {
            return this.name.Trim() == other.name.Trim();
        }

        /// <summary>
        /// Route comparison method
        /// </summary>
        /// <param name="other">Another route to be compared with</param>
        /// <returns>1 if stops number is greater than stops number of other route
        /// -1 if stops number is less than stops number of other route
        /// if the number of stops are equal the names are compared and sorted alphabetically
        /// 0 otherwise</returns>
        public int CompareTo(Route other)
        {
            int p = string.Compare(this.name, other.name, StringComparison.CurrentCulture);
            if (this.stopsNumber > other.stopsNumber)
                return 1;
            else if (this.stopsNumber < other.stopsNumber)
                return -1;
            else if (this.stopsNumber == other.stopsNumber && p < 0)
                return -1;
            return 0;
        }

        /// <summary>
        /// Method for creating a string output from class properties
        /// </summary>
        /// <returns>number, name, length, stopsNumber, startTime and endTime properties concatenated to snigle string</returns>
        public override string ToString()
        {
            return string.Format("{0,4:d2}  {1,-10}  {2,8:d2} {3,8:d2} {4,15} {5,15}", 
                 number, name, length, stopsNumber, startTime, endTime);
        }
    }
}
