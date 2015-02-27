cd C:\runmongo\bin
mkdir C:\mongodb\magicdict
mongod --port  28030 --dbpath C:\mongodb\magicdict --rest --nojournal >> C:\mongodb\magicdict\magicdict.log
