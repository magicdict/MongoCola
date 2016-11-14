# MongoCola工具
* 可执行版本 Windows Client[需要 NET Framework 4.6.2] 更新时间:2016/11/24 16:00
* Net Core版本 Browse Base Client[需要 NET Core1.0.1] 更新时间:2016/11/24 16:00
* 下载地址:  <https://github.com/magicdict/MongoCola/releases>
* 用户手册： <http://www.codesnippet.info/Article/Index?ArticleId=00000062>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* GitPage 官网 <http://magicdict.github.io/MongoCola/>
* 版本号：Ver 2.0.7
* 文档最后更新时间：2016-11-14

## 开发和测试环境
### 操作系统：
* Windows 7
* Mac OSX 10.12

### 运行时：
* NET Framework 4.6.2
* NET Core 1.1.10
* MongoDB 3.4.0-rc3

### 驱动程序
CSharp Mongo Driver 2.4.0-beta1

## 基本操作
### 第一次启动程序
第一次启动程序(MongoCola.exe)的时候，您可以选择语言：这里我们选择简体中文

![](/FileSystem/Thumbnail?filename=00000001_20161101154414_Language.png)

*语言配置文件放在 Language文件夹中，您可以自己修改翻译。部分翻译没有完成。
- ja_JP.xml 日本语
- zh_CN.xml 简体中文
- zh_TW.xml 繁体中文

###选项说明

接下来你可以对系统进行一些设定：
如果你有MongoDB的客户端工具，请在MongoBin中填写上工具的保存路径。
有一些操作是需要使用这些工具的，例如Import和Export等功能

![](/FileSystem/Thumbnail?filename=00000001_20161108164348_Option.png)

- Language:界面语言
- Font：字体（Mac系统请使用Mac的专用字体，防止乱码出现）
- Monitor Refresh Interval ： 监视程序的采样频率
- Display Number With KMGT：在显示数据的时候，过大的数字是否使用 K，M，G，T这样的字符
- MongoBin：MongoDB客户端工具程序的保存位置
- Guid：Guid的内部保存形式
- TimeZone：使用UTC或者Local来显示时间数据
- DateTimeFormat：时间日期在系统中的显示形式
- JsonOutputMode：Json对象的表示形式，表示日期的时候，形式不一样。

###建立一个数据连接

我们尝试建立一个新的数据库连接，来管理在本地端口28030运行的数据库

![](/FileSystem/Thumbnail?filename=00000001_20161108144631_NewConnection.png)

注意：请不要在连接名称中放入 冒号： 字符

新建之后勾选数据连接之前的复选框，按下确定按钮即可。

![](/FileSystem/Thumbnail?filename=00000001_20161108144752_ConnectionList.png)

你可以使用工具栏按钮将连接转为MongoUri连接字符串。也可以通过工具栏按钮通过MongoUri快速建立连接。

###使用三种视图查看数据
主界面如图所示：左边是数据库结构展示区，右边是数据展示区：

![](/FileSystem/Thumbnail?filename=00000001_20161101160732_MainGUI.png)


- 树形视图（TreeView）
树形视图便于查看数据的阶层构造。
注意：如果是ObjectId类型数据，系统将会展示ObjectId的详细信息：
CreateionTime，Machine，Pid，Increment，TimeStamp
但是这些信息字段实际上是不存在于数据库中的，是通过ObjectId计算出来的。

![](/FileSystem/Thumbnail?filename=00000001_20161102095610_TreeView.png)

- 列表视图
如果数据集的字段整齐，则列表视图将会使用关系型数据那样的二维视图展示数据

![](/FileSystem/Thumbnail?filename=00000001_20161102100153_ListView.png)

- 文本视图
在文本视图中，可以看到数据的JSON格式文本

![](/FileSystem/Thumbnail?filename=00000001_20161102100423_TextView.png)

###新建数据库
如果数据库里面没有任何数据集，则该数据库将自动被系统回收，所以，新建数据库的时候，会要求设定初始数据集。

![](/FileSystem/Thumbnail?filename=00000001_20161102143247_NewDatabase.png)

###新建数据集
软件使用了完全可视化的界面来帮助您新建一个数据集

![](/FileSystem/Thumbnail?filename=00000001_20161104143101_CreateCollection.png)

- 数据集名称前后的空白将被工具自动去除
- 自动Id索引：自动建立一个以Id为字段的索引
- 容量限制Capped
- 排序规则：设置字符串排序规则
- 文档验证功能

![](/FileSystem/Thumbnail?filename=00000001_20161104143323_CreateCollection_Validation.png)


###新建视图
选中某个数据库，然后在右键菜单中选择“添加视图”即可打开视图创建窗体。
你可以使用软件提供的StageBuilder来添加聚合管道条件。

![](/FileSystem/Thumbnail?filename=00000001_20161104103219_CreateView.png)

