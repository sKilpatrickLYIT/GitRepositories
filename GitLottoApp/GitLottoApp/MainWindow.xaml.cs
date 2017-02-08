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

namespace GitLottoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int maxNumberRange = 0;
        int[] lottoNumbers = new int[7];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIrishLotto_Click(object sender, RoutedEventArgs e)
        {
            maxNumberRange = 52;
            StartApplication();
        }

        private void btnUKLotto_Click(object sender, RoutedEventArgs e)
        {
            maxNumberRange = 59;
            StartApplication();
        }

        private void StartApplication()
        {
            int arrayPosition = 0;
            int randomNumber = 0;
            lottoNumbers.Initialize();

            do
            {
                randomNumber = generateRandomNumber(maxNumberRange);
                bool exists = checkExisting(randomNumber);

                if (!exists)
                {
                    lottoNumbers[arrayPosition] = randomNumber;
                    arrayPosition++;
                }

            } while (arrayPosition < lottoNumbers.Length);
            Array.Sort(lottoNumbers);
            displayNumbers();
        }

        private bool checkExisting(int newNumber)
        {
            bool exists = false;

            foreach (var number in lottoNumbers)
            {
                if (number == newNumber)
                {
                    exists = true;
                }
            }
            return exists;
        }

        private int generateRandomNumber(int maxNumberRange)
        {
            int number = 0;
            Random random1 = new Random();
            number = random1.Next(1, maxNumberRange);
            return number;
        }

        private void displayNumbers()
        {
            tbxResult1.Text = lottoNumbers[0].ToString();
            tbxResult2.Text = lottoNumbers[1].ToString();
            tbxResult3.Text = lottoNumbers[2].ToString();
            tbxResult4.Text = lottoNumbers[3].ToString();
            tbxResult5.Text = lottoNumbers[4].ToString();
            tbxResult6.Text = lottoNumbers[5].ToString();
            tbxResultBonus.Text = lottoNumbers[6].ToString();
        }

        private void bgtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
