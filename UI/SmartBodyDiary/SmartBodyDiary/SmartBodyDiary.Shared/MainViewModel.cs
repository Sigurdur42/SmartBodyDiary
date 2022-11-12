using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartBodyDiary
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _selectedPageName = "";
    }
}