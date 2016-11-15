del C:\mongodb\Mongod3\*.* 
mkdir C:\mongodb\Mongod3
cd C:\runmongo\bin
mongod --port 10003 --dbpath  C:\mongodb\Mongod3 --replSet set2 --rest --smallfiles --oplogSize 128 
