#!/bin/bash

source $BASH_SCRIPT_PATH/variables.sh

if [ "$DATABASE_REINIT" -eq 1 ]
then
    echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
    echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
    echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
    echo "<<<<<<<<<<<<<<<<<<<Database Inint>>>>>>>>>>>>>>>>>>>>>>>"
    echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
    echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
    echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"

    rm -rf "$PROJECT_FULL_PATH"/database

    mkdir "$PROJECT_FULL_PATH"/database
    touch "$PROJECT_FULL_PATH"/database/"$PROJECT_NAME".sqlite3
    chmod 777 -R "$PROJECT_FULL_PATH"/database

    cd $PROJECT_FULL_PATH

    dotnet add package Microsoft.EntityFrameworkCore --version 7.0.5

    # dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.5
    dotnet add package Pomelo.EntityFrameworkCore.MySql
    # dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.5
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.5
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.5

    dotnet ef database update
fi