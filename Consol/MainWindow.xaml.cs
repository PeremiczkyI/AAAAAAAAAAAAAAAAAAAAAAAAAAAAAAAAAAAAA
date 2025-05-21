using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using celloveszetCLI;

namespace celloveszetWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    static ObservableCollection<Cellovo> lovesek = new ObservableCollection<Cellovo>();
    public MainWindow()
    {
        InitializeComponent();
        Feladat_5();
        dtgAdatok.ItemsSource = lovesek;
    }
    private static void Feladat_5()
    {
        StreamReader sr = new StreamReader("lovesek.csv");
        while (!sr.EndOfStream)
        {
            lovesek.Add(new Cellovo(sr.ReadLine()));
        }
        sr.Close();
    }

    private void btnHozzaad_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (tbL1.Text != "" && tbL2.Text != "" && tbL3.Text != "" && tbL4.Text != "" && tbNev.Text != "")
            {
                if (int.Parse(tbL1.Text) >= 0 && int.Parse(tbL1.Text) <= 99)
                {
                    if (int.Parse(tbL2.Text) >= 0 && int.Parse(tbL2.Text) <= 99)
                    {
                        if (int.Parse(tbL3.Text) >= 0 && int.Parse(tbL3.Text) <= 99)
                        {
                            if (int.Parse(tbL4.Text) >= 0 && int.Parse(tbL4.Text) <= 99)
                            {
                                // lovesek.Add(new Cellovo($"{tbNev.Text};{tbL1.Text};{tbL2.Text};{tbL3.Text};{tbL4.Text}"));
                                lovesek.Insert(0, new Cellovo($"{tbNev.Text};{tbL1.Text};{tbL2.Text};{tbL3.Text};{tbL4.Text}"));
                                tbNev.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hibás adat");
                }
            }
            else
            {
                MessageBox.Show("Üres adat");
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }

    }

    private void btnMent_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            StreamWriter sw = new StreamWriter("lovesek2.txt");
            for (int i = 0; i < lovesek.Count; i++)
            {
                sw.WriteLine($"{lovesek[i].Nev};{lovesek[i].EsloLoves};{lovesek[i].MasodikLoves};{lovesek[i].HarmadikLoves};{lovesek[i].NegyedikLoves};  {lovesek[i].Legnagyobb()}");
            }
            sw.Close();
            MessageBox.Show("Sikeres mentés");
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }

    }

    private void dtgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (dtgAdatok.SelectedIndex == -1)
        {
            btnTorol.IsEnabled = false;
        }
        else
        {
            btnTorol.IsEnabled = true;
        }

    }

    private void btnTorol_Click(object sender, RoutedEventArgs e)
    {
        lovesek.RemoveAt(dtgAdatok.SelectedIndex);
    }
}