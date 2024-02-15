using projet_sgbd.couches_access_db;
using sgbd_wpf.vue_modele;
using System;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            this.DataContext = new sgbd_wpf.vue_modele.GestionInscriptionVueModele();
        }



        /**private void Effectuer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GestionInscriptionVueModele
                    vm = (GestionInscriptionVueModele)this.DataContext;
                string resultat = vm.EffectuerAction(GrilleInscris.SelectedIndex);
                MessageBox.Show(resultat);
            }

            catch (ExceptionAccessBD err)
            {
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GestionInscriptionVueModele vm =
                    (GestionInscriptionVueModele)this.DataContext;
                int index = GrilleInscris.SelectedIndex;
                if (index < 0)
                {
                    MessageBox.Show("Sélectionner une ligne à modifier.");
                    return;
                }
                vm.Modifier(index);
            }

            catch (ExceptionAccessBD err)
            {
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }**/
    }
}
