cd C:\runmongo\bin
mkdir C:\mongodb\Daruma
mongod --port  28040 --dbpath C:\mongodb\Daruma --rest --setParameter textSearchEnabled=true --nojournal
