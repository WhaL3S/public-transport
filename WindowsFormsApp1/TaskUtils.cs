using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Class to do the tasks
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Find the length of selected route
        /// </summary>
        /// <param name="Routes1">First list of routes</param>
        /// <param name="Routes2">Second list of routes</param>
        /// <param name="routeName">Route which length is searched</param>
        /// <returns></returns>
        public static int LengthOfRoute(List<Route> Routes1, List<Route> Routes2, string routeName)
        {
            int result = 0;
            for (int i = 0; i < Routes1.Count; i++)
                if (Routes1[i].name == routeName)
                    result = Routes1[i].length;
            for (int i = 0; i < Routes2.Count; i++)
                if (Routes2[i].name == routeName)
                    result = Routes2[i].length;
            return result;
        }

        /// <summary>
        /// Finds and adds routes which undergo conditions of length
        /// </summary>
        /// <param name="Routes">Dynamic array of routes</param>
        /// <param name="ResultRoutes">Resulting array of routes</param>
        /// <param name="a">Lowest value of the interval for length</param>
        /// <param name="b">Highest value of the interval for length</param>
        public static void RoutesWithinInterval(List<Route> Routes, List<Route> ResultRoutes, int a, int b)
        {
            for (int i = 0; i < Routes.Count; i++)
            {
                Route r = Routes[i];
                if (r.length <= b && r.length >= a)
                {
                    Route newR = new Route(r.number, r.name, r.length, r.stopsNumber, r.startTime, r.endTime);
                    if (ResultRoutes.Contains(newR) == false)
                    {
                        ResultRoutes.Add(newR);
                    }
                }
            }
            Checker(ResultRoutes, a, b);
        }

        /// <summary>
        /// Checks if there is any route which doesn't undergo length conditions
        /// </summary>
        /// <param name="ResultRoutes">Resulting array of routes</param>
        /// <param name="a">Lowest value of the interval for length</param>
        /// <param name="b">Highest value of the interval for length</param>
        private static void Checker(List<Route> ResultRoutes, int a, int b)
        {
            for (int i = 0; i < ResultRoutes.Count; i++)
            {
                Route r = ResultRoutes[i];
                if (r.length > b || r.length < a)
                {
                    ResultRoutes.Remove(r);
                }
            }
        }

        /// <summary>
        /// Removes routes with specified symbol in their names
        /// </summary>
        /// <param name="ResultContainer">Resulting array of routes</param>
        /// <param name="symbol">words that include this symbol will be removed</param>
        public static void Remover(List<Route> ResultRoutes, char symbol)
        {
            for (int i = 0; i < ResultRoutes.Count; i++)
            {
                Route r = ResultRoutes[i];
                foreach (char s in r.name)
                {
                    if (char.ToLower(s) == char.ToLower(symbol))
                    {
                        ResultRoutes.Remove(r);
                        i = i - 1;
                    }
                }
            }
        }

        /// <summary>
        /// Inserts dadta from the array to the specified array within keeping everything sorted
        /// </summary>
        /// <param name="ResultRoutes">Resulting array of routes</param>
        /// <param name="RoutesToInsert">Array of routes to insert into resulting array</param>
        public static void InsertAll(List<Route> ResultRoutes, List<Route> RoutesToInsert)
        {
            for(int i = 0; i < RoutesToInsert.Count; i++)
            {
                Route routeToInsert = RoutesToInsert[i];
                int j;
                for(j = 0; (j < ResultRoutes.Count) && (ResultRoutes[j].CompareTo(routeToInsert) < 0); j++) { }
                ResultRoutes.Insert(j, routeToInsert);
            }
        }

    }
}
