using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using MySql.Data.MySqlClient;


namespace Radouham
{
    public class Bdd
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        
        public static void Initialize()
        {
            server = "localhost";
            database = "laravele";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

  

        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Erreur connexion BDD");
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #region Insert
        public static void InsertClient(string nom, string prenom, string mail, int tel, string ville, int cp)
        {
            //Requête Insertion Magazine
            string query = "INSERT INTO client (NomCli, PrenomCli, MailCli, TelCli, VilleCli, CPCli) VALUES('" + nom + "','" + prenom + "','" + mail + "','" + tel + "','" + ville + "','" + cp + "')";
            MessageBox.Show(Convert.ToString(query));

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }

        }
        public static void InsertRDV(string type, string nom, string prenom, string adresse, string ville, DateTime date, DateTime heure)
        {
            //Requête Insertion Pigiste
            string query = "INSERT INTO rdv (Type, Nom, Prenom, Adresse, Ville, Date, Heure) VALUES('" + type + "','" + nom + "','" + prenom + "','" + adresse + "','" + ville + "','" + date + "','" + heure + ")";
            Console.WriteLine(query);

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void InsertProduit(string nomprod, int prixprod, string descprod)
        {
            //Requête Insertion Pigiste
            string query = "INSERT INTO produit (NomProd, PrixProd, DescProd) VALUES('" + nomprod + "','" + prixprod + "','" + descprod + ")";
            Console.WriteLine(query);

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }

        public static void InsertCommande(DateTime date, int prixtot)
        {
            //Requête Insertion Pigiste
            string query = "INSERT INTO commande (DateCo, PrixProd, DescProd) VALUES('" + date + "','" + prixtot + ")";
            Console.WriteLine(query);

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }

        public static void InsertProspect( string nom, string prenom, DateTime datenaiss, string ville, string adresse, int cp)
        {
            //Requête Insertion Pigiste
            string query = "INSERT INTO prospect (NomPros, PrenomPros, DateNaiss, Ville, Adresse, CP) VALUES('" + nom + "','" + prenom + "','" + datenaiss + "','" + ville + "','" + adresse + "','" + cp + ")";
            Console.WriteLine(query);

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        #endregion

        #region Update
        public static void UpdateClient(int idcli, string nom, string prenom, string mail, int tel, string ville, int cp)
        {
            //Update Magazine
            string query = "UPDATE Client SET DateSortieMagazine='" + nom + "', DatePaiementMagazine='" + prenom + "', DatePaiementMagazine='" + mail + "', DatePaiementMagazine='" + tel + "', DatePaiementMagazine='" + tel + "', BudgetMagazine = " + cp + " WHERE NumMagazine=" + idcli;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void UpdateRDV(string type, string nom, string prenom, string adresse, string ville, DateTime date, DateTime heure)
        {
            //Update Pigiste
            string query = "UPDATE rdv SET TypeRDV='" + type + "', NomRDV='" + nom + "', PrenomRDV='" + prenom + "', AdresseRDV ='" + adresse + "', VilleRDV='" + ville + "', DateRDV='" + date + "', HeureRDV='" + heure;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void UpdateProduit(int idprod, string nomprod, int prixprod, string descprod)
        {
            //Update Pigiste
            string query = "UPDATE Produit SET NomProd='" + nomprod + "', PrixProd='" + prixprod + "', DescProd='" + descprod + "WHERE IdProd=" + idprod;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }

        public static void UpdateCommande(int idco, DateTime date, int prixtot)
        {
            //Update Pigiste
            string query = "UPDATE Commande SET Date='" + date + "', PrixTot='" + prixtot + "WHERE IdCo=" + idco;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }

        public static void UpdateProspect(int idpro, string nom, string prenom, DateTime datenaiss, string ville, string adresse, int cp)
        {
            //Update Magazine
            string query = "UPDATE Prospect SET Nom='" + nom + "', Prenom='" + prenom + "', DateNaiss='" + datenaiss + "', Ville='" + ville + "', Adresse='" + adresse + "', CP = " + cp + " WHERE IdPro=" + idpro;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        #endregion

        #region delete
        public static void DeleteClient(int idCli)
        {
            //Delete Magazine
            string query = "DELETE FROM Client WHERE NumCli=" + idCli;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }
        public static void DeleteRdv(int numRdv)
        {
            //Delete Pigiste
            string query = "DELETE FROM rdv WHERE NumRDV" + numRdv;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }
        public static void DeleteProduit(int idProd)
        {
            //Delete Pigiste
            string query = "DELETE FROM Produit WHERE NumProduit" + idProd;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }

        public static void DeleteCommande(int idCo)
        {
            //Delete Pigiste
            string query = "DELETE FROM Commande WHERE NumCo" + idCo;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }

        public static void DeleteProspect(int idPro)
        {
            //Delete Pigiste
            string query = "DELETE FROM Prospect WHERE NumProspect" + idPro;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }
        #endregion

        public static List<Clientele> SelectClient()
        {
            //Select statement
            string query = "SELECT * FROM Client";

            //Create a list to store the result
            List<Clientele> dbClient = new List<Clientele>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Clientele leClient = new Clientele(Convert.ToInt16(dataReader["NumClient"]), Convert.ToString(dataReader["NomClient"]), Convert.ToString(dataReader["PrenomClient"]), Convert.ToString(dataReader["Adresse"]), Convert.ToInt16(dataReader["Tel"]), Convert.ToString(dataReader["Ville"]), Convert.ToInt16(dataReader["CP"]));
                    dbClient.Add(leClient);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbClient;
            }
            else
            {
                return dbClient;
            }
        }
        public static List<Rendez_vous> SelectRDV()
        {
            //Select statement
            string query = "SELECT * FROM rdv";

            //Create a list to store the result
            List<Rendez_vous> dbRDV = new List<Rendez_vous>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Rendez_vous leRDV = new Rendez_vous(Convert.ToString(dataReader["Type"]), Convert.ToString(dataReader["Adresse"]), Convert.ToString(dataReader["Ville"]), Convert.ToString(dataReader["Date"]), Convert.ToString(dataReader["Heure"]));
                    dbRDV.Add(leRDV);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbRDV;
            }
            else
            {
                return dbRDV;
            }
        }
        public static List<Produit> SelectProduit()
        {
            //Select statement
            string query = "SELECT * FROM produit";

            //Create a list to store the result
            List<Produit> dbProduit = new List<Produit>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Produit leProduit = new Produit(Convert.ToInt16(dataReader["NumProduit"]), Convert.ToString(dataReader["LibelleProduit"]), Convert.ToString(dataReader["DescProd"]), Convert.ToInt16(dataReader["PrixProd"]));
                    dbProduit.Add(leProduit);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbProduit;
            }
            else
            {
                return dbProduit;
            }
        }

        public static List<Facturation> SelectCommande()
        {
            //Select statement
            string query = "SELECT * FROM commande";

            //Create a list to store the result
            List<Facturation> dbCommande = new List<Facturation>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    int numFact = Convert.ToInt16(dataReader["NumFact"]);
                    int numClient = Convert.ToInt16(dataReader["NumClient"]);
                    int numProduit = Convert.ToInt16(dataReader["NumProduit"]);

                    // Récupérer les instances correctes de Clientele et Produit
                    Clientele client = GetClient(numClient);
                    Produit produit = GetProduit(numProduit);

                    // Créer l'objet Facturation avec les instances récupérées
                    Facturation laCommande = new Facturation(numFact, client, produit);
                    dbCommande.Add(laCommande);

                    //Facturation laCommande = new Facturation(Convert.ToInt16(dataReader["NumFact"]), Convert.ToInt16(dataReader["NumClient"]), Convert.ToInt16(dataReader["NumProduit"]));
                    //dbCommande.Add(laCommande);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbCommande;
            }
            else
            {
                return dbCommande;
            }
        }

        public static List<Prospect> SelectProspect()
        {
            //Select statement
            string query = "SELECT * FROM prospect";

            //Create a list to store the result
            List<Prospect> dbProspect = new List<Prospect>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Prospect leProspect = new Prospect(Convert.ToInt16(dataReader["NumProspect"]), Convert.ToString(dataReader["NomProspect"]), Convert.ToString(dataReader["PrenomProspect"]), Convert.ToString(dataReader["AdresseProspect"]), Convert.ToInt32(dataReader["TelProspect"]), Convert.ToString(dataReader["VilleProspect"]), Convert.ToInt16(dataReader["CPProspect"]), Convert.ToString(dataReader["NaissProspect"]));
                    dbProspect.Add(leProspect);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbProspect;
            }
            else
            {
                return dbProspect;
            }
        }

