using System;

namespace Classe
{
    class CompteBancaire
    {
        private string m_titulaire;
        public string Titulaire
        {
            get { return m_titulaire; }
            set { m_titulaire = value; }
        }

        private double m_solde;
        public double Solde
        {
            get { return m_solde; }
            set { m_solde = value; }
        }


        private string m_devise;
        public string Devise
        {
            get { return m_devise; }
            set { m_devise = value; }
        }

        private int m_nbCompte;
        public int NbCompte
        {
            get { return m_nbCompte; }
            set { m_nbCompte = value; }
        }

        public CompteBancaire(string titulaire, double solde, string devise)
        {
            this.m_titulaire = titulaire;
            this.m_solde = solde;
            this.m_devise = devise;
            Console.WriteLine("Nouveau compte crée avec pour titulaire " + titulaire + ", pour solde : " + solde + " et pour devise : " + devise);
        }


        public void Crediter (double credit)
        {
            Console.WriteLine("L'ancien solde est de : " + this.m_solde);
            double nSolde = this.m_solde + credit;
            this.m_solde = nSolde;
            Console.WriteLine("Apres credit, le nouveau solde est de : " + this.m_solde);
        }

        public void Debiter(double debit)
        {
            Console.WriteLine("L'ancien solde est de : " + this.m_solde);
            double nSolde = this.m_solde - debit;
            this.m_solde = nSolde;
            Console.WriteLine("Apres debit, le nouveau solde est de : " + this.m_solde);
        }

        public void Decrire()
        {
            Console.WriteLine("Le titulaire du compte est : " + this.m_titulaire + ", son solde est de : " + this.m_solde + " et sa devise est : " + m_devise + ".\n");
        }

    }


    class Client
    {
        private double m_CIN;
        public double CIN
        {
            get { return m_CIN; }
            set { m_CIN = value; }
        }

        private string m_nom;
        public string Nom
        {
            get { return m_nom; }
            set { m_nom = value; }
        }


        private string m_prenom;
        public string Prenom
        {
            get { return m_prenom; }
            set { m_prenom = value; }
        }

        private string m_tel;
        public string Tel
        {
            get { return m_tel; }
            set { m_tel = value; }
        }

        public Client(double cin, string nom, string prenom, string tel)
        {
            this.m_CIN = cin;
            this.m_nom = nom;
            this.m_prenom = prenom;
            this.m_tel = tel;
            Console.WriteLine("Nouveau client créé avec pour CIN " + cin + ", pour nom et prenom : " + nom + " " + prenom + " et pour telephone : " + tel);
        }

        public Client(double cin, string nom, string prenom)
        {
            this.m_CIN = cin;
            this.m_nom = nom;
            this.m_prenom = prenom;
            this.m_tel = "Non defini";
            Console.WriteLine("Nouveau client créé avec pour CIN " + cin + "et pour nom et prenom : " + nom + " " + prenom + ".");
        }

        public void Afficher()
        {
            Console.WriteLine("Les informations clients sont : \n" + "CIN : " + this.m_CIN + "\nPrenom et Nom : " + this.m_prenom + this.m_nom + "\nTelephone : " + m_tel);
        }

    }


    class Compte
    {
        private double solde;
        private static int code;
        private static int numberCompte;
        private Client m_proprietaire;

        public int Code
        {
            get { return code; }
        }

        public double Solde
        {
            get { return solde; }
        }

        public int NumberCompte
        {
            get { return numberCompte; }
        }

        internal Client Proprietaire { get => m_proprietaire; set => m_proprietaire = value; }

        public Compte( Client proprietaire)
        {
            this.m_proprietaire = proprietaire;
            code = ++numberCompte;
            this.solde = 0;
        }

        public void Crediter(double credit)
        {
            Console.WriteLine("\nL'ancien solde est de : " + this.solde);
            double nSolde = this.solde + credit;
            this.solde = nSolde;
            Console.WriteLine("Apres credit, le nouveau solde est de : " + this.solde);
        }

        public void Crediter(double credit, Compte compteACrediter)
        {
            Console.WriteLine("\nL'ancien solde est de : " + compteACrediter.solde);
            double nSoldeDebit = compteACrediter.solde - credit;
            double nSoldeCredit = this.solde + credit;
            compteACrediter.solde = nSoldeDebit;
            this.solde = nSoldeCredit;
            Console.WriteLine("Apres debit, le nouveau solde du compte " + compteACrediter.Code + " est de : " + compteACrediter.solde);
            Console.WriteLine("Apres credit, le nouveau solde du compte " + this.Code + " est de : " + this.solde);
        }

