using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedTube.controls;
using RedTube.Interface;
using RedTube.models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace RedTube.views
{
    public partial class Procura : ContentPage
    {

        private String endereco;
        public Procura()
        {
            InitializeComponent();
            endereco = "http://api.redtube.com/?data=redtube.Videos.searchVideos&output=json&thumbsize=medium";
            iniciar();
        }


        public void Atualiza(String categoria)
        {
            endereco = "http://api.redtube.com/?data=redtube.Videos.searchVideos&category=" + categoria + "&output=json&thumbsize=medium";
            listar.ItemsSource = new List<ListasMOD>();
           iniciar();
        }



        private async void iniciar()
        {

            RequisicaoHTTP d = new RequisicaoHTTP();
            var resposta = await d.endereco(endereco);


           var  dd = JsonConvert.DeserializeObject<ProcuraVideos>(resposta);

            var video = dd.videos;

            ListasMOD temp;

            List<ListasMOD> dados = new List<ListasMOD>();

            foreach (var m in video)
            {

                temp = new ListasMOD();
                temp.titulo = Convert.ToString(m.video.title);
                temp.imagem = new Uri(Convert.ToString(m.video.default_thumb));
                temp.video = Convert.ToString(m.video.embed_url);
                temp.visitas = "Total de " + Convert.ToString(m.video.views) + " Visitas";
                dados.Add(temp);


            }

            listar.ItemsSource = dados;
            listar.ItemTapped += async (e, a) =>
            {

                var item = a.Item as ListasMOD;


                RequisicaoHTTP c = new RequisicaoHTTP();
                String resultado = await c.endereco(item.video);
                String videos = Regex.Match(resultado, "<source.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;

                DependencyService.Get<IVideoPlayer>().AbrirPlayer(videos);


            };
        }



    }
}
