#!/bin/bash

. "${BASH_SOURCE%/*}/color.sh"

clear
COLOR $MAGENTA '\nPurging project root directory...\n\n'

rm -rf bin/ dist/ obj/ packages/

COLOR $MAGENTA '\nProject directory cleared.\n\n'
