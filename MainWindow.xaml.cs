using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace Radouham
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Clientele> lesClienteles = new List<Clientele>();
        List<Prospect> lesProspects = new List<Prospect>();
        List<Rendez_vous> lesRendezVous = new List<Rendez_vous>();
        List<Produit> lesProduits = new List<Produit>();
        List<Facturation> lesFacturations = new List<Facturation>();

        Bdd bdd;

        public MainWindow()
        {
            InitializeComponent();
            HideTableItems();
            bdd = new Bdd();
            Bdd.Initialize();

            CboType.Items.Add("Client");
            CboType.Items.Add("Prospect");
            CboNumCliRdv.ItemsSource = lesClienteles ;
            CboNumCliRdv.DisplayMemberPath = "Num";
            cboNomFact.ItemsSource = lesClienteles;
            cboNomFact.DisplayMemberPath = "Nom";

            lesClienteles.Add(new Clientele(1, "Jean", "Michel", "3 rue des Lilas", 0606060606,"Bourg-en-Bresse" , 01000));
            lesClienteles.Add(new Clientele(2, "Terrieur", "Alain", "15 rue Saint Antoine", 0607020809, "Bourg-en-Bresse", 01000));
            lesClienteles.Add(new Clientele(3, "Onyme", "Anne", "30 rue du blé", 0305060401, "Bourg-en-Bresse", 01000));

            lesProspects.Add(new Prospect(1, "Alex", "Terrieur", "33 rue Jean sans peur", 0603325148,"Dijon", 21000, "03/05/1999"));

            DtgClientele.ItemsSource = lesClienteles;
            DtgProspect.ItemsSource = lesProspects;
            DtgRdv.ItemsSource = lesRendezVous;
            DtgProd.ItemsSource = lesProduits;
            DtgFact.ItemsSource = lesFacturations;

            
        }

        #region identification
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;


            // Vérification des informations d'identification 
            if (username == "id" && password == "mdp")
            {
                MessageBox.Show("Connexion réussie !");
                ShowTableItems();

            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !");
            }
        }

        private void HideTableItems()
        {

            TabItemClientele.Visibility = Visibility.Hidden;
            TabItemProspect.Visibility = Visibility.Hidden;
            TabItemRendezvous.Visibility = Visibility.Hidden;
            TabItemProduits.Visibility = Visibility.Hidden;
            TabItemFacturation.Visibility = Visibility.Hidden;
        }
        private void ShowTableItems()
        {

            // Afficher les éléments après la connexion réussie
            TabItemClientele.Visibility = Visibility.Visible;
            TabItemProspect.Visibility = Visibility.Visible;
            TabItemRendezvous.Visibility = Visibility.Visible;
            TabItemProduits.Visibility = Visibility.Visible;
            TabItemFacturation.Visibility = Visibility.Visible;
        }
        #endregion

        #region Clientele
        private void btnAjCli_Click(object sender, RoutedEventArgs e)
        {
            /*lesClienteles.Add(new Clientele(Convert.ToInt32(txtNumCli.Text), txtNom.Text, txtPrenom.Text, txtMail.Text, Convert.ToInt32(txtDateNaiss.Text), txtVille.Text, Convert.ToInt32(txtCP.Text)));
            Clientele NewClientele = new Clientele();

            NewClientele.Num = Convert.ToInt32(txtNumCli.Text);
            NewClientele.Nom = txtNom.Text;
            NewClientele.Prenom = txtPrenom.Text;
            NewClientele.Mail = txtMail.Text;
            NewClientele.Tel = Convert.ToInt32(txtDateNaiss.Text);
            NewClientele.Ville = txtVille.Text;
            NewClientele.CP = Convert.ToInt32(txtCP.Text);
            

            Bdd.InsertClient(NewClientele.Nom,NewClientele.Prenom, NewClientele.Mail, NewClientele.Tel, NewClientele.Ville, NewClientele.CP);*/

            lesClienteles.Add(new Clientele(Convert.ToInt32(txtNumCli.Text), txtNom.Text, txtPrenom.Text, txtMail.Text, Convert.ToInt32(txtDateNaiss.Text), txtVille.Text, Convert.ToInt32(txtCP.Text)));
            DtgRdv.ItemsSource = null;
            DtgRdv.ItemsSource = lesRendezVous;
        }



        private void btnModifCli_Click(object sender, RoutedEventArgs e)
        {
            int index = DtgClientele.SelectedIndex;

            lesClienteles[index].Num = Convert.ToInt32(txtNumCli.Text);
            lesClienteles[index].Nom = txtNom.Text;
            lesClienteles[index].Prenom = txtPrenom.Text;
            lesClienteles[index].Mail = txtMail.Text;
            lesClienteles[index].Ville = txtVille.Text;
            lesClienteles[index].CP = Convert.ToInt32(txtCP.Text);
            lesClienteles[index].Tel = Convert.ToInt32(txtDateNaiss.Text);

            DtgClientele.Items.Refresh();
        }

        private void btnSupprCli_Click(object sender, RoutedEventArgs e)
        {
            lesClienteles.Remove((Clientele)DtgClientele.SelectedItem);
            DtgClientele.SelectedItem = 0;
            DtgClientele.Items.Refresh();
        }

        private void DtgClientele_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DtgClientele.SelectedItem != null)
            {
                Clientele selectedClientele = DtgClientele.SelectedItem as Clientele;
                txtNumCli.Text = Convert.ToString(selectedClientele.Num);
                txtNom.Text = selectedClientele.Nom;
                txtPrenom.Text = selectedClientele.Prenom;
                txtCP.Text = Convert.ToString(selectedClientele.CP);
                txtVille.Text = selectedClientele.Ville;
                txtMail.Text = selectedClientele.Mail;
                txtDateNaiss.Text = Convert.ToString(selectedClientele.Tel);
            }
        }
        #endregion

        #region Prospect
        private void btnProspect_Click(object sender, RoutedEventArgs e)
        {
            lesProspects.Add(new Prospect(Convert.ToInt32(txtNumPro.Text), txtNomPro.Text, txtPnomPro.Text, txtAdressePro.Text, Convert.ToInt32(txtTelPro.Text), txtVillePro.Text, Convert.ToInt32(txtCPPro.Text), txtDatePro.Text));
            DtgProspect.ItemsSource = null;
            DtgProspect.ItemsSource = lesProspects;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            Prospect selectedProspect = (Prospect)DtgProspect.SelectedItem;

            // Ajouter le prospect à la liste de la clientèle
            lesClienteles.Add(new Clientele(selectedProspect.Num, selectedProspect.Nom, selectedProspect.Prenom, selectedProspect.Adresse, selectedProspect.Tel, selectedProspect.Ville, selectedProspect.CP));

            // Supprimer le prospect de la liste des prospects
            lesProspects.Remove(selectedProspect);

            // Mettre à jour les DataGrids
            DtgClientele.ItemsSource = null;
            DtgClientele.ItemsSource = lesClienteles;

            DtgProspect.ItemsSource = null;
            DtgProspect.ItemsSource = lesProspects;
        }

        private void btnSupprPro_Click(object sender, RoutedEventArgs e)
        {
            lesProspects.Remove((Prospect)DtgProspect.SelectedItem);
            DtgProspect.SelectedItem = 0;
            DtgProspect.Items.Refresh();
        }

        private void DtgProspect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DtgProspect.SelectedItem != null)
            {
                Prospect selectedProspect = DtgProspect.SelectedItem as Prospect;
                txtNumCli.Text = Convert.ToString(selectedProspect.Num);
                txtNom.Text = selectedProspect.Nom;
                txtPrenom.Text = selectedProspect.Prenom;
                txtCP.Text = Convert.ToString(selectedProspect.CP);
                txtVille.Text = selectedProspect.Ville;
                txtMail.Text = selectedProspect.Adresse;
                txtDateNaiss.Text = Convert.ToString(selectedProspect.Tel);
            }
        }
        #endregion

        #region Rendez_Vous
        private void btnAjRdv_Click(object sender, RoutedEventArgs e)
        {
            lesRendezVous.Add(new Rendez_vous(Convert.ToString(CboType.SelectedItem), txtAdresseRdv.Text, txtVilleRdv.Text, txtHeureRdv.Text, txtDateRdv.Text));
            DtgRdv.ItemsSource = null;
            DtgRdv.ItemsSource = lesRendezVous;
        }

        private void btnModifRdv_Click(object sender, RoutedEventArgs e)
        {
            int index = DtgRdv.SelectedIndex;

            lesRendezVous[index].LaClientele = (Clientele)CboNumCliRdv.SelectedItem;
            lesRendezVous[index].Type = Convert.ToString(CboType.SelectedItem);
            lesRendezVous[index].Date = txtDateRdv.Text;
            lesRendezVous[index].Heure = txtHeureRdv.Text;
            lesRendezVous[index].Ville = txtVille.Text;
            lesRendezVous[index].Adresse = txtAdresseRdv.Text;

            DtgRdv.Items.Refresh();
        }

        private void btnSupprRdv_Click(object sender, RoutedEventArgs e)
        {
            lesRendezVous.Remove((Rendez_vous)DtgRdv.SelectedItem);
            DtgRdv.SelectedItem = 0;
            DtgRdv.Items.Refresh();
        }

        private void DtgRdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DtgRdv.SelectedItem != null)
            {
                Rendez_vous selectedRendezVous = DtgRdv.SelectedItem as Rendez_vous;
                CboNumCliRdv.SelectedItem = Convert.ToString(selectedRendezVous.LaClientele);
                CboType.SelectedItem = selectedRendezVous.Type;
                txtMail.Text = selectedRendezVous.Adresse;
                txtVille.Text = Convert.ToString(selectedRendezVous.Ville);
                txtHeureRdv.Text = selectedRendezVous.Heure;
                txtDateRdv.Text = selectedRendezVous.Date;
            }
        }
        #endregion

        #region Produit
        private void btnAjProd_Click(object sender, RoutedEventArgs e)
        {
            lesProduits.Add(new Produit(Convert.ToInt32(txtNumProd.Text), txtLib.Text, txtDesc.Text, Convert.ToInt32(txtPrix.Text)));
            DtgProd.ItemsSource = null;
            DtgProd.ItemsSource = lesProduits;
        }

        private void btnModifProd_Click(object sender, RoutedEventArgs e)
        {
            int index = DtgProd.SelectedIndex;

            lesProduits[index].Num = Convert.ToInt32(txtNumProd.Text);
            lesProduits[index].Libelle = txtLib.Text;
            lesProduits[index].Desc = txtDesc.Text;
            lesProduits[index].Prix = Convert.ToInt32(txtPrix.Text);

            DtgProd.Items.Refresh();
        }

        private void btnSupprProd_Click(object sender, RoutedEventArgs e)
        {
            lesProduits.Remove((Produit)DtgProd.SelectedItem);
            DtgProd.SelectedItem = 0;
            DtgProd.Items.Refresh();
        }

        private void DtgProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DtgProd.SelectedItem != null)
            {
                Produit selectedProduit = DtgProd.SelectedItem as Produit;
                txtNumProd.Text = Convert.ToString(selectedProduit.Num);
                txtLib.Text = selectedProduit.Libelle;
                txtDesc.Text = selectedProduit.Desc;
                txtPrix.Text = Convert.ToString(selectedProduit.Prix);
            }
        }
        #endregion

        #region Facturation
        private void btnAjFact_Click(object sender, RoutedEventArgs e)
        {
            lesFacturations.Add(new Facturation(Convert.ToInt32(txtNumFact.Text), (Clientele)cboNomFact.SelectedItem, (Produit)cboPrixFact.SelectedItem));
            DtgFact.ItemsSource = null;
            DtgFact.ItemsSource = lesFacturations;
        }

        private void btnModifFact_Click(object sender, RoutedEventArgs e)
        {
            int index = DtgFact.SelectedIndex;

            lesFacturations[index].Num = Convert.ToInt32(txtNumFact.Text);
            lesFacturations[index].LaClientele = (Clientele)cboNomFact.SelectedItem;
            lesFacturations[index].LeProduit = (Produit)cboPrixFact.SelectedItem;

            DtgFact.Items.Refresh();
        }

        private void btnSupprFact_Click(object sender, RoutedEventArgs e)
        {
            lesFacturations.Remove((Facturation)DtgFact.SelectedItem);
            DtgFact.SelectedItem = 0;
            DtgFact.Items.Refresh();
        }

        private void DtgFact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DtgFact.SelectedItem != null)
            {
                Facturation selectedFact = DtgFact.SelectedItem as Facturation;
                txtNumFact.Text = Convert.ToString(selectedFact.Num);
                cboNomFact.SelectedItem = Convert.ToString(selectedFact.LaClientele);
                cboPrixFact.SelectedItem = Convert.ToString(selectedFact.LeProduit);
            }
        }
        #endregion
        /*class Program
        {
            static void Main(string[] args)
            {
                // Initialiser la classe Bdd
                Bdd.Initialize();

                // Maintenant vous pouvez utiliser les méthodes de la classe Bdd ici

                // Exemple d'utilisation : Insérer un client
                Bdd.InsertClient("NomClient", "PrenomClient", "mail@example.com", 123456789, "Ville", 12345);

                // Exemple d'utilisation : Sélectionner tous les clients
                var clients = Bdd.SelectClient();
                foreach (var client in clients)
                {
                    Console.WriteLine($"Nom : {client.Nom}, Prénom : {client.Prenom}, Adresse : {client.Mail}");
                }

                // Exemple d'utilisation : Supprimer un client
                Bdd.DeleteClient(1);

                // Exemple d'utilisation : Fermer la connexion à la base de données
                // Notez que vous n'avez généralement pas besoin d'appeler cela explicitement,
                // car il est recommandé de laisser la connexion ouverte aussi longtemps que nécessaire.
                //Bdd.CloseConnection();
            }
        }*/

    }
}
