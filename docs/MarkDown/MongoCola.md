# MongoCola工具
* 可执行版本 Windows Client[需要 NET Framework 4.6.2] 更新时间:2016/11/24 16:00
* Net Core版本 Browse Base Client[需要 NET Core1.0.1] 更新时间:2016/11/24 16:00
* 下载地址:  <https://github.com/magicdict/MongoCola/releases>
* 用户手册： <http://www.codesnippet.info/Article/Index?ArticleId=00000062>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* GitPage 官网 <http://magicdict.github.io/MongoCola/>
* 版本号：Ver 2.0.3
* 文档最后更新时间：2016-11-02 14:32:57 星期三

## 开发和测试环境
### 操作系统：
* Windows 7
* Mac OSX 10.12

### 运行时：
* NET Framework 4.6.2
* NET Core 1.1.10
* MongoDB 3.4.0-rc2

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

![](/FileSystem/Thumbnail?filename=00000001_20161101155300_option.png)

- Language:界面语言
- Font：字体（Mac系统请使用Mac的专用字体，防止乱码出现）
- Monitor Refresh Interval ： 监视程序的采样频率
- Display Number With KMGT：在显示数据的时候，过大的数字是否使用 K，M，G，T这样的字符
- MongoBin：MongoDB客户端工具程序的保存位置
- Guid：Guid的内部保存形式
- TimeZone：使用UTC或者Local来显示时间数据
- DateTimeFormat：时间日期在系统中的显示形式

###建立一个数据连接

我们尝试建立一个新的数据库连接，来管理在本地端口28030运行的数据库

![](/FileSystem/Thumbnail?filename=00000001_20161101155910_NewConnectiong.png)

新建之后勾选数据连接之前的复选框，按下确定按钮即可。

![](/FileSystem/Thumbnail?filename=00000001_20161101160117_ConnectionList1.png)

主界面如图所示：左边是数据库结构展示区，右边是数据展示区：

![](/FileSystem/Thumbnail?filename=00000001_20161101160732_MainGUI.png)

###使用三种视图查看数据
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

![](/FileSystem/Thumbnail?filename=00000001_20161102130549_CreateCollection.png)

- 数据集名称前后的空白将被工具自动去除
- 高级选项包含了自动Id索引，容量限制Capped和文档验证功能

###新建视图
选中某个数据库，然后在右键菜单中选择“添加视图”即可打开视图创建窗体。
你可以使用软件提供的StageBuilder来添加聚合管道条件。

![](/FileSystem/Thumbnail?filename=00000001_20161102131835_CreateView.png)

你也可以使用聚合功能来创建视图：参见[聚合管道命令]

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

![](/FileSystem/Thumbnail?filename=00000001_20161102093904_GeoJSON.png)
注意：半球坐标，使用WGS84坐标系 经度纬度的取值范围：经度 [-180,180] ,纬度[-90,90]

- BsonMaxKey Sharding用最大值
- BsonMinKey Sharding用最小值
- BsonBinary Base64的数据 注意：请直接填写内容即可，系统自动进行转换

![](/FileSystem/Thumbnail?filename=00000001_20161102093738_BsonBinary.png)

- BsonUndifined （测试用，请不要选择）

###文档的插入

![](/FileSystem/Thumbnail?filename=00000001_20161102094939_CreateDocument.png)

- 实际使用中，如果希望系统生成"_id"字段，则请不要添加"_id"字段
- 建议使用预览功能来验证数据格式然后再进行添加操作

##聚合功能
### 聚合管道命令

![](/FileSystem/Thumbnail?filename=00000001_20161102131308_Aggregation.png)

- StageBuilder可以帮助你设定一些简单的Stage条件

![](/FileSystem/Thumbnail?filename=00000001_20161102131443_StageBuilder.png)

当然您也可以通过AddStage将一个复杂的Stage的JSON定义加入到StagePipeline中。

当您创建完成一个聚合管道命令时，你可以将这个聚合管道转换为一个视图（View）

## 更新履历
###新增
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

###修改
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

###聚合
1. $indexStats $stage，$sortByCount（From MongoDB3.4）, $sample, $unwind
2. 聚合操作符的更新
3. 优化聚合UI
4. 聚合结果保存为视图

###mongobooster功能的借鉴
1. 增加了MongoDB官方文档的链接
2. BsonGuidRepresentation概念的引入
3. BsonMaxKey,BsonMinKey概念的引入
4. BsonBinaryData概念的引入