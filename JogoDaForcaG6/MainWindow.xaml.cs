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


namespace JogoDaForcaG6
{
    
    public partial class MainWindow : Window
    {
        string palavra = "";
        bool comecouJogo = false;
        string mostraPalavra;
        int erros = 0;
        string letrasErradas = "";
        string MostraletrasErradas = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnJogar_Click(object sender, RoutedEventArgs e)
        {
            //Definir a palavra e começar jogo
            if(tb.Text != "" && !comecouJogo){   
                //Esconde as paradas
                txt_cabeca.Visibility = Visibility.Hidden;
                txt_tronco.Visibility = Visibility.Hidden;
                txt_bracoD.Visibility = Visibility.Hidden;
                txt_bracoE.Visibility = Visibility.Hidden;
                txt_pernaD.Visibility = Visibility.Hidden;
                txt_pernaE.Visibility = Visibility.Hidden;
                txt_palavra.Text = "";

                //Armazena o texto de tb na string palavra
                palavra = tb.Text.ToUpper();

                //Muda os textos e configurações do Text Block
                txt_informa.Text = "Informe uma letra:";
                tb.Clear();
                tb.MaxLength = 1;

                //Condição para percorrer palavra
                for (int i = 0; i < palavra.Length; i++)
                {
                    txt_palavra.Text += "_ ";
                    mostraPalavra += "_";
                }

                comecouJogo = true;


                //Após o jogo começar
            }
            else if(tb.Text != "" && comecouJogo){
                char letra = char.Parse(tb.Text.ToUpper());
                List<char> txtChars = mostraPalavra.ToList();
                List<char> palavraChars = palavra.ToList();


                //formatação do txt das letras certas
                for (int i = 0; i < palavra.Length; i++)
                {
                    if(palavraChars[i] == letra)
                    {
                        txtChars[i] = letra;
                    }
                }

                mostraPalavra = string.Join("", txtChars);
                txt_palavra.Text = string.Join(" ", txtChars);

                //Contar erros e acertos e aparecer boneco

                if(erros != 6)
                {
                    if (!palavra.Contains(letra) && !letrasErradas.Contains(letra))
                    {
                        erros += 1;
                        letrasErradas += letra;
                        MostraletrasErradas += letra + ".";
                        txt_erros1.Text = MostraletrasErradas;
                        if(erros == 1)
                        {
                            txt_cabeca.Visibility = Visibility.Visible;
                        }
                        else if(erros == 2)
                        {
                            txt_tronco.Visibility = Visibility.Visible;
                        }
                        else if (erros == 3)
                        {
                            txt_bracoD.Visibility = Visibility.Visible;
                        }
                        else if (erros == 4)
                        {
                            txt_bracoE.Visibility = Visibility.Visible;
                        }
                        else if (erros == 5)
                        {
                            txt_pernaD.Visibility = Visibility.Visible;
                        }
                        else if (erros == 6)
                        {
                            txt_pernaE.Visibility = Visibility.Visible;
                        }

                    }
                    else if (palavra == mostraPalavra)
                    {
                        MessageBoxResult result = MessageBox.Show($"Você acertou a palavra!\n{palavra.ToUpper()}", "Parabéns!");
                        ReiniciarJogo();
                    }
                }else if(erros == 6)
                {
                    MessageBoxResult result = MessageBox.Show($"Você errou a palavra!\n{palavra.ToUpper()}", "Wasted!");
                    ReiniciarJogo();
                }
                

                tb.Text = "";
            }
        }

      

        private void botaoSair(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ReiniciarJogo()
        {
            erros = 0;
            comecouJogo = false;
            palavra = "";
            letrasErradas = "";
            MostraletrasErradas = "";
            mostraPalavra = "";
            txt_palavra.Text = "_._._._._._._._._._._";
            txt_erros1.Text = "_._._._._._._._._._._";
            txt_informa.Text = "Informe a Palavra";
            tb.MaxLength = 18;
            txt_cabeca.Visibility = Visibility.Visible;
            txt_tronco.Visibility = Visibility.Visible;
            txt_bracoD.Visibility = Visibility.Visible;
            txt_bracoE.Visibility = Visibility.Visible;
            txt_pernaD.Visibility = Visibility.Visible;
            txt_pernaE.Visibility = Visibility.Visible;
        }

    }
}
