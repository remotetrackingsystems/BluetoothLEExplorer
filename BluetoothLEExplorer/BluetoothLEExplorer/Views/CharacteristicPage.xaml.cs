// <copyright file="CharacteristicPage.xaml.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------
using BluetoothLEExplorer.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BluetoothLEExplorer.ViewModels;


public static class Global
{
    public static bool clearFlag = false;
    public static bool configFlag = false;
}

namespace BluetoothLEExplorer.Views
{
    /// <summary>
    /// Characteristic Page
    /// </summary>
    /// 




    public sealed partial class CharacteristicPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacteristicPage" /> class.
        /// </summary>
        /// 



        public CharacteristicPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            _console.Text = "";



        }
        
        
        
        private void Clear_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
            _console.Text = "";
            Global.clearFlag = true;
            
        }

        /*
        private void Config_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Global.configFlag = true;

        }
        */
        

        private void WriteValue_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            WriteBoxBackgroundCheck();
        }

        private void radioButton5_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            WriteBoxBackgroundCheck();
        }

        private void radioButton5_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            WriteBoxBackgroundCheck();
        }

        private void WriteBoxBackgroundCheck()
        {
            if (ViewModel.WriteType == ViewModels.CharacteristicPageViewModel.WriteTypes.Hex)
            {
                int buf;
                if (string.IsNullOrWhiteSpace(WriteValue.Text) == false)
                {
                    for(int i = 0; i < WriteValue.Text.Length; i++)
                    {
                        if(int.TryParse(WriteValue.Text[i].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier, null, out buf) == false)
                        {
                            WriteValue.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                            return;
                        }
                    }
                }
            }

            WriteValue.Background = new SolidColorBrush(Windows.UI.Colors.White);
        }
		
        private void DescriptorsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedDescriptor = (ObservableGattDescriptors)e.ClickedItem;
        }

        


    }
}
