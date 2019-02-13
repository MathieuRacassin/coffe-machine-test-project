using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachineProject
{
    /// <summary>
    /// Provide a mail notifier 
    /// </summary>
    public interface IEmailNotifier
    {
        /// <summary>
        /// Notify missing drink via mail
        /// </summary>
        /// <param name="drink"></param>
        void NotifyMissingDrink(string drink);
    }
}
