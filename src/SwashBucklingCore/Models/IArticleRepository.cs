using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwashBucklingCore.Models
{
    public interface IArticleRepository
    {
        void Add(Article article);
        IEnumerable<Article> GetAll();
        Article Find(string id);
        Article Remove(string id);
        void Update(Article article);
    }
    public class ArticleRepository : IArticleRepository
    {
        static ConcurrentDictionary<string, Article> _articles = new ConcurrentDictionary<string, Article>();
        public ArticleRepository()
        {
            Add(new Article { Title = "New Article" });
        }
        
        public void Add(Article article)
        {
            article.Id = Guid.NewGuid().ToString();
            _articles[article.Id] = article;
        }

        public Article Find(string id)
        {
            Article article;
            _articles.TryGetValue(id, out article);
            return article;
        }
        
        public Article Remove(string id)
        {
            Article article;
            _articles.TryGetValue(id, out article);
            _articles.TryRemove(id, out article);
            return article;
        }
        
        public void Update(Article article)
        {
            _articles[article.Id] = article;
        }
        public IEnumerable<Article> GetAll()
        {
            return _articles.Values;
        }
    }
}
