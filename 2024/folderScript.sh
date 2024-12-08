#!/bin/bash
echo "Bash version ${BASH_VERSION}..."
echo "Running script"
END=25
for ((i=8;i<=END;i++));
do
    echo "Creating folder day $i";
    mkdir -p -- "Day$i" && touch -- "Day$i/Solution.cs";
done