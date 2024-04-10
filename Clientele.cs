using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Radouham
{
	public class Clientele
    {
		private int _num;
		private string _nom;
		private string _prenom;
		private string _mail;
        private int _tel;
        private string _ville;
		private int _cp;
        internal static Visibility Visibility;

        public int Num
		{
			get { return _num; }
			set { _num = value; }
		}

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		public string Prenom
		{
			get { return _prenom; }
			set { _prenom = value; }
		}

		public string Mail
		{
			get { return _mail; }
			set { _mail = value; }
		}

		public int Tel
        {
			get { return _tel; }
			set { _tel = value; }
		}

		

		public string Ville
		{
			get { return _ville; }
			set { _ville = value; }
		}

		public int CP
		{
			get { return _cp; }
			set { _cp = value; }
		}
		
		public Clientele(int num, string nm, string pn, string ad, int tl, string vl, int cp)
        {
			_num = num;
			_nom = nm;
			_prenom = pn;
			_mail = ad;
            _tel = tl;
            _ville = vl;
			_cp = cp;
			
        }

		public override string ToString()
		{
			return Num.ToString(); // ou retournez une représentation sous forme de chaîne appropriée
		}
	}
}
