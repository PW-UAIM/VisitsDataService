docker login -u majumi -p uaimrzadzi

docker rmi majumi/visitsdataservice:dataservice

docker build -f ../majumi.CarService.VisitsDataService.Rest/Dockerfile.prod -t majumi/visitsdataservice:dataservice ..

docker logout

pause