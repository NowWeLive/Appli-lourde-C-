using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Radouham
{
    public class Produit
    {
        private int _num;
        private string _libelle;
        private string _desc;
        private int _prix;
        internal static Visibility Visibility;

        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }

        public int Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public Produit(int num, string lib, string desc, int prix)
        {
            _num = num;
            _libelle = lib;
            _desc = desc;
            _prix = prix;
        }
    }
}
