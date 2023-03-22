<h2>.NET Developer Task</h2>
<p>Create a console application to manage Visma’s resource shortage using .NET6. Requirements: 
<p2>● Command to register a new shortage. 
○ All shortage information should be stored in JSON file. 
Application should retain data between restarts</p2>
○ Shortage model should contain the following properties:
■ Title
■ Name
■ Room (Fixed values - Meeting room / kitchen / bathroom)
■ Category (Fixed values - Electronics / Food / Other)
■ Priority (Number 1-10, 1 - not important, 10 - very 
important)
■ CreatedOn (date request was created)
○ If shortage is already added (Title and Room matches), do not 
create new request but show a warning message. Though if the 
priority of new the request is higher, override the initial one
● Command to delete the request. Only the person who created or 
administrator can delete the request.
● Command to list all the requests. 
○ Administrator can see all the requests, other users are able to 
see only the ones they created
○ Add the following parameters to filter the data:
■ Filter by title (if the title is “wireless speaker”, searching 
for “Speaker” should return this entry)
■ Filter by CreatedOn date (e.g requests that was 
registered between 2023-01-01 and 2023-02-01)
■ Filter by Category
■ Filter by Room
○ Returned results should be listed with high priority on the top</p>