using Newtonsoft.Json;
using RedTube.controls;
using RedTube.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RedTube.views
{
    public partial class Categoria : ContentPage
    {
        public Categoria()
        {
            InitializeComponent();
            inicializa();
        }


        private async void inicializa()
        {

            RequisicaoHTTP r = new RequisicaoHTTP();
            string dados = await r.endereco("http://api.redtube.com/?data=redtube.Categories.getCategoriesList&output=json");

            try
            {
                Categorias cat;

                cat = JsonConvert.DeserializeObject<Categorias>(dados);

                Lista.ItemsSource = cat.categories;

                Lista.ItemTapped += (e, a) => {

                    var item = a.Item as Category;

                    App.Categoria(item.category);


                };

            }
            catch
            {
                await DisplayAlert("Erro", "Não possivel buscar as catorias", "Fechar");
            }





        }
    }
}
