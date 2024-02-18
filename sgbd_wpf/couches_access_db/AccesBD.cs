using Npgsql;
using projet_sgbd.couches_metier;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace projet_sgbd.couches_access_db
{
    class AccesBD
    {
        private NpgsqlConnection SqlConn;



        public AccesBD()
        {
            try
            {
                this.SqlConn = new NpgsqlConnection("Server=localhost; Port=5432; Database=sgbd; User ID=postgres; Password =password");
                this.SqlConn.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionAccessBD("Connexion à la base de données", e);
            }   
            
        }


        public void FermerConnexion(NpgsqlConnection connexion)
        {
            try
            {
                if (connexion != null && connexion.State == System.Data.ConnectionState.Open)
                {
                    connexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD("Erreur lors de la fermeture de la connexion à la base de données.", ex);
            }
        }

        // Autres méthodes pour exécuter des requêtes, récupérer des données, etc.

        // Méthode d'ajout
        /* Ajoute un étudiant
         * 
         * Entrée: 
         * Un objet étudiant
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int AjouterEtudiant(Etudiant etudiant)
        {
           
            NpgsqlCommand sqlCmd2 = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * from ajoutEtudiant " +
                        "(:nom, :prenom, :sexe, :gsm, :rue, :codepostal, :localite, :email)"
                        , this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("nom", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("prenom", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("sexe", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("gsm", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("rue", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("codepostal", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("localite", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("email", NpgsqlTypes.NpgsqlDbType.Varchar));

                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = etudiant.Nom;
                sqlCmd2.Parameters[1].Value = etudiant.Prenom;
                sqlCmd2.Parameters[2].Value = etudiant.Sexe;
                sqlCmd2.Parameters[3].Value = etudiant.Gsm;
                sqlCmd2.Parameters[4].Value = etudiant.Rue;
                sqlCmd2.Parameters[5].Value = etudiant.Codepostal;
                sqlCmd2.Parameters[6].Value = etudiant.Localite;
                sqlCmd2.Parameters[7].Value = etudiant.Email;


                return (sqlCmd2.ExecuteNonQuery());
            } 
            catch (Exception ex) {
 
                    throw new Exception(ex.Message);
             
                
            }
            

        }


        /* Ajoute un prof
         * 
         * Entrée: 
         * Un objet prof
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int AjouterProf(Professeur professeur)
        {

 
            NpgsqlCommand sqlCmd2 = null;

            try
            {

    

                sqlCmd2 = new NpgsqlCommand("select * from ajoutProf " +
                        "(:nom, :prenom, :sexe, :gsm, :rue, :codepostal, :localite, :matricule, :email)"
                        , this.SqlConn);



                // Ajouter les parametres



                sqlCmd2.Parameters.Add(new NpgsqlParameter("nom", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("prenom", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("sexe", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("gsm", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("rue", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("codepostal", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("localite", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("matricule", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("email", NpgsqlTypes.NpgsqlDbType.Varchar));

                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres


                sqlCmd2.Parameters[0].Value = professeur.Nom;
                sqlCmd2.Parameters[1].Value = professeur.Prenom;
                sqlCmd2.Parameters[2].Value = professeur.Sexe;
                sqlCmd2.Parameters[3].Value = professeur.Gsm;
                sqlCmd2.Parameters[4].Value = professeur.Rue;
                sqlCmd2.Parameters[5].Value = professeur.Codepostal;
                sqlCmd2.Parameters[6].Value = professeur.Localite;
                sqlCmd2.Parameters[7].Value = professeur.Matricule;
                sqlCmd2.Parameters[8].Value = professeur.Email;


                return (sqlCmd2.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd2.CommandText, ex);
            }



        }



        /* Ajoute une section
         * 
         * Entrée: 
         * Un objet section
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int AjouterSection(Section section)
        {
            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("select * from ajoutSection " +
                 "(:libelle) " 
                ,this.SqlConn);




                // Ajouter les parametres

                sqlCmd.Parameters.Add(new NpgsqlParameter("libelle", NpgsqlTypes.NpgsqlDbType.Varchar));



                // Prepare la commande
                sqlCmd.Prepare();

                //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = section.Libelle;


                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }


        /* Ajoute une ue
         * 
         * Entrée: 
         * Un objet ue
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int AjouterUe(Ue ue)
        {
            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("select * from ajoutUe " +
                 "(:libelle, :nbreperiodes, :section) " 
                 , this.SqlConn);




                // Ajouter les parametres

                sqlCmd.Parameters.Add(new NpgsqlParameter("libelle", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd.Parameters.Add(new NpgsqlParameter("nbreperiodes", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("section", NpgsqlTypes.NpgsqlDbType.Varchar));



                // Prepare la commande
                sqlCmd.Prepare();

                //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = ue.Libelle;
                sqlCmd.Parameters[1].Value = ue.Nbreperiodes;
                sqlCmd.Parameters[2].Value = ue.Section;

               
                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }

        /* Ajoute un étudiant a une ue et une année academique aces la date de la séance
        * 
        * Entrée: 
        * L'idue et un objet ueAcadémique
        * Sortie : 
        * Un entier qui confirme la réussite ou l'échec de la méthode
        */
        public int AjouterUeAnneeAcademiqueDateSeance(UeAnneeAcademique ueAca, int idue)
        {
            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("select * from ajoutUeAcaDateSeance " +
                 "(:idue, :datedebut, :datefin)", this.SqlConn);




                // Ajouter les parametres
                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("datedebut", NpgsqlTypes.NpgsqlDbType.Date));
                sqlCmd.Parameters.Add(new NpgsqlParameter("datefin", NpgsqlTypes.NpgsqlDbType.Date));
   


                // Prepare la commande
                sqlCmd.Prepare();

            //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = idue;
                sqlCmd.Parameters[1].Value = ueAca.DateDebut;
                sqlCmd.Parameters[2].Value = ueAca.DateFin;

                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }

        // Méthode qui prend le choix de l'utilisateur pour l'inscription d'un étudiant dans une ue


        /* Ajoute un étudiant à une ue
         * 
         * Entrée: 
         * Le choixEtudiant et le choix de l'ue
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int AjouterEtudiantUe(int choixEtudiant, int choixUe)
        {
            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("select * from ajoutEtudiantUe" +
                 "(:idpersonne, :idue)", this.SqlConn);




                // Ajouter les parametres

                sqlCmd.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
  

                // Prepare la commande
                sqlCmd.Prepare();


            //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = choixEtudiant;
                sqlCmd.Parameters[1].Value = choixUe;
 

                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }

        /* Ajoute une séance
         * 
         * Entrée: 
         * Un objet séeance
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int AjouterSeance(Seance seance)
        {
            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("select * from ajoutSeance" +
                 "(:idue, :dateseance)" 
                 ,this.SqlConn);




                // Ajouter les parametres

                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("dateseance", NpgsqlTypes.NpgsqlDbType.Date));


                // Prepare la commande
                sqlCmd.Prepare();


                //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = seance.Idue;
                sqlCmd.Parameters[1].Value = seance.DateSeance;


                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }



        // Méthode pour modifier
        /* Modifie une personne
         * 
         * Entrée: 
         * Un objet personne
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int ModifierPersonne(Personne personne)
        {
            NpgsqlCommand sqlCmd2 = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * from modifierPersonne " +
                        "(:idpersonne, :nom, :prenom, :gsm, :rue, :codepostal, :localite)"
                     , this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("nom", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("prenom", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("gsm", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("rue", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("codepostal", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("localite", NpgsqlTypes.NpgsqlDbType.Varchar));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = personne.Nom;
                sqlCmd2.Parameters[1].Value = personne.Prenom;
                sqlCmd2.Parameters[2].Value = personne.Gsm;
                sqlCmd2.Parameters[3].Value = personne.Rue;
                sqlCmd2.Parameters[4].Value = personne.Codepostal;
                sqlCmd2.Parameters[5].Value = personne.Localite;
                sqlCmd2.Parameters[6].Value = personne.IdPersonne;

                return (sqlCmd2.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }

        /* Modifie la date de la seance
         * 
         * Entrée: 
         * Un objet seance
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int ModifierSeance(Seance seance)
        {
            NpgsqlCommand sqlCmd2 = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * from modifierDateSeance" +
                        "(:idseance, :dateseance)"
                     , this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("dateseance", NpgsqlTypes.NpgsqlDbType.Date));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("idseance", NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = seance.DateSeance;
                sqlCmd2.Parameters[1].Value = seance.Idseance;

                return (sqlCmd2.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }

        /* modifie un étudiant en fonction de son idue, idpersonne et résultat
         * 
         * Entrée: 
         * Un idue, idpersonne, resultat
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int ModifierResultat(int idue, int idpersonne, int resultat)
        {
            NpgsqlCommand sqlCmd2 = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("UPDATE " +
                        "INSCRIPTION SET resultat =:resultat WHERE idue = :idue AND idpersonne = :idpersonne"
                     , this.SqlConn);



                // Ajouter les parametres
                sqlCmd2.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("resultat", NpgsqlTypes.NpgsqlDbType.Integer));

                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = idue;
                sqlCmd2.Parameters[1].Value = idpersonne;
                sqlCmd2.Parameters[2].Value = resultat;

                
                return (sqlCmd2.ExecuteNonQuery());
                
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
            
        }



        /* Liste la liste des étudiants
         * 
         * Entrée: 
         * 
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Etudiant> ListeEtudiant()
        {
            List<Etudiant> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select idpersonne, nom, prenom, sexe, gsm, rue, codepostal, localite, email " +
                                            "from etudiant " +
                                            "order by nom, prenom", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if(sqlreader.Read()) { 
                    liste = new List<Etudiant>();
                    do
                    {
                        liste.Add(new Etudiant(Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToString(sqlreader["nom"]),
                                               Convert.ToString(sqlreader["prenom"]),
                                               Convert.ToChar(sqlreader["sexe"]),
                                               Convert.ToString(sqlreader["gsm"]),
                                               Convert.ToString(sqlreader["rue"]),
                                               Convert.ToString(sqlreader["codepostal"]),
                                               Convert.ToString(sqlreader["localite"]),
                                               Convert.ToString(sqlreader["email"])));
                    } while(sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex) {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
                
            
            }
            return liste;
        }




        /* Liste la liste des section
         * 
         * Entrée: 
         * 
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Section> ListeSection()
        {
            List<Section> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select * " +
                                            "from section ", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Section>();
                    do
                    {
                        liste.Add(new Section(
                                              Convert.ToString(sqlreader["libelle"])
                                              )
                                                );
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }


        public List<Inscription> ListeInscris()
        {
            List<Inscription> liste = new List<Inscription>();

            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("SELECT idue, idpersonne, resultat FROM inscription", this.SqlConn);

                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();

                while (sqlreader.Read())
                {
                    int idue = Convert.ToInt32(sqlreader["idue"]);
                    int idpersonne = Convert.ToInt32(sqlreader["idpersonne"]);
                    int? resultat = sqlreader["resultat"] != DBNull.Value ? Convert.ToInt32(sqlreader["resultat"]) : (int?)null;

                    if (resultat == null)
                    {
                        liste.Add(new Inscription(idue, idpersonne));
                    }
                    else
                    {
                        liste.Add(new Inscription(idue, idpersonne, resultat.Value));
                    }
                }

                sqlreader.Close();
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }

            return liste;
        }


        

        /* Liste la liste des professeurs
        * 
        * Entrée: 
        * 
        * Sortie : 
        * Un entier qui confirme la réussite ou l'échec de la méthode
        */
        public List<Professeur> ListeProf()
        {
            List<Professeur> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select idpersonne, nom, prenom, sexe, gsm, rue, codepostal, localite, matricule, email " +
                                            "from professeur " +
                                            "order by nom, prenom", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Professeur>();
                    do
                    {
                        liste.Add(new Professeur(Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToString(sqlreader["nom"]),
                                               Convert.ToString(sqlreader["prenom"]),
                                               Convert.ToChar(sqlreader["sexe"]),
                                               Convert.ToString(sqlreader["gsm"]),
                                               Convert.ToString(sqlreader["rue"]),
                                               Convert.ToString(sqlreader["codepostal"]),
                                               Convert.ToString(sqlreader["localite"]),
                                               Convert.ToString(sqlreader["matricule"]),
                                               Convert.ToString(sqlreader["email"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }



        /* Liste la liste des personnes
        * 
        * Entrée: 
        * 
        * Sortie : 
        * Un entier qui confirme la réussite ou l'échec de la méthode
        */
        public List<Personne> ListePersonne()
        {
            List<Personne> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select idpersonne, nom, prenom, sexe, gsm, rue, codepostal, localite " +
                                            "from personne " +
                                            "order by nom, prenom", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Personne>();
                    do
                    {
                        liste.Add(new Personne(Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToString(sqlreader["nom"]),
                                               Convert.ToString(sqlreader["prenom"]),
                                               Convert.ToChar(sqlreader["sexe"]),
                                               Convert.ToString(sqlreader["gsm"]),
                                               Convert.ToString(sqlreader["rue"]),
                                               Convert.ToString(sqlreader["codepostal"]),
                                               Convert.ToString(sqlreader["localite"])
                                              ));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }




        /* Liste la liste des séances
         * 
         * Entrée: 
         * 
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Seance> ListeSeance()
        {
            List<Seance> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select * " +
                                            "from seance ", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Seance>();
                    do
                    {
                        liste.Add(new Seance(Convert.ToInt32(sqlreader["idseance"]),
                                               Convert.ToDateTime(sqlreader["dateseance"]),
                                               Convert.ToInt32(sqlreader["idue"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }


        /* Liste la liste des présences à une séance donné
         * 
         * Entrée: 
         * 
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Participation> ListeParticipation()
        {
            List<Participation> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select * " +
                                            "from participation ", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Participation>();
                    do
                    {
                        liste.Add(new Participation(Convert.ToInt32(sqlreader["idue"]),
                                               Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToInt32(sqlreader["idseance"]),
                                               Convert.ToString(sqlreader["statut"])
                                               ));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }


        /* Liste les étudiants en fonction de leur idpersonne
         * 
         * Entrée: 
         * Une liste d'idpersonne
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Etudiant> ListeEtudiantId(List<int> idPersonnes)
        {
            List<Etudiant> liste = new List<Etudiant>();
            NpgsqlCommand sqlCmd = new NpgsqlCommand();


            // Assurez-vous que la liste d'identifiants n'est pas null
            if (idPersonnes != null)
            {
                foreach (int idPersonne in idPersonnes)
                {


                    try
                    {
                        sqlCmd = new NpgsqlCommand("SELECT * FROM ETUDIANT WHERE idpersonne = :idpersonne", this.SqlConn);

                        // Ajouter le paramètre
                        sqlCmd.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));
                        sqlCmd.Parameters[0].Value = idPersonne;

                        NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();

                        // Lire les données et ajouter à la liste
                        if (sqlreader.Read())
                        {
                            liste = new List<Etudiant>();
                            do
                            {
                                liste.Add(new Etudiant(Convert.ToInt32(sqlreader["idpersonne"]),
                                                       Convert.ToString(sqlreader["nom"]),
                                                       Convert.ToString(sqlreader["prenom"]),
                                                       Convert.ToChar(sqlreader["sexe"]),
                                                       Convert.ToString(sqlreader["gsm"]),
                                                       Convert.ToString(sqlreader["rue"]),
                                                       Convert.ToString(sqlreader["codepostal"]),
                                                       Convert.ToString(sqlreader["localite"]),
                                                       Convert.ToString(sqlreader["email"])));
                            } while (sqlreader.Read());
                        }
                        sqlreader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return liste;
        }



        /* Liste les ue en fonction de l'idue
         * 
         * Entrée: 
         * Une liste d'idue
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Ue> ListeUeId(List<int> idue)
        {
            List<Ue> liste = new List<Ue>();
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            // Assurez-vous que la liste d'identifiants n'est pas null
            if (idue != null)
            {
                foreach (int id in idue)
                {
                    try
                    {
                        sqlCmd = new NpgsqlCommand("SELECT * FROM UE WHERE idue = :idue", this.SqlConn);

                        // Ajouter le paramètre
                        sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                        sqlCmd.Parameters[0].Value = id;

                        NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();

                        // Lire les données et ajouter à la liste
                        if (sqlreader.Read())
                        {
                            liste = new List<Ue>();
                            do
                            {
                                liste.Add(new Ue(
                                    Convert.ToInt32(sqlreader["idue"]),
                                    Convert.ToString(sqlreader["libelle"]),
                                    Convert.ToInt32(sqlreader["nbreperiodes"]),
                                    Convert.ToString(sqlreader["section"])
                                ));
                            } while (sqlreader.Read());
                        }
                        sqlreader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return liste;
        }





        /* Liste les ue
         * 
         * Entrée: 
         * 
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Ue> ListeUe()
        {
            List<Ue> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select *" +
                                            "from UE " +
                                            "order by idue", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Ue>();
                    do
                    {
                        liste.Add(new Ue(Convert.ToInt32(sqlreader["idue"]),
                                               Convert.ToString(sqlreader["libelle"]),
                                               Convert.ToInt32(sqlreader["nbreperiodes"]),
                                               Convert.ToString(sqlreader["section"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }



        /* Liste les ue academique
        * 
        * Entrée: 
        * 
        * Sortie : 
        * Un entier qui confirme la réussite ou l'échec de la méthode
        */
        public List<UeAnneeAcademique> ListeUeAca()
        {
            List<UeAnneeAcademique> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select *" +
                                            "from UEACADEMIQUE " +
                                            "order by idue", this.SqlConn);

                // Parametres


                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<UeAnneeAcademique>();
                    do
                    {
                        liste.Add(new UeAnneeAcademique(Convert.ToInt32(sqlreader["idue"]),
                                               Convert.ToDateTime(sqlreader["datedebut"]),
                                               Convert.ToDateTime(sqlreader["datefin"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }


        /* Liste les ue en fonction de la section
         * 
         * Entrée: 
         * Le libellé de la section
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Ue> ListeUeSectionDonne(string section)
        {
            List<Ue> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select * " +
                                            "from UE " +
                                            "WHERE section = :section", this.SqlConn);

                // Parametres
                sqlCmd.Parameters.Add(new NpgsqlParameter("section", NpgsqlTypes.NpgsqlDbType.Varchar));

                
                
                // Commande
                sqlCmd.Prepare();


                sqlCmd.Parameters[0].Value = section;   

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Ue>();
                    do
                    {
                        liste.Add(new Ue(Convert.ToInt32(sqlreader["idue"]),
                                               Convert.ToString(sqlreader["libelle"]),
                                               Convert.ToInt32(sqlreader["nbreperiodes"]),
                                               Convert.ToString(sqlreader["section"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }



        // Méthode qui va lister les étudiants en fonction de l'ue donné et une année académique donné
        /* Liste les étudiants en fonction de l'année académique en cours
         * 
         * Entrée: 
         * Un idue et la date de fin
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Etudiant> ListeEtudiantUeAnneeAca(int idue, DateTime datefin)
        {
            List<Etudiant> liste = null;
            List<Inscription> inscription = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();
            NpgsqlCommand sqlCmd2 = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("SELECT * " +
                           "FROM INSCRIPTION i " +
                           "JOIN UEACADEMIQUE u ON i.idue = u.idue " +
                           "JOIN ETUDIANT e ON i.idpersonne = e.idpersonne " +
                       "WHERE u.idue = :idue AND u.datefin = :datefin", this.SqlConn);
            // Parametres
                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("datefin", NpgsqlTypes.NpgsqlDbType.Date));


                // Commande
                /*sqlCmd.Prepare();*/


                sqlCmd.Parameters[0].Value = idue;
                sqlCmd.Parameters[1].Value = datefin;

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Etudiant>();
                    do
                    {
                        liste.Add(new Etudiant(Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToString(sqlreader["nom"]),
                                               Convert.ToString(sqlreader["prenom"]),
                                               Convert.ToChar(sqlreader["sexe"]),
                                               Convert.ToString(sqlreader["gsm"]),
                                               Convert.ToString(sqlreader["rue"]),
                                               Convert.ToString(sqlreader["codepostal"]),
                                               Convert.ToString(sqlreader["localite"]),
                                               Convert.ToString(sqlreader["email"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();

            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }



        // Méthode qui va lister les étudiants en fonction de l'ue donné et une année académique donné
        /* Liste les étudiants en fonction de l'année académique en cours
         * 
         * Entrée: 
         * Un idue et la date de fin
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Etudiant> ListeEtudiantUeAnneeAcademique(int idue, DateTime datefin)
        {
            List<Etudiant> liste = null;
            List<Inscription> inscription = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();
            NpgsqlCommand sqlCmd2 = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("SELECT * " +
                           "FROM INSCRIPTION i " +
                           "JOIN UEACADEMIQUE u ON i.idue = u.idue " +
                           "JOIN ETUDIANT e ON i.idpersonne = e.idpersonne " +
                       "WHERE u.idue = :idue AND u.datefin = :datefin", this.SqlConn);
                // Parametres
                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("datefin", NpgsqlTypes.NpgsqlDbType.Date));


                // Commande
                /*sqlCmd.Prepare();*/


                sqlCmd.Parameters[0].Value = idue;
                sqlCmd.Parameters[1].Value = datefin;

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Etudiant>();
                    do
                    {
                        liste.Add(new Etudiant(Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToString(sqlreader["nom"]),
                                               Convert.ToString(sqlreader["prenom"]),
                                               Convert.ToString(sqlreader["email"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();

            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }

        /* Liste la liste des présence des étudiants en fonction de l'idue
         * 
         * Entrée: 
         * L'idue de l'ue en question
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Participation> ListePrésence(int idue)
        {
            List<Participation> liste = null;
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
                sqlCmd = new NpgsqlCommand("select * " +
                                            "from PARTICIPATION p " +
                                            "JOIN ETUDIANT e ON e.idpersonne = p.idpersonne " +
                                            "JOIN SEANCE s ON s.idue = p.idue " +
                                            "WHERE s.idue = :idue", this.SqlConn);

                // Parametres
                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));


                sqlCmd.Parameters[0].Value = idue;

                // Commande
                sqlCmd.Prepare();

                NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
                if (sqlreader.Read())
                {
                    liste = new List<Participation>();
                    do
                    {
                        liste.Add(new Participation(Convert.ToInt32(sqlreader["idue"]),
                                               Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToInt32(sqlreader["idseance"]),
                                               Convert.ToString(sqlreader["statut"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }


        /* Liste les étudiants qui ont des ue en cours ou réussis en fonction de leur idpersonne
         * 
         * Entrée: 
         * L'idpersonne de la personne en question
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Inscription> ListeUeReussiOuEnCours(int idpersonne)
        {
            List<Inscription> liste = new List<Inscription>(); // Instancier la liste en dehors de la boucle
            NpgsqlCommand sqlCmd = new NpgsqlCommand();

            try
            {
            sqlCmd = new NpgsqlCommand("select * " +
                                        "from INSCRIPTION " +
                                        "WHERE idpersonne = :idpersonne", this.SqlConn);

            // Parametres
            sqlCmd.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));
            sqlCmd.Parameters[0].Value = idpersonne;

            // Commande
            sqlCmd.Prepare();

            NpgsqlDataReader sqlreader = sqlCmd.ExecuteReader();
            if (sqlreader.Read())
            {
                do
                {
                    liste.Add(new Inscription(Convert.ToInt32(sqlreader["idue"]),
                                           Convert.ToInt32(sqlreader["idpersonne"]),
                                           Convert.ToInt32(sqlreader["resultat"])
                                           ));
                } while (sqlreader.Read());
            }
            sqlreader.Close();
            }

            catch (Exception ex)
            {

                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);


            }
            return liste;
        }

        /* Trouve un étudiant en fonction de son idpersonne 
         * 
         * Entrée: 
         * L'idpersonne de l'étudiant en question
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public Personne InfoPersonne(int idPersonne)
        {
            NpgsqlCommand sqlCmd2 = null;
            Personne personne = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * " +
                        "from PERSONNE WHERE idpersonne = :idpersonne"
                     , this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));


                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = idPersonne;

                NpgsqlDataReader sqlreader = sqlCmd2.ExecuteReader();
                if (sqlreader.Read())
                {
                    personne = new Personne(idPersonne,
                        Convert.ToString(sqlreader["nom"]),
                        Convert.ToString(sqlreader["prenom"]),
                        Convert.ToChar(sqlreader["sexe"]),
                        Convert.ToString(sqlreader["gsm"]),
                        Convert.ToString(sqlreader["rue"]),
                        Convert.ToString(sqlreader["codepostal"]),
                        Convert.ToString(sqlreader["localite"])
                        );
                    
                }
                sqlreader.Close();
                return personne;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }


        /* Trouve une ue en fonction du libellé de l'ue
         * 
         * Entrée: 
         * Le libellé de l'ue en question
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public Ue InfoUe(string libelle)
        {
            NpgsqlCommand sqlCmd2 = null;
            Ue ue = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * " +
                        "from UE WHERE libelle = :libelle"
                     , this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("libelle", NpgsqlTypes.NpgsqlDbType.Varchar));


                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = libelle;

                NpgsqlDataReader sqlreader = sqlCmd2.ExecuteReader();
                if (sqlreader.Read())
                {
                    ue = new Ue(Convert.ToInt32(sqlreader["idue"]),
                        Convert.ToString(sqlreader["libelle"]),
                        Convert.ToInt32(sqlreader["nbreperiodes"]),
                        Convert.ToString(sqlreader["section"])
                        );

                }
                sqlreader.Close();
                return ue;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }


        /* Trouve une séance en fonction de l'idseance
         * 
         * Entrée: 
         * Un paramètre idseance de type int(entier)
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public Seance InfoSeance(int idSeance)
        {
            NpgsqlCommand sqlCmd2 = null;
            Seance seance = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * " +
                        "from SEANCE WHERE idseance = :idseance"
                     , this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("idseance", NpgsqlTypes.NpgsqlDbType.Integer));


                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = idSeance;

                NpgsqlDataReader sqlreader = sqlCmd2.ExecuteReader();
                if (sqlreader.Read())
                {
                    seance = new Seance(idSeance,
                        Convert.ToDateTime(sqlreader["dateseance"])
                        );

                }
                sqlreader.Close();
                return seance;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }


        /* Liste les étudiants en fonction de leur idue et idpersonne
         * 
         * Entrée: 
         * Un paramètre idue et un paramètre idpersonne
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public List<Inscription> InfoInscription(int idue, int idpersonne)
        {
            NpgsqlCommand sqlCmd2 = null;
            List<Inscription> inscris = null;

            try
            {

                sqlCmd2 = new NpgsqlCommand("select * " +
                                   "FROM INSCRIPTION i " +
                                   /*"JOIN UEACADEMIQUE u ON i.idue = u.idue " +*/
                                   /*"JOIN ETUDIANT e ON i.idpersonne = e.idpersonne " +*/
                                   "WHERE i.idue = :idue AND i.idpersonne = :idpersonne"
                                    ,this.SqlConn);



                // Ajouter les parametres

                sqlCmd2.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd2.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));


                // Prepare la commande
                sqlCmd2.Prepare();

                //Ajouter les valeurs aux parametres

                sqlCmd2.Parameters[0].Value = idue;
                sqlCmd2.Parameters[1].Value = idpersonne;

                NpgsqlDataReader sqlreader = sqlCmd2.ExecuteReader();
                if (sqlreader.Read())
                {
                    inscris = new List<Inscription>();
                    do
                    {
                        inscris.Add(new Inscription(Convert.ToInt32(sqlreader["idpersonne"]),
                                               Convert.ToInt32(sqlreader["idue"])));
                    } while (sqlreader.Read());
                }
                sqlreader.Close();
                return inscris;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }


        /* Encode un résultat pour une ue d'un étudiant
         * 
         * Entrée: 
         * Un objet inscription
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int EncoderResulat(Inscription inscris)
        {

            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("insert into " +
                 "INSCRIPTION(resultat) " +
                 "VALUES " +
                 "(:resultat)", this.SqlConn);




                // Ajouter les parametres

                sqlCmd.Parameters.Add(new NpgsqlParameter("resultat", NpgsqlTypes.NpgsqlDbType.Varchar));
             


                // Prepare la commande
                sqlCmd.Prepare();


                //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = inscris.Resultat;
              


                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }


        /* Encode les présences d'une séance
         * 
         * Entrée: 
         * Un objet participation
         * Sortie : 
         * Un entier qui confirme la réussite ou l'échec de la méthode
         */
        public int EncoderPresence(Participation participation)
        {

            NpgsqlCommand sqlCmd = null;

            try
            {

                sqlCmd = new NpgsqlCommand("insert into " +
                 "PARTICIPATION(idue,idpersonne,idseance,statut) " +
                 "VALUES " +
                 "(:idue,:idpersonne,:idseance,:statut)", this.SqlConn);




                // Ajouter les parametres

                sqlCmd.Parameters.Add(new NpgsqlParameter("idue", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("idpersonne", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("idseance", NpgsqlTypes.NpgsqlDbType.Integer));
                sqlCmd.Parameters.Add(new NpgsqlParameter("statut", NpgsqlTypes.NpgsqlDbType.Varchar));



                // Prepare la commande
                sqlCmd.Prepare();


                //Ajouter les valeurs aux parametres
                sqlCmd.Parameters[0].Value = participation.Idue;
                sqlCmd.Parameters[1].Value = participation.Idpersonne;
                sqlCmd.Parameters[2].Value = participation.Idseance;
                sqlCmd.Parameters[3].Value = participation.Statut;



                return (sqlCmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ExceptionAccessBD(sqlCmd.CommandText, ex);
            }
        }

       
    }
}
