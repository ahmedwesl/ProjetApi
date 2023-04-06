using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // définir l'URL du service web
            string url = "https://data.mobilites-m.fr/api/linesNear/json";


            double latitude = 450.1846394; // remplacer xxx par la longitude du point de référence
            double longitude = 5.7316593; // remplacer xxx par la latitude du point de référence
            string lat = latitude.ToString().Replace(",", ".");
            string lon = longitude.ToString().Replace(",", ".");

            int dist = 1000; // remplacer 500 par la distance du centre de recherche en mètres
            bool details = true; // remplacer true si vous souhaitez avoir une description plus précise des éléments retournés, false sinon

            // construire l'URL de la requête
            string requestUrl = $"{url}?y={lat}&x={lon}&dist={dist}&details={details}";
            Console.WriteLine(requestUrl);
            // créer la requête
            WebRequest request = WebRequest.Create(requestUrl);

            // définir le type de requête
            request.Method = "GET";

            // ajouter les en-têtes nécessaires
            request.Headers.Add("Accept-Language", "fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");

            // activer les protocoles de sécurité nécessaires
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            // envoyer la requête et récupérer la réponse
            WebResponse response = request.GetResponse();


            // lire le contenu de la réponse
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();

                // Désérialiser la réponse JSON en un tableau d'objets Stop
                List<Stop> stops = JsonConvert.DeserializeObject<List<Stop>>(json);

                // Afficher les noms des arrêts et les lignes de transport associées
                foreach (Stop stop in stops)
                {
                    Console.WriteLine(stop.Name + " - " + string.Join(", ", stop.Lines));
                }


                // Fermer la réponse
                response.Close();
            }
        }

       
    }
}