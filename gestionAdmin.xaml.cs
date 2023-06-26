using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Restaurant
{
    /// <summary>
    /// Logique d'interaction pour gestionAdmin.xaml
    /// </summary>
    public partial class gestionAdmin : Window
    {
        public gestionAdmin()
        {
            InitializeComponent();
        }

       

        public async Task GetAllPlats()
        {
            using (HttpClient client = new HttpClient())
            {

                
                try
                {
                    var response = await client.GetAsync("http://localhost:5001/api/ItalianRistorante");
                    response.EnsureSuccessStatusCode();
                    
                        String resp = await response.Content.ReadAsStringAsync();
                        List<Plat> plat = JsonConvert.DeserializeObject<List<Plat>>(resp);
                   
                        datagrid.ItemsSource = plat;
                        Console.WriteLine(resp);
                       
                }
                catch
                {
                    MessageBox.Show("error");
                }

            }

        }

        private const string apiUrl = "http://localhost:5001/api/ItalianRistorante"; 
                
                
              

                

            

       

        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            await GetAllPlats();
        }

        private  async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Récupérer les données depuis un TextBox ou un autre contrôle WPF
              
                
                

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Créer un objet contenant les données à envoyer à l'API
                    string insertname = TBXNM.Text;
                    int insertprice = int.Parse(TBXPr.Text);
                    var data = new Plat {id ="", Name = insertname, Price = insertprice };

                    // Convertir l'objet en JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    // Créer un contenu JSON à envoyer
                    var content = new StringContent(jsonData, Encoding.Default, "application/json");

                    // Envoyer la requête POST à l'API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Vérifier si la requête a réussi
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Données envoyées avec succès !" +jsonData);
                        await GetAllPlats();

                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de l'envoi des données.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une exception s'est produite : " + ex.Message);
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String personId = TBXId.Text; 

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{personId}"; // Construire l'URL complète pour la ressource à supprimer

                    // Envoyer la requête DELETE à l'API
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    // Vérifier si la requête a réussi
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le plat a été supprimée avec succès !");
                        await GetAllPlats();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la suppression du plat.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une exception s'est produite : " + ex.Message);
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string personId = TBXId.Text; // Récupérer l'ID de la personne à mettre à jour depuis un TextBox ou un autre contrôle WPF
            string newName = TBXNM.Text; // Récupérer le nouveau nom depuis un TextBox ou un autre contrôle WPF
            int newAge = int.Parse(TBXPr.Text); // Récupérer le nouvel âge depuis un TextBox ou un autre contrôle WPF

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{personId}"; // Construire l'URL complète pour la ressource à mettre à jour

                    // Créer un objet contenant les nouvelles données de la personne
                    var updatedPerson = new Plat{ id="",Name = newName, Price = newAge };

                    // Convertir l'objet en JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(updatedPerson);

                    // Créer un contenu JSON à envoyer
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Envoyer la requête PUT à l'API
                    HttpResponseMessage response = await client.PutAsync(url, content);

                    // Vérifier si la requête a réussi
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le menu a été mise à jour avec succès !");
                        await GetAllPlats();

                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la mise à jour du menu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une exception s'est produite : " + ex.Message);
            }
        }
    }
}







        