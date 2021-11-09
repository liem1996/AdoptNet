  <img alt="Coding" width="400" src="Adoptnet.PNG">

# AdoptNet Website :dog2: :cat2:
Our website helps to connect between associations and adopters in order to make it easier to adopt cats and dogs from all kinds of associations.

# Background :page_facing_up:
This is our final project in the course "Web application development" as part of B.Sc Computer science studies that was taught by Mr. Hemi Leibowitz.
This project shows our abilities to work with different programming langueges and technologies.

# Technologies and Logic :bulb:

- HTML & CSS & Bootstrap - creating the design of the website.
- C# - all the controller's classes are based on C# and functions with combinatitons of SQL queries.
- The backend technology based on asp.net MVC.
- MVC architecture - clearly seperation between the model, view and controller.
- Using 7 main models including animals, associations, adopting days, pictures of animals and associations etc.
- 3 different main connections between the models:
Many to many - each association can have several adoption days, and each adoption day can have several associations that take a part in this day.
One to one - each association and animal has it's one of a kind picture, and also each animal can have a unique product.
One to many - each association can have several dogs and cats.
- Support in Creating, Deletion, Searching and List of each one of the models.
- The DB is based on Entity Framework and Linq.
- Main Searching box in the navbar, and in each page to each model.
- Using the query "Group By" - in the index of animals to sort all the animals accroding to the association that they are belong to.
- Using the query "Join" - combain between two tables and therefore create a new one, one for the index of the animals and one for the index of the products.
- JQuery - using Ajax and js to create Bing map that shows each association's location, and to create 2 graphs that show number of dogs vs number of cats and distribution of adoption days.
- JS - we use js to create the weather widget that shows up in the home page.
- Twitter API - creating controller with get and post functions using speacial keys values to connect to our developers account on twitter. When an animal is added - it is tweet on our twitter account.
- Authorization - Creating 3 types of authorities - "Client" in the database reffer as 0, "Association" as 1 and Admin as 2.

| Client  | Association  | Admin |
| :------------ |:---------------:| -----:|
| Content of the website      | Add/delete/edit animlals | Add/delete/edit animlals |
|       | Add/delete/edit animlals images | Add/delete/edit animlals images |
|       | Add/delete/edit adoption days        |   Add/delete/edit adoption days |
|  | Add/delete/edit products        |    Add/delete/edit products |
|  |         |    Add/delete/edit associations |
|       |  | Add/delete/edit associations images |
|  |         |    Add/delete/edit users |

# Demo

We uploaded a demo video of our website to youtube, please check it out! :smile:

https://www.youtube.com/watch?v=leE451AsPrY
