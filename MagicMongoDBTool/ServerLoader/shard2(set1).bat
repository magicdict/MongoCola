del C:\mongodb\shard2\*.* 
cd C:\runmongo\bin
mongod --shardsvr  --port 10002 --dbpath  C:\mongodb\shard2 --replSet set1 --rest 
