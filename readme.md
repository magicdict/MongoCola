#Release Note
       
* 可执行版本[需要 NET Framework 4.6] 更新时间:2016/06/18 16:00
* 下载地址:  <http://files.cnblogs.com/files/TextEditor/ReleaseVersion.zip>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* 版本号：Ver 2.0.0
 
***

# 开发和测试环境
## 操作系统：
* Windows 7
* Mac OSX 10.11.2

***

## 运行时：
* NET Framework 4.6
* Mono 4.5
* MongoDB 3.2.7 

***

## 驱动程序
CSharp Mongo Driver 2.2.4

***

# 项目说明
* ExternalTools:外部工具  
1. ConfigurationFile 配置文件编辑器
2. MultiLanEditor 多语言文件编辑器
* Assistant:业务逻辑和辅助类  
* Winform:窗体和控件  

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
***

# 发布履历
##Ver 2.0 2016/06/29
1.Query增加了删除条件的功能
2.修正了Query的一些错误
3.机器学习：线性回归
4.AuthMechanism

##Ver 1.5 (Beta3)  2016/04/25
以下 更新来自于   QiQi  https://github.com/1354092549


1. 优化聚合功能
-  对齐组件，更美观
-  优化聚合管道（Aggregate）相关功能，和Mongodb官方统一，使用名词stage
-  Add Stage（应用第2条前的Add Aggregate）支持提供数组，用于一次添加多个stage
2. 优化中文语言包

##Ver 1.5(Beta2)  2016/02/17 @ Shanghai China 
###感谢 张鹏 zp11qm12#hotmail.com 对于1，2，3点的贡献
1. 修复了collection中数据删除不掉的bug（id应强转为ObjectId）
2. 修改了ctlJsEditor界面，现可直接执行已经保存的javascript代码（我的团队需要这个功能）
3. 添加了复制数据库的功能（其实是复制表，目的是为了同步javascript代码）
4. CSharp Mongo Driver 2.2.3
5. GFS修复重构后没有处理的功能

***

##Ver 1.5(Beta)  2015/12/31 @ Shanghai China 
###MongoDB 3.2.0 新功能对应版本
1. Text Search V3 的对应：大小写敏感
2. Partial Index 的创建  
3. 独立外部工具 Configuration Creator 初版
4. 创建Collection时候可以设定DocumentValidation参数
5. MongoDump 增加 --gzip --archive
6. 修复添加Collection后UI没有实时更新的BUG 

***

##Ver 1.5(Alpha)  2015/07/09 @ Shanghai China
1. 重构代码，Mongo业务代码和界面代码分开
2. 新代码尽可能适配MongoDriver2.0.1
3. MongoServer尽可能用MongoClient代替
4. 窗体TabPage管理功能的独立化
5. TextSearch功能的修改（MongoDB 2.6之后使用不同的方法）
6. 各种Status改用树型结构表示
7. 新建数据库无效,删除数据库错误等问题.

***

# 已知BUG
1. 新建数据库时,必须要新建一个数据集.
2. MONO  Windows API Crash!
3. ZedGraph For Mono Chart
4. Status里面的列无效，MMVP和WireTiger数据集状态不同
5. MongoBin没有设置的时候，非Windows的时候，Cmd命令无法执行的问题
6. User命令未完成
[Fixed]7. JS文件等不应该保存到Mongo数据库中，如果没有获得客户允许的时候（张鹏修复了这个问题）
