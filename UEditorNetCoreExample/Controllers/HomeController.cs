using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UEditorNetCore.IService;
using UEditorNetCore.Model.Entity;
using UEditorNetCore.Model.OtherModel;
using UEditorNetCoreExample.AOP;
using UEditorNetCoreExample.Common;
using UEditorNetCoreExample.Models;

namespace UEditorNetCoreExample.Controllers
{
    public class HomeController : Controller
    {
        public readonly IArticleService articleService;

        public CommonHelper commonHelper = new CommonHelper();
        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        /// <summary>
        /// 查看结果html
        /// </summary>
        /// <returns></returns>
        [StaticFileHandlerFilterAttribute(Key ="id")]
        public IActionResult Show(int id)
        {
            var res = articleService.GetById(id);
            if (res == null)
            {
                JsonResult jsonResult1 = new JsonResult(new AjaxResult() { status = "fail", errorMsg = "不存在该文章" });
                return jsonResult1;
            }
            return View(res);
        }
      

        /// <summary>
        /// 展示Demo
        /// </summary>
        /// <returns></returns>
        public IActionResult Demo()
        {
            return View();
        }
        /// <summary>
        /// 查看列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            var res = articleService.GetList();
            return View(res);
        }
        /// <summary>
        /// 添加文章界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Article model)
        {
            if (ModelState.IsValid)
            {
               
                var res =articleService.Add(model);
                if (res!=null)
                {
                    JsonResult jsonResult1 = new JsonResult(new AjaxResult(){ status = "success" });
                    return jsonResult1;
                }
            }
            return View();
        }
        /// <summary>
        /// 修改文章界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  IActionResult Detail(int id)
        {
            var res = articleService.GetById(id);
            if (res==null)
            {
                JsonResult jsonResult1 = new JsonResult(new AjaxResult() { status = "fail",errorMsg="不存在该文章" });
                return jsonResult1;
            }
          
            return View(res);
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(Article model)
        {
            //删除html
            var isDelete = commonHelper.DeleteHtml(model.Id);
            //如果异常 记录日志
            var isok = articleService.Update(model);
            if (isok)
            {
              
               
                JsonResult jsonResult = new JsonResult(new AjaxResult() { status = "success" });
                return jsonResult;
            }
            JsonResult jsonResult1 = new JsonResult(new AjaxResult() { status = "fail", errorMsg = "更新失败" });
            return jsonResult1;
        }
        /// <summary>
        /// 根据ID 硬删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult Delete(int id)
        {
            var isOK = articleService.Delete(id);
            if (isOK)
            {

                JsonResult jsonResult = new JsonResult(new AjaxResult() { status = "success"});
                return jsonResult;
            }
            JsonResult jsonResult1 = new JsonResult(new AjaxResult() { status = "fail", errorMsg = "更新失败" });
            return jsonResult1;
        }






        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
