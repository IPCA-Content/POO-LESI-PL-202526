//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>13-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace WpfAppDemo.Views.Enums
{
    /// <summary>
    /// Specifies the types of views available in the application.
    /// </summary>
    public enum ViewType
    {
        #region View Types

        /// <summary>
        /// Represents the login view.
        /// </summary>
        Login,

        /// <summary>
        /// Represents the main application view.
        /// </summary>
        Main,

        /// <summary>
        /// Represents the registry application view.
        /// </summary>
        Registry,

        /// <summary>
        /// Represents the create employee application view.
        /// </summary>
        EditEmployee,

        // TODO: Add more view types here as needed.

        #endregion
    }
}
