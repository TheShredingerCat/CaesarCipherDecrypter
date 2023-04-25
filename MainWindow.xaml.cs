using System;
using System.Windows;

namespace CaesarCipherDecoder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            string textToDecrypt = textToDecryptTextBox.Text;
            int decryptionKey;
            if (int.TryParse(decryptionKeyTextBox.Text, out decryptionKey))
            {
                string decryptedText = Decrypt(textToDecrypt, decryptionKey);
                decryptedTextBox.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Please enter a valid decryption key (0-25).");
            }
        }

        private string Decrypt(string textToDecrypt, int decryptionKey)
        {
            string decryptedText = "";
            const int alphabetSize = 26;

            foreach (char c in textToDecrypt)
            {
                if (char.IsLetter(c))
                {
                    char currentChar = char.ToLower(c);
                    int shiftedChar = currentChar - decryptionKey;

                    if (shiftedChar < 'a')
                    {
                        shiftedChar += alphabetSize;
                    }

                    decryptedText += char.IsLower(c) ? (char)shiftedChar : char.ToUpper((char)shiftedChar);
                }
                else
                {
                    decryptedText += c;
                }
            }

            return decryptedText;
        }
    }
}