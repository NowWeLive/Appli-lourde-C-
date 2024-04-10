using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Radouham
{
    public class Rendez_vous
    {
		private string _type;
		private string _adresse;
		private string _ville;
		private string _date;
        private string _heure;
        private Clientele _laClientele;
        internal static Visibility Visibility;

        public Clientele LaClientele
        {
            get { return _laClientele; }
            set { _laClientele = value; }
        }


        public string Heure
        {
            get { return _heure; }
            set { _heure = value; }
        }

        public string Date
		{
			get { return _date; }
			set { _date = value; }
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


		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public Rendez_vous(string tp, string ad, string vl, string date, string h)
		{
			_type = tp;
			_adresse = ad;
			_ville = vl;
			_date = date;
			_heure = h;
		}
	}
}
