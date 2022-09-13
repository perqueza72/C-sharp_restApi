# C-sharp_restApi
Web application build on c# and using ORM Framework for creating a CRUD operations. Database was created in SQLServer.


# Petitions:

## GET

Get an element or a list of elements.

1. ${HOST_NAME}/api/products -> Get all products.
2. ${HOST_NAME}/api/products?description={@description} -> Get products by description using like statement.
3. ${HOST_NAME}/api/products?id={@productID} -> Get product by ID.

## POST

Insert new element to Database.

1. ${HOST_NAME}/api/products -> Insert a new product if it doesn't already exists and it has all require fields filled.



## PUT

Update partial or completelly an element.

1. ${HOST_NAME}/api/products/{@productID} -> Update a product if already exists.

## DELETE

Delete an element.

1. ${HOST_NAME}/api/products/{@productID} -> Delete a product if exists.
