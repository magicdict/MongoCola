#MongoCola
       
* 可执行版本 Windows Client[需要 NET Framework 4.6.2] 更新时间:2016/11/24 16:00
* Net Core版本 Browse Base Client[需要 NET Core1.0.1] 更新时间:2016/11/24 16:00
* 下载地址:  <https://github.com/magicdict/MongoCola/releases>
* 用户手册： <http://www.codesnippet.info/Article/Index?ArticleId=00000062>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* GitPage 官网 <http://magicdict.github.io/MongoCola/>
* 版本号：Ver 2.0.5
 
***

# 开发和测试环境
## 操作系统：
* Windows 7
* Mac OSX 10.12

***

## 运行时：
* NET Framework 4.6.2
* NET Core 1.1.10
* MongoDB 3.4.0-rc2 

***

## 驱动程序
CSharp Mongo Driver 2.4.0-beta1

***

# 项目说明
C#的代码分为两个解决方案：

- MongoCola解决方案
* ExternalTools:外部工具  
1. ConfigurationFile 配置文件编辑器
2. MultiLanEditor 多语言文件编辑器
* Assistant:业务逻辑和辅助类  
* Winform:窗体和控件  
* PlugIn：插件

- MongoCola.Core解决方案
1. MongoUtilityCore：MongoUtility的.Net Core编译配置
2. MongoColaWebAdmin:Asp.Net Core版的网页版程序

# 计划
0. Fix Bug  
	解决所有发现的Bug 
1. Config Options  
	一个MongoService用Config File文件的生成工具 
2. 扩大Model.TryUpdate的使用范围  
	Winform使用了MVC的概念，自动将Model和UI双向绑定
	已经在frmConnnection/frmOption里面尝试了
3. MutliLanguage  
	进一步改进多语言系统
4. User System  
	用户系统
5. Machine Learning
    加入对于机器学习方法和BI的支持
6. SQL转AggregateFrame
	原本不完整的SQL转AggregateFrame废止
7. 服务器读写状态的实时报表：MongoStatus 和 MongoTop，需要进行强化
8. C#直接操作MongoShell

***
