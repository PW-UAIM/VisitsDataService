echo off
set url=https://localhost:5003

CALL:curl_test "Dane wizyty o ID 1" GET /visit/1 

CALL:curl_test "Wszystkie wizyty klienta o ID 1" GET /visit/client/1

CALL:curl_test "Wszystkie wizyty mechanika o ID 1" GET /visit/mechanic/1

CALL:curl_test "Wszystkie wizyty mechanika o ID 1 w dniu 01.01.2022" GET /visit/mechanic/1/date/2022/1/1

CALL:curl_test "Zmien status wizyty o ID 1 na 'Trwa' " PATCH /visit/1/update/Trwa

CALL:curl_test "Dane wizyty o ID 1" GET /visit/1 

echo Nazwa testu: "Dodaj wizyte o ID 20"
echo Testowany url: https://localhost:5003/visit/add
curl -X POST https://localhost:5003/visit/add -H "Content-Type: application/json"  -d ^
"{^
	\"visitID\": 20,^
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

CALL:curl_test "Dane wizyty o ID 20" GET /visit/20 

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