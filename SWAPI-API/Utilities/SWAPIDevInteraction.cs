using System;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using SWAPI_API.Models;

namespace SWAPI_API.Utilities
{
    public class SWAPIDevInteraction
    {
        public SWAPIDevInteraction()
        {
        }

        private enum HttpMethod
        {
            GET,
            POST
        }

        private readonly string apiUrl = "http://swapi.dev/api";
        private readonly string _proxyName;


        public SWAPIDevInteraction(string proxyName)
        {
            _proxyName = proxyName;
        }

        #region Private

        private string Request(string url, HttpMethod httpMethod)
        {
            return Request(url, httpMethod, null, false);
        }

        private string Request(string url, HttpMethod httpMethod, string data, bool isProxyEnabled)
        {
            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            if (!String.IsNullOrEmpty(_proxyName))
            {
                httpWebRequest.Proxy = new WebProxy(_proxyName, 80);
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }

            if (data != null)
            {
                byte[] bytes = UTF8Encoding.UTF8.GetBytes(data.ToString());
                httpWebRequest.ContentLength = bytes.Length;
                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Dispose();
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
            result = reader.ReadToEnd();
            reader.Dispose();

            return result;
        }

        private string SerializeDictionary(Dictionary<string, string> dictionary)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                parameters.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }




        private T GetSingle<T>(string endpoint, Dictionary<string, string> parameters = null) where T : StarWarsCategory
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            return GetSingleByUrl<T>(url: string.Format("{0}{1}{2}", apiUrl, endpoint, serializedParameters));
        }

        private StarWarsCategoryResults<T> GetMultiple<T>(string endpoint) where T : StarWarsCategory
        {
            return GetMultiple<T>(endpoint, null);
        }

        private StarWarsCategoryResults<T> GetMultiple<T>(string endpoint, Dictionary<string, string> parameters) where T : StarWarsCategory
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            string json = Request(string.Format("{0}{1}{2}", apiUrl, endpoint, serializedParameters), HttpMethod.GET);
            StarWarsCategoryResults<T> swapiResponse = JsonConvert.DeserializeObject<StarWarsCategoryResults<T>>(json);
            return swapiResponse;
        }

        private NameValueCollection GetQueryParameters(string dataWithQuery)
        {
            NameValueCollection result = new NameValueCollection();
            string[] parts = dataWithQuery.Split('?');
            if (parts.Length > 0)
            {
                string QueryParameter = parts.Length > 1 ? parts[1] : parts[0];
                if (!string.IsNullOrEmpty(QueryParameter))
                {
                    string[] p = QueryParameter.Split('&');
                    foreach (string s in p)
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(temp[0], temp[1]);
                        }
                        else
                        {
                            result.Add(s, string.Empty);
                        }
                    }
                }
            }
            return result;
        }

        private StarWarsCategoryResults<T> GetAllPaginated<T>(string entityName, string pageNumber = "1") where T : StarWarsCategory
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            StarWarsCategoryResults<T> result = GetMultiple<T>(entityName, parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        private StarWarsCategoryResults<T> GetEverything<T>(string entityName) where T : StarWarsCategory
        {
            List<T> result = new List<T>();
            bool keepGoing = true;
            int page = 1;
            while (keepGoing)
            {
                StarWarsCategoryResults<T> results = GetAllPaginated<T>(entityName, page.ToString());
                {
                    results.results.ForEach(r => result.Add(r));

                    if (String.IsNullOrEmpty(results.next))
                    {
                        keepGoing = false;
                    }

                    page = page + 1;

                }
            }
            StarWarsCategoryResults<T> swapiResult = new StarWarsCategoryResults<T>();
            swapiResult.results = result;
            swapiResult.count = result.Count();

            return swapiResult;
            
        }

            #endregion

            #region Public

            /// <summary>
            /// get a specific resource by url
            /// </summary>
            public T GetSingleByUrl<T>(string url) where T : StarWarsCategory
            {
                string json = Request(url, HttpMethod.GET);
                T swapiResponse = JsonConvert.DeserializeObject<T>(json);
                return swapiResponse;
            }

            // People
            /// <summary>
            /// get a specific people resource
            /// </summary>
            public Person GetPerson(string id)
            {
                return GetSingle<Person>("/people/" + id);
            }

            public Person GetPersonByName(string name)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("name", name.ToString());
                return GetSingle<Person>("/people/", parameters);
            }

            /// <summary>
            /// get all the people resources
            /// </summary>
            public StarWarsCategoryResults<Person> GetAllPeople()
            {
                StarWarsCategoryResults<Person> result = GetEverything<Person>("/people/");

                return result;
            }

            //// Film
            //// <summary>
            //// get a specific film resource
            /// </summary>
            //public Film GetFilm(string id)
            //{
            //    return GetSingle<Film>("/films/" + id);
            //}

            /// <summary>
            /// get all the film resources
            /// </summary>
            public StarWarsCategoryResults<Film> GetAllFilms()
            {
                StarWarsCategoryResults<Film> result = GetEverything<Film>("/films/");

                return result;
            }

        // Planet
        /// <summary>
        /// get a specific planet resource
        /// </summary>
        //public Planet GetPlanet(string id)
        //{
        //    return GetSingle<Planet>("/planets/" + id);
        //}

        /// <summary>
        /// get all the planet resources
        /// </summary>
        public StarWarsCategoryResults<Planet> GetAllPlanets()
        {
            StarWarsCategoryResults<Planet> result = GetEverything<Planet>("/planets/");

            return result;
        }

        // Specie
        /// <summary>
        /// get a specific specie resource
        /// </summary>
        //public Species GetSpecie(string id)
        //{
        //    return GetSingle<Species>("/species/" + id);
        //}

        /// <summary>
        /// get all the specie resources
        /// </summary>
        public StarWarsCategoryResults<Species> GetAllSpecies(string pageNumber = "1")
            {
                StarWarsCategoryResults<Species> results = GetEverything<Species>("/species/");

                return results;
            }

            // Starship
            /// <summary>
            /// get a specific starship resource
            /// </summary>
            public Starship GetStarship(string id)
            {
                return GetSingle<Starship>("/starships/" + id);
            }

            /// <summary>
            /// get all the starship resources
            /// </summary>
            public StarWarsCategoryResults<Starship> GetAllStarships()
            {
                StarWarsCategoryResults<Starship> result = GetEverything<Starship>("/starships/");

                return result;
            }

            //// Vehicle
            ///// <summary>
            ///// get a specific vehicle resource
            ///// </summary>
            //public Vehicle GetVehicle(string id)
            //{
            //    return GetSingle<Vehicle>("/vehicles/" + id);
            //}

            ///// <summary>
            ///// get all the vehicle resources
            ///// </summary>
            //public StarWarsCategoryResults<Vehicle> GetAllVehicles(string pageNumber = "1")
            //{
            //    StarWarsCategoryResults<Vehicle> result = GetAllPaginated<Vehicle>("/vehicles/", pageNumber);

            //    return result;
            //}

            #endregion
        

    }

}