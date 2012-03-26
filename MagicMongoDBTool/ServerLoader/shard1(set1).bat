del C:\mongodb\shard1\*.* 
cd C:\runmongo\bin
mongod --shardsvr  --port 10001 --dbpath  C:\mongodb\shard1 --replSet set1 --rest 
