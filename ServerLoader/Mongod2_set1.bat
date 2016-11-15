del C:\mongodb\Mongod2\*.* 
mkdir C:\mongodb\Mongod2
cd C:\runmongo\bin
mongod --port 10002 --dbpath  C:\mongodb\Mongod2 --replSet set1 --rest --smallfiles --oplogSize 128 --shardsvr