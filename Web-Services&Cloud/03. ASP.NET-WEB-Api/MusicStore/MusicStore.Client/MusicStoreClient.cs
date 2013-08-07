using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MusicStore.Client
{
    //Note: Please dont forget to change the connection string in the App.config and Web.congif files. Thank you ! 

    class MusicStoreClient
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:15847/")
            };

            client.DefaultRequestHeaders.Accept.Add(new
               MediaTypeWithQualityHeaderValue("application/json"));

            //Create objects

            //Calling the create methods several times to populate the DB with some info

            CreateAlbum(client);

            CreateArtist(client, 1);

            CreateSong(client, 1, 1);


            CreateAlbum(client);

            CreateArtist(client, 1);

            CreateSong(client, 1, 1);


            CreateAlbum(client);

            CreateArtist(client, 1);

            CreateSong(client, 1, 1);

            //Get all objects from the DB

            GetAllSongs(client);

            GetAllArtists(client);

            GetAlbums(client);

            //Get object by ID from the DB

            GetAlbumById(client, 1);

            GetSongById(client, 2);

            GetArtistById(client, 3);

            //Update given object 

            UpdateArtist(client, 2);

            UpdateAlbum(client, 2);

            UpdateSongs(client, 2);

            //Delete Given Object

            //Please note that if the ID might is be present you will receive 404. Check in the DB for existing ID-s and try again. 

            //Cascade deleting is enabled for Albums eg. all related artists and songs are deleted as well. 
            DeleteAlbum(client, 2);

            DeleteArtist(client, 3);

            DeleteSong(client, 1);
        }

        private static void CreateSong(HttpClient client, int artistId, int albumId)
        {
            var song = new Song()
            {
                TItle = "New Created Song",
                Ganre = "some ganre",
                Date = DateTime.Now,
                ArtistId = artistId,
                AlbumId = albumId
            };

            var response = client.PostAsJsonAsync<Song>("api/songs", song).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success creating Song");
            }

            else
                ShowError(response);
        }

        private static void CreateAlbum(HttpClient client)
        {
            var album = new Album()
            {
                Name = "Black Friday",
                Producer = "Gosho",
                Date = DateTime.Now
            };

            var response = client.PostAsJsonAsync<Album>("api/albums", album).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success creating Album");
            }

            else
                ShowError(response);
        }


        private static void CreateArtist(HttpClient client, int albumId)
        {
            var artist = new Artist()
            {
                Name = "Pesho",
                Country = "Bulgaria",
                DateOfBirth = new DateTime(1980, 1, 1),
                AlbumId = albumId
            };

            var response = client.PostAsJsonAsync<Artist>("api/artists", artist).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success creating Artis");
            }

            else
                ShowError(response);
        }

        private static void DeleteAlbum(HttpClient client, int id)
        {
            var response = client.DeleteAsync(string.Format("api/albums/{0}", id)).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success deleting Albums with ID: {0}", id);
            }

            else
                ShowError(response);
        }

        private static void DeleteArtist(HttpClient client, int id)
        {
            var response = client.DeleteAsync(string.Format("api/artists/{0}", id)).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success deleting Artists with ID: {0}", id);
            }

            else
                ShowError(response);
        }

        private static void DeleteSong(HttpClient client, int id)
        {
            var response = client.DeleteAsync(string.Format("api/songs/{0}", id)).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success deleting Song with ID: {0}", id);
            }

            else
                ShowError(response);
        }

        private static void UpdateSongs(HttpClient client, int id)
        {
            HttpResponseMessage originalResponce = client.GetAsync("api/songs/" + id + "").Result;

            var originalSong = originalResponce.Content.ReadAsAsync<Song>().Result;
            originalSong.TItle = "Some Song Name";
            var response = client.PostAsJsonAsync<Song>(string.Format("api/songs/{0}", id), originalSong).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success edditing Song with ID: {0}", id);
            }

            else
                ShowError(response);
        }

        private static void UpdateAlbum(HttpClient client, int id)
        {
            HttpResponseMessage originalResponce = client.GetAsync("api/albums/" + id + "").Result;

            var originalAlbum = originalResponce.Content.ReadAsAsync<Album>().Result;
            originalAlbum.Name = "Some Name";
            var response = client.PostAsJsonAsync<Album>(string.Format("api/albums/{0}", id), originalAlbum).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success edditing Album with ID: {0}", id);
            }

            else
                ShowError(response);
        }

        private static void UpdateArtist(HttpClient client, int id)
        {
            HttpResponseMessage originalResponce = client.GetAsync("api/artists/" + id + "").Result;

            var originalArtist = originalResponce.Content.ReadAsAsync<Artist>().Result;
            originalArtist.Name = "Stamat";
            var response = client.PostAsJsonAsync(string.Format("api/artists/{0}", id), originalArtist).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success edditing Artist with ID: {0}", id);
            }

            else
                ShowError(response);
        }

        private static void GetArtistById(HttpClient client, int id)
        {
            HttpResponseMessage response =
            client.GetAsync("api/artists/" + id + "").Result;

            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                Console.WriteLine("Artist  Name: " + artist.Name);
                Console.WriteLine("Artist Country: " + artist.Country);
                Console.WriteLine("Artist Date of Birth: " + artist.DateOfBirth);

                Console.WriteLine(new string('-', 35));
            }

            else
                ShowError(response);
        }

        private static void GetSongById(HttpClient client, int id)
        {
            HttpResponseMessage response =
            client.GetAsync("api/songs/" + id + "").Result;

            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;

                Console.WriteLine("Song Title: {0}", song.TItle);
                Console.WriteLine("Song Ganre: {0}", song.Ganre);
                Console.WriteLine("Song Date: {0}", song.Date);

                Console.WriteLine(new string('-', 35));
            }

            else
                ShowError(response);
        }

        private static void GetAlbumById(HttpClient client, int id)
        {
            HttpResponseMessage response =
              client.GetAsync("api/albums/" + id + "").Result;

            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                Console.WriteLine("Album Name: {0}", album.Name);
                Console.WriteLine("Album Producer: {0}", album.Producer);
                Console.WriteLine(new string('-', 35));
            }

            else
                ShowError(response);
        }

        private static void GetAlbums(HttpClient client)
        {
            HttpResponseMessage response =
                client.GetAsync("api/albums").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content
                    .ReadAsAsync<IEnumerable<Album>>().Result;

                foreach (var a in albums)
                {
                    Console.WriteLine("Album Name: {0}", a.Name);
                    Console.WriteLine("Artists:");
                    foreach (var artist in a.Artists)
                    {
                        Console.WriteLine(artist.Name);
                    }
                    Console.WriteLine("Album Producer: {0}", a.Producer);
                    Console.WriteLine("Album Year: {0}", a.Date.Value.Year);
                    Console.WriteLine("Songs: ");
                    foreach (var song in a.Songs)
                    {
                        Console.WriteLine(song.TItle);
                    }

                    Console.WriteLine(new string('-', 35));
                }
            }

            else
                ShowError(response);
        }

        private static void GetAllArtists(HttpClient client)
        {
            HttpResponseMessage response =
                client.GetAsync("api/artists").Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content
                    .ReadAsAsync<IEnumerable<Artist>>().Result;

                foreach (var a in artists)
                {
                    Console.WriteLine("Artist Name: {0}", a.Name);
                    Console.WriteLine("Artist Country: {0}", a.Country);
                    Console.WriteLine("Artist Date of Birth: {0}", a.DateOfBirth);
                    Console.WriteLine(new string('-', 35));
                }
            }

            else
                ShowError(response);
        }

        private static void ShowError(HttpResponseMessage response)
        {
            Console.WriteLine("{0} ({1})",
                (int)response.StatusCode, response.ReasonPhrase);
        }

        private static void GetAllSongs(HttpClient client)
        {
            HttpResponseMessage response =
                client.GetAsync("api/Songs").Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content
                    .ReadAsAsync<IEnumerable<Song>>().Result;

                foreach (var s in songs)
                {
                    Console.WriteLine("Song Name: {0}", s.TItle);
                    Console.WriteLine("Artist Name: {0}", s.Artist.Name);
                    Console.WriteLine("Album Name: {0}", s.Album.Name);
                    Console.WriteLine(new string('-', 35));
                }
            }

            else
                ShowError(response);
        }
    }
}
