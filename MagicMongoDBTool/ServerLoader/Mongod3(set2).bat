del C:\mongodb\Mongod3\*.* /Y
cd C:\runmongo\bin
mongod --port 10003 --dbpath  C:\mongodb\Mongod3 --replSet set2 --rest --smallfiles --oplogSize 128 