        public void Debiter(double debit)
        {
            Console.WriteLine("\nL'ancien solde est de : " + this.solde);
            double nSolde = this.solde - debit;
            this.solde = nSolde;
            Console.WriteLine("Apres debit, le nouveau solde est de : " + this.solde);
        }

        public void Debiter(double debit, Compte compteACrediter)
        {
            Console.WriteLine("\nL'ancien solde est de : " + compteACrediter.solde);
            double nSoldeDebit = compteACrediter.solde - debit;
            double nSoldeCredit = this.solde + debit;
            compteACrediter.solde = nSoldeCredit;
            this.solde = nSoldeDebit;
            Console.WriteLine("Apres credit, le nouveau solde du compte " + compteACrediter.Code + " est de : " + compteACrediter.solde);
            Console.WriteLine("Apres debit, le nouveau solde du compte " + this.Code + " est de : " + this.solde);
        }

        public void Afficher()
        {
            Console.WriteLine("\nLes informations du compte sont : \n" + "code : " + this.Code + "\nsolde : " + this.solde);
            Console.WriteLine("Les informations du proprietaire sont : \n" + "CIN : " + this.m_proprietaire.CIN + "\nPrenom et Nom : " + this.m_proprietaire.Prenom + this.m_proprietaire.Nom + "\nTelephone : " + m_proprietaire.Tel);
        }

        public void NbCompte()
        {
            Console.WriteLine("\nLe nombre de compte créé est de : " + this.NumberCompte);
        }

    }

    class Article
    {
        private static string m_reference;
        private static string m_designation;
        private static double m_prixHT;
        private static double m_tauxTVA;

        public string Reference { get => m_reference; set => m_reference = value; }
        public string Designation { get => m_designation; set => m_designation = value; }
        public double PrixHT { get => m_prixHT; set => m_prixHT = value; }
        public double TauxTVA { get => m_tauxTVA; set => m_tauxTVA = value; }

        public Article()
        {
            this.Reference = "A1A1A1A1";
            this.Designation = "Produit par defaut";
            this.PrixHT = 1500;
            this.TauxTVA = 20;
            Console.WriteLine("\n Utilisation du constructeur initialisant les valeurs");
        }

        public Article(string reference, string designation)
        {
            this.Reference = reference;
            this.Designation = designation;
            this.PrixHT = 1500;
            this.TauxTVA = 20;
            Console.WriteLine("\n Utilisation du constructeur passant reference et designation en parametre");
        }

        public Article(Article previousArticle)
        {
            this.Reference = previousArticle.Reference;
            this.Designation = previousArticle.Designation;
            this.PrixHT = previousArticle.PrixHT;
            this.TauxTVA = previousArticle.TauxTVA;
            Console.WriteLine("\n Utilisation du constructeur par recopie");
        }


        public double CalculerPrixTTC()
        {
            double prixTTC = this.PrixHT + (this.PrixHT * this.TauxTVA / 100);
            return prixTTC;
        }

        public void AfficherArticle()
        {
            Console.WriteLine("\nLes informations de l'article sont : \n" + "Reference : " + this.Reference + "\nDesignation : " + this.Designation
               + "\nPrixHT: " + this.PrixHT + "\nTauxTVA: " + this.TauxTVA + "\nPrixTTC: " + this.CalculerPrixTTC());
        }
    }

    class TestExercice
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EXERCICE 1 \nTest de la classe CompteBanquaire \n");
            CompteBancaire premier = new CompteBancaire("toto", 5000, "euros");
            premier.Decrire();
            premier.Crediter(250);
            premier.Decrire();
            premier.Debiter(750);
            premier.Decrire();


            Console.WriteLine("\n\nEXERCICE 2\nTest de la classe Compte \n");

            Client George = new Client(1234567891234, "POMPIDOU", "George", "0505050505");
            Client Charle = new Client(1234567891234, "MAGNE", "Charle");

            Compte compteGeorge = new Compte(George);
            Compte compteCharle = new Compte(Charle);

            compteGeorge.NbCompte();

            compteGeorge.Afficher();
            compteCharle.Afficher();

            compteGeorge.Crediter(5000);
            compteCharle.Crediter(2500);

            compteGeorge.Debiter(500);

            compteGeorge.Crediter(750, compteCharle);
            compteGeorge.Debiter(250, compteCharle);


            Console.WriteLine("\n\nEXERCICE 3\nTest de la classe Article \n");

            Article un = new Article();
            Article deux = new Article("1567894531AkjGHJDGHGJG", "pas d'idee de nom");
            Article trois = new Article(deux);

            un.AfficherArticle();
            deux.AfficherArticle();
            trois.AfficherArticle();
        }
    }

}
