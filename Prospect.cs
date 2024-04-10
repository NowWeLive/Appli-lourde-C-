using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Radouham
{
    public class Prospect
    {
		private int _num;
		private string _nom;
		private string _prenom;
		private string _adresse;
        private int _tel;
        private string _ville;
		private int _cp;
		private string _dateNaiss;
        internal static Visibility Visibility;

        public string DateNaiss
		{
			get { return _dateNaiss; }
			set { _dateNaiss = value; }
		}

        public int Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public int CP
		{
			get { return _cp; }
			set { _cp = value; }
		}


		public string Ville
		{
			get { return _ville; }
			set { _ville = value; }
		}


		public string Adresse
		{
			get { return _adresse; }
			set { _adresse = value; }
		}
		
		public string Prenom
		{
			get { return _prenom; }
			set { _prenom = value; }
		}


		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		public int Num
		{
			get { return _num; }
			set { _num = value; }
		}

		public Prospect(int num, string nm, string pn, string ad,int tl, string vl, int cp, string naiss)
		{
			_num = num;
			_nom = nm;
			_prenom = pn;
			_adresse = ad;
			_tel = tl;
			_ville = vl;
			_cp = cp;
			_dateNaiss = naiss;
		}
	}
}
