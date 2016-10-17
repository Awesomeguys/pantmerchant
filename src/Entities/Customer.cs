using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;
using System.IO;

namespace PantMerchant
{
    /// <summary>
    /// Concrete customer class
    /// </summary>
    public class Customer : Person
    {

        /// <summary>
        /// Initialises a new instance of Person with 
        /// the given name at the given position.
        /// </summary>
        /// <param name="Name">Name of the person. eg "John Smith"</param>
        /// <param name="position">Grid position the person currently occupies</param>
        public Customer(string Name, Point2D position) 
            : base(Name, position, Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\pantmerchant\\sprites\\customer\\")
        { }
    }
}