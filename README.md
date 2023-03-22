<h2>.NET Developer Task</h2>
<p>Create a console application to manage Visma’s resource shortage using .NET6. Requirements: </br>
● Command to register a new shortage. All shortage information should be stored in JSON file. Application should retain data between restarts </br>
Shortage model should contain the following properties:</br>
<ul>
    <li>- Title</li></br>
    * Name</br>
    * Room (Fixed values - Meeting room / kitchen / bathroom)</br>
    * Category (Fixed values - Electronics / Food / Other)</br>
    * Priority (Number 1-10, 1 - not important, 10 - very important)</br>   
    * CreatedOn (date request was created)</br>
○ If shortage is already added (Title and Room matches), do not  create new request but show a warning message. Though if the priority of new the request is higher, override the initial one</br>
● Command to delete the request. Only the person who created or administrator can delete the request.</br>
● Command to list all the requests. </br>
○ Administrator can see all the requests, other users are able to see only the ones they created</br>
○ Add the following parameters to filter the data:</br>
* Filter by title (if the title is “wireless speaker”, searching  for “Speaker” should return this entry)</br>
* Filter by CreatedOn date (e.g requests that was  registered between 2023-01-01 and 2023-02-01)</br>
* Filter by Category</br>
* Filter by Room</br>
○ Returned results should be listed with high priority on the top<</br></p>
<h4>Additional information</h4>
<p>To use Admin role:</p><br>
<li>Register new user</li>
<li>Go to C: disk \temp folder and open user.json </li>
<li>Changes user role from basic to Admin and save</li>

