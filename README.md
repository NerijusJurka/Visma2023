<h2>.NET Developer Task</h2>
<p>Create a console application to manage Visma’s resource shortage using .NET6. Requirements: </br>
● Command to register a new shortage. All shortage information should be stored in JSON file. Application should retain data between restarts </br>
Shortage model should contain the following properties:</br>
<ul><li>Title</li>
    <li>Name</li>
    <li>Room (Fixed values - Meeting room / kitchen / bathroom)</li>
    <li>Category (Fixed values - Electronics / Food / Other)</li>
    <li>Priority (Number 1-10, 1 - not important, 10 - very important)</li> 
    <li>CreatedOn (date request was created)</li>
    <li>If shortage is already added (Title and Room matches), do not  create new request but show a warning message. Though if the priority of new the request is higher, override the initial one</li></ul>
● Command to delete the request. Only the person who created or administrator can delete the request.</br>
● Command to list all the requests. </br>
<p2>○ Administrator can see all the requests, other users are able to see only the ones they created</p2></br>
<p2>○ Add the following parameters to filter the data:</p2></br>
<ul><li>Filter by title (if the title is “wireless speaker”, searching  for “Speaker” should return this entry)</li>
<li>Filter by CreatedOn date (e.g requests that was  registered between 2023-01-01 and 2023-02-01)</li>
<li>Filter by Category</li>
<li>Filter by Room</li></ul>
○ Returned results should be listed with high priority on the top</br></p>
<h4>Additional information</h4>
<p>To use Admin role:</p>
<ul><li>Register new user</li>
<li>Go to C: disk \temp folder and open user.json </li>
<li>Changes user role from basic to Admin and save</li></ul>
