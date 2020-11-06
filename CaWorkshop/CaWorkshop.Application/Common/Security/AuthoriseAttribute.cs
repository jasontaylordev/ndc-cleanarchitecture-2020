using System;

namespace CaWorkshop.Application.Common.Security
{
    /// <summary>
    /// Specifies the class this attribute is applied to requires authorization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthoriseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeAttribute"/> class. 
        /// </summary>
        public AuthoriseAttribute() { }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
        /// </summary>
        public string Roles { get; set; }
    }
}