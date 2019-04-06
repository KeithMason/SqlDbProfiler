﻿// ----------------------------------------------------------------------
// <copyright file="Settings.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler.Properties
{
    //// This class allows you to handle specific events on the settings class:
    ////  The SettingChanging event is raised before a setting's value is changed.
    ////  The PropertyChanged event is raised after a setting's value is changed.
    ////  The SettingsLoaded event is raised after the setting values are loaded.
    ////  The SettingsSaving event is raised before the setting values are saved.

    /// <summary>
    /// Settings Class
    /// </summary>
    internal sealed partial class Settings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            //// // To add event handlers for saving and changing settings, uncomment the lines below:
            ////
            //// this.SettingChanging += this.SettingChangingEventHandler;
            ////
            //// this.SettingsSaving += this.SettingsSavingEventHandler;
            ////
        }

        /// <summary>
        /// Settings the changing event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Configuration.SettingChangingEventArgs"/> instance containing the event data.</param>
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            // Add code to handle the SettingChangingEvent event here.
        }

        /// <summary>
        /// Settings saving event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //// Add code to handle the SettingsSaving event here.
        }
    }
}