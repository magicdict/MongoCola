del C:\mongodb\Mongod1\*.* 
mkdir C:\mongodb\Mongod1
cd C:\runmongo\bin
mongod --port 10001 --dbpath  C:\mongodb\Mongod1 --replSet set1 --rest --smallfiles --oplogSize 128 --shardsvr