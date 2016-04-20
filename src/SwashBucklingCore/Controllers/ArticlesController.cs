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
        public List<Article> Articles { get; set; }
        ArticlesController()
        {
            Articles.Add(new Article { Id = 1, Title = "Article1", Body = "This is an interestig article", Author = "Shakespeare"});
            Articles.Add(new Article { Id = 2, Title = "Article2", Body = "This is another interestig article", Author = "Sarang"});
        }
        // GET: api/articles
        [HttpGet]
        [SwaggerOperation("GetArticles")]
        public IEnumerable<Article> Get()
        {
            return Articles.ToArray();
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetArticle")]
        public Article Get(int id)
        {
            return Articles.Where(a => a.Id == id).FirstOrDefault();
        }

        // POST api/articles
        [HttpPost]
        [SwaggerOperation("PostArticle")]
        [SwaggerOperationFilter(typeof(ConsumesJsonFilter))]
        public void Post([FromBody]string article)
        {
        }

        // PUT api/articles/5
        [HttpPut("{id}")]
        [SwaggerOperation("PutArticle")]
        [SwaggerOperationFilter(typeof(ConsumesJsonFilter))]
        public void Put(int id, [FromBody]string article)
        {
        }

        // DELETE api/articles/5
        [SwaggerOperation("DeleteArticle")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
