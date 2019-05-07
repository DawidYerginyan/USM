#!/bin/bash

. "${BASH_SOURCE%/*}/color.sh"

FILE='USM.dll'
REMOTE='git@github.com:DawidYerginyan/USM.git'

DIST_DIR='dist/'
TEMP='temp/'
META='meta/'

echo $REMOTE

function DEPLOY
{
  mkdir $TEMP
  cp package.json $TEMP
  cp -a "$DIST_DIR." $TEMP
  cp -a "$META." $TEMP

  git -C $TEMP init
  git -C $TEMP add -Af
  git -C $TEMP remote add origin "$REMOTE"
  git -C $TEMP commit -m "package deploy"
  git -C $TEMP push -f origin master:release

  rm -rf $TEMP
}

clear
COLOR $MAGENTA '\nStarting deployment process...\n\n'

if [ -f "$DIST_DIR$FILE" ]; then
  DEPLOY
  COLOR $MAGENTA '\nDeployment succeeded.\n\n'
  exit 0
else
  COLOR $MAGENTA "\nDeployment failed, missing $FILE.\n\n"
  exit 1
fi
