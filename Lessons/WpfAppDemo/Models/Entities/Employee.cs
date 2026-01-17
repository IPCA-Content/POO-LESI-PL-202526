//-----------------------------------------------------------------
//    <copyright file="Helper.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>17-11-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace WpfAppDemo.ViewModels.Models
{
    /// <summary>
    /// Represents an employee entity used inside the WPF application.
    /// This class is CLS compliant and supports UI binding through INotifyPropertyChanged.
    /// </summary>
    [CLSCompliant(true)]
    public class Employee
    {
        #region Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDay { get; set; }
        #endregion 
    }
}
