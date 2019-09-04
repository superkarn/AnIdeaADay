namespace AIAD.Library.Global
{
    public class AuthenticationConfigs
    {
        /// <summary>
        /// This is the application name used by DataProtection service.  All projects
        /// must use the same name so that the service can decrypt the data.
        /// </summary>
        public const string APPLICATION_NAME = "An Idea A Day";

        /// <summary>
        /// This is the name of the cookies to be used between all the projects.
        /// </summary>
        public const string COOKIE_NAME = "AIAD";

        /// <summary>
        /// Authentication Scheme is used to determine how a project authenticates the users.
        /// This should be set in Startup.cs of the project that offloads the authentication
        /// process, such as A3D.Web.  
        /// Since A3D.Authentication is the project that does the actual authentication,
        /// its Startup.cs does not need to specify this.
        /// </summary>
        public const string AUTHENTICATION_SCHEME = "Identity.Application";
    }
}
