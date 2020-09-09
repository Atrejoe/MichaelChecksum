::Publish Docker image, requires write access atreyu/inkycal.server
docker-compose build
docker tag michaelchecksum_web:latest atreyu/michaelchecksum:latest
docker push atreyu/michaelchecksum:latest