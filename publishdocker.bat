::Publish Docker image, requires write access atreyu/inkycal.server
docker-compose build
docker tag docker.io/library/michaelchecksum-web atreyu/michaelchecksum:latest
docker push atreyu/michaelchecksum:latest