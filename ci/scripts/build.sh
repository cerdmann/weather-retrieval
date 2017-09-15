#!/usr/bin/env bash

set -e
export TERM=${TERM:-dumb}

echo "=============================================="
echo "Beginning build of dotnet core application"
echo "$(dotnet --version)"
echo "=============================================="

cd git-repo

dotnet restore
dotnet publish -r ubuntu.14.04-x64 --configuration Release -f netcoreapp2.0 --output published-app

tar -zcvf weather-retrieval.tar.gz ./published-app

ARTIFACT=weather-retrieval.tar.gz
COMMIT=$(git rev-parse HEAD)

echo $ARTIFACT > ../artifact/release_name.txt
echo $(git log --format=%B -n 1 $COMMIT) > ../artifact/release_notes.md
echo $COMMIT > ../artifact/release_commitish.txt

cp ./$ARTIFACT ../artifact
cp ./concourse-dev-manifest.yml ../artifact
cp -R ./published-app ../artifact/

echo "----------------------------------------------"
echo "Build Complete"
ls -lah ../artifact
ls -lah ../artifact/published-app
echo "----------------------------------------------"
