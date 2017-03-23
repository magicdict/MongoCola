# MongoCola工具

MongoCola是一款帮助你在图形界面下查看，操作MongoDB的工具类软件。
本工具的目标是尽量用图形界面来代替命令脚本帮您完成一些日常的MongoDB管理工作。

* 本软件是**完全免费**的软件，您可以无条件的使用本软件的任何功能。
* 下载地址:  <https://github.com/magicdict/MongoCola/releases>
* 用户手册： <http://www.codesnippet.info/Article/Index?ArticleId=00000062>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* 版本号：Ver 2.1.0
* 文档最后更新时间：2016-11-24

## 开发和测试环境
**操作系统：**
* Windows 7

**运行时：**
* NET Framework 4.6.2
* MongoDB 3.4.2

**驱动程序：**
* CSharp Mongo Driver 2.4.3

.Net Core的WebPage版本还在试水中。本软件虽然可以通过编译成Mono版本在MacOS和Linux中使用，但是用户体验不好，所以建议只在Windows中使用本软件。



## 基本操作
### 第一次启动程序/选项说明
**本软件需要.Net Framework 4.6.2**
[下载 .Net Framework4.6.2](https://blogs.msdn.microsoft.com/dotnet/2016/08/02/announcing-net-framework-4-6-2/ "下载 .Net Framework4.6.2")
**注意：本软件针对MongoDB3.4重新开发，很多功能可能在低版本上会出现问题**
**注意：MongoCola.exe和MongoCola.exe.config文件以及其他的DLL文件不能缺少**
**注意：MultiLanguageEditor，ConfigurationFile这两个Exe暂时不在资源中**
**注意：MachineLearning的插件只是实验性质，所以也不在资源中**

第一次启动程序(MongoCola.exe)的时候，您可以选择语言：这里我们选择简体中文
（由于语言文件没有准备妥当，下载包配置文件默认为简体中文）

![](/FileSystem/Thumbnail?filename=00000001_20161101154414_Language.png)

*语言配置文件放在 Language文件夹中，您可以自己修改翻译。
- zh_CN.xml 简体中文

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

###建立一个数据连接/查看数据
启动一个MongoDB数据库，使其在端口28030运行。
这里我们假设您安装的MongoDB在C:\runmongo\，则在其bin目录下面有mongod.exe等可执行文件
下面这个Bat将新建一个目录用来存放MongoDB的数据库文件，并且在28030端口运行一个MongoD实例。
同时指定了wiredTiger为存储引擎（在MongoDB3.4里，默认已经是wiredTiger，可不指定）。
这里的MongoD执行日志重定向到C:\mongodb\CodeSnippet\DataBase\Logger.log这个文件中
（一般正式的项目应该使用Config文件，并且MongoDB作为服务启动，这里为了简化才使用BAT文件的）

```bash
C:
cd C:\runmongo\bin
mkdir C:\mongodb\CodeSnippet\DataBase
mongod --port 28030 --storageEngine wiredTiger --dbpath C:\mongodb\CodeSnippet\DataBase --rest --nojournal  >> C:\mongodb\CodeSnippet\DataBase\Logger.log
```

![](/FileSystem/Thumbnail?filename=00000001_20161117131413_MongoDos.png)

我们尝试建立一个新的数据库连接，来管理在本地端口28030运行的数据库。我们只需要填写最基本的信息即可。
**注意：如果你使用了用户，密码将使用明文保存在配置文件中。**当然，你也可以选择在连接时输入密码的选项，这样密码不会被保存在任何地方，在系统进行连接的时候才要求您输入密码。

**注意：请不要在连接名称中放入 冒号： 字符**
（注意：SSH，SSL，Auth等没有进行测试，暂时请不要使用。ReadWrite不是数据库连接属性，可以不用配置。）

![](/FileSystem/Thumbnail?filename=00000001_20161118145656_ConnectionMgr.png)

新建之后勾选数据连接之前的复选框，按下确定按钮即可。

![](/FileSystem/Thumbnail?filename=00000001_20161117132042_ConnectionList.png)

你可以使用工具栏按钮将连接转为MongoUri连接字符串。
也可以通过工具栏按钮通过MongoUri快速建立连接。


主界面如图所示：左边是数据库结构展示区，右边是数据展示区：
（如果有admin数据库，将默认置顶）
![](/FileSystem/Thumbnail?filename=00000001_20161123163948_MainGUI.png)


- 树形视图（TreeView）
树形视图便于查看数据的阶层构造。
注意：如果是ObjectId类型数据，系统将会展示ObjectId的详细信息：
CreateionTime，Machine，Pid，Increment，TimeStamp
但是这些信息字段实际上是不存在于数据库中的，是通过ObjectId计算出来的。

![](/FileSystem/Thumbnail?filename=00000001_20161102095610_TreeView.png)

- 列表视图
如果数据集的字段整齐，则列表视图将会使用关系型数据那样的二维视图展示数据

![](/FileSystem/Thumbnail?filename=00000001_20161102100153_ListView.png)

- JSON视图
在文本视图中，可以看到数据的JSON格式文本。
你可以通过JsonOutputMode来设定Json对象的表示形式，具体差异请参照：
[MongoDB Extended JSON](https://docs.mongodb.com/master/reference/mongodb-extended-json/ "MongoDB Extended JSON")

![](/FileSystem/Thumbnail?filename=00000001_20161102100423_TextView.png)

###新建数据库/数据集/视图
如果数据库里面没有任何数据集，则该数据库将自动被系统回收，所以，新建数据库的时候，会要求设定初始数据集。

![](/FileSystem/Thumbnail?filename=00000001_20161102143247_NewDatabase.png)


软件使用了完全可视化的界面来帮助您新建一个数据集
数据集名称前后的空白将被工具自动去除

![](/FileSystem/Thumbnail?filename=00000001_20161116174815_CreateCollection.png)

- 容量限制Capped
**[Capped Collections](https://docs.mongodb.com/master/core/capped-collections/ "Capped Collections")**
这里的最大尺寸单位是Byte

- 排序规则：设置字符串排序规则
**[Collation](https://docs.mongodb.com/master/reference/collation/ "Collation")**
- 文档验证功能：可以设定文档验证表达式来验证文档。当文档被修改时候，可以产生错误或者警告信息。
**[Data Modeling Introduction](https://docs.mongodb.com/master/data-modeling/ "Data Modeling Introduction")**

（ 自动Id索引：根据官方建议，从MongoDB3.4开始这个选项被移除）

![](/FileSystem/Thumbnail?filename=00000001_20161117151138_CreateCollection_Validation.png)

选中某个数据库，然后在右键菜单中选择“添加视图”即可打开视图创建窗体。
你可以使用软件提供的StageBuilder来添加聚合管道条件。

![](/FileSystem/Thumbnail?filename=00000001_20161104103219_CreateView.png)

你也可以使用聚合功能来创建视图：参见[聚合管道命令]
你也可以使用排序规则生成器来创建排序规则：参见[排序规则]

在主界面，你可以选中一个视图，然后使用ViewInfo菜单来查看视图属性。

![](/FileSystem/Thumbnail?filename=00000001_20161118145407_ViewInfo.png)

###复制数据库

通过复制数据库命令，可以将数据库中的数据集复制到其他数据库中。
注意：**复制索引**还没有开发完成

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
- BsonGeoJSON 地理数据
- LegacyPoint 地理数据

![](/FileSystem/Thumbnail?filename=00000001_20161102205658_GeoJSON.png)

注意：半球坐标，使用WGS84坐标系 经度纬度的取值范围：经度 [-180,180] ,纬度[-90,90]
**在NearAs函数中，GeoJson的Dis返回单位是meter（米），LegacyPoint返回的单位是radius（弧度）**

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
**[聚合官方文档](https://docs.mongodb.com/master/aggregation/ "聚合官方文档")**
选择任意一个数据集之后在右键菜单中可以找到聚合命令的入口

###基本聚合
Count 由于功能过于简单没有单独做成窗体。
Group功能按照MongoDB官方最新文档的指导,建议使用MapReduce或者Aggregate框架的Group功能实现

- Distinct

可以针对某个字段进行Distinct操作（**如果字段是数组，则每个数组元素都是Distinct对象**）
![](/FileSystem/Thumbnail?filename=00000001_20161117160714_distinct.png)

###MapReduce

MapReduce用户界面

![](/FileSystem/Thumbnail?filename=00000001_20161117155036_MapReduce.png)

关于Output选项的说明：

- limit
可选. 指定MapReduce的时候，作为**输入源**的最大文档数.

- jsMode
可选. 指定是否在Map和Reduce函数执行的中间过程中，将数据转成BSON格式。

- verbose
可选. 指定是否将Timing执行时间的信息放在输出文件中。

- bypassDocumentValidation
可选. 使得MapReduce在输出文档到数据集的时候，能够触发数据验证功能。

- collation
可选。语言排序用设定。

MapReduce的结果如图

![](/FileSystem/Thumbnail?filename=00000001_20161103150054_MapReduceResult.png)

这里包含了timing information.verbose：True。

### 聚合管道命令
[Aggregation Pipeline](https://docs.mongodb.com/master/core/aggregation-pipeline/ "Aggregation Pipeline")

![](/FileSystem/Thumbnail?filename=00000001_20161102131308_Aggregation.png)

StageBuilder可以帮助你设定一些简单的Stage条件

- [$project (aggregation)](https://docs.mongodb.com/master/reference/operator/aggregation/project/#pipe._S_project "$project (aggregation)")
设定那些项目需要输出，也可以对项目改名或者进行函数计算
注意：对项目进行抑制（不输出）和进行Project（改名和函数计算）操作是不能同时出现的，必须分开在两个Pipeline。

![](/FileSystem/Thumbnail?filename=00000001_20161110103345_Project.png)

- [$match (aggregation)](https://docs.mongodb.com/master/reference/operator/aggregation/match/#pipe._S_match "$match (aggregation)")
Match可以设定数据的过滤条件，支持OR和AND以及括号

![](/FileSystem/Thumbnail?filename=00000001_20161111095919_MatchPanel.png)

- [$group (aggregation)](https://docs.mongodb.com/master/reference/operator/aggregation/group/#pipe._S_group "$group (aggregation)")
在设定 Id项目和其他项目之后，可以进行Group操作

![](/FileSystem/Thumbnail?filename=00000001_20161110111433_group.png)

- [$sort (aggregation)](https://docs.mongodb.com/master/reference/operator/aggregation/sort/#pipe._S_sort "$sort (aggregation)")
将输入的文档进行排序，然后输出。

![](/FileSystem/Thumbnail?filename=00000001_20161109185102_Sort.png)

- [Pipeline Aggregation Stages](https://docs.mongodb.com/master/reference/operator/aggregation-pipeline/ "Pipeline Aggregation Stages")

![](/FileSystem/Thumbnail?filename=00000001_20161102131443_StageBuilder.png)

当然您也可以通过AddStage将一个复杂的Stage的JSON定义加入到StagePipeline中。
当您创建完成一个聚合管道命令时，你可以将这个聚合管道转换为一个视图（View）

###文本检索
**[Text Search官方文档](https://docs.mongodb.com/master/text-search/ "Text Search")**
注意：文本检索需要对数据集增加Text索引。非Enterprise版本不支持分词功能。

![](/FileSystem/Thumbnail?filename=00000001_20161102144505_TextSearch.png)

###GeoNear
GeoNear用来检索地理位置：
给出指定坐标（经度和纬度），然后寻在指定范围里面的点的集合。
**注意：GeoJSON返回的结果是meter，LegacyPoint返回的结果是弧度。Multiplier对于MaxDistance是不起作用的**
以下例子表示查找距离指定坐标10000米之内的点，返回文档中的dis字段，用公里表示（米->公里，所以结果*0.001）。

![](/FileSystem/Thumbnail?filename=00000001_20161121104551_GeoNear.png)

##Grid File System
**[Storage官方文档](https://docs.mongodb.com/master/storage/ "Storage官方文档")**

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

##副本
**[副本官方文档](https://docs.mongodb.com/master/replication/ "副本官方文档")**

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

##分片
**[分片官方文档](https://docs.mongodb.com/master/sharding/ "分片官方文档")**

###创建最小分片系统

注意：MongoDB 3.4的分片有一些变更，具体请参见：
[Sharded Cluster](https://docs.mongodb.com/master/release-notes/3.4/#sharded-cluster "Sharded Cluster")

这里我们创建一个最小的分片系统，这个分片系统包含2个副本（每个副本包含2台数据服务器），1个Config服务器，1个Route服务器(mongos)。
注意：副本服务器由于会变成Shard，所以一定要加 --shardsvr 参数。
下面是副本set1的第一台数据服务器的启动参数。其他3台根据需要进行修改即可。
（ C:\runmongo\bin 是mongod.exe mongos.exe 的路径）

```bash
del C:\mongodb\Mongod1\*.* 
mkdir C:\mongodb\Mongod1
cd C:\runmongo\bin
mongod --port 10001 --dbpath  C:\mongodb\Mongod1 --replSet set1 --rest --smallfiles --oplogSize 128 --shardsvr
```

下面是Config服务器
注意：Config服务器需要是副本，启动之后，请将其初始化副本。这里的副本名称为"config"

```bash
cd C:\runmongo\bin
mkdir C:\mongodb\config1
mongod --configsvr --port 30001 --dbpath  C:\mongodb\config1 --rest -replSet config
```

最后是Route服务器（Mongos）
--configdb 请设置为config副本的具体主机名称

```bash
cd C:\runmongo\bin
mongos --configdb config/localhost:30001 --port 30002
```

###分片的配置

使用UI工具增加Sharding，这里需要指定副本名称和主机。

![](/FileSystem/Thumbnail?filename=00000001_20161116105547_AddSharding.png)

启用Sharding

![](/FileSystem/Thumbnail?filename=00000001_20161116105649_EnableSharding.png)

增加分片区域（ShardingZone）

Sharding Zone 是 MongoDB3.4新增的概念，和以前的 Sharding Tag 类似

![](/FileSystem/Thumbnail?filename=00000001_20161116105820_AddShardingZone.png)

设置分片区域的范围

![](/FileSystem/Thumbnail?filename=00000001_20161116105911_AddShardingZoneRange.png)

##安全
###新建用户
使用本工具可以添加具有指定角色的用户

![](/FileSystem/Thumbnail?filename=00000001_20161122161351_AddUser.png)

在配置连接信息的时候，可以指定用户名和数据库：
**从Mongo3.4开始，SCRAM-SHA-1作为默认认证机制**
**由于Role-Base的认证机制比较复杂，请注意角色的分配和权限问题。有些角色不能列出数据库和数据集。**

![](/FileSystem/Thumbnail?filename=00000001_20161121152105_ConnectionMgrAuth.png)

###新建自定义角色
除了MongoDB内置的角色外，您还可以新建自定义角色

![](/FileSystem/Thumbnail?filename=00000001_20161122110741_AddCustomRole.png)


##插件系统（C#语言）

本工具支持插件系统，任何人可以为这个软件制作插件
在 PlugIn文件夹中，有一些内置的工具

###工具内置插件

- 从Access导入
支持MDB（Microsoft.Jet.OLEDB.4.0）和ACCDB（Microsoft.ACE.OLEDB.12.0）两种格式文件。
可以选择只将某些表导入Mongo数据库中。同时请保证Office正确安装，OLEDB驱动能够使用。

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

将MongoDB的数据集导出到Excel文件（Excel2010下测试正常）

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
**[Read-only Views](https://docs.mongodb.com/master/core/views/#reference-views "Read-only Views")**

视图是MongoDB 3.4 新增的一个功能，虽然其名称也是视图，但是和传统的关系型数据库的View还是有一些区别的。
MongoDB的视图是对某个数据集进行聚合操作生成的视图，暂时还不能从多个不同的数据集中抽取数据集中反映在一个视图中。
这样的View只是在大数据统计的时候，可以将一些预置的聚合条件提升为视图的概念，便于数据分析。
暂时还不清楚View的内部机理是什么，到底是实时抽取的，还是内部在监视原来的数据集，然后进行Diff更新。或者和传统数据库那样，静态View，通过手动或者定时更新。

## 更新履历

## Ver 2.1.0 2016/11/24
代码重构，废除代码移除,作为MongoDB3.4正式发布之前最后的一个预览版本。

### 修改
1. admin数据库在树形列表中置顶
2. 修正了Hash索引无法正确建立的错误
3. 修改界面表示细节

### 新增
1. 自定义角色

### 删除
1. 当前连接的用户信息的表示（不成熟的功能）

###Ver 2.0.7 2016/11/18

### 新增
1. ConvertToCapped：将普通的数据集转换为Capped数据集
2. 新增了连接时输入密码的连接选项

#### 修改
1. ImportAccess插件重制
2. 修正了NET462编译条件缺失的问题
3. 修改连接配置时候，按钮显示文字不正确的问题
4. 副本功能（初始化副本，副本设定）的修复（原来使用MongoDatabase命令，现在用Shell命令）
5. 让所有的数据库都可以执行Shell命令
6. 分片功能的修复
7. BsonTimestamp的表示
8. id缺失数据集的崩溃问题
9. 优化了连接Timeout的处理，使用Health标志说明连接状态
10. MapReduce的界面优化
11. GeoNear功能的强化，GeoJson和LegacyCoodinates的区分。
12. CreateUser命令的重写

#### 删除
1. 主从同步功能：随着Master-Slaver机制的取消，主从同步功能也随之取消。其他所有主从副本相关的代码也会渐渐剔除。
2. CreateCollection: MongoDB3.4 AutoIndex 选项将被取消，UI随着也删除AutoIndex的复选框
3. 服务器状态自动刷新的入口图标废止（本功能已经废止）

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
3. 数据集的聚合菜单下的Group功能，按照MongoDB官方的处理意见，使用Aggregate的Group Pipeline或者MapReduce功能进行代替。

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