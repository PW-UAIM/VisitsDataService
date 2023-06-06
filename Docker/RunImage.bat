docker login -u majumi -p uaimrzadzi

docker stop visitsdataservice

docker pull majumi/visitsdataservice:dataservice

docker run --name visitsdataservice -p 5004:5004 -it majumi/visitsdataservice:dataservice

pause

docker stop visitsdataservice

docker rm visitsdataservice

pause