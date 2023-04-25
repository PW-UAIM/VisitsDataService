echo off
set url=https://localhost:5003

CALL:curl_test "Istniejaca wizyta o ID 1" GET /getVisit/1 
CALL:curl_test "Nieistniejaca wizyta o ID 1024" GET /getvisit/1024 

CALL:curl_test "Wszystkie wizyty istniejacego klienta o ID 1" GET /getAllVisitsByClient/1
CALL:curl_test "Wszystkie wizyty nieistniejacego klienta o ID 1024" GET /getAllVisitsByClient/1024

CALL:curl_test "Wszystkie wizyty istniejacego mechanika o ID 1" GET /getAllVisitsByMechanic/1
CALL:curl_test "Wszystkie wizyty nieistniejacego mechanika o ID 1024" GET /getAllVisitsByMechanic/1024

CALL:curl_test "Wszystkie wizyty mechanika o ID 1 w dniu 01.03.2022" GET /getAllVisitsByMechanicInDay/1/2022/3/1

CALL:curl_test "Wizyta o ID 1 przed zmiana" GET /getVisit/1
CALL:curl_test "Zmien status wizyty o ID 1 na 'Trwa' " PATCH /updateVisitStatus/1/Trwa
CALL:curl_test "Wizyta o ID 1 po zmianie" GET /getVisit/1

echo Nazwa testu: "Dodaj wizyte"
echo Testowany url: https://localhost:5003/addVisit
curl -X POST https://localhost:5003/addVisit -H "Content-Type: application/json"  -d ^
"{^
	\"clientID\": 1,^
	\"carID\": 3,^
	\"mechanicID\": 5,^
	\"serviceType\": \"Wymiana plynu do kierunkowskazow\",^
	 \"serviceDate\": \"2023-04-14T00:32:13.530Z\",^
	 \"serviceCost\": 13,^
	 \"serviceStatus\": \"Trwa\",^
	 \"notes\": \"Brak\"^
}"
echo:
echo:
CALL:curl_test "Dane wszystkich wizyty" GET /getAllVisits

EXIT /B 0

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept:application/json'
echo:
echo:
EXIT /B 0