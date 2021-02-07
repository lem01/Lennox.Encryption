using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
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

namespace Lennox.Encryption
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //creamos estas 2 variables que seran nuestro abecedario
        //nos ayudaran para la permutacion de caracteres
        int[] abecedario1 = new int[150];
        int[] abecedario2 = new int[150];

        public MainWindow()
        {
            InitializeComponent();
            CargaAbecedario();
        }
        //funciones
        void CargaAbecedario()
        {
           
            int j = 0;
            //guardando primer abecedario
            for (int i = 70; i <= 190; i++)
            {
                abecedario1[j] = i;
                j++;
            }

            j = 0;

            //guardando segundo avecedario
            for (int i = 131; i <= 190; i++)
            {
                abecedario2[j] = i;
                j++;
            }
            //j = 24;
            for (int i = 70; i <= 130; i++)
            {
                abecedario2[j] = i;
                j++;
            }
        }

        bool Valida_Par_Impar(int i) 
        {
            if (i % 2 == 0)
                return true;
            else
                return false;
        }


        void Cifrar()
        {
            TxtCifrado.Clear();
    
            int y, z;
            string exadecimal;
            int lettertransposition;   
            string textoaux = TxtNormal.Text.ToUpper();
            string texto = "";

            //le quito los espacios y saltos a el texto
            for(int i = 0; i < TxtNormal.Text.Length; i++) 
            {
                if(textoaux[i] != ' ' && textoaux[i] != '\n')
                texto += textoaux[i];
            }

            for (int i = 0; i < texto.Length; i++)
            {
                ///con la i del for valido si la posicion de una letra del texto esta en numero par o impar
                ///en otras palabras si me sale la i par
                ///aplico una fucnion matematica y si es impar aplico otra
                if (Valida_Par_Impar(i))
                {
                    char aux = texto[i];
                    int x = aux;
                    y = (x + 20);
                    z = (x * 2);

                    x += (y + z);

                    x = (x / 2);

                    lettertransposition = TranspositionEncrypt(x);

                    exadecimal = ConverToExadecimal(lettertransposition);

                    TxtCifrado.Text += exadecimal + " ";


                }
                else
                {
                    char aux = texto[i];
                    int x = aux;
                    y = (x + 20);
                    z = (x * 2);

                    x += (y + z);

                    x = (x / 4);

                    lettertransposition = TranspositionEncrypt(x);

                    exadecimal = ConverToExadecimal(lettertransposition);

                    TxtCifrado.Text += exadecimal + " ";


                }

            }
 
        }

        int TranspositionEncrypt(int acssi)
        {
            int resultado = 0;
            for (int i = 0; i <= 120; i++)
            {
                if (acssi == abecedario1[i])
                {
                    resultado = abecedario2[i];
                    break;
                }
                    
            }

            return resultado;
        }

        string ConverToExadecimal(int numdecimal)
        {

            int[] digitoex = new int[20];
            string salida = "";
            int residuo = 0, resultado = 0, i = 0;


            do
            {
                residuo = numdecimal % 16;
                resultado = numdecimal / 16;
                digitoex[i] = residuo;
                numdecimal++;
                i++;
            } while (resultado > 15);

            digitoex[i] = resultado;

            // cambiamos el 10 al 15 por sus representacion en hexadecimal
            for (int j = i; j >= 0; j--)
            {
                if (digitoex[j] == 10)
                    salida += "A";
                else if (digitoex[j] == 11)
                    salida += "B";
                else if (digitoex[j] == 12)
                    salida += "C";
                else if (digitoex[j] == 13)
                    salida += "D";
                else if (digitoex[j] == 14)
                    salida += "E";
                else if (digitoex[j] == 15)
                    salida += "F";
                else
                    salida += digitoex[j];
            }

            return salida;
        }

        void Descifrar() 
        {
            TxtCifrado.Clear();
            string letter = TxtNormal.Text;
            string exadecimal = "";
            int numdecimal = 0,convertToPlainText = 0, count = 0;
            for (int i = 0; i < letter.Length;i++)
            {
                if(letter[i] != ' ')
                exadecimal += letter[i];
                

                if(exadecimal.Length == 2)
                    {
                    numdecimal = ConvertToDecimal(exadecimal);
                    exadecimal = "";                    

                    convertToPlainText = TranspositionDecrypt(numdecimal);

                    TxtCifrado.Text += ConvertToPlainText(convertToPlainText , count);
                    count++;
                }
            }
        }

        int ConvertToDecimal(string exadecimal)
        {
            int  numdecimal = 0, isNumber = 0;
            double number = 16, elevacion = 0;
            string aux = "";
            for (int i = exadecimal.Length-1; i >= 0; i--)
            {

                aux = exadecimal[i].ToString();
                //valido si aux es un entero o un caracter
                if (!int.TryParse(aux.ToString(), out isNumber))
                    switch (aux)
                    {
                        case "A":
                            numdecimal += 10 * (int)Math.Pow(number, elevacion);
                            break;
                        case "B":
                            numdecimal += 11 * (int)Math.Pow(number, elevacion);
                            break;
                        case "C":
                            numdecimal += 12 * (int)Math.Pow(number, elevacion);
                            break;
                        case "D":
                            numdecimal += 13 * (int)Math.Pow(number, elevacion);
                            break;
                        case "E":
                            numdecimal += 14 * (int)Math.Pow(number, elevacion);
                            break;
                        case "F":
                            numdecimal += 15 * (int)Math.Pow(number, elevacion);
                            break;
                    }
                else
                {
                   
                    numdecimal += int.Parse(aux) *  (int)Math.Pow(number, elevacion);
                }

                elevacion++;
            }
            return numdecimal;
        }
        
        int TranspositionDecrypt( int numdecimal) 
        {
            int resultado = 0;
            for (int i = 0; i <= 120; i++)
            {
                if (numdecimal == abecedario2[i])
                {
                    resultado = abecedario1[i];
                    break;
                }
               
            }

            return resultado;
        }

        string ConvertToPlainText(int x, int count) 
        {
            if(Valida_Par_Impar(count))
            x = (x / 2) - 5;
            else x = x - 5;

            //convierto numero ascci a caracter
            string planintext  = "";
            planintext += (char)x;

            return planintext;
        }
        /// ////////////////////////////////////////////////
        /// ////////////////////////////////////////////////
        private void BtnCifrar_Click(object sender, RoutedEventArgs e)
        {
            Cifrar();
        }

        private void BtnDescifrar_Click(object sender, RoutedEventArgs e)
        {
            Descifrar();   
        }

        private void TxtNormal_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int control = 0;
            string letter = e.Key.ToString();
            char num = ' ';
            if(letter.Length == 1) 
            {
                num = char.Parse(letter);
                control = num;
            }

            if (letter == "Space")
                e.Handled = false;
            else if (letter == "Back")
                e.Handled = false;
            else if (control >= 65 && control <= 90)
                e.Handled = false;
            else
                e.Handled = true;
    
        }

        private void TxtNormal_PreviewKeyUp(object sender, KeyEventArgs e)
        {
           
            //string letterUpper = "";
            //letterUpper += letter;

            //letter = letterUpper.ToUpper()[0];
            //if (char.IsControl((char)e.Key))
            //    e.Handled = false;

        }
    }
}
