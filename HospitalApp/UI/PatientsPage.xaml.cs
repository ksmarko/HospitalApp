using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        List<string> partners = new List<string>();
        string[] adress = new string[10]
        {
            "893 Maiden Dr. Oxford, MS 38655",
            "511 N. Swanson Ave. Perrysburg, OH 43551",
            "23 Jackson Dr. Middleton, WI 53562",
            "77 Cactus Ave. Miami Gardens, FL 33056",
            "943 W. Griffin Street Encino, CA 91316",
            "8476 Spruce Street Dayton, OH 45420",
            "147 W. Andover Lane Feasterville Trevose, PA 19053",
            "117 Vale St. Jenison, MI 49428",
            "8072 Pineknoll St. Marlton, NJ 08053",
            "518 Arlington Lane Bay Shore, NY 11706"
        };

        string[] operators = new string[] { "(099) ", "(098) ", "(066) ", "(067) ", "(063) ", "(095) " };

        public PatientsPage()
        {
            InitializeComponent();
        }

        private void PartnersNavigation(object sender, SelectionChangedEventArgs e)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            txtName.Text = lstPartners.SelectedItem.ToString();
            txtDate.Text = "Incoming date: " + rand.Next(10, 28) + ".0" + rand.Next(1, 9) + ".2017";
            txtMail.Text = "e-mail:   " + Regex.Replace(lstPartners.SelectedItem.ToString(), " ", ".").ToLower() + "@job.ca";
            txtPhone.Text = "Phone:   +38 " + operators[rand.Next(0, 5)] + rand.Next(100, 999) + " " + rand.Next(10, 99) + " " + rand.Next(10, 99);
            txtAdress.Text = "Adress: " + adress[rand.Next(0, 9)];
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            partners.Add("Alex Clare");
            partners.Add("Cinderella Woodberry");
            partners.Add("Annie Picou");
            partners.Add("Ophelia Bechtel");
            partners.Add("Delsie Bartholomew");
            partners.Add("Daniel Lile");
            partners.Add("Lizabeth Gleeson");
            partners.Add("Catrina Mealing");
            partners.Add("Lelia Labar");
            partners.Add("Carmelina Sweatman");
            partners.Add("Doreatha Yohn");
            partners.Add("Ruthie Beverage");
            partners.Add("Kerstin Silverberg");
            partners.Add("Eliza Penny");
            partners.Add("Berta Alewine");

            foreach (var el in partners)
                lstPartners.Items.Add(el);
        }
    }
}
