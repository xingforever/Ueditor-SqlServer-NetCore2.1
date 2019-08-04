using System;
using System.Collections.Generic;
using System.Linq;
using UEditorNetCore.IService;
using UEditorNetCore.Model;
using UEditorNetCore.Model.Entity;

namespace UEditorNetCore.Service
{
    public class ArticleService : IArticleService
    {
        public Article Add(Article model)
        {
            using (MyContext ctx=new MyContext())
            {
                ctx.Articles.Add(model);
                if (ctx.SaveChanges() > 0)
                {
                    return model;
                }
                else
                {
                    return null;
                }
                    

            }
        }

        public bool Delete(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                var res=ctx.Articles.Where(e => e.Id == id).FirstOrDefault();
                if (res!=null)
                {
                    ctx.Articles.Remove(res);
                    return ctx.SaveChanges()>0;
                }
                else
                {
                    return false;
                }

            }
        }

        public Article GetById(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                var res = ctx.Articles.Where(e => e.Id == id).FirstOrDefault();
                return res;       
              
            }
        }

        public IEnumerable<Article> GetList()
        {
            using (MyContext ctx = new MyContext())
            {
                var res = ctx.Articles.ToList();
                return res;

            }
        }

        public bool Update(Article model)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Update(model);
                return ctx.SaveChanges() > 0;

            }
        }


       
    }
}