你也可以使用聚合功能来创建视图：参见[聚合管道命令]
你也可以使用排序规则生成器来创建排序规则：参见[排序规则]

###复制数据库

通过复制数据库命令，可以将数据库中的数据集复制到其他数据库中

![](/FileSystem/Thumbnail?filename=00000001_20161102210138_CopyDataBase.png)

###排序规则生成器

Mongo3.4新增概念：通过设定Collation可以指定字符串比较的时候的具体规则
排序规则生成器可以帮助您自定义排序规则

![](/FileSystem/Thumbnail?filename=00000001_20161104095939_CreateCollation.png)

###服务器监视

你可以同时打开多个服务器监视窗体查看服务器的各种状态

![](/FileSystem/Thumbnail?filename=00000001_20161111095418_Server Monitor.png)

你也可以自定义一系列监视项目，使之同时出现在同一个图表中。（请注意，如果监视项目数值相差太大，图标的表示将会出现一些问题）

![](/FileSystem/Thumbnail?filename=00000001_20161111095615_CustomItems.png)

##索引管理
###索引一览和删除
选中一个你想处理的数据集，通过右键菜单的"索引管理"可以打开索引管理器。
在第一个Tab页，你可以看到当前数据集的所有索引一览。你可以选择索引，然后将其删除。
注意：_id这个索引一般不建议删除

![](/FileSystem/Thumbnail?filename=00000001_20161101161432_IndexMgr_List.png)

###新建索引
建立索引的界面能够帮助您快速建立索引，但是索引建立有很多规则：
例如 Text索引必须建立在BsonString型字段上，地理相关的索引请注意是否为Sphere的字段。

![](/FileSystem/Thumbnail?filename=00000001_20161101161703_IndexMgr_Create.png)

- Ascending ： 升序
- Desceding ： 降序
- Hashed：散列
- Text：文本索引（全文检索必须，只用作用于BsonString型字段）
- GeoSpatial：地理（二维）
- GeoSpatialSpherical：地理（球形）
- GeoSpatialHaystack: 地理(HayStack,GeoHayStack操作必须)

