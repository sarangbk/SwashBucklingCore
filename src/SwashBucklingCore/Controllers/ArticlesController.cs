using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
 
namespace SwashBucklingCore.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        // GET: api/articles
        [HttpGet]
        [SwaggerOperation("GetArticles")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Article1", "Article2" };
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        [SwaggerOperation("GetArticle")]
        public string Get(int id)
        {
            return "Article";
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
