# This structure of the project

## 1. TestApi 
This is the main project  
The **RegionController** has the method that detect the region from a phone number  
The regions records from the sql server database is accessed via Dapper ORM  
  
## 2. TestUnit
This is the test cases project  
There are five test cases that includes the algorithm, for each case the method name describes the function of a test case  

## 3. BenchmarkTest  
This is the project that has the performance test  
The statistic of the performance test code is on the **BenchmarkDotNet.Artifacts** folder on this project
