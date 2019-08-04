using System;
using System.Collections.Generic;
using UEditorNetCore.Model.Entity;

namespace UEditorNetCore.IService
{
    public interface IArticleService
    {
        Article Add(Article model);
        Article GetById(int id);
        bool  Update(Article model);
        bool Delete(int id);

        IEnumerable<Article> GetList();
    }
}
