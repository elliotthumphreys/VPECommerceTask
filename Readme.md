## VP Tech Task

Please create a .Net Core API that can receive some JSON representing a typical e-commerce order and place it into a SQL database. The order should link a customer to their order and the products they have ordered.

- We are not expecting you to spend more than 2-3 hours on this.
- We do not require unit tests
- We want to see how you structure a solution in Visual Studio and what projects you use in your solution
- We want to see how you layout your code
- We want to see how you design your database and business logic layers

Your solution will provide the basis for your technical interview where we will explore extending your solution given certain business challenges Please build the service as you would work normally.
However, I'm providing the following video for reference around the approach we take to building services and domain-driven design.  If you get a chance it would be good to watch it, we don't expect you to watch the whole thing but there's a useful section between 15-25 mins that gives an example of the way we work. https://vimeo.com/43598193 - Jimmy Bogard - Crafting Wicked Domain Models.

## Assumptions
- No auth required
- No sessions data required
- Use of an in-memory database is okay. The in-memory database provider that is supported by EF Core is only loosely a 'database', it is not a relational database at all and thus provides no relational checking. If this was for the purpose of a production application then the In-Memory database provider would not be used as concurrency, referential integrity would be required. This is being used for the ease of running on other peoples machines without any prior setup.

## The Solution

### Database Design
_Some field names may have changed / not been included_

![Entity_Relationship_Diagram](https://github.com/elliotthumphreys/VPECommerceTask/blob/main/Entity_Relationship_Diagram.PNG?raw=true)

### API Design
Split solution into 3 projects
- DataAccess - holds the concrete implementation for the Repositories, holds the DbContext, abstracts logic to do with underlining provider
- Domain - holds the domain entities, and their logic
- ECommerceAPI - network access to service, API contracts

### Improvements
- IColletion fields within Orders, Products, and Customer are exposed
- Repository implementation didn't include a generic way of handling includes of collections contained within an entity.
- The logic around checking whether products exist for a customers order should probably be part of the CreateOrder method, as I shouldn't rely on the developer to check for this every time they want to use that method.
- Logic around stock levels was never done. The stock count field exists, and so is the quantity when a user makes an order, so the stock levels should be checked/reduced accordingly.

### How to run the application
```bash
cd [[repo-location]]/ECommerceAPI
dotnet run
# Then go to https://localhost:5001/swagger for the swagger interface.
```

### Example data you can use to populate database

_Product_ - [POST] /Product
```json
{
  "costPerItem": 10,
  "stockCount": 100,
  "name": "Some really good Book",
  "metaData": {
    "Author": "Some really good author",
    "Publisher": "Some really good publisher",
    "PublishDate": "10-09-1994"
  }
}
```

_Customer_ - [POST] /Customer
```json
{
  "firstName": "John",
  "lastName": "Smith",
  "email": "john-smith@john-smith.com"
}
```

_Order_ - [POST] /Customer/1/order 
```json
{
  "orderItem": [
    {
      "productId": 1,
      "quantity": 10
    }
  ]
}
```
