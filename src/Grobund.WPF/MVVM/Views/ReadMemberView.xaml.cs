﻿using Grobund.Data.Models;
using Grobund.DataAccess.Repositories;
using Grobund.WPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Grobund.WPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ReadMemberView.xaml
    /// </summary>
    public partial class ReadMemberView : UserControl
    {

        public ReadMemberView()
        {
            InitializeComponent();
        }
    }
}