        public static Clientele SearchClient(int numC)
        {
            //Select statement
            string query = "SELECT * FROM client WHERE NumClient = " + numC;

            //Create a list to store the result
            List<Clientele> dbClient = new List<Clientele>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Clientele leClient = new Clientele(Convert.ToInt16(dataReaderS["NumClient"]), Convert.ToString(dataReaderS["NomClient"]), Convert.ToString(dataReaderS["PrenomClient"]), Convert.ToString(dataReaderS["Adresse"]), Convert.ToInt16(dataReaderS["TelClient"]) ,Convert.ToString(dataReaderS["Ville"]), Convert.ToInt16(dataReaderS["CP"]));
                dbClient.Add(leClient);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbClient[0];


        }
        public static Rendez_vous SearchRDV(int numRDV)
        {
            //Select statement
            string query = "SELECT * FROM rdv WHERE NumRDV = " + numRDV;

            //Create a list to store the result
            List<Rendez_vous> dbRDV = new List<Rendez_vous>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Rendez_vous leRDV = new Rendez_vous(Convert.ToString(dataReaderS["Type"]), Convert.ToString(dataReaderS["Adresse"]), Convert.ToString(dataReaderS["Ville"]), Convert.ToString(dataReaderS["Date"]), Convert.ToString(dataReaderS["Heure"]));
                dbRDV.Add(leRDV);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbRDV[0];

        }

