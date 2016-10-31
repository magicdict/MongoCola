##MongoDB3.4新特性
###视图（ReadOnly View）
视图是MongoDB 3.4 新增的一个功能，虽然其名称也是视图，但是和传统的关系型数据库的View还是有一些区别的。
MongoDB的视图是对某个数据集进行聚合操作生成的视图，暂时还不能从多个不同的数据集中抽取数据集中反映在一个视图中。
这样的View只是在大数据统计的时候，可以将一些预置的聚合条件提升为视图的概念，便于数据分析。
暂时还不清楚View的内部机理是什么，到底是实时抽取的，还是内部在监视原来的数据集，然后进行Diff更新。或者和传统数据库那样，静态View，通过手动或者定时更新。


###新建数据库
通过实验发现，如果一个数据库没有任何数据集的话，该数据库则会被系统回收掉。
所以，工具中新建数据库的时候，必须指定初始数据集的名称。


##MongoCola工具
伴随着MongoDB3.4 RC1的发布，本工具也进行了相关的对应
[GitHub地址](https://github.com/magicdict/MongoCola "GitHub地址")
[可执行文件下载](https://github.com/magicdict/MongoCola/releases "可执行文件下载")

###新增
1. 添加视图（From MongoDB 3.4）
2. 视图的展示（From MongoDB 3.4）
3. BsonInt64，BSonDecimal128 的对应
4. 有视图的时候，状态窗体的对应
5.修正了无法保存配置的严重错误！

###修改
1. 新建数据集的BUG修正，数据集验证的修复
2. 新建文档时候出现的无法通过数据集验证的异常处理
3. 数据库必须有一个数据集，如果没有数据集的话，则数据库会被回收掉,所以新建数据库的时候，可以指定初始数据集的名称

###聚合
1. $indexStats $stage，$sortByCount（From MongoDB3.4）, $sample, $unwind
2. 聚合操作符的更新
3. 优化聚合UI
4. 聚合结果保存为视图
Downloads



