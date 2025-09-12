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
            CarregarTodosPokemons();
            ConfigurarComboBox();

        }

        private void ConfigurarComboBox()
        {
            PokemonComboBox.GotFocus += PokemonComboBox_CliqueFoco;
        }

        private void PokemonComboBox_CliqueFoco(object sender, RoutedEventArgs e)
        {
            if(PokemonComboBox.Text == "Digite o nome do Pokémon...") // combobox.text != null
            {
                PokemonComboBox.Text = "";
            }

            if(view != null)
            {
                view.Filter = null;
                PokemonComboBox.IsDropDownOpen = true;
            }
        }
        private async void CarregarTodosPokemons()
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    string url = "https://pokeapi.co/api/v2/pokemon?limit=2000";

                    string json = await cliente.GetStringAsync(url);

                    PokemonApiResponse response = JsonConvert.DeserializeObject<PokemonApiResponse>(json);

                    PokemonNomes = response.results.Select(p => char.ToUpper(p.name[0]) + p.name.Substring(1)).OrderBy(p => p).ToList();

                    // codigo da linha acima refatorado, para melhor entendimento
                    /*
                    
                    var pokemonResultado = response.results;

                    var nomesFormatados = pokemonResultado.Select(p => char.ToUpper(p.name[0]) + p.name.Substring(1));

                    var nomesOrdenados = nomesFormatados.OrderBy(name => name);

                    PokemonNomes = nomesOrdenados.ToList();

                    */

                    PokemonComboBox.ItemsSource = PokemonNomes;


                    view = (CollectionView)CollectionViewSource.GetDefaultView(PokemonComboBox.ItemsSource);
                    view.Filter = FiltroDigitado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de pokemons: "+ex.Message);
            }
        }

        private bool FiltroDigitado(object item)
        {

            //teste
            return true;
        }
    }
}