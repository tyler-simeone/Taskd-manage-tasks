#!/bin/zsh

# Load environment variables from .env 
source .env

# Run the Docker container with specified environment variables and port mapping
docker run -d \
  --name manage-tasks \
  -p 5273:80 \
  -e LocalDBConnection=$LOCAL_DB_CONX \
  -e UserPoolId=$USER_POOL_ID \
  -e Region=$REGION \
  tylersimeone/projectb/manage-tasks:latest

if [ $? -ne 0 ]; then
  echo "Docker run command failed!"
  exit 1
fi

echo "Docker container started successfully."