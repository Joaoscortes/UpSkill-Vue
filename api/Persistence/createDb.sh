#!/bin/bash  
echo "Delete old db"
rm -i database.db
echo "Delete old Migrations"
cd ..
rm -R Migrations
echo "Run ef migrations"
dotnet ef migrations add InitialCreate --context SqliteDB --output-dir Migrations/SqliteMigrations -v
echo "Run database update" 
dotnet ef database update --context SqliteDB
echo "End Script"