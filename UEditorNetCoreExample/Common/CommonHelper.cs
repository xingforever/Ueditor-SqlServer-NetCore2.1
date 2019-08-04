using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UEditorNetCore.IService;
using UEditorNetCore.Service;

namespace UEditorNetCoreExample.Common
{
    public class CommonHelper
    {
        public readonly IArticleService _articleService;
        public  CommonHelper()
        {
            this._articleService = new ArticleService();
        }
        public DateTime GetArticleUpdateTime(int id)
        {
            var article = _articleService.GetById(id);
            if (article!=null)
            {
                return article.UpdateTime;
            }
            return DateTime.MinValue;
        }

        public bool DeleteHtml(int id)
        {
            var article = _articleService.GetById(id);
            if (article != null)
            {
                var filepath = article.htmlUrl;
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                    return true;
                }

            }
            return false;
        }
        public bool  UpdateHtml(int id,string url)
        {
            var article = _articleService.GetById(id);
            if (article != null)
            {
                article.htmlUrl = url;
                return _articleService.Update(article);
            }
           
            return false;
        }

    

    }
}
