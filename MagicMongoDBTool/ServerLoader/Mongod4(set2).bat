del C:\mongodb\Mongod4\*.* /Y
cd C:\runmongo\bin
mongod --port 10004 --dbpath  C:\mongodb\Mongod4 --replSet set2 --rest --smallfiles --oplogSize 128 
