using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RedTube.controls
{




    public class RequisicaoHTTP : HttpClient
    {


        private CancellationTokenSource cts;
        private int tempoMaximo = 10000;
        private int contagem = 0;
        private int tentativas = 5;
        private Boolean isBusy = false;

        public async Task<String> endereco(String url)
        {
            contagem++;
            String retorno = String.Empty;
            if (!isBusy)
            {
                isBusy = true;
                try
                {


                    DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)");
                    Timeout = TimeSpan.FromMilliseconds(tempoMaximo);
                    cts = new CancellationTokenSource();
                    cts.CancelAfter(tempoMaximo);
                    BaseAddress = new Uri(url);

                    HttpResponseMessage dados = await GetAsync(url, cts.Token);
                    dados.EnsureSuccessStatusCode();

                    retorno = await dados.Content.ReadAsStringAsync();
                    contagem = 0;
                }
                catch (Exception)
                {


                }
                finally
                {
                    isBusy = false;
                }
            }
            else
            {
                if (contagem <= tentativas * 2)
                {
                    await Task.Delay(2000);
                    retorno = await endereco(url);
                }
            }

            if (retorno.Equals(String.Empty))
            {

                if (contagem <= tentativas)
                {
                    await Task.Delay(2000);
                    retorno = await endereco(url);
                }

            }
            return retorno;
        }

    }
}

