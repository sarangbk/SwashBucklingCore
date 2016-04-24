using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using SwashBucklingCore.Models;
 
namespace SwashBucklingCore.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        //This property will be injected from the services configured in Startup.cs
        [FromServices]
        public IArticleRepository Articles { get; set; }

        // GET: api/articles
        [HttpGet]
        [SwaggerOperation("GetArticles")]
        public IEnumerable<Article> Get()
        {
            return Articles.GetAll();
        }

        // GET api/article/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetArticle")]
        public IActionResult Get(string id)
        {
            var article = Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound(string.Format("Article id {0} not found", id));
            }
            return new ObjectResult(article);
        }

        // POST api/article
        [HttpPost]
        [SwaggerOperation("PostArticle")]
        [SwaggerOperationFilter(typeof(ConsumesJsonFilter))]
        public void Post([FromBody]string article)
        {
        }

        // PUT api/article/5
        [HttpPut("{id}")]
        [SwaggerOperation("PutArticle")]
        [SwaggerOperationFilter(typeof(ConsumesJsonFilter))]
        public IActionResult Put(string id, [FromBody]Article article)
        {
            if(article == null || article.Id != id)
            {
                return HttpBadRequest();
            }
            var articleToUpdate = Articles.Find(id);
            if(articleToUpdate == null)
            {
                return HttpNotFound(string.Format("Cannot find Article with id {0}", id));
            }
            Articles.Update(article);
            return new HttpOkResult();

        }

        // DELETE api/article/5
        [SwaggerOperation("DeleteArticle")]
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Articles.Remove(id);
        }
    }
}