        public static Produit SearchProduit(int numProd)
        {
            //Select statement
            string query = "SELECT * FROM produit WHERE NumProd = " + numProd;

            //Create a list to store the result
            List<Produit> dbProduit = new List<Produit>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Produit leContrats = new Produit(Convert.ToInt16(dataReaderS["NumProduit"]), Convert.ToString(dataReaderS["LibelleProduit"]), Convert.ToString(dataReaderS["DescProd"]), Convert.ToInt16(dataReaderS["PrixProd"]));
                dbProduit.Add(leContrats);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbProduit[0];
        }

        public static Facturation SearchCommande(int numCo)
        {
            //Select statement
            string query = "SELECT * FROM commande WHERE NumCo = " + numCo;

            //Create a list to store the result
            List<Facturation> dbCommande = new List<Facturation>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                int numFact = Convert.ToInt16(dataReaderS["NumFact"]);
                int numClient = Convert.ToInt16(dataReaderS["NumClient"]);
                int numProduit = Convert.ToInt16(dataReaderS["NumProduit"]);

                // Récupérer les instances correctes de Clientele et Produit
                Clientele client = GetClient(numClient);
                Produit produit = GetProduit(numProduit);

                Facturation laCommande = new Facturation(numFact, client, produit);
                dbCommande.Add(laCommande);

                //Facturation laCommande = new Facturation(Convert.ToInt16(dataReaderS["NumFact"]), Convert.ToInt16(dataReaderS["NumClient"]), Convert.ToInt16(dataReaderS["NumProduit"]));
                //dbCommande.Add(laCommande);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbCommande[0];
        }

        public static Prospect SearchProspect(int numPro)
        {
            //Select statement
            string query = "SELECT * FROM prospect WHERE NumPro = " + numPro;

            //Create a list to store the result
            List<Prospect> dbCommande = new List<Prospect>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Prospect leProspect = new Prospect(Convert.ToInt16(dataReaderS["NumProspect"]), Convert.ToString(dataReaderS["NomProspect"]), Convert.ToString(dataReaderS["PrenomProspect"]), Convert.ToString(dataReaderS["AdresseProspect"]), Convert.ToInt32(dataReaderS["TelProspect"]), Convert.ToString(dataReaderS["VilleProspect"]), Convert.ToInt16(dataReaderS["CPProspect"]), Convert.ToString(dataReaderS["NaissProspect"]));
                dbCommande.Add(leProspect);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbCommande[0];
        }

        private static Produit GetProduit(int numProduit)
        {
            Produit produit = null;

            // Requête SQL pour sélectionner les informations du produit
            string query = "SELECT * FROM produit WHERE NumProduit = @NumProduit";

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NumProduit", numProduit);

                MySqlDataReader reader = cmd.ExecuteReader();

                // Si des données sont disponibles, créez une instance de Produit
                if (reader.Read())
                {
                    produit = new Produit(
                        Convert.ToInt16(reader["NumProduit"]),
                        Convert.ToString(reader["LibelleProduit"]),
                        Convert.ToString(reader["DescProduit"]),
                        Convert.ToInt16(reader["PrixProduit"])
                    );
                }

                reader.Close();
                Bdd.CloseConnection();
            }

            return produit;
        }

        private static Clientele GetClient(int numClient)
        {
            Clientele client = null;

            // Requête SQL pour sélectionner les informations du client
            string query = "SELECT * FROM clientele WHERE NumClient = @NumClient";

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NumClient", numClient);

                MySqlDataReader reader = cmd.ExecuteReader();

                // Si des données sont disponibles, créez une instance de Clientele
                if (reader.Read())
                {
                    client = new Clientele(
                        Convert.ToInt32(reader["NumClient"]),
                        Convert.ToString(reader["NomClient"]),
                        Convert.ToString(reader["PrenomClient"]),
                        Convert.ToString(reader["AdresseClient"]),
                        Convert.ToInt16(reader["NaissClient"]),
                        Convert.ToString(reader["VilleClient"]),
                        Convert.ToInt16(reader["CPClient"])

                    );
                }

                reader.Close();
                Bdd.CloseConnection();
            }

            return client;
        }
    }
}