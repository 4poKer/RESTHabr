using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebHabrParser.Models;

namespace WebHabrParser.Controllers
{
    public class ArticlesController : ApiController
    {

        public IEnumerable<HabrArticle> GetAllArticles()
        {
            return HabrArticleController.GetData();
        }

        public HabrArticle GetArticle(int id)
        {
            var habrArticle = HabrArticleController.GetDataById(id);

            if (habrArticle == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };

                throw new HttpResponseException(resp);
            }

            return habrArticle;
        }

        [HttpPost]
        public void CreateArticle([FromBody]HabrArticle article)
        {
           HabrArticleController.AddData(article);
        }

        public void DeleteArticle(int id)
        {
            HabrArticleController.DeleteData(id);
        }

    }
}
