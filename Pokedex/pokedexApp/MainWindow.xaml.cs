using System.Net.Http;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Linq;
using System.Windows.Shapes;

namespace pokedexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class PokemonResult
        {
            public string name { get; set; }

            public int id { get; set; }

            public string type { get; set; }

            public string url { get; set; }
        }

        public class PokemonApiResponse
        {
            public int count { get; set; }
            public List<PokemonResult> results { get; set; }
        }

        List<string> PokemonNomes = new List<string>();
        CollectionView view;

        public MainWindow()
        {
            InitializeComponent();
            CarregarPokemons();
        }
        private void CarregarPokemons()
        {

        }
    }
}