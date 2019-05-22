using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo3_Calculatrice_WPF
{
    class Calculatrice
    {
        public Calculatrice()
        {
        }

        public string Calcul(string operation)
        {
            if (operation == "Erreur")
            {
                return "";
            }
            if (operation.Length > 0)
            {
                int i;
                double locale = 0;
                double multiple = 0;
                double addition = 0;
                string tmp;
                char[] separator = { '+', '-', '*', '/' };
                List<double> valeur = new List<double>();
                List<String> liste = new List<String>();
                List<String> signe = new List<String>();

                string[] nombre = operation.Split(separator);// On récupère les nombres du paramètre

                i = 0;
                while (i < nombre.Length)// on ajoute dans une liste les nombres (il sont casté au passage)
                {
                    if (nombre[i] == "")//-si le 1er chiffre est négatif
                    {
                        valeur.Add(-Convert.ToDouble(SQLPointToVirgule(nombre[1])));
                        i++;
                    }
                    else
                    {
                        valeur.Add(Convert.ToDouble(SQLPointToVirgule(nombre[i])));
                    }
                    i++;
                }

                i = 0;
                while (i < operation.Length)// on ajoute dans une liste chaque caractère du paramètre
                {
                    string sub = operation.Substring(i, 1);
                    liste.Add(sub);
                    i++;
                }

                if (liste[0] == "-")// on vérifie si le 1er nombre du paramètre est négatif
                {
                    liste.RemoveAt(0);
                }

                i = 0;
                while (i < liste.Count)// on ajoute les signes du paramètre
                {
                    if (liste[i] == "+" || liste[i] == "-" || liste[i] == "*" || liste[i] == "/")
                    {
                        signe.Add(liste[i]);
                    }
                    i++;
                }

                for (i = 0; i < 2; i++) //- on parcours 2 fois la chaîne
                {
                    if (i == 0)//- on effectue en priorité les multiplications et divisions, s'il y en a
                    {
                        int j = 0;
                        while (j < signe.Count)
                        {
                            if (signe[j] == "*")//multiplication
                            {
                                multiple = valeur[j] * valeur[j + 1];
                                valeur.RemoveAt(j + 1);
                                valeur.RemoveAt(j);
                                valeur.Insert(j, multiple);
                                signe.RemoveAt(j);
                                j--;
                            }
                            else if (signe[j] == "/")//division
                            {
                                if (valeur[j + 1] != 0)
                                {
                                    multiple = valeur[j] / valeur[j + 1];
                                    valeur.RemoveAt(j + 1);
                                    valeur.RemoveAt(j);
                                    valeur.Insert(j, multiple);
                                    signe.RemoveAt(j);
                                    j--;
                                }
                                else
                                {
                                    tmp = Convert.ToString(locale);
                                    return tmp = "Erreur";
                                }
                            }
                            j++;
                        }
                    }
                    else//- on effectue ensuite les additions et soustractions, s'il y en a
                    {
                        int j = 0;
                        int bcl = signe.Count;
                        while (j < bcl)
                        {
                            if (signe[0] == "+")//addition
                            {
                                addition = valeur[0] + valeur[1];
                                valeur.RemoveAt(1);
                                valeur.RemoveAt(0);
                                valeur.Insert(0, addition);
                                signe.RemoveAt(0);
                            }
                            else if (signe[0] == "-")//soustraction
                            {
                                addition = valeur[0] - valeur[1];
                                valeur.RemoveAt(1);
                                valeur.RemoveAt(0);
                                valeur.Insert(0, addition);
                                signe.RemoveAt(0);
                            }
                            j++;
                        }
                    }
                }
                locale = valeur[0];
                tmp = Convert.ToString(locale);

                return tmp;
            } else
            {
                return "";
            }
            
        }

        public static String SQLPointToVirgule(Object nombre)
        {
            return nombre.ToString().Replace(".", ",");
        }
    }
}
