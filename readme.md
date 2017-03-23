#MongoCola
MongoCola是一款帮助你在图形界面下查看，操作MongoDB的工具类软件。  
本工具的目标是尽量用图形界面来代替命令脚本帮您完成一些日常的MongoDB管理工作。  
* 本软件是完全免费的软件，您可以无条件的使用本软件的任何功能。         
* 下载地址:  <https://github.com/magicdict/MongoCola/releases>
* 用户手册： <http://www.codesnippet.info/Article/Index?ArticleId=00000062>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* GitPage 官网 <http://magicdict.github.io/MongoCola/>
* 版本号：Ver 2.1.1
 
***

# 开发和测试环境
## 操作系统：
* Windows 7
* Mac OSX 10.12(UI效果不是很好)

***

## 运行时：
* NET Framework 4.6.2
* NET Core 1.1.10
* MongoDB 3.4.2

***

## 驱动程序
CSharp Mongo Driver 2.4.3

***

# 重要事项

MongoCola项目的App.config里面不要写任何东西。特别是私有路径，原因如下。  
在Mongo Driver中会使用到System.Runtime.InteropServices.RuntimeInformation.dll这个动态连接库。  
而如果你的插件项目也有需要RuntimeInformation这个库，请一定要保证设定私有路径，不然会参照MongoDriver的这个库。  
但是，你只能在自己的项目里面设定，不能在MongoCola主项目里面设定。  
同时MongoUtility项目，由于要和.Net Core共享代码，一定要注意编译条件是否设定，特别是VS版本更新的时候，可能造成编译条件的缺失。  

由于该软件的核心动态链接库需要在WebPage和Winform中使用，在当前阶段的开发者，请一定注意以下几点：

使用Nuget包的net463版本的DLL(Nuget包版本是4.1.0，注意，是一个0！！！)

- System.Linq.dll (4.1.0.0)
- System.Linq.Expressions.dll (4.1.0.0)

需要加入Nuget包

- System.Runtime.dll （4.1.0.0）
- System.Runtime.Extensions.dll 4.1.0.0）
- System.Runtime.InteropServices.RuntimeInformation.dll （4.0.0.0）
- System.Xml.ReaderWriter.dll (4.1.0.0)

MongoUtilityStandard正式取代MongoUtility使用在项目里面。
由于二义性问题，只能做两份代码了。MongoUtility作为备份只是放着，但是不进行编辑了。

# 项目说明
C#的代码分为三个解决方案： 

- MongoCola解决方案 
* Assistant:业务逻辑和辅助类  
* Winform:窗体和控件  
* PlugIn：插件基类  
 
- ExternalTools:解决方案     
1. ConfigurationFile 配置文件编辑器  
2. MultiLanEditor 多语言文件编辑器  
3. 插件实现  

- MongoCola.Core解决方案  
1. MongoUtilityStandard：MongoUtility的.Net Core编译配置  （VS15构成OK）
2. MongoColaWebAdmin:Asp.Net Core版的网页版程序  （VS15重新构成出错）

- Master Slave Replication的废除  
从MongoDB 3.2开始，官方全面废除主从副本，所以所有主从副本的代码都停止维护，并且从代码中删除。
Deprecated since version 3.2: MongoDB 3.2 deprecates the use of master-slave replication for components of sharded clusters.
详细参见官网：https://docs.mongodb.com/manual/core/master-slave/

- Group功能的废除：
按照MongoDB官方的处理意见，使用Aggregate的Group Pipeline或者MapReduce功能进行代替。

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
	自定义监视组：改组图标的项目都是自定义的
8. C#直接操作MongoShell

***