[MongoDB官方索引参考文档](https://docs.mongodb.com/master/indexes/ "MongoDB官方索引参考文档")

##元数据的编辑
###添加或者修改
选中一个元素之后，双击便可进行简单的修改元素值了。
暂时不提供修改元素名的功能

![](/FileSystem/Thumbnail?filename=00000001_20161101163948_CreateElement.png)

- BsonString：字符串
- BsonInt32/BsonInt64 32位/64位整型
- BsonDecimal128 128位整型
- BsonDouble 双精度
- BsonDateTime 日期可以选择，时间为当前时间
- BsonArray 数组
- BsonDocument 文档，具体参考【插入文档】
- BsonGeo 地理数据

![](/FileSystem/Thumbnail?filename=00000001_20161102205658_GeoJSON.png)

注意：半球坐标，使用WGS84坐标系 经度纬度的取值范围：经度 [-180,180] ,纬度[-90,90]

- BsonMaxKey Sharding用最大值
- BsonMinKey Sharding用最小值
- BsonBinary Base64的数据 注意：请直接填写内容即可，系统自动进行转换

![](/FileSystem/Thumbnail?filename=00000001_20161102093738_BsonBinary.png)

- BsonUndifined （测试用，请不要选择）

###文档的插入

![](/FileSystem/Thumbnail?filename=00000001_20161108164848_NewDocument.png)

- 实际使用中，如果希望系统生成"_id"字段，则请不要添加"_id"字段
- 建议使用预览功能来验证数据格式然后再进行添加操作
- 预览之后显示的文本，可以通过选项JsonOutput来进行设定

##聚合功能

选择任意一个数据集之后在右键菜单中可以找到聚合命令的入口

###基本聚合
Count 由于功能过于简单没有单独做成窗体。
Group功能按照MongoDB官方最新文档的指导,建议使用MapReduce或者Aggregate框架的Group功能实现

- Distinct

![](/FileSystem/Thumbnail?filename=00000001_20161102144741_Distinct_FieldPick.PNG)

![](/FileSystem/Thumbnail?filename=00000001_20161102145040_Distinct_Result.PNG)

###MapReduce

MapReduce用户界面

![](/FileSystem/Thumbnail?filename=00000001_20161103153439_MapReduce.png)

- limit
Optional. Specifies a maximum number of documents for the input into the map function.

- jsMode
Optional. Specifies whether to convert intermediate data into BSON format between the execution of the map and reduce functions. Defaults to false.

- verbose
Optional. Specifies whether to include the timing information in the result information. The verbose defaults to true to include the timing information.

- bypassDocumentValidation
Optional. Enables mapReduce to bypass document validation during the operation. This lets you insert documents that do not meet the validation requirements.

- collation
Coming Soon

MapReduce的结果如图

![](/FileSystem/Thumbnail?filename=00000001_20161103150054_MapReduceResult.png)

这里包含了timing information.

### 聚合管道命令

![](/FileSystem/Thumbnail?filename=00000001_20161102131308_Aggregation.png)

StageBuilder可以帮助你设定一些简单的Stage条件

- project

设定那些项目需要输出，也可以对项目改名或者进行函数计算
注意：对项目进行抑制（不输出）和进行Project（改名和函数计算）操作是不能同时出现的，必须分开在两个Pipeline。

![](/FileSystem/Thumbnail?filename=00000001_20161110103345_Project.png)

- Match

Match可以设定数据的过滤条件，支持OR和AND以及括号

![](/FileSystem/Thumbnail?filename=00000001_20161111095919_MatchPanel.png)

- group
在设定 Id项目和其他项目之后，可以进行Group操作

![](/FileSystem/Thumbnail?filename=00000001_20161110111433_group.png)

- Sort :设定排序

![](/FileSystem/Thumbnail?filename=00000001_20161109185102_Sort.png)

- Misc

![](/FileSystem/Thumbnail?filename=00000001_20161102131443_StageBuilder.png)

当然您也可以通过AddStage将一个复杂的Stage的JSON定义加入到StagePipeline中。

当您创建完成一个聚合管道命令时，你可以将这个聚合管道转换为一个视图（View）

###文本检索
注意：文本检索需要对数据集增加Text索引。
非Enterprise版本不支持分词功能。

![](/FileSystem/Thumbnail?filename=00000001_20161102144505_TextSearch.png)

###GeoNear
GeoNear用来检索地理位置：
给出指定坐标（经度和纬度），然后寻在指定范围里面的点的集合。

![](/FileSystem/Thumbnail?filename=00000001_20161104143522_GeoNear.png)

##GFS
你可以使用MongoDB的GridFileSystem来存储文件。
这里我们使用 “上传” 这个词语表示将文件放入数据库。
这里我们使用 “下载” 这个词语表示将文件数据库取出。

###文件一览

![](/FileSystem/Thumbnail?filename=00000001_20161102211009_GFS.png)

为了文件图标能够正常显示，请使用系统管理员权限运行本工具。

###文件的上传
你可以使用工具栏按钮上传文件和文件夹。在Windows平台，也支持使用拖放的操作来上传文件夹。
在上传文件夹的时候，可以进行一些配置

![](/FileSystem/Thumbnail?filename=00000001_20161103093226_GFSInsertOption.png)
服务器端的文件名选项：
- 仅文件名：文件名作为文件名字段
- 全路径：全路径作为文件名字段

文件已经存在时的选项
- 添加（系统允许出现同名文件）
- 重命名:增加数字后缀
- 跳过:不进行上传
- 覆盖文件
- 停止上传：已上传文件不删除

##副本和分片
###初始化副本

这里使用以下数据库配置启动数据库（Bat中包括目录的建立）：
副本名称为set1

```bash
del C:\mongodb\Mongod1\*.* 
mkdir C:\mongodb\Mongod1
cd C:\runmongo\bin
mongod --port 10001 --dbpath  C:\mongodb\Mongod1 --replSet set1 --rest --smallfiles --oplogSize 128 

```
这时候查看Repl信息如下所示

![](/FileSystem/Thumbnail?filename=00000001_20161114113814_BeforeInitRs.png)

使用工具的初始化副本功能，正确的输入副本名称之后，再次查看Repl信息如下。
同时树形目录会出现Admin数据库

![](/FileSystem/Thumbnail?filename=00000001_20161114114501_AfterInitRs.png)

当然，你也可以通过在local数据库中执行以下语句，手动初始化副本。

![](/FileSystem/Thumbnail?filename=00000001_20161114114604_EvalRsInit.png)

###修改副本
对于副本，可以使用修改副本的工具来进行副本中主机的添加和修改

![](/FileSystem/Thumbnail?filename=00000001_20161114133620_ReplConf.png)

注意：请注意你主机的名字，localhost的话，MongoDB可能会帮你改为主机名称。
副本要求所有的主机是localhost或者全部不是localhost

##插件系统（C#语言）

本工具支持插件系统，任何人可以为这个软件制作插件
在 PlugIn文件夹中，有一些内置的工具

###工具内置插件

- 从Access导入
支持MDB（Microsoft.Jet.OLEDB.4.0）和ACCDB（Microsoft.ACE.OLEDB.12.0）两种格式文件。
可以选择某些表导入Mongo数据库中。

```csharp
        //ID:Integer
        //备注:WChar
        //货币:Currency
        //日期时间:Date
        //是否:Boolean
        //数字（长整形）:Integer
        //数字（单精度）:Single
        //数字（双精度）:Double
        //数字（同步复制ID）:Guid
        //数字（小数）:Numeric
        //数字（整型）:SmallInt
        //数字（字节）:UnsignedTinyInt
        //文本:WChar
```

![](/FileSystem/Thumbnail?filename=00000001_20161111151645_ImportAccess.png)

- 导出到Excel

将MongoDB的数据集导出到Excel文件

MongoDB的数据：

![](/FileSystem/Thumbnail?filename=00000001_20161111152910_ExportToExcel2.PNG)

导出到Excel

![](/FileSystem/Thumbnail?filename=00000001_20161111152818_ExportToExcel.PNG)

## MongoDB3.4

###Read Concern linearizable
在ReadConcern 增加了 "linearizable"

###Decimal Type
从MongoDB3.4开始，增加了128位的Decimal的数据格式。

###视图（ReadOnly View）
视图是MongoDB 3.4 新增的一个功能，虽然其名称也是视图，但是和传统的关系型数据库的View还是有一些区别的。
MongoDB的视图是对某个数据集进行聚合操作生成的视图，暂时还不能从多个不同的数据集中抽取数据集中反映在一个视图中。
这样的View只是在大数据统计的时候，可以将一些预置的聚合条件提升为视图的概念，便于数据分析。
暂时还不清楚View的内部机理是什么，到底是实时抽取的，还是内部在监视原来的数据集，然后进行Diff更新。或者和传统数据库那样，静态View，通过手动或者定时更新。


## 更新履历

###Ver 2.0.7 2016/11/18

####修改
1. ImportAccess插件重制
2. 修正了NET462编译条件缺失的问题
3. 修改连接配置时候，按钮显示文字不正确的问题
4. 副本功能（初始化副本，副本设定）的修复（原来使用MongoDatabase命令，现在用Shell命令）
5. 让所有的数据库都可以执行Shell命令

###Ver 2.0.5 2016/11/11

####修改
1. 调整服务器监视功能的入口，移动到服务器顶层菜单
2. 树形数据展示控件，文档根字段表示优化
3. 服务器属性菜单表示的内容合并到服务器状态中
4. 启动后自动选中数据库结构的根对象
5. 服务器监视功能的强化，允许同时打开多个监视窗体（改为非模态），自定义监视项目
6. 连接管理，增加了对于连接名称的检查
7. 连接字符串放在连接管理器的最外层，方便快速建立连接。
8. 连接转连接字符串的最简单实现
9. Javascript编辑器的优化
10. JsonOutputMode 默认设定为Shell
11. AggregateBuilder的全面优化和改进

####删除
1. QueryFilter功能入口去除：由于聚合框架和视图功能的存在，原先的QueryFilter功能废止
   同样的功能，建议使用聚合管理器，制作一个视图来替代该功能
2. 数据集的聚合菜单下的Count功能，没有什么作用，Count结果已经在数据集名称旁边表示了
3. 数据集的聚合菜单下的Group功能，按照MongoDB官方的处理意见，使用Group或者MapReduce功能进行代替。

###Ver 2.0.3 2016/11/03

####新增
1. 添加视图（From MongoDB 3.4）
2. 视图的展示（From MongoDB 3.4）
3. BsonInt64，BSonDecimal128 的对应
4. 有视图的时候，状态窗体的对应
5. GFS拖曳上传功能
6. GeoHaystackSearchAs的追加
7. ObjectId详细信息的表示
8. 增加了地理数组的快捷输入
9. 日期格式的设定
10. 更新了索引种类（7种索引）
11. ReadConcern初步引入
12. MapReduce 扩展选项的对应
13. Collation概念的引入

####修改
1. 新建数据集的BUG修正，数据集验证的修复
2. 新建文档时候出现的无法通过数据集验证的异常处理
3. 数据库必须有一个数据集，如果没有数据集的话，则数据库会被回收掉,所以新建数据库的时候，可以指定初始数据集的名称
4. 修正了无法保存配置的严重错误！(感谢错误报告者： https://github.com/shipf0820)
5. ML插件化
6. 修正了切断连接无效的问题
7. NetCore和Net版本条件编译
8. BsonDocument树形表示优化
9. 树形数据展示，双击是否能被修改的问题
10. 导入数据集时候，提示框文字不正确
11. ShardingRange设置BsonValue的优化
12. GeoNear放入聚合菜单
 
####移除(不成熟烂尾功能)
1. SQL转换功能
2. 实时状态报表的移除

####聚合
1. $indexStats $stage，$sortByCount（From MongoDB3.4）, $sample, $unwind
2. 聚合操作符的更新
3. 优化聚合UI
4. 聚合结果保存为视图

####mongobooster功能的借鉴
1. 增加了MongoDB官方文档的链接
2. BsonGuidRepresentation概念的引入
3. BsonMaxKey,BsonMinKey概念的引入
4. BsonBinaryData概念的引入