del C:\mongodb\Mongod4\*.* 
mkdir C:\mongodb\Mongod4
cd C:\runmongo\bin
mongod --port 10004 --dbpath  C:\mongodb\Mongod4 --replSet set2 --rest --smallfiles --oplogSize 128 --shardsvr 
