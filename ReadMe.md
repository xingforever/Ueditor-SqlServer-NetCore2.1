UEditorNetCoreExample Demo说明：

 一个ASP.NET Core 2.1 使用Ueditor 写文章 ，展示的例子，Demo 基于https://github.com/chenderong/UEditorNetCore 进行 修改。

主要内容有：

1使用Sql server进行文章存取 ,并采用EFCore ORM 框架

2 实现文章的添加，修改，查询，删除（基于Bootstrap,LayUI）

3 实现基于文章的更新时间而生成静态文件 （修改后未进行静态文件删除，用与Demo ,未细究）

**一  展示页面：**

1 程序结构：

![1564904898485](C:\Users\Xmap00\AppData\Roaming\Typora\typora-user-images\1564904898485.png)



1 List

![1564904862206](C:\Users\Xmap00\AppData\Roaming\Typora\typora-user-images\1564904862206.png)



2 Add

![1564904944830](C:\Users\Xmap00\AppData\Roaming\Typora\typora-user-images\1564904944830.png)

2 Edit

![1564904973977](C:\Users\Xmap00\AppData\Roaming\Typora\typora-user-images\1564904973977.png)



3 展示

![1564905105811](C:\Users\Xmap00\AppData\Roaming\Typora\typora-user-images\1564905105811.png)





4 静态文件 （存于bin文件夹下， 规则为文章更新日期）

![1564905200842](C:\Users\Xmap00\AppData\Roaming\Typora\typora-user-images\1564905200842.png)



**二配置方法：**

确保 项目生成成后，进行数据库创建

使用CodeFirst 模式创建数据库，建立Article表：

![数据库表](https://github.com/xingforever/Article-s-CURD-By-UEditor-/blob/master/img/1564904202761.png "Article")

在程序中：

1 appsettings.json 中 修改ConnectionStrings为自己本地数据库连接

2 UEditorNetCore.Model 的MyContext 类中OnConfiguring方法 更改 本地数据库连接

 3 在更改数据完毕后 ：在 程序包管理中，项目选择Model,输入命令：add-migration "first" 而后输入"update-database"



![输入命令](https://github.com/xingforever/Article-s-CURD-By-UEditor-/blob/master/img/1564904405562.png "数据库生成")

此时 sql server 数据库生成

**说明：**

改程序为ASP.NET Core 2.1 使用UEditor的例子 ，为了简单化，很多优化没有做。由于时间关系，还没有写博客进行细究如有疑问可以发邮件：1003863495@qq.com