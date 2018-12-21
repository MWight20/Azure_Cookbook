
# Dev notes

**12/21**
```
> Designed Recipe Details page with bootstrap grids
> Modified layout to not include div class container. Placed into views manually to give customized options for margin spacing.(possibly revert this or refactor).
```

**12/20**
```
> Removed edit and delete functionality for all anonymous users

> Implemented comparison logic of recipe usernames to
    Users.Identity.Username

> Created separate pages for Recipe details
    >> Recipe owners can edit or delete their recipe
    >> Everybody else has readonly versions

> Similarly created separate pages for userRecipe pages

> When submitting a recipe, No longer need to submit a custom username
    >> Either logged in username or "Anonymous" for guest submissions

> Added a "Profile" page for a logged in user
    >> contains a link to identity's account settings view.
```

**12/18**
```
> lots of basic styling and reformatting
> background image added
> cookbook icon added
```


**12/15**
```
> UsersList has datatables rendering
```

**12/14**
```
> table data through API is succesfully being called with JQuery
> DataTables plugin working correctly with table data
```

**12/12**
```
> Users index now queries and renders all users instead of 
     just looping through every recipes (eliminated duplicates).
```

**12/11**
```
> Installed Mapper
> Setup MappingProfile in App_Start to use Dto->obj and obj->dto
> Created Dtos folder and RecipeDtos.cs
> Automapper is set and Dtos are in place within the Recipes API
> CamelCasing is setup in WebApiConfig.cs class

```

**12/8 - 12/10**
```
> Lots of trial and error to get viewmodels working with rendering lists to tables
> Finally rendered successfully with users view index.cshtml
```

**12/7/2018**
```
> completed basic linking and rendering of users recipe information
   in userRecipe page
> completed basic linking and rendering of Recipe edit form from recipelist
```

**12/6/2018**
```
> Mostly mental organization
> Next steps:
   set up DTOs and automapper?
   get bootbox plugin

```

**12/4/2018**
```
> Recipes api written for GET, POST, PUT, and DELETE
> Dummy recipe inserted into database
> GET api tested in Postman
```

**12/3/2018**
```
> Built form for submitting new recipe
```

**12/2/2018**
```
> Further functionality simplification through model updating
> Possible custom username submission through guest, rather than current logged in
   user for sake of continuing on.
> Populate RecipeTypes
> Further understanding viewmodels and routing to recipeForm
```

**11/27/2018**
```
> Model Updating, researching to understand applicationUser
> Simplifying functionality to build onto later
```


**11/8/2018**
```
> Did modifying to Recipe Model - haven't updated with migration yet
> Need to create Directions and IngredientList tables?
> Might just be able to make List<string> of each 
    -- is this bad relationalDB practice?
```

**11/3/2018**
```
> Fixed bug: Couldn't log in properly. Email no longer a required login field.
> Found out how to get current logged in user info to display
```

**11/2/2018**
```
> InitialModel migration for IdentityRole setup.
> Modified IdentityRole MVC code to allow login with "Username" instead of "Email".
> Admin role seeded into database
> Migrations: Model update for Recipe and RecipeType.
```


**10/26/2018**
```
> Created loose skeleton layout for controllers and views to test routing. 
```