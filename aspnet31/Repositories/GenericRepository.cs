using aspnet31.Context;
using aspnet31.Models;
using aspnet31.Repositories.Data;
using aspnet31.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace aspnet31.Repositories
{
    public class GenericRepository<TModel, TPrimaryKey> : IGenericRepository<TModel, TPrimaryKey>
        where TModel : class
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        internal readonly string uriBase = "https://localhost:44318/api/";
        private string modelName;
        IHttpContextAccessor accessor = null;
        HttpClient client = null;

        public GenericRepository(string modelName)
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            this.modelName = modelName;
            accessor = new HttpContextAccessor();
            client = new HttpClient(); 
            client.BaseAddress = new Uri(uriBase);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessor.HttpContext.Session.GetString("JWToken"));
        }

        #region delete
        public int Delete(TPrimaryKey id)
        {
            using (client)
            {
                var deleteTask = client.DeleteAsync(modelName+"/"+id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }
        }
        #endregion delete

        #region get
        public List<TModel> Get()
        {
            List<TModel> storedData = null;
            using (client)
            {
                var responseTask = client.GetAsync(modelName);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var data = parsedObject["data"].ToString();

                    storedData = JsonConvert.DeserializeObject<List<TModel>>(data);
                }
            }
            return storedData;
        }
        #endregion get

        #region getById
        public TModel Get(TPrimaryKey id)
        {
            TModel storedData = null;
            using (client)
            {
                client.BaseAddress = new Uri(uriBase);
                var responseTask = client.GetAsync(modelName+"/"+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var data = parsedObject["data"].ToString();

                    storedData = JsonConvert.DeserializeObject<TModel>(data);
                }
                else
                {
                    storedData = null;
                }
            }

            return storedData;
        }
        #endregion getById

        #region Create
        public int Post(TModel model)
        {
            var test = model;
            using (client)
            {
                client.BaseAddress = new Uri(uriBase+modelName);

                var postTask = client.PostAsJsonAsync<TModel>(modelName, model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion Create

        #region Edit
        public int Put(TModel model)
        {
            using (client)
            {
                client.BaseAddress = new Uri(uriBase + modelName);

                var putTask = client.PutAsJsonAsync<TModel>(modelName, model);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion Edit
    }
}
