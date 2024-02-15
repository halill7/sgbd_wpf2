﻿using System;
using System.Collections.Generic;
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

namespace Page_Navigation_App.View
{
    /// <summary>
    /// Interaction logic for Shipments.xaml
    /// </summary>
    public partial class Shipments : UserControl
    {
        public Shipments()
        {
            InitializeComponent();
            this.DataContext = new sgbd_wpf.vue_modele.GestionSeanceVueModele();
        }
    }
}
