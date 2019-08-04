using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UEditorNetCore.Model.Entity
{
  public   class Article
    {
        public  int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public  string Title { get; set; }
        [Required]
        public  string Context { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public  DateTime UpdateTime { get; set; }
        /// <summary>
        /// 生成静态文件Html
        /// </summary>
        public  string htmlUrl { get; set; }
    }
}
