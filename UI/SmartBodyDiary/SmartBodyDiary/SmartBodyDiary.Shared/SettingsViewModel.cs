using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartBodyDiary
{
    [ObservableObject]
    public partial class SettingsViewModel
    {
        [ObservableProperty]
        private string _sample = "Settings Page";
    }
}