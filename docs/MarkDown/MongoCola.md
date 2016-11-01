# MongoCola工具
* 可执行版本 Windows Client[需要 NET Framework 4.6.2] 更新时间:2016/10/31 16:00
* Net Core版本 Browse Base Client[需要 NET Core1.0.1] 更新时间:2016/12/31 16:00
* 下载地址:  <https://github.com/magicdict/MongoCola/releases>
* GitHub 项目地址 <https://github.com/magicdict/MongoCola/>
* GitPage 官网 <http://magicdict.github.io/MongoCola/>
* 版本号：Ver 2.0.3
* 文档最后更新时间：2016-11-01 16:44:41 星期二

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
- BsonDocument 文档
- BsonGeo 地理数据
- BsonMaxKey Sharding用最大值
- BsonMinKey Sharding用最小值
- BsonBinary Base64的数据 注意：请直接填写内容即可，系统自动进行转换
- BsonUndifined （测试用，请不要选择）

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