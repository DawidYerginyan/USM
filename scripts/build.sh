#!/bin/bash

. "${BASH_SOURCE%/*}/color.sh"

clear
COLOR $MAGENTA '\nRunning .NET classlib build...\n\n'
dotnet publish -o ./dist -f netstandard2.0 -c Release
rm -r bin obj dist/USM.deps.json dist/System.Runtime.InteropServices.WindowsRuntime.dll
COLOR $MAGENTA '\n\nBuild completed.\n'
