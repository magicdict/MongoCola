cd C:\runmongo\bin
mkdir C:\mongodb\SinaWeibo
mongod --port  28030 --dbpath C:\mongodb\SinaWeibo --rest --setParameter textSearchEnabled=true
