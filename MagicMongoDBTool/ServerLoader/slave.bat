cd C:\runmongo\bin
mkdir C:\mongodb\slave
mongod --port  28019 --dbpath C:\mongodb\slave --slave --source   localhost:28018