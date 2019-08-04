using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UEditorNetCoreExample.Common;

namespace UEditorNetCoreExample.AOP
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class StaticFileHandlerFilterAttribute : ActionFilterAttribute
    {
        public string Key
        {
            get; set;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //按照一定的规则生成静态文件的名称，这里是按照controller+"-"+action+id规则生成
            string controllerName = context.RouteData.Values["controller"].ToString().ToLower();
            string actionName = context.RouteData.Values["action"].ToString().ToLower();        
            //这里的id默认等于id，当然我们可以配置不同的id名称
            string id = context.RouteData.Values.ContainsKey(Key) ? context.RouteData.Values[Key].ToString() : "";
            if (string.IsNullOrEmpty(Key) && context.HttpContext.Request.Query.ContainsKey(Key))
            {
                id = context.HttpContext.Request.Query[Key];
            }
            if (id=="")
            {
                id= context.HttpContext.Request.Query["id"].FirstOrDefault();
            }
            var articleUpdateTime =new CommonHelper().GetArticleUpdateTime(int.Parse(id));
            //如果异常应该记录日志
            if (articleUpdateTime==DateTime.MinValue)
            {
                return;
            }
            var articleYear = articleUpdateTime.Year.ToString();
            var articleMonth = articleUpdateTime.Month.ToString();
            var articleDay = articleUpdateTime.Day.ToString();
            //文件的地址： 年/月/日/id.html（文件ID 是唯一 的，可以修改为guid）
            string filePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", articleYear, articleMonth , articleDay, id+ ".html");
            //判断文件是否存在
            if (File.Exists(filePath))
            {
                //如果存在，直接读取文件
                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        //通过contentresult返回文件内容
                        ContentResult contentresult = new ContentResult();
                        contentresult.Content = sr.ReadToEnd();
                        contentresult.ContentType = "text/html";
                        context.Result = contentresult;
                    }
                }
            }



        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //获取结果
            IActionResult actionResult = context.Result;
            //判断结果是否是一个ViewResult
            if (actionResult is ViewResult)
            {
                ViewResult viewResult = actionResult as ViewResult;
                //下面的代码就是执行这个ViewResult，并把结果的html内容放到一个StringBuiler对象中
                var services = context.HttpContext.RequestServices;
                var executor = services.GetRequiredService<IActionResultExecutor<ViewResult>>() as ViewResultExecutor
    ?? throw new ArgumentNullException("executor");
                var option = services.GetRequiredService<IOptions<MvcViewOptions>>();
                var result = executor.FindView(context, viewResult);
                result.EnsureSuccessful(originalLocations: null);
                var view = result.View;
                StringBuilder builder = new StringBuilder();

                using (var writer = new StringWriter(builder))
                {
                    var viewContext = new ViewContext(
                        context,
                        view,
                        viewResult.ViewData,
                        viewResult.TempData,
                        writer,
                        option.Value.HtmlHelperOptions);

                    view.RenderAsync(viewContext).GetAwaiter().GetResult();                    
                    writer.Flush();
                }
                //按照规则生成静态文件名称
             
                string id = context.RouteData.Values.ContainsKey(Key) ? context.RouteData.Values[Key].ToString() : "";
                if (string.IsNullOrEmpty(Key) && context.HttpContext.Request.Query.ContainsKey(Key))
                {
                
                    id = context.HttpContext.Request.Query[Key];
                }
                if (id == "")
                {
                    //Get请求 url 链接方式
                    id = context.HttpContext.Request.Query["id"].FirstOrDefault();
                }
              
                var articleUpdateTime = new CommonHelper().GetArticleUpdateTime(int.Parse(id));
                if (articleUpdateTime == DateTime.MinValue)
                {
                    return;
                }
                var articleYear = articleUpdateTime.Year.ToString();
                var articleMonth = articleUpdateTime.Month.ToString();
                var articleDay = articleUpdateTime.Day.ToString();
                string devicedir = Path.Combine(AppContext.BaseDirectory, "wwwroot", articleYear, articleMonth, articleDay);
                if (!Directory.Exists(devicedir))
                {
                    Directory.CreateDirectory(devicedir);
                }

                //写入文件
                string filePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", articleYear, articleMonth, articleDay, id+ ".html");
                using (FileStream fs = File.Open(filePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.Write(builder.ToString());
                    }
                }
                //更新Aritcle 的一个静态url
                var isOK = new CommonHelper().UpdateHtml(int.Parse(id), filePath);
                //输出当前的结果
                ContentResult contentresult = new ContentResult();
                contentresult.Content = builder.ToString();
                contentresult.ContentType = "text/html";
                context.Result = contentresult;
            }


        }
        
    }
}
