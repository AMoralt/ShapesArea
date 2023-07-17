SELECT Products.Name, Categories.Name
FROM Products
LEFT JOIN ProductCategory ON Products.Id = ProductCategory.ProductId
LEFT JOIN Categories ON ProductCategory.CategoryId = Categories.Id;