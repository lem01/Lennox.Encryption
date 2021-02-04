using System;
using System.Collections.Generic;
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
        int[] abecedario1 = new int[100];
        int[] abecedario2 = new int[100];
        public MainWindow()
        {
            InitializeComponent();
            CargaAbecedario();
        }
        //funciones
        //funcion cifrar
        void cifrar()
        {
            TxtCifrado.Clear();

            int y, z;
            string exadecimal;
            int lettertransposition;

            //string caracter = TextCifrar.Text;
            // int a = Convert.ToChar(caracter);
            // MessageBox.Show(a.ToString());
            string texto = TxtNormal.Text.ToUpper();

            for (int i = 0; i < TxtNormal.Text.Length; i++)
            {
                //MessageBox.Show(texto[i].ToString());
                if (texto[i] != ' ' && texto[i] != '\n') 
                {
                    char aux = texto[i];
                    int x = (int)aux;
                    y = (x + 20);
                    z = (x * 2);

                    x += (y + z);

                    x = (x / 2);

                    lettertransposition = Lettertransposition(x);

                    exadecimal = ConverToExadecimal(lettertransposition);

                    TxtCifrado.Text += exadecimal + " ";
                }
                //MessageBox.Show(exadecimal);

                //EtCifrado.Text += (char)x;
                ////MessageBox.Show(TxtCifrado.Text.Length.ToString());

                //a += (char)x;

                //MessageBox.Show(a);
            }

            //MessageBox.Show(TxtCifrado.Text.Length.ToString());

        }

        void CargaAbecedario()
        {
            int j = 0;
            //guardando primer abecedario
            for (int i = 140; i <= 190; i++)
            {
                abecedario1[j] = i;
                j++;
            }

            j = 0;

            //guardando segundo avecedario
            for (int i = 166; i <= 190; i++)
            {
                abecedario2[j] = i;
                j++;
            }
            //j = 24;
            for (int i = 140; i <= 165; i++)
            {
                abecedario2[j] = i;
                j++;
            }


            //MessageBox.Show(abecedario1.Length + "\n" + abecedario2.Length);
        }

        int Lettertransposition(int ascii)
        {
            //string n = "";
            //MessageBox.Show(n.Length.ToString());
            //for (int i = 0; i < abecedario1.Length; i++) 
            //{
            //    n += abecedario2[i].ToString() + "--";
            //}
            //MessageBox.Show(n);

            int a;
            int resultado = 0;
            for (int i = 0; i <= 50; i++)
            {
                a = abecedario1[i];
                if (ascii == abecedario1[i])
                    resultado = abecedario2[i];
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
            string letter = TxtCifrado.Text;
            string exadecimal = "";
            int lettertransposition = 0;
            for (int i = 0; i <= letter.Length;i++)
            {
                if(letter[i] != ' ')
                exadecimal += letter[i];
                else
                if(letter[i] == ' ' )
                {
                    lettertransposition = ConvertToDecimal(exadecimal);
                    exadecimal = "";
                }
            }
        }

        int ConvertToDecimal(string exadecimal)
        {
            int elevacion = 0, numdecimal = 0, isNumber = 0;
            string aux = "";
            for (int i = exadecimal.Length; i >= 0; i--)
            {

                aux = exadecimal[i].ToString();
                //valido si aux es un entero o un caracter
                if (!int.TryParse(aux.ToString(), out isNumber))
                    switch (aux)
                    {
                        case "A":
                            numdecimal += 10 * (16 ^ elevacion);
                            break;
                        case "B":
                            numdecimal += 11 * (16 ^ elevacion);
                            break;
                        case "C":
                            numdecimal += 12 * (16 ^ elevacion);
                            break;
                        case "D":
                            numdecimal += 13 * (16 ^ elevacion);
                            break;
                        case "E":
                            numdecimal += 14 * (16 ^ elevacion);
                            break;
                        case "F":
                            numdecimal += 15 * (16 ^ elevacion);
                            break;
                    }
                else
                {
                    numdecimal += int.Parse(aux) * (16 ^ elevacion);
                }

                elevacion++;
            }
            return numdecimal;
        }
        /// ////////////////////////////////////////////////
        private void BtnCifrar_Click(object sender, RoutedEventArgs e)
        {
            cifrar();
        }

        private void BtnDescifrar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
