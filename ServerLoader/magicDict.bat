cd C:\runmongo\bin
mkdir C:\mongodb\magicdict
mongod --port 28030 --storageEngine wiredTiger --dbpath C:\mongodb\magicdict --rest --nojournal >> C:\mongodb\magicdict\magicdict.log
