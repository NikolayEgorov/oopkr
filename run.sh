#!/bin/bash

source $(pwd)/bashscripts/variables.sh

RUN_MODE=0;

while getopts m: flag
do
    case "${flag}" in
        m) RUN_MODE=${OPTARG};;
    esac
done

cd $PROJECT_FULL_PATH
if [ "$RUN_MODE" -eq 0 ]
then
    source $BASH_SCRIPT_PATH/run.sh
elif [ "$RUN_MODE" -eq 1 ]
then
    source $BASH_SCRIPT_PATH/deploy.sh
fi