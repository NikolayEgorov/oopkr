#!/bin/bash

source $BASH_SCRIPT_PATH/variables.sh

echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
echo "<<<<<<<<<         OOOOOOOO  OO      OO  OO         OO           >>>>>>>"
echo "<<<<<<<<<         OO    OO  OO      OO  OO        OOO           >>>>>>>"
echo "<<<<<<<<<         OO    OO  OO      OO  OO       O OO           >>>>>>>"
echo "<<<<<<<<<         OO    OO  OO      OO  OO      O  OO           >>>>>>>"
echo "<<<<<<<<<         OOOOOOOO  OO      OO  OO     O   OO           >>>>>>>"
echo "<<<<<<<<<         OO O      OO      OO  OO    O    OO           >>>>>>>"
echo "<<<<<<<<<         OO  O     OO      OO  OO   O     OO           >>>>>>>"
echo "<<<<<<<<<         OO   O    OO      OO  OO  O      OO           >>>>>>>"
echo "<<<<<<<<<         OO    O   OOOOOOOOOO  OO O       OO           >>>>>>>"
echo "<<<<<<<<<         OO     O  OOOOOOOOOO  OOO        OO           >>>>>>>"
echo "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"

cd $PROJECT_FULL_PATH

dotnet tool install --global dotnet-ef
dotnet add package BCrypt.Net-Next --version 4.0.3
dotnet add package Microsoft.AspNetCore.Authentication --version 2.2.0

dotnet new tool-manifest --force
dotnet tool install --local dotnet-ef --version 7.0.5
dotnet ef

# source $BASH_SCRIPT_PATH/database.sh

chmod -R 777 $PROJECT_FULL_PATH

cd $PROJECT_FULL_PATH
dotnet run