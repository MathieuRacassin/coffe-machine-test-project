using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachineProject
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBeverageQuantityChecker
    {
        /// <summary>
        /// Check if the drink level is Empty
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        bool IsEmpty(string drink);
    }
}
