using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Radouham
{
    public class Facturation
    {
        private Clientele _laClientele;
        private Produit _leProduit;
        private int _num;
        internal static Visibility Visibility;

        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }


        public Produit LeProduit
        {
            get { return _leProduit; }
            set { _leProduit = value; }
        }


        public Clientele LaClientele
        {
            get { return _laClientele; }
            set { _laClientele = value; }
        }

        public Facturation(int num, Clientele cli, Produit prod)
        {
            _num = num;
            _laClientele = cli;
            _leProduit = prod;
        }

    }
}
