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

            public string url { get; set; }
        }

        public class PokemonApiResponse
        {
            public int count { get; set; }
            public List<PokemonResult> results { get; set; }
        }

        public class PokemonDetalhes
        {
            public int id { get; set; }
            public string? name { get; set; }
            public int height { get; set; }
            public int weight { get; set; }
            public List<TipoPokemon>? types { get; set; }
            public Sprites? sprites { get; set; }
        }

            public class TipoPokemon
            {
                public TipoInfo type { get; set; }
            }

            public class TipoInfo
            {
                public string name { get; set; }
            }

            public class Sprites
            {
                public string front_default { get; set; }
            }


            List<string> PokemonNomes = new List<string>();
        CollectionView? view;

        public MainWindow()
        {
            InitializeComponent();
            CarregarTodosPokemons();
            ConfigurarComboBox();
        }

        // FILTRO
        private void ConfigurarComboBox()
        {
            PokemonComboBox.KeyUp += PokemonComboBox_TextoAlterado;
            PokemonComboBox.GotFocus += PokemonComboBox_CliqueFoco;
            PokemonComboBox.DropDownOpened += PokemonComboBox_Aberto;
            PokemonComboBox.SelectionChanged += PokemonComboBox_SelecaoAlterada;
            
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
        private void PokemonComboBox_TextoAlterado(object sender, KeyEventArgs e)
        {
            if(view != null && !string.IsNullOrEmpty(PokemonComboBox.Text) && PokemonComboBox.Text != "Digite o nome do Pokémon...")
            {
                view.Filter = FiltroDigitado;
                PokemonComboBox.IsDropDownOpen = true;
            }else if(PokemonComboBox.Text == "")
            {
                view.Filter = null;
            }
        }
        private void PokemonComboBox_Aberto(object sender, EventArgs e)
        {
            if (view != null)
            {
                view.Filter = null;
            }
        }
        private void PokemonComboBox_ValidarEntradas(object sender, TextCompositionEventArgs e)
        {
            
        }
        private void PokemonComboBox_SelecaoAlterada(object sender, SelectionChangedEventArgs e)
        {
            if (PokemonComboBox.SelectedItem != null)
            {
                string pokemonSelecionado = PokemonComboBox.SelectedItem.ToString();
                MessageBox.Show($"Pokémon selecionado: {pokemonSelecionado}");
                ObterDetalhesPokemonEscolhido(pokemonSelecionado);
                LimparFiltro();
            }
        }
        
        private async void ObterDetalhesPokemonEscolhido(string pokemonEscolhido)
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido.ToLower()}";
                    string json = await cliente.GetStringAsync(url);
                    PokemonDetalhes detalhes = JsonConvert.DeserializeObject<PokemonDetalhes>(json);
                    CarregarDetalhesPokemonEscolhido(detalhes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: { ex.Message}");
            }
        }

        private void CarregarDetalhesPokemonEscolhido(PokemonDetalhes detalhes)
        {
            if(detalhes == null)
            {
                //LimparDadosDaTela();
                return;
            }

            //Nome do pokemon com texto formatado e ID do pokemon
            string nomePokemon = detalhes.name;
            int idPokemon = detalhes.id;
            if (!string.IsNullOrEmpty(nomePokemon))
            {
                char primeiraLetra = char.ToUpper(nomePokemon[0]);

                string restoDoNome = nomePokemon.Substring(1);


                NomePokemonEscolhido.Text = $"#{idPokemon:D4} | {primeiraLetra + restoDoNome} ";
            }
            else
            {
                NomePokemonEscolhido.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(detalhes?.sprites?.front_default))
            {
                try
                {
                    Uri uri = new Uri(detalhes.sprites.front_default);
                    BitmapImage bitmap = new BitmapImage();

                    bitmap.BeginInit();

                    bitmap.UriSource = uri;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;

                    bitmap.EndInit();

                    SpritePokemonEscolhido.Source = bitmap;
                }
                catch (Exception ex)
                {
                    SpritePokemonEscolhido.Source = null;
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}");
                }
            }
            else
            {
                SpritePokemonEscolhido.Source = null;
            }
        }

        private bool FiltroDigitado(object item)
        {
            string pokemon = item.ToString();
            string textoPesquisa = PokemonComboBox.Text;
            return pokemon.StartsWith(textoPesquisa, StringComparison.OrdinalIgnoreCase);
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
                    //view.Filter = FiltroDigitado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de pokemons: "+ex.Message);
            }
        }

    }
}